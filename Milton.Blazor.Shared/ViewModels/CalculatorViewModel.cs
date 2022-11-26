using Microsoft.AspNetCore.Components;
using Milton.Blazor.Shared.Interfaces;
using Milton.Blazor.Shared.Models;
using Milton.Blazor.Shared.ViewModels.Base;
using MudBlazor;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Milton.Blazor.Shared.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public Subject SelectedLanguageOrChoosed
        #region
        {
            get => _selectedLanguageOrChoosed;
            set => SetPropertyValue(ref _selectedLanguageOrChoosed, value);
        }
        private Subject _selectedLanguageOrChoosed;
        #endregion

        public Subject SelectedNaturalScience
        #region
        {
            get => _selectedNaturalScience;
            set => SetPropertyValue(ref _selectedNaturalScience, value);
        }
        private Subject _selectedNaturalScience;
        #endregion

        public Subject SelectedSecondaryNaturalScience
        #region
        {
            get => _selectedSecondaryNaturalScience;
            set => SetPropertyValue(ref _selectedSecondaryNaturalScience, value);
        }
        private Subject _selectedSecondaryNaturalScience;
        #endregion

        public List<Subject> CurrentSubjects
        #region
           => _currentSubjects;
        private List<Subject> _currentSubjects;
        #endregion

        #region Graduation

        public List<Graduation> CurrentGraduations
        #region
           => _currentGraduations;
        private List<Graduation> _currentGraduations;
        #endregion

        public Graduation GraduationLanguage
        #region
        {
            get => _graduationLanguage;
            set => SetPropertyValue(ref _graduationLanguage, value);
        }
        private Graduation _graduationLanguage;
        #endregion

        public Graduation GraduationChoosed
        #region
        {
            get => _graduationChoosed;
            set => SetPropertyValue(ref _graduationChoosed, value);
        }
        private Graduation _graduationChoosed;
        #endregion

        #endregion Graduation

        private ISubjectRepo _subjectRepo;

        private void FillCurrentSubjects()
        {
            _currentSubjects = new List<Subject>()
        {
            new Subject(){ Name = "magyar irodalom" },
            new Subject(){ Name = "magyar nyelv" },
            new Subject(){ Name = "történelem" },
            new Subject(){ Name = "matematika" },
        };
        }
        private void FillCurrentGraduations()
        {
            _currentGraduations = new List<Graduation>()
        {
            new Graduation(){ Name = "magyar nyelv és irodalom" },
            new Graduation(){ Name = "történelem" },
            new Graduation(){ Name = "matematika" },
        };
        }

        private List<string> _allSubejcts;

        public CalculatorViewModel(IPageTitleService pageTitleService, ISnackbar snackbar, ISubjectRepo subjectRepo, NavigationManager navigation) : base(pageTitleService, snackbar, navigation)
        {
            _subjectRepo = subjectRepo;
            _selectedLanguageOrChoosed = new();
            _selectedNaturalScience = new();
            _selectedSecondaryNaturalScience = new();

            _graduationLanguage = new();
            _graduationChoosed = new();

            PageTitleService.MainTitle = "Eredmények";
            PageTitleService.SubTitle = "Pontszámító";

            FillCurrentSubjects();
            FillCurrentGraduations();
        }

        public List<string> GetNaturalSciences()
        {
            Span<string> spanList = CollectionsMarshal.AsSpan(_subjectRepo.NaturalSciences);
            ref var referenceData = ref MemoryMarshal.GetReference(spanList);

            List<string> templist = new();

            for (int i = 0; i < spanList.Length; i++)
            {
                var item = Unsafe.Add(ref referenceData, i);
                var pointer = Unsafe.AsRef(SelectedSecondaryNaturalScience.Name);

                if (item.Equals(pointer) == false)
                    templist.Add(item);
            }
            return templist;
        }

        public List<string> GetSecondaryNaturalSciences()
        {
            Span<string> spanList = CollectionsMarshal.AsSpan(_subjectRepo.NaturalSciences);
            ref var referenceData = ref MemoryMarshal.GetReference(spanList);

            List<string> templist = new();
            string selectedName = SelectedNaturalScience.Name;
            for (int i = 0; i < spanList.Length; i++)
            {
                var item = Unsafe.Add(ref referenceData, i);
                var pointer = Unsafe.AsRef(SelectedNaturalScience.Name);
                if (item.Equals(pointer) == false)
                    templist.Add(item);
            }
            return templist;
        }

        public Task InitAsync()
        {
            Span<string> languagesSpan = CollectionsMarshal.AsSpan(_subjectRepo.Langages);
            Span<string> choosedSpan = CollectionsMarshal.AsSpan(_subjectRepo.ChoosedSubjects);
            _allSubejcts = new List<string>(languagesSpan.Length + choosedSpan.Length);

            #region Languages
            ref var languagesData = ref MemoryMarshal.GetReference(languagesSpan);
            for (int i = 0; i < languagesSpan.Length; i++)
            {
                var data = Unsafe.Add(ref languagesData, i);
                _allSubejcts.Add(data);
            }
            #endregion Languages

            #region ChoosedData
            ref var chooseData = ref MemoryMarshal.GetReference(choosedSpan);
            for (int i = 0; i < choosedSpan.Length; i++)
            {
                var data = Unsafe.Add(ref chooseData, i);
                _allSubejcts.Add(data);
            }
            #endregion ChoosedData

            return Task.CompletedTask;
        }

        public IList<string> GetAllSubjects => _allSubejcts;

        protected override void UpdateMainTitle()
        {
            PageTitleService.MainTitle = "Eredmények";
            PageTitleService.SubTitle = "Pontszámító";
        }

        private int CalculateGraduatePoints()
        {
            int points = 0;
            byte maxGraduationCount = 2;
            for (int i = 0; i < CurrentGraduations.Count; i++)
            {
                Graduation grad = CurrentGraduations[i];
                points += grad.Percentage;
                if (grad.IsHigh && grad.Percentage > 45 && maxGraduationCount > 0)
                {
                    points += 50;
                    maxGraduationCount--;
                }
            }
            return points;
        }
        private int CalculateHighSchoolPoints()
        {
            int points = 0;
            Span<Subject> subjects = CollectionsMarshal.AsSpan(CurrentSubjects);
            ref var pointer = ref MemoryMarshal.GetReference(subjects);

            for (int i = 0; i < CurrentSubjects.Count; i++)
            {
                Subject subject = Unsafe.Add(ref pointer, i);
                points += subject.SumGrades();
            }
            points += SelectedLanguageOrChoosed.SumGrades();
            points += SelectedNaturalScience.SumGrades();
            return points * 2;
        }

        public void SaveDatas()
        {
            List<string> validationErrors = new();

            void SubjectVaidation(Subject @subject)
            {
                if (@subject.CurrentGrade < 1)
                    validationErrors.Add($"{@subject.Name}, 12. osztályos adat megadás kötelező");

                if (@subject.BeforeCurrentGrade < 1)
                    validationErrors.Add($"{@subject.Name}, 11. osztályos adat megadás kötelező");
            }

            Span<Subject> subjects = CollectionsMarshal.AsSpan(CurrentSubjects);
            ref var pointer = ref MemoryMarshal.GetReference(subjects);

            for (int i = 0; i < CurrentSubjects.Count; i++)
            {
                Subject subject = Unsafe.Add(ref pointer, i);
                SubjectVaidation(subject);
            }

            if (string.IsNullOrEmpty(SelectedLanguageOrChoosed.Name))
                validationErrors.Add($"Választott tárgy megadása kötelező");
            else
                SubjectVaidation(SelectedLanguageOrChoosed);

            if (string.IsNullOrEmpty(SelectedNaturalScience.Name))
                validationErrors.Add($"Természettudományos tárgy megadása kötelező");
            else
                SubjectVaidation(SelectedNaturalScience);

            //Optional
            if (string.IsNullOrEmpty(SelectedSecondaryNaturalScience.Name) == false)
                SubjectVaidation(SelectedSecondaryNaturalScience);

            if (validationErrors.Count > 0)
            {
                foreach (var error in validationErrors)
                {
                    ShowSnakbar(error, Severity.Error);
                }
            }
            else
            {

                PointResult results = new();

                #region Graduation
                results.GraduationPoints = new List<PointResult.GraduationPoint>();
                foreach (Graduation grad in CurrentGraduations)
                {
                    results.GraduationPoints.Add(new PointResult.GraduationPoint()
                    {
                        IsHighLevel = grad.IsHigh,
                        Name = grad.Name,
                        Point = grad.Percentage
                    });
                }
                results.GraduationPoints.Add(new PointResult.GraduationPoint()
                {
                    IsHighLevel = GraduationChoosed.IsHigh,
                    Name = GraduationChoosed.Name,
                    Point = GraduationChoosed.Percentage
                });
                results.GraduationPoints.Add(new PointResult.GraduationPoint()
                {
                    IsHighLevel = GraduationLanguage.IsHigh,
                    Name = GraduationLanguage.Name,
                    Point = GraduationLanguage.Percentage
                });
                #endregion Graduation

                var jsonResult = System.Text.Json.JsonSerializer.Serialize(results);
                Navigation.NavigateTo($"point/{jsonResult}");
            }
        }
    }
}
