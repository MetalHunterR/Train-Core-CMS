using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;

namespace TrainCore.Module.Migrations
{
    public class CoachePartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager contentDefinitionManager;

        public CoachePartMigrations(IContentDefinitionManager contentDefinitionManager)
        {
            this.contentDefinitionManager = contentDefinitionManager;
        }

        public int Create()
        {
            contentDefinitionManager.AlterPartDefinition(nameof(CoachPart), part => part
                .Attachable()
                .Reusable()
            );

            contentDefinitionManager.AlterTypeDefinition("CoachWidget", type => type
                .WithPart(nameof(CoachPart))
                .Stereotype("Widget")
            );

            return 3;
        }
    }
}
