using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using TrainCore.Module.Models;

namespace TrainCore.Module.Migrations
{
    public class LocomotivePartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager contentDefinitionManager;

        public LocomotivePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            this.contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            contentDefinitionManager.AlterPartDefinition(nameof(LocomotivePart), part => part
                .Attachable()
                .Reusable()
                .WithField(nameof(LocomotivePart.Description), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("LocomotivePart Description")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe your locomotive in a couple of sentances here..."
                    })
                    .WithEditor("TextArea"))
            );

            contentDefinitionManager.AlterTypeDefinition("LocomotivePage", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .WithPart(nameof(LocomotivePart))
            );

            return 3;
        }
    }
}
