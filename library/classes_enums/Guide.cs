﻿using library.classes_enums;

using System.Reflection;

namespace poolProject
{
    public class Guide
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Gender GenderGuide { get; set; }
        public string ActivityName { get; set; }
        public bool Status { get; set; } = true;
    }
}
