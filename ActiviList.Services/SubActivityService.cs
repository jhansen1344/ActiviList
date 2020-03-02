using ActiviList.Data;
using ActiviList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviList.Services
{
    public class SubActivityService
    {
        private readonly Guid _userId;

        public SubActivityService(Guid userId)
        {
            _userId = userId;
        }

        public bool Create(SubActivityCreate model)
        {
            var entity =
                new SubActivity()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Nombre = model.Nombre,
                    Items = model.Items,
                };
            using(var ctx=new ApplicationDbContext())
            {
                ctx.SubActivities.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
