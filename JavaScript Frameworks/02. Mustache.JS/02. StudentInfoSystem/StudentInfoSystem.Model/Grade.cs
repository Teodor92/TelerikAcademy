using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    [DataContract]
    public class Grade
    {
        public int Id { get; set; }

        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }

        public virtual Student Student { get; set; }
    }
}
