using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace _04.ConsumingWebServices
{
    public class Program
    {
        static void Main(string[] args)
        {
            UI.Load(new ArticleProvider("http://api.feedzilla.com/"));
        }
    }
}
