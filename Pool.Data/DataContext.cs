using Pool.Core.models;
using Pool.Core;

namespace Pool.Data
{
    public class DataContext : IDataContext
    {
        public List<Guide> guides { get; set; } = new List<Guide>() { new Guide() { Id = 1, Name = "Chaim", Age = 32, GenderGuide = Gender.Male, ActivityName = "Free Swimming" } };
        public List<Swimmer> swimmers { get; set; } = new List<Swimmer>() { new Swimmer() { Id = 1, Name = "Ruty", Age = 45, GenderSwimmer = Gender.Female, ActivityId = 2 } };
        public List<Activity> activities { get; set; } = new List<Activity>() { new Activity() { Id = 1, Name = "free swimming", BeginHour = new TimeSpan(10, 0, 0), EndHour = new TimeSpan(10, 45, 0), ActivityDay = Day.Sunday, GuideId = 1 } };

    }
}
