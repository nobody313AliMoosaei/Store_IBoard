using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.General
{
    public interface IGeneralService
    {
        Task<object> GetAllCategoryGoods();
        Task<object> GetAllCategory();
        Task<object> GetAllCategoryGroupGoods();
        Task<object> GetAllGoods(int PageNumber, int PageSize);
        Task<object> FindGoods(string GoodName);
        Task<object> FindCategory(string CategoryName);
        Task<object> FindGroupGood(string GroupGoodName);
    }
}
