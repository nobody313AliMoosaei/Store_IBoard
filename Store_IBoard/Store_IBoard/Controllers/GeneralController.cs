using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store_IBoard.BL.Services.General;

namespace Store_IBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController : ControllerBase
    {
        private IGeneralService _generalService;
        public GeneralController(IGeneralService generalService)
        {
            _generalService = generalService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> FindCategory(string CategoryName)
        => Ok(await _generalService.FindCategory(CategoryName));

        [HttpGet("[action]")]
        public async Task<IActionResult> FindGoods(string GoodName)
            => Ok(await _generalService.FindGoods(GoodName));

        [HttpGet("[action]")]
        public async Task<IActionResult> FindGroupGood(string GroupGoodName)
            => Ok(await _generalService.FindGroupGood(GroupGoodName));

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategory()
            => Ok(await _generalService.GetAllCategory());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategoryGoods()
            => Ok(await _generalService.GetAllCategoryGoods());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategoryGroupGoods()
            => Ok(await _generalService.GetAllCategoryGroupGoods());

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllGoods(int PageNumber,int PageSize)
            => Ok(await _generalService.GetAllGoods(PageNumber,PageSize));
    }
}
