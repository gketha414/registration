using PreRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PreRegistration
{
    public static class ViewDataExtension
    {
        public static bool IsValid(this ViewDataDictionary viewData)
        {
            return viewData.ModelState.IsValid;
        }

        public static string GetLayout(this IViewModel model)
        {
            switch (model.UserGroup)
            {
                case "ReadOnly":
                    return "~/Views/Shared/_Layout.cshtml";
                case "Contributor":
                    return "~/Views/Shared/_Layout.cshtml";
                case "Admin":
                    return "~/Views/Shared/_LayoutAdmin.cshtml";
                default:
                    return "~/Views/Shared/_Layout.cshtml";
            }
        }
        public static HtmlString GetModelErrors(this ViewDataDictionary viewData)
        {
            StringBuilder errorMsg = new StringBuilder("<ul>");
            foreach (KeyValuePair<string, ModelState> item in viewData.ModelState)
            {
                if (item.Value.Errors.Count > 0)
                {
                    errorMsg.Append("<li>").Append(item.Value.Errors[0].ErrorMessage).Append("</li>");
                }
            }
            errorMsg.Append("</ul>");
            return MvcHtmlString.Create(errorMsg.ToString());
        }

    }


    public static class HtmlExtensions
    {
        private static string _tagEnd;
        private static string _controlId;
        private static StringBuilder _control;

        /// <summary>
        /// Returns a select element for each property in the object that is represented
        /// by the specified expression
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">Container property</typeparam>
        /// <param name="htmlHelper">The type of the value</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to
        /// render.</param>
        /// <param name="defaultValue">Default value</param>
        /// <param name="attributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML input element whose type attribute is set to "text" for each property
        /// in the object that is represented by the expression.</returns>
        public static MvcHtmlString SelectFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList dropDownSelectList)
        {
            buildSelectControl(expression);
            foreach (SelectListItem item in dropDownSelectList.Items)
            {
                object selected = expression.Compile().Invoke(htmlHelper.ViewData.Model);
                if (selected != null)
                    item.Selected = item.Value.Equals(selected.ToString());
            }
            addSelectListItems(dropDownSelectList);
            return MvcHtmlString.Create(_control.ToString());
        }
        public static MvcHtmlString SelectFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            SelectList dropDownSelectList,
            object attributes)
        {
            buildSelectControl(expression, attributes);
            foreach (SelectListItem item in dropDownSelectList.Items)
            {
                object selected = expression.Compile().Invoke(htmlHelper.ViewData.Model);
                if (selected != null)
                    item.Selected = item.Value.Equals(selected.ToString());
            }
            addSelectListItems(dropDownSelectList);
            return MvcHtmlString.Create(_control.ToString());
        }
        private static void buildSelectControl<TModel, TProperty>(
            Expression<Func<TModel, TProperty>> expression,
            object attributes = null)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            _tagEnd = "></select>";
            _controlId = buildControlId(body);
            _control = new StringBuilder();
            string controlName = _controlId.Replace("_", ".");
            _control.Append("<select");
            _control.Append(" id=")
                .Append("\"")
                .Append(_controlId)
                .Append("\"")
                .Append(" name=")
                .Append("\"")
                .Append(controlName)
                .Append("\" ")
                .Append(buildAttributeString(attributes))
                .Append(_tagEnd);
        }
        private static void addSelectListItems(
            SelectList dropDownSelectList,
            string defaultValue = null)
        {
            StringBuilder optionText = new StringBuilder();
            string startText = ">";
            bool hasSelectedItem = false;
            optionText.Append(startText);
            foreach (SelectListItem thisItem in dropDownSelectList.Items)
            {
                if (!hasSelectedItem && thisItem.Selected)
                    hasSelectedItem = true;
                optionText.Append("<option ");
                optionText.Append(thisItem.Selected
                    ? "selected=\"selected\" "
                    : String.Empty);
                optionText.Append("value=")
                    .Append("\"")
                    .Append(thisItem.Value)
                    .Append("\"")
                    .Append(" title=")
                    .Append("\"")
                    .Append(thisItem.Text)
                    .Append("\"")
                    .Append(">")
                    .Append(thisItem.Text)
                    .Append("</option>\r\n");
            }
            optionText.Append("</select>");
            _control.Replace(_tagEnd, optionText.ToString());
        }
        private static string buildControlId(
            MemberExpression body)
        {
            int expressionPos = body.ToString().IndexOf('.') + 1;
            string name = body.ToString().Substring(expressionPos);
            return name.Replace('.', '_');
        }
        private static StringBuilder buildAttributeString(
           object attributes)
        {
            StringBuilder returnValue = new StringBuilder();
            if (attributes != null)
            {
                string[] theseAttributes = attributes.ToString().Replace("}", "").Replace("{", "").Split('`');
                if (theseAttributes.Length > 0)
                {
                    StringBuilder attr = new StringBuilder();
                    foreach (string thisAttribute in theseAttributes)
                    {
                        string[] attrArray = thisAttribute.Split(',');
                        foreach (string thisAttr in attrArray)
                        {
                            string[] attKeyValue = thisAttr.Split('=');
                            KeyValuePair<string, string> keyValue = new KeyValuePair<string, string>(attKeyValue[0], attKeyValue[1]);
                            if (!replaceControlAttribute(keyValue))
                            {
                                attr.Append(buildControlAttribute(keyValue));
                            }
                        }
                    }
                    returnValue = attr;
                }
            }
            return returnValue;
        }
        private static string buildControlAttribute(
            KeyValuePair<string, string> keyValue)
        {
            StringBuilder attr = new StringBuilder();
            attr.Append(" ")
                .Append(keyValue.Key.Trim())
                .Append("=\"")
                .Append(keyValue.Value.Trim())
                .Append("\"");
            return attr.ToString();
        }
        private static bool replaceControlAttribute(
            KeyValuePair<string, string> newAttribute)
        {
            int attributeLen = newAttribute.Key.Trim().ToLower().Length;
            string key = String.Format("{0}=", newAttribute.Key);
            int existingAttrStart = _control.ToString().ToLower().IndexOf(key.Trim().ToLower());
            if (existingAttrStart > -1)
            {
                int existingAttribEnd = _control.ToString().IndexOf("\"", existingAttrStart + attributeLen + 2);
                string existingValues = _control.ToString().Substring(existingAttrStart, existingAttribEnd - existingAttrStart);
                _control.Replace(existingValues, String.Format("{0}=\"{1}", newAttribute.Key, newAttribute.Value));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Builds an Hmtl span control
        /// </summary>
        /// <typeparam name="TModel">The type of the model</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to</param>
        /// <returns>MvcHtmlString containg the span control</returns>
        /// <remarks>Builds a span element from the data provided by the Expression.</remarks>
        public static MvcHtmlString SpanFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            _control = new StringBuilder("<span id=\"")
                .Append(buildControlId(body))
                .Append("\">")
                .Append(expression.Compile().Invoke(htmlHelper.ViewData.Model))
                .Append("</span>");
            _controlId = String.Empty;
            return MvcHtmlString.Create(_control.ToString());
        }
        public static MvcHtmlString RequiredLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {

            MemberExpression body = (MemberExpression)expression.Body;
            object[] attrs = body.Member.GetCustomAttributes(false);
            bool isRequired = false;
            foreach (object attr in attrs)
            {
                isRequired = attr.GetType().Equals(typeof(RequiredAttribute));
                if (isRequired)
                    break;
            }
            MvcHtmlString returnValue = System.Web.Mvc.Html.LabelExtensions.LabelFor(htmlHelper, expression);
            if (isRequired)
                return MvcHtmlString.Create(String.Format("<sup class='error'>*</sup>{0}", returnValue.ToString()));
            return returnValue;
        }
        public static MvcHtmlString RequiredLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            object attributes)
        {

            MemberExpression body = (MemberExpression)expression.Body;
            object[] attrs = body.Member.GetCustomAttributes(false);
            bool isRequired = false;
            foreach (object attr in attrs)
            {
                isRequired = attr.GetType().Equals(typeof(RequiredAttribute));
                if (isRequired)
                    break;
            }
            MvcHtmlString returnValue = System.Web.Mvc.Html.LabelExtensions.LabelFor(htmlHelper, expression, attributes);
            if (isRequired)
                return MvcHtmlString.Create(String.Format("<sup class='error'>*</sup>{0}", returnValue.ToString()));
            return returnValue;
        }
    }
}