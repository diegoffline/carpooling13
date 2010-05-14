using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CarpoolingModel.Repository;

namespace CarpoolingMVC.Controllers
{
    public class ClientController : Controller
    {
        ClientRepository cr = ClientRepository.getInstanca();
        //
        // GET: /Client/

        public void Index() {
            var client = cr.getAllClients();
        }

        //
        // HTTP-GET: /Dinners/Details/2

        public void Details(int id) {
            Response.Write("<h1>Details DinnerID: " + id + "</h1>");
        }

    }
}
