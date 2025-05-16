using Project.DataAccessLayer.ContextClasses;
using Project.DataAccessLayer.Repositories.Abstracts;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccessLayer.Repositories.Concretes
{
    public class AppRoleRepository : BaseRepository<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(MyContext db) : base(db)
        {
        }
    }
}
