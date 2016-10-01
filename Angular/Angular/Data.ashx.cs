using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Angular
{
    /// <summary>
    /// Data 的摘要说明
    /// </summary>
    public class Data : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "json/application";
            if (!string.IsNullOrEmpty(context.Request["Id"]) || context.Request.HttpMethod == "POST")
            {
                var id = Guid.NewGuid();
                context.Response.Write(JsonConvert.SerializeObject(new { Id = id, Value = "Value:" + id }));
                return;
            }

            var list = new List<object>();
            for (int i = 0; i < 4; i++)
            {
                list.Add(new { Id = i, Value = "Value:" + i });
            }
            //var data = new {Data = list, Count = 20};
            context.Response.Write(JsonConvert.SerializeObject(list));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}