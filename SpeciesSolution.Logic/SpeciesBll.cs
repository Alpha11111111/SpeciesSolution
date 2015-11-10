using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeciesSolution.DataAccess;
using SpeciesSolution.DataAccess.Model;

namespace SpeciesSolution.Logic.SpeciesQuery
{
    public static class SpeciesBll
    {
        public static IList<Taxa> getChild(Taxa parent)
        {
            return TaxaBll.GetInstence().Find(x => x.Parent_Id == parent.Id);
        }

        public static Taxa getParent(Taxa child)
        {
            return TaxaBll.GetInstence().Find(x=>x.Id==child.Parent_Id).First();
        }

        public static IList<Taxa> getTree(Taxa taxa)
        {
            IList<Taxa> result=new List<Taxa>();
            result.Add(taxa);
            
            while ((taxa = getParent(taxa))!= null)
            {
                result.Add(taxa);
            }
            return result.OrderBy(x=>x.Rank_Id).ToList();
        }

        public static DataAccess.Model.TaxaTreeNode getDownTree(Taxa root)
        {
            TaxaTreeNode rootNode=new TaxaTreeNode();
            rootNode.Data = root;
            IList<TaxaTreeNode> child=new List<TaxaTreeNode>();
            IList<Taxa> children = TaxaBll.GetInstence().Find(x => x.Parent_Id == root.Id);
            if (children != null)
            {
                foreach (Taxa taxa in children)
                {
                    child.Add(getDownTree(taxa));
                }
            }
            foreach (TaxaTreeNode taxaTreeNode in child)
            {
                rootNode.Child.Add(taxaTreeNode);
            }
            
            return rootNode;
        } 
          
    }
}
