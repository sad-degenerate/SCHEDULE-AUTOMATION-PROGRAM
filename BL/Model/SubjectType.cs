using System;
using System.Collections.Generic;

namespace BL.Model
{
    public class SubjectType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Subject> Subjects { get; set; }

        public SubjectType() { }

        public SubjectType(string name, string code)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(code))
                throw new ArgumentNullException();

            Name = name;
            Code = code;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}