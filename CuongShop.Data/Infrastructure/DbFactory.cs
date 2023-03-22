using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuongShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private CuongShopDbContext dbContext;

        public CuongShopDbContext Init()
        {
            return dbContext ?? (dbContext = new CuongShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
