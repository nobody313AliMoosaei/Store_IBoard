using Microsoft.EntityFrameworkCore;
using Store_IBoard.BL.DTO.INPUT.Admin;
using Store_IBoard.BL.Services.Public;
using Store_IBoard.DL.ApplicationDbContext;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.ApplicationBusiness.Admin
{
    public class AdminService : IAdminService
    {
        private ApplicationDBContext _context;
        public AdminService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<ErrorsVM> AddNewCategory(string CategoryName)
        {
            var res = new ErrorsVM();
            try
            {
                if (await _context.Categories.Where(e => e.CategoryName == CategoryName).AnyAsync())
                    res.Message = "دسته بندی با این اسم وجود دارد";
                else
                {
                    _context.Categories.Add(new DL.Entities.Category
                    {
                        CategoryName = CategoryName
                    });
                    await _context.SaveChangesAsync();
                    res.Message = "دسته بندی با موفقیت ثبت شد";
                    res.IsValid = true;
                }
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> AddNewGoods(AddNewGoodsDTO NewGood)
        {
            var res = new ErrorsVM();
            try
            {
                if (await _context.Goods.Where(e => e.GoodName == NewGood.GoodName && e.GoodCode == NewGood.GoodCode).AnyAsync())
                    res.Message = "چنین کالایی وجود دارد";
                else
                {
                    var GroupGood = await _context.GroupGoods.Where(e => e.Id == NewGood.GGRef).FirstOrDefaultAsync();
                    if (GroupGood is not null)
                    {
                        var good = new Good
                        {
                            GoodCode = NewGood.GoodCode,
                            GoodName = NewGood.GoodName,
                            GoodPrice = NewGood.GoodPrice,
                            GoodDescription = NewGood.GoodDsr,
                            GroupGoodRef = GroupGood.Id,
                            GroupGoodRefNavigation = GroupGood,
                        };
                        _context.Goods.Add(good);
                        await _context.SaveChangesAsync();
                        if (NewGood.ColorsRef.Any())
                        {
                            var Colors = await _context.BasColors.Where(e => NewGood.ColorsRef.Contains(e.Id)).ToListAsync();
                            if (Colors.Any())
                            {
                                good = await _context.Goods.FirstOrDefaultAsync(e => e.GoodCode == NewGood.GoodCode);
                                var lstGoodColor = new List<GoodsColor>();
                                foreach (var color in Colors)
                                {
                                    lstGoodColor.Add(new GoodsColor
                                    {
                                        ColorRef = color.Id,
                                        GoodRef = good.Id,
                                        ColorRefNavigation = color,
                                        GoodRefNavigation = good
                                    });
                                }

                                _context.GoodsColors.AddRange(lstGoodColor);
                                await _context.SaveChangesAsync();
                            }
                        }
                        res.Message = "کالا اضافه شده است";
                        res.IsValid = true;
                    }
                    else
                        res.Message = "گروه بندی کالا وجود ندارد";
                }
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> AddNewGroupGoods(AddNewGroupGoodsDTO NewGG)
        {
            var res = new ErrorsVM();
            try
            {
                var Category = await _context.Categories.Where(e => e.Id == NewGG.CategoryRef).FirstOrDefaultAsync();
                if (Category is not null)
                {
                    _context.GroupGoods.Add(new GroupGood
                    {
                        CategoryRef = Category.Id,
                        CategoryRefNavigation = Category,
                        GroupName = NewGG.GGname
                    });
                    await _context.SaveChangesAsync();
                    res.Message = " گروه بندی اضافه شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "دسته بندی یافت نشد";

            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;

        }

        public async Task<ErrorsVM> DeleteCategory(long Id)
        {
            var res = new ErrorsVM();
            try
            {
                var Category = await _context.Categories.FirstOrDefaultAsync(e => e.Id == Id);
                if (Category is not null)
                {
                    _context.Categories.Remove(Category);
                    await _context.SaveChangesAsync();
                    res.Message = "دسته بندی حذف شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "دسته بندی یافت نشد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> DeleteGoods(long Id)
        {
            var res = new ErrorsVM();
            try
            {
                var good = await _context.Goods.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (good is not null)
                {
                    _context.Goods.Remove(good);
                    await _context.SaveChangesAsync();
                    res.Message = "کالا حذف شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "کالا وجود ندارد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> DeleteGroupGoods(long Id)
        {
            var res = new ErrorsVM();
            try
            {
                var gg = await _context.GroupGoods.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (gg is not null)
                {
                    _context.GroupGoods.Remove(gg);
                    await _context.SaveChangesAsync();
                    res.Message = "گروه دسته بندی حذف شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "گروه دسته بندی وجود ندارد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> UpdateCategory(long Id, string NewName)
        {
            var res = new ErrorsVM();
            try
            {
                var category = await _context.Categories.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (category is not null)
                {
                    category.CategoryName = NewName.IsNullOrEmpty() ? category.CategoryName : NewName;
                    _context.Categories.Update(category);
                    await _context.SaveChangesAsync();
                    res.Message = "دسته بندی بروزرسانی شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "دسته بندی یافت نشد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> UpdateGoods(long Id, AddNewGoodsDTO NewGood)
        {
            var res = new ErrorsVM();
            try
            {
                var good = await _context.Goods.Where(e => e.Id == Id).FirstOrDefaultAsync();
                if (good is not null)
                {
                    good.GoodName = NewGood.GoodName.IsNullOrEmpty() ? good.GoodName : NewGood.GoodName;
                    good.GoodCode = NewGood.GoodCode.IsNullOrEmpty() ? good.GoodCode : NewGood.GoodCode;
                    good.GoodDescription = NewGood.GoodDsr.IsNullOrEmpty() ? good.GoodDescription : NewGood.GoodDsr;
                    good.GoodPrice = NewGood.GoodPrice <= 0 ? good.GoodPrice : NewGood.GoodPrice;
                    _context.Goods.Update(good);
                    await _context.SaveChangesAsync();
                    res.Message = "کالا بروزرسانی شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "کالا یافت نشد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }

        public async Task<ErrorsVM> UpdateGroupGoods(long Id, AddNewGroupGoodsDTO GGData)
        {
            var res = new ErrorsVM();
            try
            {
                var gg = await _context.GroupGoods.Where(e=>e.Id==Id).FirstOrDefaultAsync();
                if (gg is not null)
                {
                    gg.GroupName = GGData.GGname.IsNullOrEmpty() ? gg.GroupName : GGData.GGname;
                    var category = await _context.Categories.Where(e=>e.Id == GGData.CategoryRef).FirstOrDefaultAsync();
                    if(category is not null)
                    {
                        gg.CategoryRefNavigation = category;
                        gg.CategoryRef = category.Id;
                    }
                    _context.GroupGoods.Update(gg);
                    await _context.SaveChangesAsync();
                    res.Message = "گروه دسته بندی بروزرسانی شد";
                    res.IsValid = true;
                }
                else
                    res.Message = "گروه دسته بندی یافت نشد";
            }
            catch (Exception ex)
            {
                res.ExceptionError(ex);
            }
            return res;
        }
    }
}
