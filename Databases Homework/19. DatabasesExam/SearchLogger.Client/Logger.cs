namespace SearchLogger.Client
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using SearchLogger.Data;
    using SearchLogger.Model;

    public static class Logger
    {
        public static void AddLog(string xmlQuery)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            SearchLoggerEntities context = 
                new SearchLoggerEntities();

            SearchLog newLog = new SearchLog
            {
                Query = xmlQuery,
                ExecDateTime = DateTime.Now
            };

            context.SearchLogs.Add(newLog);
            context.SaveChanges();
        }
    }
}
