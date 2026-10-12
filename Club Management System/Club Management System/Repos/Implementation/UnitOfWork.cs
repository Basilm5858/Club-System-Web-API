using Club_Management_System.Data;
using Club_Management_System.Repos.Interfaces;

namespace Club_Management_System.Repos.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly My_AppContext _context;

        public UnitOfWork(My_AppContext context, AuthRepoCustomRepo authRepoCustomRepo,BookingCustomRepo bookingCustomRepo, PaymentCustomRepo paymentCustomRepo, MemberCustomRepo memberCustomRepo, MemberShipCustomRepo memberShipCustomRepo, FacilityCustomRepo facilityCustomRepo)
        {
            _context = context;
            BookingCustomRepo = bookingCustomRepo;
            PaymentCustomRepo = paymentCustomRepo;
            MemberCustomRepo = memberCustomRepo;
            MemberShipCustomRepo = memberShipCustomRepo;
            FacilityCustomRepo = facilityCustomRepo;
            AuthRepoCustomRepo = authRepoCustomRepo;
        }
        public AuthRepoCustomRepo AuthRepoCustomRepo { get; }
        public BookingCustomRepo BookingCustomRepo { get; }

        public PaymentCustomRepo PaymentCustomRepo { get; }

        public MemberCustomRepo MemberCustomRepo { get; }

        public MemberShipCustomRepo MemberShipCustomRepo { get; }

        public FacilityCustomRepo FacilityCustomRepo { get; }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
