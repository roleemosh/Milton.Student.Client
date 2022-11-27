using Microsoft.AspNetCore.Components;
using Milton.Blazor.Shared.Interfaces;
using Milton.Blazor.Shared.Models;
using Milton.Blazor.Shared.ViewModels.Base;
using MudBlazor;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
            new Subject(){ Name = "magyar nyelv"},
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

        public CalculatorViewModel(IPageTitleService pageTitleService, ISnackbar snackbar, ISubjectRepo subjectRepo, NavigationManager navigation)
            : base(pageTitleService, snackbar, navigation)
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

                #region Subjects
                results.Subjects.AddRange(_currentSubjects);
                results.Subjects.Add(_selectedLanguageOrChoosed);
                results.Subjects.Add(_selectedNaturalScience);
                results.Subjects.Add(_selectedSecondaryNaturalScience);
                #endregion Subjects

                #region Graduations
                results.Graduations.AddRange(_currentGraduations);
                results.Graduations.Add(_graduationLanguage);
                results.Graduations.Add(_graduationChoosed);
                #endregion Graduations


                string jsonResult = System.Text.Json.JsonSerializer.Serialize(results);
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(jsonResult);
                string base64 = Convert.ToBase64String(plainTextBytes);
                Navigation.NavigateTo($"calculatorresult/{base64}");
            }
        }

        public void TestNavigation()
        {
            PointResult results = new();

            #region Subjects
            results.Subjects.Add(new Subject() { Name = "magyar irodalom", CurrentGrade = 4, BeforeCurrentGrade = 2 });
            results.Subjects.Add(new Subject() { Name = "magyar nyelv", CurrentGrade = 3, BeforeCurrentGrade = 5 });
            results.Subjects.Add(new Subject() { Name = "történelem", CurrentGrade = 4, BeforeCurrentGrade = 4 });
            results.Subjects.Add(new Subject() { Name = "matematika", CurrentGrade = 3, BeforeCurrentGrade = 5 });
            results.Subjects.Add(new Subject() { Name = "informatika", CurrentGrade = 4, BeforeCurrentGrade = 5 });
            results.Subjects.Add(new Subject() { Name = "kémia", CurrentGrade = 4, BeforeCurrentGrade = 5 });
            #endregion Subjects

            #region Graduations
            results.Graduations.Add(new Graduation() { Name = "magyar nyelv és irodalom", IsHigh = false, Percentage = 75 });
            results.Graduations.Add(new Graduation() { Name = "matematika", IsHigh = true, Percentage = 54 });
            results.Graduations.Add(new Graduation() { Name = "történelem", IsHigh = false, Percentage = 55 });
            results.Graduations.Add(new Graduation() { Name = "angol nyelv", IsHigh = false, Percentage = 77 });
            results.Graduations.Add(new Graduation() { Name = "informatika ismeretek", IsHigh = true, Percentage = 99 });
            #endregion Graduations

            string jsonResult = System.Text.Json.JsonSerializer.Serialize(results);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(jsonResult);
            string base64 = Convert.ToBase64String(plainTextBytes);
            Navigation.NavigateTo($"calculatorresult/{base64}");
        }

    }
}
