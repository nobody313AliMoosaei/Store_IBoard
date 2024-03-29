namespace Store_IBoard.Utlities.ExtentionHost
{
    public static class ApplicationHost
    {
        public static WebApplication CacheCategoryGroup(this WebApplication app)
        {
            var Services = app.Services.CreateScope();
            
            var SessionService = Services.ServiceProvider.GetRequiredService<Store_IBoard.BL.Services.Session.ISessionService>();
            var GeneralService = Services.ServiceProvider.GetRequiredService<Store_IBoard.BL.Services.General.IGeneralService>();
            var e = Task.Run(()=> GeneralService.GetAllCategoryGroupGoods());
            e.Wait();
            SessionService.SetValue("", Newtonsoft.Json.JsonConvert.SerializeObject(e));
            return app;
        }
    }
}
