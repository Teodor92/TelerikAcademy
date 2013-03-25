namespace SoftwareAcademy
{
    public class LocalCourse : Course, ILocalCourse
    {
        // fileds and autoprops
        public string Lab { get; set; }

        // constructors
        public LocalCourse(string name, ITeacher teacher, string lab) : base(name, teacher)
        {
            this.Lab = lab;
        }

        // methods
        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Lab))
            {
                return base.ToString();
            }
            else
            {
                return base.ToString() + string.Format("; Lab={0}", this.Lab);
            }
        }
    }
}