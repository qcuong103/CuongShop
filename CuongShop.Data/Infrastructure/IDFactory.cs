using System;

namespace CuongShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        CuongShopDbContext Init();
    }
}