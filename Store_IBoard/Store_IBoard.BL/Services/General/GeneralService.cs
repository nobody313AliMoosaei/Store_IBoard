using Microsoft.EntityFrameworkCore;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.General
{
    public class GeneralService : IGeneralService
    {
        private DL.ApplicationDbContext.ApplicationDBContext _context;
        private RepositoryGeneric<Category> _categoryRepo;
        public GeneralService(DL.ApplicationDbContext.ApplicationDBContext context,
            RepositoryGeneric<Category> categoryRepo)
        {
            _context = context;
            _categoryRepo = categoryRepo;
        }


        public async Task<object> FindCategory(string CategoryName)
        {
            try
            {
                return await _categoryRepo.Entity
                        .Where(e => e.CategoryName.Contains(CategoryName))
                        .Select(e => new
                        {
                            e.Id,
                            e.CategoryName
                        }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<object> FindGoods(string GoodName)
        {
            try
            {

                return await _context.Goods
                    .Where(e => e.GoodName.Contains(GoodName))
                    .Select(e => new
                    {
                        e.Id,
                        e.GoodName,
                        e.GoodDescription,
                        e.GroupGoodRef,
                        e.GoodPrice
                    }).ToListAsync();

            }
            catch
            {
                return null;
            }
        }

        public async Task<object> FindGroupGood(string GroupGoodName)
        {
            try
            {
                return await _context.GroupGoods
                    .Where(e => e.GroupName.Contains(GroupGoodName))
                    .Select(e => new
                    {
                        e.Id,
                        e.GroupName,
                        e.CategoryRef
                    }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<object> GetAllCategory()
        {
            try
            {
                return await _categoryRepo.Entity
                    .Select(e => new
                    {
                        e.Id,
                        e.CategoryName
                    }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<object> GetAllCategoryGoods()
        {
            try
            {
                return await _categoryRepo.Entity
                    .Include(e => e.GroupGoods)
                    .ThenInclude(e => e.Goods)
                    .ThenInclude(e => e.GoodsColors)
                    .ThenInclude(e => e.ColorRefNavigation)

                    .Select(e => new
                    {
                        e.Id,
                        e.CategoryName,
                        GroupGoods =
                        e.GroupGoods.Select(r => new
                        {
                            r.Id,
                            r.GroupName,
                            r.CategoryRef,
                            Goods =
                            r.Goods.Select(t => new
                            {
                                t.Id,
                                t.GoodName,
                                t.GoodDescription,
                                t.GoodPrice,
                                t.GroupGoodRef,
                                GoodsColors =
                                t.GoodsColors.Select(q => new
                                {
                                    GoodsColorsId = q.Id,
                                    q.GoodRef,
                                    q.ColorRef,
                                    ColorId = (q.ColorRefNavigation == null) ? 0 : q.ColorRefNavigation.Id,
                                    ColorName = (q.ColorRefNavigation == null) ? "" : q.ColorRefNavigation.PersianColorName,
                                    ColorHexCode = (q.ColorRefNavigation == null) ? "" : q.ColorRefNavigation.HexCode
                                }).ToList()
                            }).ToList()
                        }).ToList()
                    }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<object> GetAllCategoryGroupGoods()
        {
            try
            {
                return await _categoryRepo.Entity
                    .Include(e => e.GroupGoods)
                    .Select(e => new
                    {
                        e.Id,
                        e.CategoryName,
                        GroupGoods =
                        e.GroupGoods.Select(r => new
                        {
                            r.Id,
                            r.GroupName,
                        }).ToList()
                    }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<object> GetAllGoods(int PageNumber, int PageSize)
        {
            try
            {
                return await _context.Goods
                    .Include(e => e.GoodsColors)
                    .ThenInclude(e => e.ColorRefNavigation)
                    .Skip((PageNumber - 1) * PageSize)
                    .Take(PageSize)
                    .Select(e => new
                    {
                        e.Id,
                        e.GoodName,
                        e.GoodDescription,
                        e.GoodPrice,
                        e.GroupGoodRef,
                        Colors =
                        e.GoodsColors.Select(r => new
                        {
                            ColorId = (r.ColorRefNavigation == null) ? 0 : r.ColorRefNavigation.Id,
                            ColorName = (r.ColorRefNavigation == null) ? "" : r.ColorRefNavigation.PersianColorName,
                            ColorHexCode = (r.ColorRefNavigation == null) ? "" : r.ColorRefNavigation.HexCode
                        }).ToList()
                    }).ToListAsync();
            }
            catch
            {
                return null;
            }
        }
    }
}
