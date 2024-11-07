using library.classes_enums;

using System.Reflection;
namespace poolProject
{
    public class Swimmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AgeRange Age { get; set; }
        public Gender GenderSwimmer { get; set; }
        public int ActivityId { get; set; }
        public bool Status { get; set; } = true;
    }
}
