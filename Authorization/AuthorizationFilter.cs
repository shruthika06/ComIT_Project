using Online_Shopping.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Online_Shopping.Authorization
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
    }
}