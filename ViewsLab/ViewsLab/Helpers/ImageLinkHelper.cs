using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ViewsLab.Helpers
{
    public static class ImageLinkHelper
    {
        public static MvcHtmlString ImageLink(this HtmlHelper helper, string actionName, 
            string imageUrl, string alternateText, object routeValues, 
            object linkHtmlAttributes, object imageHtmlAttributes)
        {
            //  Create an instance of the url helper class
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            
            //  Set up variables for the parameters to be passed to the various methods
            //  of the helper to construct the html.
            //  Use the Action method to generate the correct Url
            var url = urlHelper.Action(actionName, routeValues);
            //  Add any attributes to the RouteValueDictionary
            var linkAttributes = new RouteValueDictionary(linkHtmlAttributes);
            //  Use the Content method to generate the url fot eh image (not an action url)
            var imgUrl = urlHelper.Content(imageUrl);
            //  Use the Encode method to ensure any text is property encoded, to stop scripting attacks
            var imgAltText = urlHelper.Encode(alternateText);
            var imgAttributes = new RouteValueDictionary(imageHtmlAttributes);

            //  Create the Anchor tag to hold the href.
            var linkTagbuilder = new TagBuilder("a");
            //  Add the href attribute
            linkTagbuilder.MergeAttribute("href", url);
            //  Add any attributes passed into method.
            linkTagbuilder.MergeAttributes(linkAttributes);

            //  Create the img tag to contain the image
            var imageTagBuilder = new TagBuilder("img");
            //  Add the alt and src attributes
            imageTagBuilder.MergeAttribute("alt", imgAltText);
            imageTagBuilder.MergeAttribute("src", imgUrl);
            //  Add any additional attributes passed into the method.
            imageTagBuilder.MergeAttributes(imgAttributes);
            
            //  Add the img tag inside the Anchor tag.
            linkTagbuilder.InnerHtml = imageTagBuilder.ToString(TagRenderMode.SelfClosing);

            //  Wrap the html in an MvcHtmlString and return.
            //  If we use the TagRenderMode.SelfClosing for this operation, it wipes out
            //  the innerHtml.
            return new MvcHtmlString(linkTagbuilder.ToString());
        }

        //  overload the helper method to offer less parameters
        public static MvcHtmlString ImageLink(this HtmlHelper helper, string actionName,
            string imageUrl, string alternateText, object routeValues)
        {
            return ImageLink(helper, actionName, imageUrl, alternateText, routeValues, null, null);
        }

        //  overload the helper method to offer less parameters
        public static MvcHtmlString ImageLink(this HtmlHelper helper, string actionName,
            string imageUrl, string alternateText)
        {
            return ImageLink(helper, actionName, imageUrl, alternateText, null, null, null);
        }






    }
}