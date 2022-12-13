using TrainCore.Module.Models;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;

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
                .WithField(nameof(CoachPart.Description), field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Coach Description")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "Describe your coach in a couple of sentances here..."
                    })
                    .WithEditor("TextArea"))
            );

            contentDefinitionManager.AlterTypeDefinition("CoachPage", type => type
                .Creatable()
                .Listable()
                .Draftable()
                .WithPart(nameof(CoachPart))
            );

            return 3;
        }
    }
}
