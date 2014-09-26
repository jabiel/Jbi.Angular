using Jbi.Angular.Core;
using Jbi.Angular.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Jbi.Angular.Api.Controllers
{
    [RoutePrefix("api/Orders")]
    public class OrdersController : ApiController
    {
        static List<Order> OrderList { get; set; }

        public OrdersController()
        {
            if (OrderList == null)
            {
                OrderList = Order.CreateOrders();
            }
        }


        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            var Name = ClaimsPrincipal.Current.Identity.Name;
            var Name1 = User.Identity.Name;

            //var userName = principal.Claims.Where(c => c.Type == "sub").Single().Value;
            
            var orders = OrderList; // Order.CreateOrders();
            /*
            orders.Add(new Order() { 
               CustomerName = Name,
               ShipperCity = Name1,
               IsShipped = true,
               OrderID = 666
            });
             * */
            return Ok(orders);
        }

        [Route("api/Orders/getusers")]
        public IHttpActionResult GetUsers()
        {
            var ctx = new AuthContext();
            return Ok(ctx.RefreshTokens.ToList());
            
        }


        public IHttpActionResult Delete(int id)
        {
            //apps.Delete(id);
            OrderList.Remove(OrderList.FirstOrDefault(p=>p.OrderID == id));
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Post(Order model)
        {
            OrderList.Add(model);
            return Ok();
        }

        public IHttpActionResult Put(Order model)
        {
            var ent = OrderList.FirstOrDefault(p=>p.OrderID == model.OrderID);
            ent.CustomerName = model.CustomerName;
            return Ok();
        }

    }


    #region Helpers

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }


        public static List<Order> CreateOrders()
        {
            List<Order> OrderList = new List<Order> 
            {
                new Order {OrderID = 10248, CustomerName = "Taiseer Joudeh", ShipperCity = "Amman", IsShipped = true },
                new Order {OrderID = 10249, CustomerName = "Ahmad Hasan", ShipperCity = "Dubai", IsShipped = false},
                new Order {OrderID = 10250,CustomerName = "Tamer Yaser", ShipperCity = "Jeddah", IsShipped = false },
                new Order {OrderID = 10251,CustomerName = "Lina Majed", ShipperCity = "Abu Dhabi", IsShipped = false},
                new Order {OrderID = 10252,CustomerName = "Yasmeen Rami", ShipperCity = "Kuwait", IsShipped = true}
            };

            return OrderList;
        }
    }

    #endregion
}
