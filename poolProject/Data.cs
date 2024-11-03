namespace poolProject
{
   public static class Data
    {
        public static List<Guide> guides { get; set; } = new List<Guide>() { new Guide() { Id = 1, Name = "Chaim", Age = 32, GenderGuide = Gender.Male, ActivityName = "Free Swimming" } };
        public static int GuideCount { get; set; } = 1;

        public static List<Swimmer> swimmers { get; set; } = new List<Swimmer>() { new Swimmer() { Id = 1, Name = "Ruty", Age = AgeRange.teenager
            , GenderSwimmer = Gender.Female, ActivityId = 2 } };
        public static int SwimmerCount { get; set; } = 1;

        public static List<Activity> activities { get; set; } = new List<Activity>() { new Activity() { Id = 1, Name = "free swimming",
            BeginHour=new TimeSpan(10,0,0),EndHour=new TimeSpan(10,45,0),ActivityDay=Day.Sunday,GuideId=1 } };
        public static int ActivityCount { get; set; } = 1;
    }
}
