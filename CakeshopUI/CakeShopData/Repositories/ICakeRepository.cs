using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShopData.Model;

namespace CakeShopData
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> GetCakes();
    }
}
