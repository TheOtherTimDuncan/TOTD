using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TOTD.Mvc
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute()
            : base()
        {
        }

        public AuthorizeRolesAttribute(params string[] roles)
        {
            this.Roles = string.Join(",", roles);
        }
    }
}
