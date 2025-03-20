﻿using System;

namespace EcoinverGMAO_api.Models.Dto
{
    public class CommercialNeedsDto
    {
        public int Id { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal Kgs { get; set; }
    }
}
