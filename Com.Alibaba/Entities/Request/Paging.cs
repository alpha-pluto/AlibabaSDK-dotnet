/*======================================================================
    Daniel.Zhang
    
    文件名：Paging.cs
    文件功能描述：结果分页 基类

======================================================================*/
using System;

namespace Com.Alibaba.Entities.Request
{
    /// <summary>
    /// 结果分页 基类
    /// </summary>
    [Serializable]
    public class Paging
    {
        /// <summary>
        /// 
        /// </summary>
        public Paging()
        {
            page = 1;
            pageSize = 20;
        }

        /// <summary>
        /// 查询分页页码，从1开始		1
        /// 是否必须: 否
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 查询的每页的数量(最高20)		20
        /// 是否必须: 否
        /// </summary>
        public int pageSize { get; set; }
    }
}
