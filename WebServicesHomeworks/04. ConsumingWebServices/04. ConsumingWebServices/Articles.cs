using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ConsumingWebServices
{
    public class AllArticles
    {
        public HashSet<Article> Articles { get; set; }

        public string Description { get; set; }

        public string SyndicationUrl { get; set; }

        public string Title { get; set; }
    }
}
