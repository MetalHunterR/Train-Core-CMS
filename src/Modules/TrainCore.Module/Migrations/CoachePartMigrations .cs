using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata.Builders;

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
                .WithField(nameof(CoachPart.Description), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Coach Description")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe the coach/wagon here...",
                    }))
                .WithField(nameof(CoachPart.LightDetails), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Coach Light Details")
                    .WithEditor("TextArea")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe the lights of the coach/wagon here...",
                    }))
            );

            contentDefinitionManager.AlterTypeDefinition("CoachPage", type => type
                .Creatable()
                .Listable()
                .WithTitlePart()
                .WithPart(nameof(CoachPart))
            );

            return 1;
        }
    }
}
