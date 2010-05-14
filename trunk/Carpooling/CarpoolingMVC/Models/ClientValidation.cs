using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using CarpoolingModel;

namespace CarpoolingMVC.Models {
    public class ClientValidation: Client{
        public bool IsValid {
            get { return (GetRuleViolations().Count() == 0); }
        }
        public ClientValidation() : base() { }

        public IEnumerable<RuleViolation> GetRuleViolations() {
            //if (String.IsNullOrEmpty(Age))
            //    yield return new RuleViolation("Title required", "Title");

            //if (String.IsNullOrEmpty(Consumption))
            //    yield return new RuleViolation("Description required", "Description");

            //if (String.IsNullOrEmpty(HostedBy))
            //    yield return new RuleViolation("HostedBy required", "HostedBy");

            //if (String.IsNullOrEmpty(Address))
            //    yield return new RuleViolation("Address required", "Address");

            //if (String.IsNullOrEmpty(Country))
            //    yield return new RuleViolation("Country required", "Country");

            //if (String.IsNullOrEmpty(ContactPhone))
            //    yield return new RuleViolation("Phone# required", "ContactPhone");

            //if (!PhoneValidator.IsValidNumber(ContactPhone, Country))
            //    yield return new RuleViolation("Phone# does not match country", "ContactPhone");

            yield break;
        }
    }
}
