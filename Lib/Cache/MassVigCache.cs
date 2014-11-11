using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassVigSystem.Lib.Cache.CacheManager;

namespace MassVigSystem.Lib.Cache
{
    #region 版本信息
    /*****************************************
     * 作者：顾宗祥
     * 名称:MassVigCache
     * 描述：缓存管理类
     * 创建时间：2014/11/11 10:16:52
     * 更新时间：2014/11/11 10:16:52
     ******************************************/
    #endregion

    public class MassVigCache
    {
        private static object _locker = new object();//锁对象

        private static ICacheStrategy _cachestrategy = null;//缓存策略
        private static ICacheManager _cachemanager = null;//缓存管理

        static MassVigCache()
        {
            _cachemanager = new CacheByRegex();
            _cachestrategy=new CacheStrategy();
        }
        /// <summary>
        /// 缓存过期时间
        /// </summary>
        public static int TimeOut
        {
            get
            {
                return _cachestrategy.TimeOut;
            }
            set
            {
                lock (_locker)
                {
                    _cachestrategy.TimeOut = value;
                }
            }
        }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        public static object Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;
            return _cachestrategy.Get(_cachemanager.GenerateGetKey(key));
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        public static void Insert(string key, object data)
        {
            if (string.IsNullOrWhiteSpace(key) || data == null)
                return;
            lock (_locker)
            {
                _cachestrategy.Insert(_cachemanager.GenerateInsertKey(key), data);
            }
        }

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        public static void Insert(string key, object data, int cacheTime)
        {
            if (string.IsNullOrWhiteSpace(key) || data == null)
                return;
            lock (_locker)
            {
                _cachestrategy.Insert(_cachemanager.GenerateInsertKey(key), data, cacheTime);
            }
        }

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        public static void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return;
            lock (_locker)
            {
                foreach (string k in _cachemanager.GenerateRemoveKey(key))
                    _cachestrategy.Remove(k);
            }
        }

        /// <summary>
        /// 清空缓存所有对象
        /// </summary>
        public static void Clear()
        {
            lock (_locker)
            {
                _cachestrategy.Clear();
            }
        }

    }
}
