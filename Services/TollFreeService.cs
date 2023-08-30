using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TollFee.Api.Models;

namespace TollFee.Api.Services
{
    public static class TollFreeService
    {
		public static IEnumerable<DateTime> RemoveFree(DateTime[] passages)
        {
            foreach (var p in passages)
            {
                if (p.DayOfWeek != DayOfWeek.Saturday && p.DayOfWeek != DayOfWeek.Sunday && !IsInOtherFreeDays(p.Date) && p.Month != 7)
                    yield return p;
            }
        }

		public static bool IsInOtherFreeDays(DateTime date)
        {
            using (var context = new TollDBContext())
            {
				var item = context.TollFrees.FirstOrDefault(f => f.Date == date);

                if (item != null)
                {
                    return true;
                }

                return false;
			}
        }
    }
}
