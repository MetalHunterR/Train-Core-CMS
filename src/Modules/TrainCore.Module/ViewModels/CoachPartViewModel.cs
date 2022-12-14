using OrchardCore.ContentFields.Fields;
using System.ComponentModel.DataAnnotations;

namespace TrainCore.Module.ViewModels
{
    public class CoachPartViewModel : BaseTrainViewModel
	{
        public override string ModelScale { get; set; }

        public override string CompanyName { get; set; }
		
        public override string ModelEra { get; set; }

        public override TextField Description { get; set; }

        public override TextField LightDetails { get; set; }

        [Required]
        public bool HasInteriorBuiltIn { get; set; }
	}
}
