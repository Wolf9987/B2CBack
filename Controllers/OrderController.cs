using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bit2C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;
        private readonly UserManager<AppUser> _userManager;
        public OrderController(AppDBContext appDBContext, UserManager<AppUser> userManager)
        {
            this._appDBContext = appDBContext;
            this._userManager = userManager;
        }
        
        // POST api/<OrderController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("Orders")]
        public async Task<Object> Orders([FromBody] GetOrdersBindingModel model)
        {
            try
            {
                var orders = _appDBContext.UserOrders.Where(o => o.Email == model.Email)
                .Select(x => new UserOrderDTO(x.Amount, x.Price, x.BuySell)).ToList();
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "", orders));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
            
        }

        //POST api/<OrderController>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("CreateOrder")]
        public async Task<Object> CreateOrder([FromBody] OrderBindingModel model)
        {
            try
            {

                UserOrder userOrder = new UserOrder()
                {
                    Email = model.Email,
                    Amount = model.Amount,
                    Price = model.Price,
                    BuySell = model.BuySell,

                };
                var tempUser = _userManager.FindByEmailAsync(model.Email.ToUpper());
                if (tempUser == null)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Email not found", null));
                }
                _appDBContext.UserOrders.Add(userOrder);
                var res = await _appDBContext.SaveChangesAsync();
                if (res > 0)
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Added Successfully", null));
                }
                return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Failed to create order", null));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(new ResponseModel(ResponseCode.Error, ex.Message, null));
            }
            
            
        }

    }
}
