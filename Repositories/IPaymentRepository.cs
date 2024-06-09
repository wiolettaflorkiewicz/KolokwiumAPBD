using KolokwiumDF.Models;
using System.Threading.Tasks;

namespace KolokwiumDF.Repositories
{
    public interface IPaymentRepository
    {
        Task AddPaymentAsync(Payment payment);
        Task<Payment?> GetExistingPaymentAsync(int idClient, int idSubscription, DateTime startDate, DateTime endDate);
    }
}
