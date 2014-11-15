using Recruitment.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Recruitment.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString MessageDisplayer<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            BaseViewModel model = htmlHelper.ViewData.Model as BaseViewModel;

            if (model != null && model.Messages.Any())
            {
                StringBuilder sb = new StringBuilder();
                if(model.Messages.Any(m=>m.MessageType == ViewModelMessageType.Error))
                {
                    sb.Append("<div class=\"alert alert-danger\" role=\"alert\">");
                    foreach (var msg in model.Messages.Where(m => m.MessageType == ViewModelMessageType.Error))
                    {
                        sb.Append(string.Format("<p>{0}</p>", msg.MessageText));
                    }
                    sb.Append("</div>");
                }
                if (model.Messages.Any(m => m.MessageType == ViewModelMessageType.Info))
                {
                    sb.Append("<div class=\"alert alert-info\" role=\"alert\">");
                    foreach (var msg in model.Messages.Where(m => m.MessageType == ViewModelMessageType.Info))
                    {
                        sb.Append(string.Format("<p>{0}</p>", msg.MessageText));
                    }
                    sb.Append("</div>");
                }
                if (model.Messages.Any(m => m.MessageType == ViewModelMessageType.Success))
                {
                    sb.Append("<div class=\"alert alert-success\" role=\"alert\">");
                    foreach (var msg in model.Messages.Where(m => m.MessageType == ViewModelMessageType.Success))
                    {
                        sb.Append(string.Format("<p>{0}</p>", msg.MessageText));
                    }
                    sb.Append("</div>");
                }
                if (model.Messages.Any(m => m.MessageType == ViewModelMessageType.Warning))
                {
                    sb.Append("<div class=\"alert alert-warning\" role=\"alert\">");
                    foreach (var msg in model.Messages.Where(m => m.MessageType == ViewModelMessageType.Warning))
                    {
                        sb.Append(string.Format("<p>{0}</p>", msg.MessageText));
                    }
                    sb.Append("</div>");
                }
                return new MvcHtmlString(sb.ToString());
            }
            
            return new MvcHtmlString("");
        }


        public static IDictionary<string, object> GetHtmlAttributes(string @class = "", string placeholder = "", string id = "", string name = "", string role = "", bool disabled = false)
        {
            var htmlValues = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(@class))
                htmlValues.Add("class", @class);

            if (!string.IsNullOrEmpty(placeholder))
                htmlValues.Add("placeholder", placeholder);

            if (!string.IsNullOrEmpty(id))
                htmlValues.Add("id", id);

            if (!string.IsNullOrEmpty(name))
                htmlValues.Add("name", name);

            if (!string.IsNullOrEmpty(role))
                htmlValues.Add("role", role);

            if(disabled)
                htmlValues.Add("disabled", "disabled");

            return htmlValues;
        }
    }
}