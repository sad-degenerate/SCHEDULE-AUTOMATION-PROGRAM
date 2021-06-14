namespace BL.Model
{
    public class OptimalityCriterion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int Value { get; set; }

        public OptimalityCriterion() { }

        public OptimalityCriterion(string name, string code, int value)
        {
            Name = name;
            Code = code;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}