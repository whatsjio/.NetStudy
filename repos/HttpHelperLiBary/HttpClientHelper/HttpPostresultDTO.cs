using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSimple
{

    /// <summary>
    /// Http提交结果
    /// </summary>
    public class HttpPostresultDTO
    {

        /// <summary>
        /// 消息
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HttpPostresultDTO():this(true,"成功")
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="result"></param>
        public HttpPostresultDTO(bool success,string result)
        {
            Success = success;
            Result = result;
        }
    }
}
