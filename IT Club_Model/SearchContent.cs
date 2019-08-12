using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Club_Model
{
   public class SearchContent
    {
        public int id { get; set; }
        public string productname { get; set; }
        public string productdesc { get; set; }
        public LuceneTypeEnum LuceneTypeEnum { get; set; }
    }
}
