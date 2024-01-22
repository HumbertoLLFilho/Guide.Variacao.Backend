using Guide.Variacao.Core.DataBase.Repository;
using Guide.Variacao.Infra.Context;

namespace Guide.Variacao.Domain.Services
{
    public class BaseRepository<T> : Repository<T> where T : class
    {
        public BaseRepository(GuideVariacaoContext _context) : base(_context)
        {
        }
    }
}
