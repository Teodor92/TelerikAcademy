namespace StudentSystem.Models
{
    using System;
    using System.Linq;

    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
