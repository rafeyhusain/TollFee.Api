using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TollFee.Api.Services;

namespace TollFee.Api.Models
{
    public class CalculateFeeResponse
    {
        public decimal TotalFee { get; set; }
        public decimal AverageFeePerDay { get; set; }
    }
}
