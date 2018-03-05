using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWiki
{
    public class WikiDataSet
    {
        public WikiDataSet()
        {

        }

        public String unique_id{ get; set; }
        public String page_name { get; set; }
        public String start_year { get; set; }
        public String end_year { get; set; }
        public String blurb { get; set; }
    }
}
