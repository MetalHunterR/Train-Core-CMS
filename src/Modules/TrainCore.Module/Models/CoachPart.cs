using OrchardCore.ContentFields.Fields;

namespace TrainCore.Module.Models
{
    public class CoachPart : BaseTrain
	{
        public override string ModelScale { get; set; }

        public override string CompanyName { get; set; }

        public override string ModelEra { get; set; }

        public override TextField Description { get; set; }

        public override TextField LightDetails { get; set; }
		
        public bool HasInteriorBuiltIn { get; set; }
	}
}
