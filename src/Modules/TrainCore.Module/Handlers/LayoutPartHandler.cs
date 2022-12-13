using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using TrainCore.Module.Models;

namespace TrainCore.Module.Handlers
{
    public class LayoutPartHandler : ContentPartHandler<LayoutPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, LayoutPart instance)
        {
            context.ContentItem.DisplayText = instance.LayoutTitle;
            return Task.CompletedTask;
        }
    }
}
