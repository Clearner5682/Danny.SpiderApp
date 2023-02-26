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
            str = str.ReplaceFirst(":", "");
            str = str.ReplaceFirst("：", "");
            var startIndex = str.IndexOf("【");
            var endIndex = str.IndexOf("】");
            str=str.Remove(startIndex,(endIndex-startIndex+1));

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
                    Thread.Sleep(2000);
                }
            }

            return default(TOut);
        }

        public static async Task<string> GetInfoAsync(this string[] contentArray,string propertyName)
        {
            var result = "";
            if(contentArray.Length> 0)
            {
                foreach(var item in contentArray)
                {
                    if (item.Contains(propertyName))
                    {
                        result = item.RemoveUseless();
                        break;
                    }
                }
            }


            return await Task.FromResult(result);
        }
    }
}
