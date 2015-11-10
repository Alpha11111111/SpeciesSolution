 
using System;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: Article
        /// Primary Key: Id
        /// </summary>
        public class ArticleTable {
			/// <summary>
			/// 表名
			/// </summary>
			public static string TableName {
				get{
        			return "Article";
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
   			public static string ArticleName{
			      get{
        			return "ArticleName";
      			}
		    }
                    
        }
}
