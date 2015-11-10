 
using System;
using System.Text;

namespace SpeciesSolution.DataAccess.Model
{
    /// <summary>
    /// Article表实体类
    /// </summary>
	//[Serializable] 
    public partial class Article
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


		private string _ArticleName = "";
		/// <summary>
		/// 
		/// </summary>
		public string ArticleName
		{
			get { return _ArticleName; }
			set { _ArticleName = value; }
		}


		/// <summary>
        /// 输出实体所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();

			sb.Append("Id=" +　Id + "; ");

			sb.Append("ArticleName=" +　ArticleName + "; ");

			return sb.ToString();
        }

    } 

}


