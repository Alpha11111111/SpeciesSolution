 
using System;
using System.Text;

namespace SpeciesSolution.DataAccess.Model
{
    /// <summary>
    /// Taxa表实体类
    /// </summary>
	//[Serializable] 
    public partial class Taxa
    {


		private long _Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public long Id
		{
			get { return _Id; }
			set { _Id =value; }
		}


		private long _Rank_Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public long? Rank_Id
		{
			get { return _Rank_Id; }
			set { _Rank_Id =(long)value; }
		}


		private long _Parent_Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public long? Parent_Id
		{
			get { return _Parent_Id; }
			set { _Parent_Id =(long)value; }
		}


		private string _TaxaCName = "";
		/// <summary>
		/// 
		/// </summary>
		public string TaxaCName
		{
			get { return _TaxaCName; }
			set { _TaxaCName = value; }
		}


		private string _TaxaLName = "";
		/// <summary>
		/// 
		/// </summary>
		public string TaxaLName
		{
			get { return _TaxaLName; }
			set { _TaxaLName = value; }
		}


		private string _RefArticles = "";
		/// <summary>
		/// 
		/// </summary>
		public string RefArticles
		{
			get { return _RefArticles; }
			set { _RefArticles = value; }
		}


		private string _TaxaPic = "";
		/// <summary>
		/// 
		/// </summary>
		public string TaxaPic
		{
			get { return _TaxaPic; }
			set { _TaxaPic = value; }
		}


		/// <summary>
        /// 输出实体所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();

			sb.Append("Id=" +　Id + "; ");

			sb.Append("Rank_Id=" +　Rank_Id + "; ");

			sb.Append("Parent_Id=" +　Parent_Id + "; ");

			sb.Append("TaxaCName=" +　TaxaCName + "; ");

			sb.Append("TaxaLName=" +　TaxaLName + "; ");

			sb.Append("RefArticles=" +　RefArticles + "; ");

			sb.Append("TaxaPic=" +　TaxaPic + "; ");

			return sb.ToString();
        }

    } 

}


