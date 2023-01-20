using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDesafioDotNetCore.OT.Base.Request
{
    /// <summary>
    /// Base requests implementations
    /// </summary>
    public abstract class BaseRequest
    {
        /// <inheritdoc />
        public override string ToString()
        {
            var configuracaoJson = new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-ddTHH:mm:sszzz",
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            configuracaoJson.Converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(this, configuracaoJson);
        }
    }
}
