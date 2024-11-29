using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieTicket.Application.DataTransferObjs.CinemaCenter;
using MovieTicket.Application.DataTransferObjs.Coupon;
using MovieTicket.Application.DataTransferObjs.Coupon.Requests;
using MovieTicket.Application.Interfaces.Repositories.ReadOnly;
using MovieTicket.Application.Interfaces.Repositories.ReadWrite;
using MovieTicket.Application.ValueObjs.Paginations;
using MovieTicket.Infrastructure.Extensions;

namespace MovieTicket.API.Controllers
{
    [Route(DefaultValue.API_Route.DEFAULT_CONTROLLER_ROUTE)]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponReadOnlyRepository _couponReadOnlyRepository;
        private readonly ICouponReadWriteRepository _couponReadWriteRepository;

        public CouponController(ICouponReadOnlyRepository couponReadOnlyRepository, ICouponReadWriteRepository couponReadWriteRepository)
        {
            _couponReadOnlyRepository = couponReadOnlyRepository;
            _couponReadWriteRepository = couponReadWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? couponCode, [FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] PagingParameters pagingParameters, CancellationToken cancellationToken)
        {
            var result = await _couponReadOnlyRepository.GetAllAsync(couponCode, startDate, endDate, pagingParameters, cancellationToken);
            return Ok(new PageList<CouponDto>(result.Item.ToList(), result.MetaData.TotalCount,
                result.MetaData.CurrentPage,
                result.MetaData.PageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponRequest createCouponRequest, CancellationToken cancellationToken)
        {
            var result = await _couponReadWriteRepository.CreateAsync(createCouponRequest, cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponRequest updateCouponRequest, CancellationToken cancellationToken)
        {
            var result = await _couponReadWriteRepository.UpdateAsync(updateCouponRequest, cancellationToken);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid couponId, CancellationToken cancellationToken)
        {
            var result = await _couponReadWriteRepository.DeleteAsync(couponId, cancellationToken);
            return Ok(result);
        }
    }
}