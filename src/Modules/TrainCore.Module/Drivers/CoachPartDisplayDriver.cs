using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;
using TrainCore.Module.Models;
using TrainCore.Module.ViewModels;

namespace TrainCore.Module.Drivers
{
    public class CoachPartDisplayDriver : ContentPartDisplayDriver<CoachPart>
    {
        public override IDisplayResult Display(CoachPart part, BuildPartDisplayContext context) =>
            Initialize<CoachPartViewModel>(GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        public override IDisplayResult Edit(CoachPart part, BuildPartEditorContext context) =>
            Initialize<CoachPartViewModel>(GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(CoachPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var vM = new CoachPartViewModel();

            await updater.TryUpdateModelAsync(vM, Prefix);

            part.ModelScale = vM.ModelScale;
            part.CompanyName = vM.CompanyName;
            part.ModelEra = vM.ModelEra;
            part.Description = vM.Description;
            part.LightDetails = vM.LightDetails;
            part.HasInteriorBuiltIn= vM.HasInteriorBuiltIn;

            return await EditAsync(part, context);
        }

        private static void PopulateViewModel(CoachPart part, CoachPartViewModel viewModel)
        {
            viewModel.ModelScale = part.ModelScale;
            viewModel.CompanyName = part.CompanyName;
            viewModel.ModelEra = part.ModelEra;
            viewModel.Description = part.Description;
            viewModel.LightDetails = part.LightDetails;
            viewModel.HasInteriorBuiltIn= part.HasInteriorBuiltIn;
        }
    }
}
