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
                int previousType = -1;
                foreach (var message in model.Messages.OrderBy(m => m.MessageType))
                {
                    string @class = string.Empty;
                    if (previousType != (int)message.MessageType)
                    {
                        if(previousType != -1)
                            sb.Append("</div>");

                        switch (message.MessageType)
                        {
                            case ViewModelMessageType.Error:
                                @class = "danger";
                                break;
                            case ViewModelMessageType.Info:
                                @class = "info";
                                break;
                            case ViewModelMessageType.Success:
                                @class = "success";
                                break;
                            case ViewModelMessageType.Warning:
                                @class = "warning";
                                break;
                        }
                        sb.Append(string.Format("<div class=\"alert alert-dismissible alert-{0}\" role=\"alert\">", @class));
                        sb.Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\"><span aria-hidden=\"true\">&times;</span><span class=\"sr-only\">Close</span></button>");

                        previousType = (int)message.MessageType;
                    }
                    sb.Append("<p>");
                    sb.Append(string.IsNullOrEmpty(message.MessageTitle) ? string.Empty : string.Format("<strong>{0}</strong>", message.MessageTitle));
                    sb.Append(message.MessageText);
                    sb.Append("</p>");
                }
                sb.Append("</div>");

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

            if (disabled)
                htmlValues.Add("disabled", "disabled");

            return htmlValues;
        }
    }
}