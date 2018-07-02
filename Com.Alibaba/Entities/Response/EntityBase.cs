using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Alibaba.Entities.Response
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class EntityBase : AliJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public object ReturnObject { get; set; }
    }
}
