 
using System;
using SubSonic.Schema;
using SubSonic.DataProviders;
using System.Data;

namespace SpeciesSolution.DataAccess.DataModel {
        /// <summary>
        /// Table: Taxa
        /// Primary Key: Id
        /// </summary>

        public class TaxaStructs: DatabaseTable {
            
            public TaxaStructs(IDataProvider provider):base("Taxa",provider){
                ClassName = "Taxa";
                SchemaName = "dbo";
                


                Columns.Add(new DatabaseColumn("Id", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0,
					PropertyName = "Id"
                });


                Columns.Add(new DatabaseColumn("Rank_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0,
					PropertyName = "Rank_Id"
                });


                Columns.Add(new DatabaseColumn("Parent_Id", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int64,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = true,
	                MaxLength = 0,
					PropertyName = "Parent_Id"
                });


                Columns.Add(new DatabaseColumn("TaxaCName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TaxaCName"
                });


                Columns.Add(new DatabaseColumn("TaxaLName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TaxaLName"
                });


                Columns.Add(new DatabaseColumn("RefArticles", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "RefArticles"
                });


                Columns.Add(new DatabaseColumn("TaxaPic", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255,
					PropertyName = "TaxaPic"
                });
                    
                
                
            }


            public IColumn Id{
                get{
                    return this.GetColumn("Id");
                }
            }
				
            

            public IColumn Rank_Id{
                get{
                    return this.GetColumn("Rank_Id");
                }
            }
				
            

            public IColumn Parent_Id{
                get{
                    return this.GetColumn("Parent_Id");
                }
            }
				
            

            public IColumn TaxaCName{
                get{
                    return this.GetColumn("TaxaCName");
                }
            }
				
            

            public IColumn TaxaLName{
                get{
                    return this.GetColumn("TaxaLName");
                }
            }
				
            

            public IColumn RefArticles{
                get{
                    return this.GetColumn("RefArticles");
                }
            }
				
            

            public IColumn TaxaPic{
                get{
                    return this.GetColumn("TaxaPic");
                }
            }
				
            
                    
        }
        
}
