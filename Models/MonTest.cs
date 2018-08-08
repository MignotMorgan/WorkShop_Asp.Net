using System;

namespace MvcMovie.Models
{
    public class MonTest
    {
        public string Name { get; set; }

        public MonTest(string name = "monnom")
        {
            Name = name;
        }
    }
}