using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TollFee.Api.Models;

namespace TollFee.Api.Services
{
    public static class TollFeeService
    {
		public static decimal CalculateFee(DateTime[] passages)
        {
			var notFree = TollFreeService.RemoveFree(passages);
			var totalFee = GetFee(notFree);

            return totalFee;
		}

		public static decimal GetFee(IEnumerable<DateTime> passages)
        {
			decimal totalFee = 0;

            using (var context = new TollDBContext())
            {
                foreach (var p in passages)
                {
                    var fee = context.Fees.FirstOrDefault(f => f.Year == p.Year && p.TimeOfDay.TotalMinutes >= f.FromMinute && p.TimeOfDay.TotalMinutes <= f.ToMinute);

                    if (fee == null)
                    {
                        throw new Exception($"Fee not found for time = [{p}]");
                    } 
                    else
                    {
                        totalFee += fee.Price;
					}
                }
            }

			var actualFee = GetActualFee(totalFee);
			return actualFee;
		}

		public static decimal GetActualFee(decimal totalFee)
        {
            if (totalFee > 60)
            {
                return 60;
            }
            else
            {
                return totalFee;
            }
        }
    }
}
