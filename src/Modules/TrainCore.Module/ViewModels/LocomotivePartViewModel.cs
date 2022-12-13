using System.ComponentModel.DataAnnotations;

namespace TrainCore.Module.ViewModels
{
    public class LocomotivePartViewModel : BaseTrainViewModel
    {
        public override string VehicleName { get; set; }

        public override string ModelScale { get; set; }

        public override string CompanyName { get; set; }

        public override string ModelEra { get; set; }

        public override string Description { get; set; }

        public override string LightDetails { get; set; }

        [Required]
        public string ModelMotorType { get; set; }

        [Required]
        public int ContactWheels { get; set; }

        public bool CanUsePantograph { get; set; }
    }
}