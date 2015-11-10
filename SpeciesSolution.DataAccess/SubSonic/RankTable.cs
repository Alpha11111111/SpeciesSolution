 
using System;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: Rank
        /// Primary Key: Id
        /// </summary>
        public class RankTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Rank";
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
   			public static string RankLevel{
			      get{
        			return "RankLevel";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string RankCName{
			      get{
        			return "RankCName";
      			}
		    }

			/// <summary>
			/// 
			/// </summary>
   			public static string RankEName{
			      get{
        			return "RankEName";
      			}
		    }
                    
        }
}
