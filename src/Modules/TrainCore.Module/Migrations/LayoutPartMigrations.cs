using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

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

            contentDefinitionManager.AlterTypeDefinition("LayoutWidget", type => type
                .WithPart(nameof(LayoutPart))
                .Stereotype("Widget")
            );

            return 3;
        }
    }
}
