using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata.Builders;

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
                .WithField(nameof(LayoutPart.Description), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Layout Description")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe your layout here...",
                    }))
            );

            contentDefinitionManager.AlterTypeDefinition("LayoutPage", type => type
                .Creatable()
                .Listable()
                .WithTitlePart()
                .WithPart(nameof(LayoutPart))
            );

            return 1;
        }
    }
}
