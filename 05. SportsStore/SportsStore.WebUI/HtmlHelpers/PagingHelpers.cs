namespace SportsStore.WebUI.HtmlHelpers
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Web.Mvc;
    using Models;

    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PagingInfo pagingInfo, Func<int, String> pageUrl)
        {
            var result = new StringBuilder();

            for (var i = 1; i <= pagingInfo.TotalPages; i++)
            {
                //Construct an <a> tag
                var tag = new TagBuilder("a");

                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString(CultureInfo.InvariantCulture);

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }

                result.Append(tag);
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}