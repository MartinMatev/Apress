using System;
using System.Web.Mvc;

namespace HelperMethods.Infrastructure
{
    public static class CustomHelpers
    {
        public static MvcHtmlString DisplayMessage(this HtmlHelper html, string msg)
        {
            string encodedMessage = html.Encode(msg);
            string result = string.Format("This is the message: <p>{0}</p>", encodedMessage);
            return new MvcHtmlString(result);
        }

        public static MvcHtmlString ListOfItems(this HtmlHelper html, string[] collection)
        {
            TagBuilder tag = new TagBuilder("ul");

            foreach (string item in collection)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(item);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }
    }
}