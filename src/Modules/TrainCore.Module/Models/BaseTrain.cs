using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;

namespace TrainCore.Module.Models
{
    public abstract class BaseTrain : ContentPart
    {
        public abstract string ModelScale { get; set; }

        public abstract string CompanyName { get; set; }

        public abstract string ModelEra { get; set; }

        public abstract TextField Description { get; set; }

        public abstract TextField LightDetails { get; set; }
    }
}
