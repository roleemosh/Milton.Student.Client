using Milton.Blazor.Shared.Models;

namespace Milton.Blazor.Shared.Helpers
{
    public class CourseRepo
    {
        public static CourseRepo Instance => _instance;
        private static CourseRepo _instance = new();

        public List<Course> SubjectRequirements { get; set; }

        private CourseRepo()
        {
            SubjectRequirements = new List<Course>();
            InitSubjectRequirements();
        }

        private void InitSubjectRequirements()
        {
            Course informatics = new()
            {
                Name = "Gazdaságinformatikus alapképzési szak",
                Description = "A nappali és levelező tagozaton is elérhető képzés célja gazdaságinformatikusok képzése, akik képesek az információs társadalom feltétel- és értékrendszerében a valós üzleti folyamatok, és az azokban rejlő informatikai vonatkozású problémák megértésére és megoldására. Rendelkeznek tehát a mai gazdasági környezetben szükséges közgazdasági ismeretekkel és az üzleti tevékenység viteléhez szükséges informatikai tudással is.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Day,
                EducationLevel = EducationLevels.Basic,
                PrevPoints= 296,
                Primaries = new List<string>() { "matematika" },
                Secondaries = new List<string>()
                {
                    "fizika",
                    "gazdasági ismeretek",
                    "informatika",
                    "informatika",
                    "történelem",
                    "informatika ismeretek",
                    "informatikai ismeretek",
                    "közgazdaság ismeretek",
                    "közgazdasági ismeretek",
                    "informatikai alapismeretek",
                    "közgazdasági alapismeretek (elméleti gazdaságtan)",
                    "közgazdasági alapismeretek (üzleti gazdaságtan)",
                }
            };

            Course informatics1 = new()
            {
                Name = "Gazdaságinformatikus alapképzési szak",
                Description = "A nappali és levelező tagozaton is elérhető képzés célja gazdaságinformatikusok képzése, akik képesek az információs társadalom feltétel- és értékrendszerében a valós üzleti folyamatok, és az azokban rejlő informatikai vonatkozású problémák megértésére és megoldására. Rendelkeznek tehát a mai gazdasági környezetben szükséges közgazdasági ismeretekkel és az üzleti tevékenység viteléhez szükséges informatikai tudással is.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Correspondent,
                EducationLevel = EducationLevels.Basic,
                PrevPoints = 284,
                Primaries = new List<string>() { "matematika" },
                Secondaries = new List<string>()
                {
                    "fizika",
                    "gazdasági ismeretek",
                    "informatika",
                    "informatika",
                    "történelem",
                    "informatika ismeretek",
                    "informatikai ismeretek",
                    "közgazdaság ismeretek",
                    "közgazdasági ismeretek",
                    "informatikai alapismeretek",
                    "közgazdasági alapismeretek (elméleti gazdaságtan)",
                    "közgazdasági alapismeretek (üzleti gazdaságtan)",
                }
            };
            Course hrbase = new()
            {
                Name = "Emberi erőforrások alapképzési szak",
                Description = "A képzés célja módszertanilag felkészült, megfelelő szakmai és általános műveltséggel, valamint a humán erőforrás gazdálkodásban megalapozott tudással rendelkező gazdasági szakemberek képzése, akik képesek a human erőforrás gazdálkodás különböző funkcionális feladatainak ellátására.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Day,
                EducationLevel = EducationLevels.Basic,
                PrevPoints = 284,
                Primaries = new List<string>() { 
                    "matematika",
                    "gazdasági ismeretek",
                    "informatika",
                    "matematika",
                    "történelem",
                },
                Secondaries = new List<string>()
                {
                    "informatika ismeretek",
                    "informatikai ismeretek",
                    "kereskedelem ismeretek",
                    "kereskedelmi ismeretek",
                    "közgazdaság ismeretek",
                    "közgazdasági ismeretek",
                    "turisztika ismeretek",
                    "turisztikai ismeretek",
                    "ügyvitel ismeretek",
                    "vendéglátóipar ismeretek",
                    "vendéglátóipari ismeretek",
                    "idegennyelvű ügyviteli ismeretek",
                    "irodai ügyviteli ismeretek",
                    "angol nyelv",
                    "német nyelv",
                    "olasz nyelv",
                    "orosz nyelv",
                    "spanyol nyelv",
                    "informatikai alapismeretek",
                    "kereskedelmi és marketing alapismeretek",
                    "közgazdasági alapismeretek (elméleti gazdaságtan)",
                    "közgazdasági alapismeretek (üzleti gazdaságtan)",
                    "ügyviteli alapismeretek",
                    "vendéglátás-idegenforgalom alapismeretek",
                }
            };

            SubjectRequirements.Add(informatics);
            SubjectRequirements.Add(informatics1);
            SubjectRequirements.Add(hrbase);
        }
    }
}
