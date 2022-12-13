using OrchardCore.ContentManagement.Handlers;
using System.Threading.Tasks;
using TrainCore.Module.Models;

namespace TrainCore.Module.Handlers
{
    public class CoachPartHandler : ContentPartHandler<CoachPart>
    {
        public override Task UpdatedAsync(UpdateContentContext context, CoachPart instance)
        {
            context.ContentItem.DisplayText = instance.VehicleName;
            return Task.CompletedTask;
        }
    }
}
