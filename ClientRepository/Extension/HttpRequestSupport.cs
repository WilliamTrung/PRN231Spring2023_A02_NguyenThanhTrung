using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRepository.Extension
{
    public class HttpRequestSupport
    {
        public static string GetQueryPath(Dictionary<string, string>? param)
        {
            if (param == null)
                return "";
            string path = "?";
            foreach (var item in param)
            {
                path += item.Key;
                path += "=" + item.Value;
                path += "&";
            }
            path = path.Remove(path.Length - 1);
            return path;
        }
    }
}
