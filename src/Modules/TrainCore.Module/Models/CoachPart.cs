namespace TrainCore.Module.Models
{
    public class CoachPart : BaseTrain
    {
        public override string VehicleName { get; set; }

        public override string ModelScale { get; set; }

        public override string CompanyName { get; set; }

        public override string ModelEra { get; set; }

        public override string Description { get; set; }

        public override string LightDetails { get; set; }

        public bool HasInteriorBuiltIn { get; set; }
    }
}
