using ActiviList.Models;
using ActiviList.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ActiviList.WebAPI.Controllers
{
    [Authorize]
    public class ItemController : ApiController
    {
        public IHttpActionResult Get()
        {
            ItemService itemService = CreateItemService();
            var items = itemService.GetItems();
            return Ok(items);
        }

        public IHttpActionResult Post(ItemCreate item)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateItemService();
            if (!service.CreateItem(item))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            ItemService itemService = CreateItemService();
            var itemDetail = itemService.GetItemById(id);
            return Ok(itemDetail);
        }

        public IHttpActionResult Put(ItemUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ItemService itemService = CreateItemService();
            if (!itemService.UpdateItem(model))
                return InternalServerError();
            return Ok();

        }
        private ItemService CreateItemService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var itemService = new ItemService(userId);
            return itemService;
        }
    }
}
