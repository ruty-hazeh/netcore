using library.classes_enums;

namespace poolProject
{
    public class Data
    {
        public static List<Guide> guides { get; set; }
        public static int GuideCount { get; set; }
        public static List<Swimmer> swimmers { get; set; }
        public static int SwimmerCount { get; set; } 

        public static List<Activity> activities { get; set; } 
        public static int ActivityCount { get; set; }


        public Data()
        {
            guides = new List<Guide>() { new Guide() { Id = 1, Name = "Chaim", Age = 32, GenderGuide = Gender.Male, ActivityName = "Free Swimming" } };
            GuideCount = 1;
            swimmers = new List<Swimmer>() { new Swimmer() { Id = 1, Name = "Ruty", Age = AgeRange.teenager , GenderSwimmer = Gender.Female, ActivityId = 2 } };
            SwimmerCount = 1;
            activities = new List<Activity>() { new Activity() { Id = 1, Name = "free swimming",BeginHour=new TimeSpan(10,0,0),EndHour=new TimeSpan(10,45,0),ActivityDay=Day.Sunday,GuideId=1 } };
            ActivityCount= 1;   
        }
    }
}
