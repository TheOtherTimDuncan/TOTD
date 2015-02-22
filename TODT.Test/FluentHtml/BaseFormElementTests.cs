using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml.Attributes;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Test.FluentHtml
{
    [TestClass]
    public class BaseFormElementTests : BaseElementTests
    {
        public ViewDataDictionary<TestModel> GetViewData(TestModel model)
        {
            ViewDataDictionary<TestModel> viewData = new ViewDataDictionary<TestModel>(model)
            {
                {"StringProperty", model.StringProperty},
                {"IntegerProperty", model.IntegerProperty}
            };
            viewData.Model = model;

            return viewData;
        }

        [TestMethod]
        public void CorrectlySetsAutoFocusAttribute()
        {
            TestModel model = new TestModel
            {
                StringProperty = "StringValue"
            };
            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            new InputElement(GetHtmlHelper(viewData))
                .AutoFocus()
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("autofocus=\"autofocus\"");
        }

        [TestMethod]
        public void CorrectlySetsRequiredAttribute()
        {
            TestModel model = new TestModel
            {
                StringProperty = "StringValue"
            };
            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            new InputElement(GetHtmlHelper(viewData))
                .Required()
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("required=\"required\"");
        }

        public class TestModel
        {
            public int IntegerProperty
            {
                get;
                set;
            }

            [Placeholder("Placeholder")]
            public string StringProperty
            {
                get;
                set;
            }

            [Display(Name = "Display Label")]
            public string DisplayProperty
            {
                get;
                set;
            }

            [DataType(DataType.EmailAddress)]
            public string Email
            {
                get;
                set;
            }

            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber
            {
                get;
                set;
            }

            [DataType(DataType.Password)]
            public string Password
            {
                get;
                set;
            }

            [DataType(DataType.Date)]
            public string DateValue
            {
                get;
                set;
            }

            [DataType(DataType.DateTime)]
            public string DateTimeValue
            {
                get;
                set;
            }

            [DataType(DataType.Time)]
            public string TimeValue
            {
                get;
                set;
            }

            [DataType(DataType.Url)]
            public string Url
            {
                get;
                set;
            }

            public ChildModel Child
            {
                get;
                set;
            }
        }

        public class ChildModel
        {
            public string ChildStringProperty
            {
                get;
                set;
            }
        }
    }
}
