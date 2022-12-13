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
            );

            contentDefinitionManager.AlterTypeDefinition("LayoutPage", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .Versionable()
                .Securable()
            );

            return 3;
        }
    }
}
