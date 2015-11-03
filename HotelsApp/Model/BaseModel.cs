using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace HotelsApp.Model
{
    public class BaseModel
    {
        /// <summary>
        /// Serialize this object to json format
        /// </summary>
        /// <returns></returns>
        public virtual string Serialize2Json()
        {
            return JsonConvert.SerializeObject(this);
        }

    }
}