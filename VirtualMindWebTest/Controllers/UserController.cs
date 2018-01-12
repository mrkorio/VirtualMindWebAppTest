using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualMindWebTest.VirtualMindService;

namespace VirtualMindWebTest.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            VirtualMindServiceClient client = new VirtualMindServiceClient();

            Money dolar = client.Cotizacion("Dolar").item;
            ViewBag.DolarVenta = dolar.valueToSell;
            ViewBag.DolarCompra = dolar.valueToBuy;
            ViewBag.DolarActualizacion = dolar.lastUpdate;

            ReturnOfUserVNIoeB4G users =  client.Usuarios();


            return View(users.list);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(VirtualMindService.User newUser)
        {
            try
            {
                VirtualMindServiceClient client = new VirtualMindServiceClient();

                client.InsertUser(newUser);
               

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            VirtualMindServiceClient client = new VirtualMindServiceClient();

            var model = client.GetUserById(id);
           
            return View( model.item );
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                VirtualMindServiceClient client = new VirtualMindServiceClient();
                client.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                VirtualMindServiceClient client = new VirtualMindServiceClient();

                client.DeleteUser(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
