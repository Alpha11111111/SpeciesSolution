 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: Rank
        /// Primary Key: Id
        /// </summary>

        public class RankStructs: DatabaseTable {
            
            public RankStructs(IDataProvider provider):base("Rank",provider){
                ClassName = "Rank";
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


                Columns.Add(new DatabaseColumn("RankLevel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "RankLevel"
                });


                Columns.Add(new DatabaseColumn("RankCName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "RankCName"
                });


                Columns.Add(new DatabaseColumn("RankEName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "RankEName"
                });
                    
                
                
            }


            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            

            public IColumn RankLevel{
                get{
                    return this.GetColumn("RankLevel");
                }
            }
				
            

            public IColumn RankCName{
                get{
                    return this.GetColumn("RankCName");
                }
            }
				
            

            public IColumn RankEName{
                get{
                    return this.GetColumn("RankEName");
                }
            }
				
            
                    
        }
        
}
