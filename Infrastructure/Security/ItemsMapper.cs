using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public static class ItemsMapper
    {
        public static List<RegisterDto> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<RegisterDto>();
            foreach (var value in values)
            {
                RegisterDto item = new()
                {
                    FirstAndLastName = value[0].ToString(),
                    Email = value[1].ToString(),
                    EnglishLevel = value[2].ToString(),
                    ExpectedSalary = value[3].ToString(),
                    FieldOfInterest = value[4].ToString(),
                    PhoneNumber = value[5].ToString(),
                    TotalBudget = value[6].ToString()
                };
                items.Add(item);
            }
            return items;
        }
        public static IList<IList<object>> MapToRangeData(RegisterDto item)
        {
            var objectList = new List<object>() 
            {
                item.FirstAndLastName, 
                item.Email,
                item.EnglishLevel, 
                item.ExpectedSalary,
                item.FieldOfInterest,
                item.PhoneNumber,
                item.TotalBudget 
            };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}
