﻿using System.ComponentModel.DataAnnotations;

namespace TrainCore.Module.ViewModels
{
    public abstract class BaseTrainViewModel
    {
        [Required]
        public abstract string VehicleName { get; set; }

        [Required]
        public abstract string ModelScale { get; set; }

        [Required]
        public abstract string CompanyName { get; set; }

        public abstract string ModelEra { get; set; }

        [Required]
        public abstract string Description { get; set; }

        public abstract string LightDetails { get; set; }
    }
}
