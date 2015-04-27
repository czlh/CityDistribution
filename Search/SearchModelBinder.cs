using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Collections.Specialized;
using System.Net.Http;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;

namespace Search
{
    public class SearchModelBinder : IModelBinder
    {
        QueryModel DeserializeModel(string data)
        {
            QueryModel model = null;
            try
            {
                if (!string.IsNullOrWhiteSpace(data))
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    model = jss.Deserialize<QueryModel>(data);

                    if (model!=null && model.Conditions != null && model.Conditions.Count != 0)
                    {
                        NameValueCollection dict = ToNameValueCollection(model.Conditions);

                        var keys = dict.AllKeys.Where(c => c.StartsWith("_"));//我们认为只有[开头的为需要处理的
                        if (keys.Count() != 0)
                        {
                            foreach (var key in keys)
                            {
                                if (!key.StartsWith("_"))
                                    continue;
                                var val = dict[key];
                                //处理无值的情况
                                if (string.IsNullOrEmpty(val))
                                    continue;
                                AddSearchItem(model, key, val);
                            }
                        }

                    }
                }

            }
            catch
            {
            }

            return model;

        }

        public bool BindModel(System.Web.Http.Controllers.HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            HttpContent hc = actionContext.Request.Content;

            string data = hc.ReadAsStringAsync().Result;
            bindingContext.Model = DeserializeModel(data);
            return true;

            NameValueCollection requestP = System.Web.HttpUtility.ParseQueryString(actionContext.Request.RequestUri.Query);

            int page = 1;
            int pagesize = 10;
            QueryModel model = new QueryModel();

            int.TryParse(requestP["page"], out page);
            int.TryParse(requestP["pagesize"], out pagesize);
            model.Page = page;
            model.Pagesize = pagesize;

            
            Dictionary<string, object> di = new Dictionary<string, object>();

            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                di = FormResolvePro(data.ToString());
                
                if (di == null || di.Count == 0)
                {
                    di = jss.DeserializeObject(data) as Dictionary<string, object>;


                }
            }
            catch
            {
            }

            //NameValueCollection form = hc.ReadAsFormDataAsync().Result;
            if (di != null && di.Count != 0)
            {
                NameValueCollection dict = ToNameValueCollection(di);
                var keys = dict.AllKeys.Where(c => c.StartsWith("_"));//我们认为只有[开头的为需要处理的
                if (keys.Count() != 0)
                {
                    foreach (var key in keys)
                    {
                        if (!key.StartsWith("_"))
                            continue;
                        var val = dict[key];
                        //处理无值的情况
                        if (string.IsNullOrEmpty(val))
                            continue;
                        AddSearchItem(model, key, val);
                    }
                }

            }

            bindingContext.Model = model;
            return true;
        }

        public Dictionary<string, object> FormResolvePro(String reqStr)
        {
            Dictionary<string, object> form = new Dictionary<string, object>();
            Int32 eq = 0;
            Int32 at = 0;

            for (Int32 i = 0; i < reqStr.Length; i++)
            {
                if (reqStr[i] == '=')
                {
                    at = i;
                }
                else if (reqStr[i] == '&' || i == reqStr.Length - 1)
                {
                    Int32 valueLength = i - at - 1;
                    if (i == reqStr.Length - 1)
                    {
                        valueLength++;
                    }

                    if (at > eq && valueLength > 0)
                    {
                        String name = HttpUtility.UrlDecode(reqStr.Substring(eq, at - eq));
                        String value = HttpUtility.UrlDecode(reqStr.Substring(at + 1, valueLength));

                        if (!String.IsNullOrWhiteSpace(name))
                        {
                            form.Add(name, value);
                        }
                    }
                    eq = i + 1;
                    at = i + 1;
                }
            }
            return form;
        }


        /// <summary>
        /// 将一组key=value添加入QueryModel.Items
        /// </summary>
        /// <param name="model">QueryModel</param>
        /// <param name="key">当前项的HtmlName</param>
        /// <param name="val">当前项的值</param>
        public static void AddSearchItem(QueryModel model, string key, string val)
        {
            string field = "", prefix = "", orGroup = "", method = "";
            var keywords = key.Split(new string[]{"__", ")", "}"},StringSplitOptions.RemoveEmptyEntries);
            //将Html中的name分割为我们想要的几个部分
            foreach (var keyword in keywords)
            {
                if (Char.IsLetterOrDigit(keyword[0]))
                    field = keyword;
                var last = keyword.Substring(1);
                if (keyword[0] == '(')
                    prefix = last;
                if (keyword[0] == '_')
                    method = last;
                if (keyword[0] == '{')
                    orGroup = last;
            }
            if (string.IsNullOrEmpty(method))
                return;
            if (!string.IsNullOrEmpty(field))
            {
                var item = new ConditionItem
                {
                    Field = field,
                    Value = val.Trim(),
                    Prefix = prefix,
                    OrGroup = orGroup,
                    Method = (QueryMethod)Enum.Parse(typeof(QueryMethod), method)
                };
                model.Items.Add(item);
            }
        }

        private static NameValueCollection ToNameValueCollection(Dictionary<string, object> dic)
        {
            NameValueCollection form = new NameValueCollection(dic.Count);
            foreach (KeyValuePair<string, object> item in dic)
            {
                string key = "";
                string value = "";

                Dictionary<string, object> di = item.Value as Dictionary<string, object>;
                if (di != null && di.Count > 1)
                {
                    foreach (KeyValuePair<string, object> diItem in di)
                    {
                        key = "";
                        value = "";
                        ser(diItem, ref key, ref value);

                        form.Add(item.Key+"."+key, value);
                    }
                }
                else
                {
                    ser(item, ref key, ref value);

                    form.Add(key, value);
                }

            }

            return form;
        }

        private static void ser(KeyValuePair<string, object> item, ref string key, ref string value)
        {
            value = null;
            key = key + item.Key;

            if (item.Value != null)
            {
                Dictionary<string, object> t = item.Value as Dictionary<string, object>;

                if (t != null)
                {
                    key = key + ".";
                    ser(t.First(), ref key, ref value);
                }
                else
                {
                    value = item.Value.ToString();
                }
            }


        }
    }
}