using System;
using System.Collections.Generic;

namespace Nutrition_App.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Goal { get; set; }
        public string DietType { get; set; }
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}