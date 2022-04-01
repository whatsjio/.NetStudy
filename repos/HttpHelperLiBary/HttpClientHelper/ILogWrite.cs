using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientSimple
{

    /// <summary>
    /// 写入日志接口
    /// </summary>
    public interface ILogWrite
    {

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message"></param>
        void Log(string message);

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        void Log(string message, Exception e);
    }
}
