using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netopenai.Controllers
{
    public class RequestInfo
    {
        /// <summary>
        /// 请求的消息
        /// </summary>
        public string Message { get; set; }
        public float Temperature { get; set; }

        public int MaxTokens { get; set; }
    }
}