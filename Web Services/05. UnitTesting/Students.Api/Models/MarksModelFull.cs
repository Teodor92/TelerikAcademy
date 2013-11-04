using Students.Models;

namespace Students.Api.Models
{
    public class MarksModelFull : MarksModel
    {
        public virtual StudentsModel Student { get; set; }
    }
}