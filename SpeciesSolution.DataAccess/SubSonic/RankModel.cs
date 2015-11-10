 
using System;
using System.Text;

namespace SpeciesSolution.DataAccess.Model
{
    /// <summary>
    /// Rank表实体类
    /// </summary>
	//[Serializable] 
    public partial class Rank
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


		private string _RankLevel = "";
		/// <summary>
		/// 
		/// </summary>
		public string RankLevel
		{
			get { return _RankLevel; }
			set { _RankLevel = value; }
		}


		private string _RankCName = "";
		/// <summary>
		/// 
		/// </summary>
		public string RankCName
		{
			get { return _RankCName; }
			set { _RankCName = value; }
		}


		private string _RankEName = "";
		/// <summary>
		/// 
		/// </summary>
		public string RankEName
		{
			get { return _RankEName; }
			set { _RankEName = value; }
		}


		/// <summary>
        /// 输出实体所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();

			sb.Append("Id=" +　Id + "; ");

			sb.Append("RankLevel=" +　RankLevel + "; ");

			sb.Append("RankCName=" +　RankCName + "; ");

			sb.Append("RankEName=" +　RankEName + "; ");

			return sb.ToString();
        }

    } 

}


