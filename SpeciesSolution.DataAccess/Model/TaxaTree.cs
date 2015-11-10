using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeciesSolution.DataAccess.Model
{
    public class TaxaTree
    {
        TaxaTreeNode Head { get; set; }
        public IList<TaxaTreeNode> Nodes { get; set; } 
    }

    public class TaxaTreeNode
    {
        private Taxa _data=null;
        public Taxa Data
        {
            get { return _data; }
            set
            {
                _data = value;
                _child.Clear();
            }
        }

        private IList<TaxaTreeNode> _child = new List<TaxaTreeNode>();

        public IList<TaxaTreeNode> Child { get { return _child; }} 

    }
}
