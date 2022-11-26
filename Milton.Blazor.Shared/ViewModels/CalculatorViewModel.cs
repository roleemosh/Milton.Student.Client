using Milton.Blazor.Shared.Helpers;
using Milton.Blazor.Shared.Interfaces;
using Milton.Blazor.Shared.Models;
using Milton.Blazor.Shared.ViewModels.Base;
using MudBlazor;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static MudBlazor.CategoryTypes;

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

        public List<Subject> BeforeCurrentSubjects
        #region
            => _beforeCurrentSubjects;
        private List<Subject> _beforeCurrentSubjects;
        #endregion

        public List<Subject> CurrentSubjects
        #region
           => _currentSubjects;
        private List<Subject> _currentSubjects;
        #endregion


        #region Graduation



        #endregion Graduation

        private ISubjectRepo _subjectRepo;
        public CalculatorViewModel(IPageTitleService pageTitleService, ISnackbar snackbar, ISubjectRepo subjectRepo) : base(pageTitleService, snackbar)
        {
            _subjectRepo = subjectRepo;
            _selectedLanguageOrChoosed = new();
            _selectedNaturalScience = new();
            _selectedSecondaryNaturalScience = new();

            PageTitleService.MainTitle = "Eredmények";
            PageTitleService.SubTitle = "Pontszámító";

            FillCurrentSubjects();
        }

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

        private List<string> _allSubejcts;
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
    }
}
