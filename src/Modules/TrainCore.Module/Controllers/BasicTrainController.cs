using TrainCore.Module.Indexes;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.ContentManagement;
using System.Threading.Tasks;
using YesSql;
using System.Collections.Generic;
using OrchardCore.ContentManagement.Display;
using OrchardCore.DisplayManagement.ModelBinding;

namespace TrainCore.Module.Controllers
{
    public class BasicTrainController : Controller
    {
        private readonly ISession session;
        private readonly IContentManager contentManager;
        private readonly IContentItemDisplayManager contentItemDisplayManager;
        private readonly IUpdateModelAccessor updateModelAccessor;

        public BasicTrainController(ISession session, IContentManager contentManager, IContentItemDisplayManager contentItemDisplayManager, IUpdateModelAccessor updateModelAccessor)
        {
            this.session = session;
            this.contentManager = contentManager;
            this.contentItemDisplayManager = contentItemDisplayManager;
            this.updateModelAccessor = updateModelAccessor;
        }

        [Route("TrainList")]
        public async Task<IActionResult> TrainList(string modelCompany)
        {
            var trainPages = await session
                .QueryContentItem(Lombiq.HelpfulLibraries.OrchardCore.Contents.PublicationStatus.Published, "LocomotivePage")
                .ListAsync();


            var shape = await trainPages.AwaitEachAsync(async train =>
            {
                await contentManager.LoadAsync(train);

                return await contentItemDisplayManager.BuildDisplayAsync(train, updateModelAccessor.ModelUpdater);
            });

            return View(shape);
        }
    }
}
