using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace KolokwiumDF.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly S25007Context _context;

        public PaymentRepository(S25007Context context)
        {
            _context = context;
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<Payment?> GetExistingPaymentAsync(int idClient, int idSubscription, DateTime startDate, DateTime endDate)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.IdClient == idClient && p.IdSubscription == idSubscription && p.Date >= startDate && p.Date < endDate);
        }
    }
}
