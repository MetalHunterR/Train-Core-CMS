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
            );

            contentDefinitionManager.AlterTypeDefinition("LocomotivePage", type => type
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
