using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace Misi.MVC.Filters
{
    public class RequiredIfInRolesAttribute : RequiredAttribute
    {
        private readonly ICollection<string> _allowedRoles;

        public RequiredIfInRolesAttribute(params string[] allowedRoles)
        {
            _allowedRoles = allowedRoles;
        }

        public override bool IsValid(object value)
        {
            return _allowedRoles.Any(e =>
                HttpContext.Current.User.IsInRole(e));
        }
    }
}