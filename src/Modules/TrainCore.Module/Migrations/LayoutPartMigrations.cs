using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;

namespace TrainCore.Module.Migrations
{
    public class LayoutPartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager contentDefinitionManager;

        public LayoutPartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            this.contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            contentDefinitionManager.AlterPartDefinition(nameof(LayoutPart), part => part
                .Attachable()
                .Reusable()
                .WithField(nameof(LayoutPart.Description), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Layout Description")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe your layout in a couple of sentances here..."
                    })
                    .WithEditor("TextArea"))
            );

            contentDefinitionManager.AlterTypeDefinition("LayoutPage", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .WithPart(nameof(LayoutPart))
            );

            return 3;
        }
    }
}
