using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using TrainCore.Module.Indexes;
using TrainCore.Module.Models;
using YesSql.Sql;

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
                .WithField(nameof(LocomotivePart.Description), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Locomotive Description")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe the locomotive here...",
                    }))
                .WithField(nameof(LocomotivePart.LightDetails), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Locomotive Light Details")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe the lights of the locomotive here...",
                    }))
            );

            contentDefinitionManager.AlterTypeDefinition("LocomotivePage", type => type
                .Creatable()
                .Listable()
                .WithTitlePart()
                .WithPart(nameof(LocomotivePart))
            );

            SchemaBuilder.CreateMapIndexTable<BasicTrainIndex>(table => table
                .Column<string>(nameof(BasicTrainIndex.ContentItemId), column => column.WithLength(26))
                .Column<string>(nameof(BasicTrainIndex.CompanyName), column => column.WithLength(16))
                .Column<string>(nameof(BasicTrainIndex.ModelEra), column => column.WithLength(10))
            );

            SchemaBuilder.AlterIndexTable<BasicTrainIndex>(table => table
                .CreateIndex($"IDX_{nameof(BasicTrainIndex)}_{nameof(BasicTrainIndex.Id)}",
                nameof(BasicTrainIndex.CompanyName))
            );

            return 1;
        }
    }
}
