using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TOTD.Mvc.FluentHtml.Html;
using TOTD.Utility.Misc;
using TOTD.Utility.ReflectionHelpers;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class BaseInputElement<T> : BaseFormElement<T> where T : BaseInputElement<T>
    {
        public BaseInputElement(string inputType, HtmlHelper htmlHelper)
            : base(HtmlTag.Input, TagRenderMode.SelfClosing, htmlHelper)
        {
            For(inputType);
        }

        public T For(string inputType)
        {
            Builder.MergeAttribute(HtmlAttribute.Type, inputType, replaceExisting: true);
            return (T)this;
        }

        public T Placeholder(string text)
        {
            Builder.MergeAttribute(HtmlAttribute.Placeholder, text);
            return (T)this;
        }

        public T Value(string value)
        {
            Builder.MergeAttribute(HtmlAttribute.Value, value);
            return (T)this;
        }

        protected override void SetAttributesFromModelProperty(System.Linq.Expressions.LambdaExpression expression)
        {
            base.SetAttributesFromModelProperty(expression);

            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)expression.Body;
                MemberInfo memberInfo = memberExpression.Member;

                // If property has DataTypeAttribute set input type based on value of DataType
                DataTypeAttribute dataTypeAttribute = memberInfo.GetAttribute<DataTypeAttribute>();
                switch (dataTypeAttribute.IfNotNull(x => x.DataType, DataType.Text))
                {
                    case DataType.DateTime:
                        this.For(HtmlInputType.DateTime);
                        break;

                    case DataType.Date:
                        this.For(HtmlInputType.Date);
                        break;

                    case DataType.Time:
                        this.For(HtmlInputType.Time);
                        break;

                    case DataType.PhoneNumber:
                        this.For(HtmlInputType.Telephone);
                        break;

                    case DataType.Currency:
                    case DataType.CreditCard:
                        this.For(HtmlInputType.Number);
                        break;

                    case DataType.EmailAddress:
                        this.For(HtmlInputType.Email);
                        break;

                    case DataType.Password:
                        this.For(HtmlInputType.Password);
                        break;

                    case DataType.Url:
                        this.For(HtmlInputType.Url);
                        break;

                    default:
                        // If the property represents a number and a DataType hasn't been set then use the Number input type
                        // otherwise leave the input type as the default from the constructor
                        PropertyInfo propertyInfo = (PropertyInfo)memberInfo;
                        if (propertyInfo.PropertyType == typeof(int))
                        {
                            this.For(HtmlInputType.Number);
                        }
                        break;
                }
            }
        }

        protected override void SetValue(string value)
        {
            base.SetValue(value);
            Value(value);
        }
    }
}