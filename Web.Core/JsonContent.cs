using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core
{
    public class JsonContent : ObjectContent
    {
        public JsonContent(ApiResult value)
            : base(typeof(ApiResult), value, new JsonMediaTypeFormatter())
        {
        }

        public JsonContent(ApiResult value, MediaTypeFormatter formatter)
            : base(typeof(ApiResult), value, formatter)
        {
        }

        public JsonContent(ApiResult value, MediaTypeFormatter formatter, MediaTypeHeaderValue mediaType)
            : base(typeof(ApiResult), value, formatter, mediaType)
        {
        }

        public JsonContent(ApiResult value, MediaTypeFormatter formatter, string mediaType)
            : base(typeof(ApiResult), value, formatter, mediaType)
        {
        }
    }
}
