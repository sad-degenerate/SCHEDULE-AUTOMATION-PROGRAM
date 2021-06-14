using System;

namespace BL.Model
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public Day() { }

        public Day(string name, int order)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();
            if (order <= 0)
                throw new ArgumentException();

            Name = name;
            Order = order;
        }
    }
}