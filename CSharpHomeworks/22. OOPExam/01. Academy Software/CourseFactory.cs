namespace SoftwareAcademy
{
    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            Teacher myTeacher = new Teacher(name);

            return myTeacher;
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            LocalCourse myLocalCourse = new LocalCourse(name, teacher, lab);

            return myLocalCourse;
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            OffsiteCourse myOffsiteCourse = new OffsiteCourse(name, teacher, town);

            return myOffsiteCourse;
        }
    }
}