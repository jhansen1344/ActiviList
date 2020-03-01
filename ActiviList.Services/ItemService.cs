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

        public bool CreateItem (ItemCreate model)
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
            using (var ctx = new ApplicationDbContext)
            {
                var query =
                    ctx
                        .Items
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                        e =>
                            new ItemListItem
                            {
                                Name = e.Name,
                                Nombre = e.Nombre,
                                Location = e.Location
                            }
                        );
                return query.ToList();
            }
        }
    }

}
