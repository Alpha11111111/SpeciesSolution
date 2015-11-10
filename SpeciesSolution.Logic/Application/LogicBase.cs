using System;
using System.Linq.Expressions;

namespace SpeciesSolution.Logic.SpeciesQuery
{
    public abstract class LogicBase
    {
        #region 清空缓存
        public virtual void DelCache()
        {
            
        }
        #endregion
        #region 全表缓存加载条件
        public virtual Expression<Func<T, bool>>  GetExpression<T>()
        {
            return null;
        }
        #endregion
    }
}
