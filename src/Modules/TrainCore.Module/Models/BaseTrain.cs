using OrchardCore.ContentManagement;

namespace TrainCore.Module.Models
{
    public abstract class BaseTrain : ContentPart
    {
        public abstract string VehicleName { get; set; }

        public abstract string ModelScale { get; set; }

        public abstract string CompanyName { get; set; }

        public abstract string ModelEra { get; set; }

        public abstract string Description { get; set; }

        public abstract string LightDetails { get; set; }
    }
}
