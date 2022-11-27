namespace Milton.Blazor.Shared.Models
{
    public class DisplayCourseResult
    {
        public Course Course { get; set; }
        public string Error { get; set; }
        public string Warning { get; set; }
        public string PointInfo { get; set; }
    }
    public enum EducationLevels
    {
        Basic,
        Master,
        EducationTraining,
        UndividedMaster
    }
    public enum Schedules
    {
        Day,
        Night,
        Correspondent,
        Distance
    }
    public enum Financies
    {
        Scholarship,
        SelfPaid,
    }

    public record Course
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EducationLevels EducationLevel { get; set; }
        public Financies Finance { get; set; }

        public Schedules Schedule { get; set; }

        public int PrevPoints { get; set; }
        public List<string> Primaries { get; set; }
        public List<string> Secondaries { get; set; }
    }
}
