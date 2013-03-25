namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        // fileds and autoprops
        public string Town { get; set; }

        // constructors
        public OffsiteCourse(string name, ITeacher teacher, string town) : base(name, teacher)
        {
            this.Town = town;
        }

        // methods
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Town))
            {
                return base.ToString();
            }
            else
            {
                return base.ToString() + string.Format("; Town={0}", this.Town);
            }
        }
    }
}