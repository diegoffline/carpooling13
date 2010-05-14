using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CarpoolingModel;

namespace CarpoolingMVC.Models {
    public class ResourceValidation: Resource {
        
        public bool IsValid {
            get { return (GetRuleViolations().Count() == 0); }
        }
        public ResourceValidation() : base() { }

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
    public class RuleViolation {

        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage, string propertyName) {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
