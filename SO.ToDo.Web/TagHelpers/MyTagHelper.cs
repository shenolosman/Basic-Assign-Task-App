using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace SO.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("MyHelper")]
    public class MyTagHelper : TagHelper
    {
        public string IncomingData { get; set; } = "Shenol's Todo Web App";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var tagBuilder = new TagBuilder("p");
            //tagBuilder.InnerHtml.AppendHtml("<b>Shenol's Todo Web App</b>");
            //output.Content.SetHtmlContent(tagBuilder);

            var striingBuilder = new StringBuilder();
            striingBuilder.Append($"<p><b> {IncomingData}</b></p>");
            output.Content.SetHtmlContent(striingBuilder.ToString());
            base.Process(context, output);
        }
    }
}
