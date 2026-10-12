using AutoMapper;
using Club_Management_System.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Club_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("statits")]
        public async Task<IActionResult> GetStatists()
        {
            var res = await _unitOfWork.PaymentCustomRepo.GetPaymentWithStaticsAsync();
            return Ok(res);
        }
    }
}
