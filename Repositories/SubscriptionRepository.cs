using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace KolokwiumDF.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly S25007Context _context;

        public SubscriptionRepository(S25007Context context)
        {
            _context = context;
        }

        public async Task<Subscription?> GetSubscriptionAsync(int idSubscription)
        {
            return await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.IdSubscription == idSubscription);
        }

        public async Task<Sale?> GetLatestSaleAsync(int idClient, int idSubscription)
        {
            return await _context.Sales
                .Where(s => s.IdClient == idClient && s.IdSubscription == idSubscription)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefaultAsync();
        }
    }
}
