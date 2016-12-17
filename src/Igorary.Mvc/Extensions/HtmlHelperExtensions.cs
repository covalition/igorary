using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Covalition.Igorary.Mvc.Attributes;

namespace Covalition.Igorary.Mvc.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string GetActiveClass<TModel, TActiveLink>(this HtmlHelper<TModel> html, params TActiveLink[] activeLink) {
            return activeLink.Contains((TActiveLink)html.ViewBag.ActiveLink) ? "active" : string.Empty;
        }

        public static MvcHtmlString CurrencyFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, string currencySymbol = null) {
            if (currencySymbol == null)
                currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            string classToAdd = "calculator";
            RouteValueDictionary htmlAttributesDictionary = getHtmlAttributesDictionary(htmlAttributes, classToAdd);
            return MvcHtmlString.Create("<div class=\"input-group\"><span class=\"input-group-addon\">" + currencySymbol + "</span>" + htmlHelper.TextBoxFor(expression, "{0:F2}", htmlAttributesDictionary) + "<div class=\"input-group-btn\"><button type=\"button\" class=\"btn btn-default btn-sm\" tabindex=\"-1\" onclick=\"$('#" + (expression.Body as MemberExpression).Member.Name + "').calculator('show')\" ><i class=\"glyphicon glyphicon-list-alt\"></i></button></div></div>");
        }

        private static RouteValueDictionary getHtmlAttributesDictionary(object htmlAttributes, string classToAdd) {
            RouteValueDictionary htmlAttributesDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            string classes = htmlAttributesDictionary["class"] as string;
            classes += classes + (string.IsNullOrEmpty(classes) ? string.Empty : " ") + classToAdd;
            htmlAttributesDictionary["class"] = classes;
            return htmlAttributesDictionary;
        }

        public static MvcHtmlString DoubleFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes) {
            string classToAdd = "calculator";
            RouteValueDictionary htmlAttributesDictionary = getHtmlAttributesDictionary(htmlAttributes, classToAdd);
            return MvcHtmlString.Create("<div class=\"input-group\">" + htmlHelper.TextBoxFor(expression, "{0:F2}", htmlAttributesDictionary) + "<div class=\"input-group-btn\"><button type=\"button\" class=\"btn btn-default btn-sm\" tabindex=\"-1\" onclick=\"$('#" + (expression.Body as MemberExpression).Member.Name + "').calculator('show')\" ><i class=\"glyphicon glyphicon-list-alt\"></i></button></div></div>");
        }

        public static MvcHtmlString DateFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string divId) {
            return MvcHtmlString.Create("<div class=\"input-group date\" id='" + divId + "' data-date-format='yyyy-mm-dd'>" + htmlHelper.TextBoxFor(expression, "{0:yyyy-MM-dd}", new { @class = "form-control input-sm narrow-input" }) + "<span class='input-group-addon'><span class='glyphicon glyphicon-calendar'></span></span></div>");
        }

        // TODO: poprawić
        public static MvcHtmlString DateTimeFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string divId) {
            return MvcHtmlString.Create("<div class=\"input-group date\" id='" + divId + "' data-date-format=\"YYYY-MM-DD HH:mm:ss\">" + htmlHelper.TextBoxFor(expression, "{0:yyyy-MM-dd HH:mm:ss}", new { @class = "form-control input-sm narrow-input" }) + "<span class='input-group-addon'><span class='glyphicon glyphicon-calendar'></span></span></div>");
        }

        public static IHtmlString Table<TModel, TRowType>(this HtmlHelper<TModel> html, IEnumerable<TRowType> rows, string targetId = null, object htmlAttributes = null, string fieldNamePrefix = null, string ajaxUpdateCallbackFunction = null, params WebGridColumn[] commandColumns) {
            WebGrid grid;
            return Table<TModel, TRowType>(html, rows, targetId, out grid, htmlAttributes, fieldNamePrefix, ajaxUpdateCallbackFunction, commandColumns);
        }

        public static IHtmlString Table<TModel, TRowType>(this HtmlHelper<TModel> html, IEnumerable<TRowType> rows, string targetId, out WebGrid grid, object htmlAttributes= null, string fieldNamePrefix = null, string ajaxUpdateCallbackFunction = null, params WebGridColumn[] commandColumns) {
            ModelMetadata rowMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(TRowType));
            List<WebGridColumn> columns = rowMetadata.Properties
                .Where(p => p.ShowForDisplay)
                .Select(p => {
                    WebGridColumn col = new WebGridColumn
                    {
                        ColumnName = p.PropertyName,
                        Header = p.DisplayName,
                        CanSort = true
                    };
                    if (p.DataTypeName == DataType.Currency.ToString() || p.ModelType.IsAssignableFrom(typeof(decimal)) || p.ModelType.IsAssignableFrom(typeof(double)) || p.ModelType.IsAssignableFrom(typeof(int)))
                    // if (p.ModelType.IsAssignableFrom(typeof(int)) || p.ModelType.IsAssignableFrom(typeof(int?)))
                        col.Style = "right-cell";
                    else
                        if (p.DataTypeName == DataType.Date.ToString() || p.DataTypeName == DataType.DateTime.ToString())
                            col.Style = "center-cell";

                    //PropertyInfo propertyInfo = p.ContainerType.GetProperty(p.PropertyName);
                    LinkAttribute linkAttribute = p.ContainerType.GetProperty(p.PropertyName).GetCustomAttributes(true).OfType<LinkAttribute>().FirstOrDefault();
                    if (linkAttribute != null) {
                        // (string)getPropertyValue(p, item) -> ((object)getPropertyValue(p, item)).ToString()
                        col.Format = (item) =>
                        {
                            RouteValueDictionary routeValueDictionary = new RouteValueDictionary();
                            PropertyInfo valuePropertyInfo = p.ContainerType.GetProperty(linkAttribute.FieldId);
                            dynamic idValue = valuePropertyInfo.GetValue((item as WebGridRow).Value);
                            string text = (string)getPropertyValue(p, item);
                            if (idValue != null) {
                                routeValueDictionary.Add(linkAttribute.IdParamName, /* valuePropertyInfo.GetValue((item as WebGridRow).Value) */ idValue);
                                return html.ActionLink(/*(string)getPropertyValue(p, item)*/ text, linkAttribute.ActionName, linkAttribute.ControllerName, routeValueDictionary, null);
                            }
                            else
                                return text;
                        };
                    }
                    if (!string.IsNullOrEmpty(p.DisplayFormatString))
                        col.Format = (item) => string.Format(p.DisplayFormatString, /* Utils.GetPropValue(item, p.PropertyName) */ arg0: getPropertyValue(p, item));
                    else if (p.ModelType.IsAssignableFrom(typeof(bool))) {
                        col.Format = (item) => html.Raw("<input type='checkbox' " + ((getPropertyValue(p, item) == true) ? "checked" : "") + " disabled='disabled' />");
                        col.Style = "center-cell";
                    }
                    return col;
            }).ToList();
            if (commandColumns != null)
                columns.AddRange(commandColumns);
            grid = new WebGrid(rows as IEnumerable<dynamic>, ajaxUpdateContainerId: targetId, ajaxUpdateCallback: ajaxUpdateCallbackFunction, fieldNamePrefix: fieldNamePrefix, selectionFieldName: "SelectedRow");
            string className = "table table-bordered table-striped";
            return grid.GetHtml(tableStyle: className, columns: columns, htmlAttributes: htmlAttributes);
        }

        private static dynamic getPropertyValue(ModelMetadata modelMetadata, dynamic item) {
            object source = (item as WebGridRow).Value;
            return source.GetType().GetProperty(modelMetadata.PropertyName).GetValue(source, null);
        }

        public static MvcPanel BeginPanel(this HtmlHelper html, string header = null, string footer = null) {
            TextWriter writer = html.ViewContext.Writer;
            string headerHtml = header != null ? string.Format("<div class=\"panel-heading\">{0}</div>", header) : string.Empty;
            writer.Write(string.Format("<div class=\"panel panel-default\">{0}<div class=\"panel-body\">", headerHtml));
            return new MvcPanel(html.ViewContext, footer);
        }
    }
}