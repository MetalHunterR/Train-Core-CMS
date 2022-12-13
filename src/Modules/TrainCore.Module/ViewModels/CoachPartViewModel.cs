using System.ComponentModel.DataAnnotations;

namespace TrainCore.Module.ViewModels
{
    public class CoachPartViewModel : BaseTrainViewModel
    {
        public override string VehicleName { get; set; }

        public override string ModelScale { get; set; }

        public override string CompanyName { get; set; }

        public override string ModelEra { get; set; }

        public override string Description { get; set; }

        public override string LightDetails { get; set; }

        [Required]
        public bool HasInteriorBuiltIn { get; set; }
    }
}
