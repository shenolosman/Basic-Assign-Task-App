using Microsoft.AspNetCore.Razor.TagHelpers;
using SO.ToDo.BusinessLayer.Interfaces;

namespace SO.ToDo.WebAPP.TagHelpers
{
    [HtmlTargetElement("GetMyTaskByAppUserId")]
    public class MyTaskAppUserIdTagHelper : TagHelper
    {
        private readonly IMyTaskService _myTaskService;

        public MyTaskAppUserIdTagHelper(IMyTaskService myTaskService)
        {
            _myTaskService = myTaskService;
        }
        private int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var tasks = _myTaskService.GetByAppUserId(AppUserId);
            var done = tasks.Result.Count(x => x.IsDone);
            var notDone = tasks.Result.Count(x => !x.IsDone);
            var htmlString = $"<br>Done tasks : <strong> {done}</strong><br>Still doing : <strong>{notDone}</strong>";
            output.Content.SetHtmlContent(htmlString);

        }
    }
}
