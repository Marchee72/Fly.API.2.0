using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class RolesAttribute : AuthorizeAttribute
    {
        public RolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}
