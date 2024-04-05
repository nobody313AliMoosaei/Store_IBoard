using Store_IBoard.BL.DTO.INPUT.Admin;
using Store_IBoard.BL.Services.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.ApplicationBusiness.Admin
{
    public interface IAdminService
    {
        #region Production Management
        // Category
        Task<ErrorsVM> AddNewCategory(string CategoryName);
        Task<ErrorsVM> UpdateCategory(long Id, string NewName);
        Task<ErrorsVM> DeleteCategory(long Id);

        // GroupGoods
        Task<ErrorsVM> AddNewGroupGoods(AddNewGroupGoodsDTO NewGG);
        Task<ErrorsVM> UpdateGroupGoods(long Id, AddNewGroupGoodsDTO GGData);
        Task<ErrorsVM> DeleteGroupGoods(long Id);

        // Goods
        Task<ErrorsVM> AddNewGoods(AddNewGoodsDTO NewGood);
        Task<ErrorsVM> UpdateGoods(long Id, AddNewGoodsDTO NewGood);
        Task<ErrorsVM> DeleteGoods(long Id);
        #endregion
    }



}
