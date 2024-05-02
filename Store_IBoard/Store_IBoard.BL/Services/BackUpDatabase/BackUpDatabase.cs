using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.BackUpDatabase
{
    public class BackUpDatabase : IBackUpDatabase
    {
        private DL.ApplicationDbContext.ApplicationDBContext _context;
        private readonly BL.Services.Eamil.IEmailService _emailService;
        
        public BackUpDatabase(DL.ApplicationDbContext.ApplicationDBContext context, Eamil.IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        async Task IBackUpDatabase.BackUpDatabase()
        {
            try
            {
                string DatabaseName = _context.Database.GetDbConnection().Database;
                string strDateTime = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                string PathBackUp = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "BackUps");
                if (!Directory.Exists(PathBackUp))
                    Directory.CreateDirectory(PathBackUp);
                
                var BackUpAdd = Path.Combine(PathBackUp, $"{strDateTime}.bak");

                await _context.Database.ExecuteSqlRawAsync($"BACKUP DATABASE [{DatabaseName}] TO DISK = '{BackUpAdd}' WITH INIT, FORMAT, COMPRESSION;");

                if(System.IO.File.Exists(BackUpAdd))
                {
                    var streamFile = new FileStream(BackUpAdd,FileMode.Open,FileAccess.Read);
                    await _emailService.SendYahooMailAsync("ali.moosaei.big@gmail.com", "BackUp", streamFile);
                }

                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
