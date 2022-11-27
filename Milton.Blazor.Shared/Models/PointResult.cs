namespace Milton.Blazor.Shared.Models
{
    public class PointResult
    {
        public PointResult()
        {
            Graduations = new();
            Subjects = new();
        }
        public List<Graduation> Graduations { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}