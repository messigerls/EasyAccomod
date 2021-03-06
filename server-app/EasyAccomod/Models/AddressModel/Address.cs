﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyAccomod.Models.AddressModel
{
    public class Address
    {
        public int Id { get; set; }

        public Province Province { get; set; }

        [Required]
        public byte ProvinceId { get; set; }

        public District District { get; set; }

        [Required]
        public int DistrictId { get; set; }

        public Ward Ward { get; set; }

        [Required]
        public int WardId { get; set; }

        [Required]
        public string Street { get; set; }

        public string PublicLocationNearby { get; set; }
    }
}