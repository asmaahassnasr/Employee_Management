using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employees_Management.Utilities
{
    public class ValidEmailDomainAttribute:ValidationAttribute
    {
        private readonly string allowDomain;

        public ValidEmailDomainAttribute(string allowDomain)
        {
            this.allowDomain = allowDomain;
        }

        public override bool IsValid(object value)
        {
            string[] parts = value.ToString().Split('@');
            return parts[1].ToUpper() == this.allowDomain.ToUpper();
        }

    }
}
