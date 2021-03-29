using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolateAPI.Entities;

namespace HotChocolateAPI
{
    public class HotChocolateSeeder
    {
        private readonly HotChocolateDbContext _dbContext;
        public HotChocolateSeeder(HotChocolateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name="Customer"
                },
                new Role()
                {
                    Name="Warehouseman"
                },
                new Role()
                {
                    Name="Admin"
                }
            };
            return roles;
        }
    }
}
