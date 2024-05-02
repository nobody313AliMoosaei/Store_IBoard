using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_IBoard.BL.DTO.INPUT.Admin;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Administrator")]
    public class AdministratorController : ControllerBase
    {
        private BL.ApplicationBusiness.Admin.IAdminService _adminService;
        public AdministratorController(BL.ApplicationBusiness.Admin.IAdminService adminservice)
        {
            _adminService = adminservice;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory([FromBody] string CategoryName)
        {
            var result = await _adminService.AddNewCategory(CategoryName);
            return Ok(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCategory(long Id, string NewName)
        {
            var Result = await _adminService.UpdateCategory(Id, NewName);
            return Ok(Result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult>DeleteCategory(long id)
        {
            var Result = await _adminService.DeleteCategory(id);
            return Ok(Result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddGroupGood([FromBody] BL.DTO.INPUT.Admin.AddNewGroupGoodsDTO GroupGood)
        {
            var result = await _adminService.AddNewGroupGoods(GroupGood);
            return Ok(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGroupGood(long Id,[FromBody] BL.DTO.INPUT.Admin.AddNewGroupGoodsDTO GroupGood)
        {
            var result = await _adminService.UpdateGroupGoods(Id, GroupGood);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGroupGood(long Id)
        {
            var result = await _adminService.DeleteGroupGoods(Id);
            return Ok(result);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddGood([FromBody] AddNewGoodsDTO Good)
        {
            var result = await _adminService.AddNewGoods(Good);
            return Ok(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateGood(long Id, AddNewGoodsDTO good)
        {
            var result = await _adminService.UpdateGoods(Id, good);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteGood(long Id)
        {
            var result = await _adminService.DeleteGoods(Id);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStatusOrder(long id, int status)
        {
            var result = await _adminService.UpdateStatusOrder(id, status);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrders(int PageNumber,int PageSize)
        {
            var result = await _adminService.GetOrders(PageNumber, PageSize);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SearchOrders([FromBody] SearchOrders SO)
        {
            var result = await _adminService.SearchOrders(SO);
            return Ok(result);
        }
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOrder(long Id)
        {
            var result = await _adminService.DeleteOrder(Id);
            return Ok(result);
        }

    }
}
