using Club_Management_System.Data;
using Club_Management_System.DTOs;
using Club_Management_System.Models;
using Club_Management_System.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Repos.Implementation
{
    public class PaymentCustomRepo : GenericRepo<Payment>, IPayment
    {
        private readonly My_AppContext _context;
        public PaymentCustomRepo(My_AppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaymentDTO> GetPaymentWithStaticsAsync()
        {
            return new PaymentDTO
            {
                SumAmount = await _context.Payments.SumAsync(x => x.Amount),
                AvgAmount = await _context.Payments.AverageAsync(x => x.Amount),
                MaxAmount = await _context.Payments.MaxAsync(x => x.Amount),
                MinAmount = await _context.Payments.MinAsync(x => x.Amount),
            };
        }
    }
}
