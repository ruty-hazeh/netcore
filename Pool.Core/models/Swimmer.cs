using System.Reflection;
namespace Pool.Core.models
{
    public class Swimmer
    {
        public int Id { get; set; }//קוד שוחה
        public string Name { get; set; }//שם שוחה
        public int Age { get; set; }//גיל שוחה
        public Gender GenderSwimmer { get; set; }//זכר או נקבה
        public int ActivityId { get; set; }//קוד פעילות
        public bool Status { get; set; } = true;//סטטוס שוחה
    }
}
