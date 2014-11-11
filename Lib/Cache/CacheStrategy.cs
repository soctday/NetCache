using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace MassVigSystem.Lib.Cache
{
    #region 版本信息
    /*****************************************
     * 作者：顾宗祥
     * 名称:CacheStrategy
     * 描述：基于Asp.Net内置缓存
     * 创建时间：2014/11/11 13:08:48
     * 更新时间：2014/11/11 13:08:48
     ******************************************/
    #endregion

    public class CacheStrategy : ICacheStrategy
    {
        private System.Web.Caching.Cache _cache;

        public CacheStrategy()
        {
            _cache = HttpRuntime.Cache;
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public object Get(string key)
        {
            return _cache.Get(key);
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        public void Insert(string key, object data)
        {
            _cache.Insert(key, data, null, DateTime.Now.AddSeconds(_timeout), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public void Insert(string key, object data, int cacheTime)
        {
            _cache.Insert(key, data, null, DateTime.Now.AddSeconds(cacheTime), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        public void Clear()
        {
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            while (cacheEnum.MoveNext())
                _cache.Remove(cacheEnum.Key.ToString());
        }

        private int _timeout = 3600;//单位秒

        /// <summary>
        /// 缓存过期时间
        /// </summary>
        /// <value></value>
        public int TimeOut
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value > 0 ? value : 3600;
            }
        }
    }
}
