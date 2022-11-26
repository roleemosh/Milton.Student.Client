namespace Milton.Blazor.Shared.Interfaces
{
    public interface ISubjectRepo
    {
        List<string> NaturalSciences { get; }
        List<string> Langages { get; }
        List<string> ChoosedSubjects { get; }
        List<string> GraduationSubjects { get; }
        List<string> GraduationLanguages { get; }
    }
}
