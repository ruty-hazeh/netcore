﻿using library.classes_enums;
using poolProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class FakeContext: IDataContext
    {
        public  List<Guide> guides { get; set; } = new List<Guide>() { new Guide() { Id = 2, Name = "Chaim", Age = 32, GenderGuide = Gender.Male, ActivityName = "Free Swimming" } };
        public  List<Swimmer> swimmers { get; set; } = new List<Swimmer>() { new Swimmer() { Id = 2, Name = "Ruty", Age = AgeRange.teenager, GenderSwimmer = Gender.Female, ActivityId = 2 } };
        public  List<Activity> activities { get; set; } = new List<Activity>() { new Activity() { Id = 2, Name = "free swimming", BeginHour = new TimeSpan(10, 0, 0), EndHour = new TimeSpan(10, 45, 0), ActivityDay = Day.Sunday, GuideId = 1 } };

    }
}