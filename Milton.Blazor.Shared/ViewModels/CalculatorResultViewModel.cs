using Microsoft.AspNetCore.Components;
using Milton.Blazor.Shared.Helpers;
using Milton.Blazor.Shared.Interfaces;
using Milton.Blazor.Shared.Models;
using Milton.Blazor.Shared.ViewModels.Base;
using MudBlazor;
using System.Collections.ObjectModel;

namespace Milton.Blazor.Shared.ViewModels
{
    public class CalculatorResultViewModel : BaseViewModel
    {
        private PointResult _result;

        public int Points
        #region
        {
            get => _points;
            set => SetPropertyValue(ref _points, value);
        }
        private int _points;
        #endregion

        public string PointInfo
        #region
        {
            get => _pointInfo;
            set => SetPropertyValue(ref _pointInfo, value);
        }
        private string _pointInfo;
        #endregion

        public ObservableCollection<DisplayCourseResult> DisplayCourseResults
        #region
        {
            get => _displayCourseResults;
            set => SetPropertyValue(ref _displayCourseResults, value);
        }
        private ObservableCollection<DisplayCourseResult> _displayCourseResults;
        #endregion

        public CalculatorResultViewModel(PointResult result, IPageTitleService pageTitleService, ISnackbar snackbar, ISubjectRepo subjectRepo, NavigationManager navigation)
            : base(pageTitleService, snackbar, navigation)
        {
            _result = result;
            _displayCourseResults = new();
        }

        private void GetMaxPoints()
        {
            int academicPoints = CalculateAcademicPoints();
            int gradPoints = CalculateGraduatePoints();
            if (academicPoints > gradPoints)
            {
                Points = academicPoints;
                PointInfo = "Tanulmányi pontokból számítva";
            }
            else
            {
                Points = gradPoints;
                PointInfo = "Érettségi pontokból számítva";
            }
        }
        public Task InitAsync()
        {
            GetMaxPoints();
            PopuplateDisplayCourses();

            return Task.CompletedTask;
        }


        private void PopuplateDisplayCourses()
        {
            CourseRepo.Instance.SubjectRequirements.FastIteration(course =>
            {
                DisplayCourseResults.Add(ValidateCourse(course));
            });
        }

        private DisplayCourseResult ValidateCourse(Course course)
        {
            DisplayCourseResult displayCource = new()
            {
                Course = course,
            };

            List<Graduation> machingPrimGrads = new List<Graduation>();
            foreach (string primary in course.Primaries)
            {
                //Find all matching primary graduation value
                foreach (Graduation graduation in _result.Graduations)
                {
                    if (primary.Equals(graduation.Name))
                    {
                        machingPrimGrads.Add(graduation);
                        break;
                    }
                }
            }

            //If the course only has primaries
            if (course.Secondaries is null || course.Secondaries.Count < 1)
            {
                if (machingPrimGrads.Count < 2)
                {
                    displayCource.Error = "Nem teljesül a bejutási követelmény.";
                }
                else
                {
                    Graduation[] maxGrads = GetMaxGraduates(machingPrimGrads);
                    int maxMatchGradPoints = (maxGrads[0].Percentage + maxGrads[1].Percentage) * 2;
                    int academicPoints = CalculateAcademicPoints();

                    int localMaxPoints = maxMatchGradPoints > academicPoints ? maxMatchGradPoints : academicPoints;
                    if (localMaxPoints < course.PrevPoints)
                    {
                        displayCource.Warning = $"Sajnos nem érted el a tavalyi bejutási küszöböt.";
                    }

                    string displayInfo;
                    displayInfo = maxMatchGradPoints > academicPoints
                        ? "Tanulmányi pontok"
                        : $"Érettségi duplázás, Tárgyak: {maxGrads[0].Name} + {maxGrads[1].Name}";

                    displayCource.PointInfo = displayInfo + " " + $"Pontszám:{localMaxPoints}";
                }
            }
            else
            {
                List<Graduation> machingSecondayGrads = new();
                foreach (string secondary in course.Secondaries)
                {
                    foreach (Graduation graduation in _result.Graduations)
                    {
                        if (secondary.Equals(graduation.Name))
                        {
                            machingSecondayGrads.Add(graduation);
                            break;
                        }
                    }
                }

                if (machingSecondayGrads.Count < 1)
                {
                    displayCource.Error = "Nem teljesül a bejutási követelmény.";
                }
                else
                {
                    int maxPrimValue = 0;
                    Graduation maxPrimGrad = null;
                    machingPrimGrads.FastIteration(x =>
                    {
                        if (x.Percentage > maxPrimValue)
                        {
                            maxPrimGrad = x;
                            maxPrimValue = x.Percentage;
                        }
                    });

                    int maxSecValue = 0;
                    Graduation maxSecGrad = null;
                    machingSecondayGrads.FastIteration(x =>
                    {
                        if (x.Percentage > maxSecValue)
                        {
                            maxSecGrad = x;
                            maxSecValue = x.Percentage;
                        }
                    });

                    int maxMatchGradPoints = (maxPrimValue + maxSecValue) * 2;
                    int academicPoints = CalculateAcademicPoints();
                    int localMaxPoints = maxMatchGradPoints > academicPoints ? maxMatchGradPoints : academicPoints;

                    if (localMaxPoints < course.PrevPoints)
                    {
                        displayCource.Warning = $"Sajnos nem érted el a tavalyi bejutási küszöböt.";
                    }

                    string displayInfo;
                    displayInfo = maxMatchGradPoints > academicPoints
                        ? "Tanulmányi pontok"
                        : $"Érettségi duplázás, Tárgyak: {maxPrimGrad.Name} + {maxSecGrad.Name}";

                    displayCource.PointInfo = displayInfo + " " + $"Pontszám:{localMaxPoints}";
                }
            }


            return displayCource;
        }
        protected override void UpdateMainTitle()
        {
            PageTitleService.MainTitle = "Eredmények";
            PageTitleService.SubTitle = "Pontszámító";
        }

        private int GetHighSchoolPoints(List<Subject> @subjects)
        {
            int points = 0;
            @subjects.FastIteration((subject) =>
            {
                points += (subject.Name == "magyar irodalom" || subject.Name == "magyar nyelv")
                   ? subject.SumGrades() / 2
                   : subject.SumGrades();
            });
            return points * 2;
        }

        private int GetAverageGraduatePoints(List<Graduation> @graduations)
        {
            int points = 0;
            @graduations.FastIteration((grad) =>
            {
                points += grad.Percentage;
            });
            return points / @graduations.Count;
        }

        private int CalculateAcademicPoints()
        {
            int highSchoolPoints = GetHighSchoolPoints(_result.Subjects);
            int gradPoints = GetAverageGraduatePoints(_result.Graduations);

            return highSchoolPoints + gradPoints;
        }

        private int GetMaxGraduatesPoints(List<Graduation> @graduations)
        {
            int largestFirtValue = 0;
            int largestSecondValue = 0;

            @graduations.FastIteration((grad) =>
            {
                if (grad.Percentage > largestFirtValue)
                {
                    largestSecondValue = largestFirtValue;
                    largestFirtValue = grad.Percentage;
                }
                else if (grad.Percentage > largestSecondValue)
                {
                    largestSecondValue = grad.Percentage;
                }
            });
            return (largestSecondValue + largestFirtValue) * 2;
        }
        private Graduation[] GetMaxGraduates(List<Graduation> @graduations)
        {
            Graduation[] temp = new Graduation[2];

            @graduations.FastIteration((grad) =>
            {
                if (temp[0] is null)
                {
                    temp[0] = grad;
                }
                else if (grad.Percentage > temp[0].Percentage)
                {
                    temp[1] = temp[0];
                    temp[0] = grad;
                }
                else if (temp[1] is null)
                {
                    temp[1] = grad;
                }
                else if (grad.Percentage > temp[1].Percentage)
                {
                    temp[1] = grad;
                }
            });
            return temp;
        }

        private int CalculateGraduatePoints()
            => GetMaxGraduatesPoints(_result.Graduations);
    }
}
