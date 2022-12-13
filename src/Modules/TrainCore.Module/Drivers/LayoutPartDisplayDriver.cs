using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System.Threading.Tasks;
using TrainCore.Module.Models;
using TrainCore.Module.ViewModels;

namespace TrainCore.Module.Drivers
{
    public class LayoutPartDisplayDriver : ContentPartDisplayDriver<LayoutPart>
    {
        public override IDisplayResult Display(LayoutPart part, BuildPartDisplayContext context) =>
            Initialize<LayoutPartViewModel>(GetDisplayShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content:5")
            .Location("Summary", "Content:5");

        public override IDisplayResult Edit(LayoutPart part, BuildPartEditorContext context) =>
            Initialize<LayoutPartViewModel>(GetEditorShapeType(context),
                viewModel => PopulateViewModel(part, viewModel))
            .Location("Content:5");

        public override async Task<IDisplayResult> UpdateAsync(LayoutPart part, IUpdateModel updater, UpdatePartEditorContext context)
        {
            var vM = new LayoutPartViewModel();

            await updater.TryUpdateModelAsync(vM, Prefix);

            part.Width = vM.Width;
            part.Height = vM.Height;
            part.Length = vM.Length;
            part.LayoutTheme = vM.LayoutTheme;
            part.Description = vM.Description;

            return await EditAsync(part, context);
        }

        private static void PopulateViewModel(LayoutPart part, LayoutPartViewModel viewModel)
        {
            viewModel.Width = part.Width;
            viewModel.Height = part.Height;
            viewModel.Length = part.Length;
            viewModel.LayoutTheme = part.LayoutTheme;
            viewModel.Description = part.Description;
        }
    }
}
