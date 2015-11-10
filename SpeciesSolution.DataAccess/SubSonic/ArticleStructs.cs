 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: Article
        /// Primary Key: Id
        /// </summary>

        public class ArticleStructs: DatabaseTable {
            
            public ArticleStructs(IDataProvider provider):base("Article",provider){
                ClassName = "Article";
                SchemaName = "dbo";
                


                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = true,
	                MaxLength = 0,
					PropertyName = "Id"
                });


                Columns.Add(new DatabaseColumn("ArticleName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "ArticleName"
                });
                    
                
                
            }


            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            

            public IColumn ArticleName{
                get{
                    return this.GetColumn("ArticleName");
                }
            }
				
            
                    
        }
        
}
