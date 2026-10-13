using Club_Management_System.Data;
using Club_Management_System.Repos.Interfaces;

namespace Club_Management_System.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly My_AppContext _context;

        public UnitOfWork(My_AppContext context, IAuthRepo authRepoCustomRepo, IBooking bookingCustomRepo, IPayment paymentCustomRepo, IMember memberCustomRepo, IMemberShip memberShipCustomRepo, IFacility facilityCustomRepo)
        {
            _context = context;
            AuthRepoCustomRepo = authRepoCustomRepo;
            BookingCustomRepo = bookingCustomRepo;
            PaymentCustomRepo = paymentCustomRepo;
            MemberCustomRepo = memberCustomRepo;
            MemberShipCustomRepo = memberShipCustomRepo;
            FacilityCustomRepo = facilityCustomRepo;
        }

        public IAuthRepo AuthRepoCustomRepo { get; }
        public IBooking BookingCustomRepo { get; }

        public IPayment PaymentCustomRepo { get; }

        public IMember MemberCustomRepo { get; }

        public IMemberShip MemberShipCustomRepo { get; }

        public IFacility FacilityCustomRepo { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
