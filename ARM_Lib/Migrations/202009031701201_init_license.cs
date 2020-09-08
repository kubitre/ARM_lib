using ARM_Lib.models_db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ARM_Lib.Migrations
{
    class _202009031701201_init_license
    {
        public Res checkConcurency()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://34.105.248.127:9821/");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var result = "";
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result += reader.ReadToEnd();
                }
            }
            response.Close();
            return new JavaScriptSerializer().Deserialize<Res>(result);
        }
    }
}
