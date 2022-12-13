using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;
using TrainCore.Module.Models;
using TrainCore.Module.ViewModels;

namespace TrainCore.Module.Drivers
{
    public class LocomotivePartDisplayDriver : ContentPartDisplayDriver<LocomotivePart>
    {
        public override IDisplayResult Display(LocomotivePart part, BuildPartDisplayContext context) =>
            Initialize<LocomotivePartViewModel>(GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        public override IDisplayResult Edit(LocomotivePart part, BuildPartEditorContext context) =>
            Initialize<LocomotivePartViewModel>(GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(LocomotivePart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var vM = new LocomotivePartViewModel();

            await updater.TryUpdateModelAsync(vM, Prefix);

            part.VehicleName = vM.VehicleName;
            part.ModelScale = vM.ModelScale;
            part.CompanyName = vM.CompanyName;
            part.ModelEra = vM.ModelEra;
            part.Description = vM.Description;
            part.LightDetails = vM.LightDetails;
            part.ModelMotorType = vM.ModelMotorType;
            part.ContactWheels = vM.ContactWheels;
            part.CanUsePantograph = vM.CanUsePantograph;

            return await EditAsync(part, context);
        }

        private static void PopulateViewModel(LocomotivePart part, LocomotivePartViewModel viewModel)
        {
            viewModel.VehicleName= part.VehicleName;
            viewModel.ModelScale= part.ModelScale;
            viewModel.CompanyName= part.CompanyName;
            viewModel.ModelEra= part.ModelEra;
            viewModel.Description= part.Description;
            viewModel.LightDetails= part.LightDetails;
            viewModel.ModelMotorType= part.ModelMotorType;
            viewModel.ContactWheels= part.ContactWheels;
            viewModel.CanUsePantograph= part.CanUsePantograph;
        }
    }
}
