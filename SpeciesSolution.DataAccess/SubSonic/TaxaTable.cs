 
using System;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: Taxa
        /// Primary Key: Id
        /// </summary>
        public class TaxaTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Taxa";
      			}
			}


			/// <summary>
			/// 
			/// </summary>
   			public static string Id{
			      get{
        			return "Id";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string Rank_Id{
			      get{
        			return "Rank_Id";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string Parent_Id{
			      get{
        			return "Parent_Id";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string TaxaCName{
			      get{
        			return "TaxaCName";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string TaxaLName{
			      get{
        			return "TaxaLName";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string RefArticles{
			      get{
        			return "RefArticles";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string TaxaPic{
			      get{
        			return "TaxaPic";
      			}
		    }
                    
        }
}
