 
using System;
using System.Text;

namespace SpeciesSolution.DataAccess.Model
{
    /// <summary>
    /// RefTable表实体类
    /// </summary>
	//[Serializable] 
    public partial class RefTable
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


		private long _Taxa_Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public long Taxa_Id
		{
			get { return _Taxa_Id; }
			set { _Taxa_Id =value; }
		}


		private long _Article_Id = 0;
		/// <summary>
		/// 
		/// </summary>
		public long Article_Id
		{
			get { return _Article_Id; }
			set { _Article_Id =value; }
		}


		/// <summary>
        /// 输出实体所有值
        /// </summary>
        /// <returns></returns>
		public override string ToString(){
			var sb = new StringBuilder();

			sb.Append("Id=" +　Id + "; ");

			sb.Append("Taxa_Id=" +　Taxa_Id + "; ");

			sb.Append("Article_Id=" +　Article_Id + "; ");

			return sb.ToString();
        }

    } 

}


