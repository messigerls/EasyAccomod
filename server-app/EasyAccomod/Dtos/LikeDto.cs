﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EasyAccomod.Models;

namespace EasyAccomod.Dtos
{
    public class LikeDto
    {
        public int Id { get; set; }

        public int RenterId { get; set; }

        public string RenterName { get; set; }

        [Required]
        public int AccommodationRentalPostId { get; set; }

        public DateTime Time { get; set; }
    }
}