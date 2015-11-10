 
using System;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: RefTable
        /// Primary Key: Id
        /// </summary>
        public class RefTableTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "RefTable";
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
   			public static string Taxa_Id{
			      get{
        			return "Taxa_Id";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string Article_Id{
			      get{
        			return "Article_Id";
      			}
		    }
                    
        }
}
