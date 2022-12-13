using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using TrainCore.Module.Models;

namespace TrainCore.Module.Handlers
{
    public class LocomotivePartHandler : ContentPartHandler<LocomotivePart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, LocomotivePart instance)
        {
            context.ContentItem.DisplayText = instance.CompanyName;
            return Task.CompletedTask;
        }
    }
}
