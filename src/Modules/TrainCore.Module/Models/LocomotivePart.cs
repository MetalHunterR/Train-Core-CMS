using OrchardCore.ContentFields.Fields;

namespace TrainCore.Module.Models
{
    public class LocomotivePart : BaseTrain
	{
        public override string VehicleName { get; set; }

        public override string ModelScale { get; set; }

        public override string CompanyName { get; set; }

        public override string ModelEra { get; set; }

        public override TextField Description { get; set; }

        public override string LightDetails { get; set; }
		
        public string ModelMotorType { get; set; }

        public int ContactWheels { get; set; }

        public bool CanUsePantograph { get; set; }
	}
}
