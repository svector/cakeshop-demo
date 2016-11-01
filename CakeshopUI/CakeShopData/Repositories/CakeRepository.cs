using System.Collections.Generic;
using CakeShopData.Model;
using NHibernate;
using NHibernate.Linq;

namespace CakeShopData
{
    public class CakeRepository : ICakeRepository
    {
        private readonly ISession _session;

        public CakeRepository(ISession session)
        {
            _session = session;
        }
        public IEnumerable<Cake> GetCakes()
        {
            return _session.Query<Cake>();
        }
    }
}