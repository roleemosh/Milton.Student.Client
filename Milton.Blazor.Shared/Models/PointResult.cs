namespace Milton.Blazor.Shared.Models
{
    public class PointResult
    {
        public class SubjectPoint
        {
            public int Point { get; set; }
            public string Name { get; set; }
        }

        public class GraduationPoint
        {
            public int Point { get; set; }
            public bool IsHighLevel { get; set; }
            public string Name { get; set; }
        }

        public List<SubjectPoint> SubjectPoints { get; set; }
        public List<GraduationPoint> GraduationPoints { get; set; }

    }
}
