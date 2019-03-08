using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace ToDoList.Concrete
{
    public static class CalendarHelpers
    {
        public static MvcHtmlString Calendar<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            //var data = (DateTime)metadata.Model;

            TagBuilder tb = new TagBuilder("input");
            tb.Attributes.Add("type", "date");

            var strD = $@"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day + 10}";
            tb.Attributes.Add("value", strD);
            tb.Attributes.Add("name", name);

            return new MvcHtmlString(tb.ToString());
        }
    }
}