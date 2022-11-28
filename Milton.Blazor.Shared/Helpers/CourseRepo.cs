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
                Name = "Gazdaságinformatikus",
                Description = "A nappali és levelező tagozaton is elérhető képzés célja gazdaságinformatikusok képzése, akik képesek az információs társadalom feltétel- és értékrendszerében a valós üzleti folyamatok, és az azokban rejlő informatikai vonatkozású problémák megértésére és megoldására. Rendelkeznek tehát a mai gazdasági környezetben szükséges közgazdasági ismeretekkel és az üzleti tevékenység viteléhez szükséges informatikai tudással is.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Day,
                EducationLevel = EducationLevels.Basic,
                PrevPoints = 296,
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
                Name = "Gazdaságinformatikus",
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
                Name = "Emberi erőforrások",
                Description = "A képzés célja módszertanilag felkészült, megfelelő szakmai és általános műveltséggel, valamint a humán erőforrás gazdálkodásban megalapozott tudással rendelkező gazdasági szakemberek képzése, akik képesek a human erőforrás gazdálkodás különböző funkcionális feladatainak ellátására.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Correspondent,
                EducationLevel = EducationLevels.Basic,
                PrevPoints = 404,
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
            Course economy = new()
            {
                Name = "Gazdálkodás és menedzsment",
                Description = "Nappali és levelező tagozaton is elérhető gazdálkodási és menedzsment alapképzési szak keretében a hallgatók elsajátíthatják a modern üzletvitelhez szükséges, korszerű közgazdaságtani elméleti, módszertani és menedzsment ismereteket és képességeket.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Day,
                EducationLevel = EducationLevels.Basic,
                PrevPoints = 401,
                Primaries = new List<string>() {
                    "földrajz",
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
            Course communication = new()
            {
                Name = "Kommunikáció- és médiatudomány",
                Description = "A nappali és levelező tagozaton is elérhető kommunikáció és médiatudomány alapszak az egyik legnépszerűbb képzés, és emellett társadalomtudományi területen a legszélesebb körű és legváltozatosabb ismeretanyagot adja.",
                Finance = Financies.Scholarship,
                Schedule = Schedules.Day,
                EducationLevel = EducationLevels.Basic,
                PrevPoints = 400,
                Primaries = new List<string>() {
                    "magyar nyelv és irodalom",
                    "matematika",
                    "társadalomismeret",
                    "történelem",
                },
                Secondaries = new List<string>()
                {  
                    "angol nyelv",
                    "arab nyelv",
                    "beás nyelv",
                    "bolgár nyelv",
                    "bolgár nemzetiségi nyelv",
                    "cseh nyelv",
                    "eszperantó nyelv",
                    "finn nyelv",
                    "francia nyelv",
                    "héber nyelv",
                    "holland nyelv",
                    "horvát nyelv",
                    "horvát nemzetiségi nyelv",
                    "japán nyelv",
                    "kínai nyelv",
                    "latin nyelv",
                    "lengyel nyelv",
                    "lovári nyelv",
                    "német nyelv",
                    "német nemzetiség nyelv",
                    "olasz nyelv",
                    "orosz nyelv",
                    "portugál nyelv",
                    "román nyelv",
                    "spanyol nyelv",
                    "szerb nyelv",
                    "szlovák nyelv",
                    "szlován nyelv",
                    "szlován nemzetiségi nyelv",
                    "török nyelv",
                    "újgörög nyelv",
                    "ukrán nyelv",
                }
            };

            SubjectRequirements.Add(informatics);
            SubjectRequirements.Add(informatics1);
            SubjectRequirements.Add(hrbase);
            SubjectRequirements.Add(economy);
            SubjectRequirements.Add(communication);
        }
    }
}
