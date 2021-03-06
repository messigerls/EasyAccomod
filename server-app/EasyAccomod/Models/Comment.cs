﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyAccomod.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public Renter Renter { get; set; }

        [Required]
        public int RenterId { get; set; }

        public AccommodationRentalPost AccommodationRentalPost { get; set; }

        [Required]
        public int AccommodationRentalPostId { get; set; }

        [Required]
        [Range(1, 5)]
        public byte Rate { get; set; }

        [Required] public string Content { get; set; }

        [Required] public bool IsApproved { get; set; }

        [Required] public DateTime Time { get; set; }
    }
}