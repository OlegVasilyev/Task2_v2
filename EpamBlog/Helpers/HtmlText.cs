﻿using System.Web.Mvc;

namespace EpamBlog.Helpers
{
    public static class HtmlText
    {
        public static MvcHtmlString WriteHtml(this HtmlHelper html, string text)
        {
            return new MvcHtmlString(text);
        }
    }
}