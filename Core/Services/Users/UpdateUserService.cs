using BusinessEntities;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateProductService : IUpdateProductService
    {
        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            List<string> missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(email)) missingFields.Add(nameof(email));
            if (string.IsNullOrWhiteSpace(name)) missingFields.Add(nameof(name));
            if (missingFields.Count > 0)
            {
                throw new ArgumentNullException(string.Join(",", missingFields) + " was not provided");
            }
            decimal annualSalaryValue = 0.0m;
            if (annualSalary != null)
            {
                annualSalaryValue = annualSalary.Value;
            }
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type);
            user.SetMonthlySalary(annualSalaryValue / 12);
            user.SetTags(tags);
        }
    }
}