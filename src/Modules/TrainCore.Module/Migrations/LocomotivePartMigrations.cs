using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

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

            contentDefinitionManager.AlterTypeDefinition("LocomotiveWidget", type => type
                .WithPart(nameof(LocomotivePart))
                .Stereotype("Widget")
            );

            return 3;
        }
    }
}
