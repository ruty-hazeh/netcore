namespace poolProject
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan BeginHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public Day ActivityDay { get; set; }
        public int GuideId { get; set; }
        //public AgeRange AgeActivity { get; set; }
        //public Gender GenderActivity { get; set; }
        public bool Status { get; set; } = true;

    }
}
