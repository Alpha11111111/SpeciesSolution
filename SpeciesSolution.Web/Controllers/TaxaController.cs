using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using SpeciesSolution.DataAccess.Model;
using SpeciesSolution.Logic.SpeciesQuery;

namespace SpeciesSolution.Web.Controllers
{
    public class TaxaController : ApiController
    {
        public object GetAllTaxa()
        {
            Taxa a=TaxaBll.GetInstence().Find(x => x.TaxaCName == "根").First();

            var c = SpeciesBll.getDownTree(a);

            return c;
            DataAccess.DataModel.Taxa root=DataAccess.DataModel.Taxa.SingleOrDefault(x=>x.TaxaCName=="根");
            var result= TaxaBll.GetInstence().Find(x => x.Parent_Id == root.Id);
            return result;
        }
    }
}
