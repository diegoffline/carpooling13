using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarpoolingModel
{
    public enum RouteType
    {
        /// <summary>
        /// firm route for one client
        /// </summary>
        firmRoute = 0,
        /// <summary>
        /// dynamic routes that occur ones or few times
        /// </summary>
        variableRoute = 1,
    }
}
