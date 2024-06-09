using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KolokwiumDF.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly S25007Context _context;

        public ClientRepository(S25007Context context)
        {
            _context = context;
        }

        public async Task<Client?> GetClientAsync(int idClient)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(c => c.IdClient == idClient);
        }

        public async Task<Client?> GetClientWithSubscriptionsAsync(int idClient)
        {
            return await _context.Clients
                .Include(c => c.Sales)
                .ThenInclude(s => s.IdSubscriptionNavigation)
                .FirstOrDefaultAsync(c => c.IdClient == idClient);
        }

        public async Task<int?> GetClientDiscountAsync(int idClient)
        {
            return await _context.Discounts
                .Where(d => d.IdClient == idClient && d.DateTo >= DateTime.Now)
                .SumAsync(d => (int?)d.Value) ?? 0;
        }
    }
}
