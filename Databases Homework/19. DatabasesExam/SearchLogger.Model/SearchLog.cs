namespace SearchLogger.Model
{
    using System;

    public class SearchLog
    {
        public int Id { get; set; }

        public string Query { get; set; }

        public DateTime ExecDateTime { get; set; }
    }
}
