﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassVigSystem.Lib.Cache
{
    #region 版本信息
    /*****************************************
     * 作者：顾宗祥
     * 名称:ICacheStrategy
     * 描述：缓存接口
     * 创建时间：2014/11/11 10:10:58
     * 更新时间：2014/11/11 10:10:58
     ******************************************/
    #endregion

    public interface ICacheStrategy
    { 
        /// <summary>
        /// 缓存过期时间
        /// </summary>
        int TimeOut { set; get; }

        /// <summary>
        /// 获得指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <returns>缓存值</returns>
        object Get(string key);

        /// <summary>
        /// 从缓存中移除指定键的缓存值
        /// </summary>
        /// <param name="key">缓存键</param>
        void Remove(string key);

        /// <summary>
        /// 清空所有缓存对象
        /// </summary>
        void Clear();

        /// <summary>
        /// 将指定键的对象添加到缓存中
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        void Insert(string key, object data);

        /// <summary>
        /// 将指定键的对象添加到缓存中，并指定过期时间
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存值</param>
        /// <param name="cacheTime">缓存过期时间</param>
        void Insert(string key, object data, int cacheTime);
    }
}
