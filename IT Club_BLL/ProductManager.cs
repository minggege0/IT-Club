using IT_Club_IBLL;
using IT_Club_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.IO;
using IT_Club_Common;
using Lucene.Net.QueryParsers;

namespace IT_Club_BLL
{
    public class ProductManager : BaseManager<Product>, IProductManager
    {
        public override void SetCurrentService()
        {
            this.CurrentService = this.CurrentDBSession.ProductService;
        }
    }
}
