using Milton.Blazor.Shared.Models;

namespace Milton.Blazor.Shared.Converters
{
    public static class Converters
    {
        public static string Convert(this EducationLevels educationLevels) => educationLevels switch
        {
            EducationLevels.Basic => "alapképzés",
            EducationLevels.UndividedMaster => "osztatlan mesterképzés",
            EducationLevels.Master => "mesterképzés",
            EducationLevels.EducationTraining => "felsőoktatási szakképzés",
        };
        public static string Convert(this Schedules schedule) => schedule switch
        {
            Schedules.Distance => "távoktatás",
            Schedules.Day => "nappali",
            Schedules.Correspondent => "levelező",
            Schedules.Night => "esti",
        };
        public static string Convert(this Financies financie) => financie switch
        {
            Financies.SelfPaid => "önköltséges",
            Financies.Scholarship => "állami ösztöndíjas",
        };
    }
}
