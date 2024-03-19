using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store_IBoard.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.ApplicationDbContext
{
    public class ApplicationDbContext:IdentityDbContext<Users,Roles,long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            :base(option)
        { }

    }
}
