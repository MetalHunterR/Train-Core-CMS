using TrainCore.Module.Indexes;
using TrainCore.Module.Models;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Records;
using System.Linq;
using System.Threading.Tasks;
using YesSql;

namespace TrainCore.Module.Controllers
{
    public class BasicTrainController : Controller
    {
        private readonly ISession session;
        private readonly IContentManager contentManager;

        public BasicTrainController(ISession session, IContentManager contentManager)
        {
            this.session = session;
            this.contentManager = contentManager;
        }

        [Route("TrainList/{era}/{company}")]
        public async Task<string> List(string modelEra, string modelCompany)
        {
            var trainPages = await session
                .Query<ContentItem, ContentItemIndex>(index => index.ContentType == "LocomotivePage" || index.ContentType == "CoachPage")
                .With<BasicTrainIndex>(trainIndex => trainIndex.ModelEra == modelEra || trainIndex.CompanyName == modelCompany)
                .ListAsync();

            foreach (var trainPage in trainPages)
            {
                await contentManager.LoadAsync(trainPage);
            }

            return string.Join(", ", trainPages.Select(trainPages => trainPages.As<BaseTrain>().Description));
        }
    }
}
