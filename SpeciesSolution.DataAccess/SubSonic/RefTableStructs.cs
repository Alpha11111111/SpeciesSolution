 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: RefTable
        /// Primary Key: Id
        /// </summary>

        public class RefTableStructs: DatabaseTable {
            
            public RefTableStructs(IDataProvider provider):base("RefTable",provider){
                ClassName = "RefTable";
                SchemaName = "dbo";
                


                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0,
					PropertyName = "Id"
                });


                Columns.Add(new DatabaseColumn("Taxa_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0,
					PropertyName = "Taxa_Id"
                });


                Columns.Add(new DatabaseColumn("Article_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0,
					PropertyName = "Article_Id"
                });
                    
                
                
            }


            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            

            public IColumn Taxa_Id{
                get{
                    return this.GetColumn("Taxa_Id");
                }
            }
				
            

            public IColumn Article_Id{
                get{
                    return this.GetColumn("Article_Id");
                }
            }
				
            
                    
        }
        
}
