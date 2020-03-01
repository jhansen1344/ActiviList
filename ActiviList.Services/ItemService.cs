using ActiviList.Data;
using ActiviList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviList.Services
{
    public class ItemService
    {
        private readonly Guid _userId;

        public ItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateItem(ItemCreate model)
        {
            var entity =
                new Item()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Nombre = model.Nombre,
                    Location = model.Location
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Items.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ItemListItem> GetItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Items
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new ItemListItem
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Nombre = e.Nombre,
                                Location = e.Location
                            }
                        );
                return query.ToList();
            }
        }

        public ItemDetail GetItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.OwnerId == _userId && e.Id == id);
                return
                    new ItemDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Nombre = entity.Nombre,
                        Location = entity.Location,
                    };
            }
        }

        public bool UpdateItem(ItemUpdate model)
        {
            using(var ctx=new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Items
                    .Single(e => e.OwnerId == _userId && e.Id == model.Id);
                entity.Name = model.Name;
                entity.Nombre = model.Nombre;
                entity.Location = model.Location;

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
