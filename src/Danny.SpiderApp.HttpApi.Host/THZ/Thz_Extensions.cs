using System;
using System.Threading;
using System.Threading.Tasks;

namespace Danny.SpiderApp.THZ
{
    public static class Thz_Extensions
    {
        public static string RemoveUseless(this string str)
        {
            if (str.IsNullOrWhiteSpace())
            {
                return str;
            }

            str = str.Replace("\n", "");
            str = str.Replace(":", "");
            str = str.Replace("：", "");
            var startIndex = str.IndexOf(" 【");
            var endIndex = str.IndexOf("】");
            str=str.Remove(startIndex,endIndex);

            return str;
        }

        public static async Task<TOut> TryForTimes<TIn,TOut>(this Func<TIn,Task<TOut>> func,TIn arg,int tryTimes=5)
        {
            for(var i=tryTimes;i>0;i--)
            {
                try
                {
                    TOut result = await func(arg);

                    return result;
                }
                catch(Exception ex)
                {
                    Thread.Sleep(1000);
                    continue;
                }
            }

            throw new Exception("Failed too many times");
        }
    }
}
