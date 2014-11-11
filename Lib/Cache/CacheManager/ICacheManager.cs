using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassVigSystem.Lib.Cache.CacheManager
{
    #region 版本信息
    /*****************************************
     * 作者：顾宗祥
     * 名称:ICacheManager
     * 描述：缓存管理接口
     * 创建时间：2014/11/11 10:21:14
     * 更新时间：2014/11/11 10:21:14
     ******************************************/
    #endregion

    public interface ICacheManager
    {
        /// <summary>
        /// 生成获得时的缓存键
        /// </summary>
        /// <param name="key">原缓存键</param>
        /// <returns>新缓存键</returns>
        string GenerateGetKey(string key);

        /// <summary>
        /// 生成添加时的缓存键
        /// </summary>
        /// <param name="key">原缓存键</param>
        /// <returns>新缓存键</returns>
        string GenerateInsertKey(string key);

        /// <summary>
        /// 生成要移除的缓存键列表
        /// </summary>
        /// <returns></returns>
        List<string> GenerateRemoveKey(string key);
  
    }
}
