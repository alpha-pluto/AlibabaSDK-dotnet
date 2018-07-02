/*======================================================================
    Daniel.Zhang
    
    文件名：StringHelper.cs
    文件功能描述：字符串处理

======================================================================*/
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Com.Alibaba.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        private static void MyFunc(string str1, string str2)
        {
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(0);
            // 如果要获取上层函数信息调用 GetFrame(1)， 这样就可以写成通用函数了

            var methodBase = stackFrame.GetMethod();
            Console.WriteLine("函数名：" + methodBase.Name);

            var parameterInfos = methodBase.GetParameters();

            foreach (var parameterInfo in parameterInfos)
            {
                Console.WriteLine("参数信息：" + parameterInfo.Name);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inStr"></param>
        /// <param name="uriSchema"></param>
        /// <returns></returns>
        public static string UriSchemaFill(this string inStr, UriSchema uriSchema)
        {
            var retStr = inStr;
            switch (uriSchema)
            {
                case UriSchema.http:
                    retStr = Regex.Replace(retStr, @"(?isx)\$\{RequestSchema\}", Convert.ToString(uriSchema));
                    break;
                case UriSchema.https:
                    retStr = Regex.Replace(retStr, @"(?isx)\$\{RequestSchema\}", Convert.ToString(uriSchema));
                    break;
                default:
                    break;

            }
            return retStr;
        }
    }
}
