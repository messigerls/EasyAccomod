﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyAccomod.Models
{
    public class AccommodationStatus
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class AccommodationStatusName
    {
        public const string Rented = "Đã cho thuê";
        public const string NotRented = "Chưa cho thuê";
    }
}