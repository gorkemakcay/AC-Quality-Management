using Microsoft.Extensions.DependencyInjection;
using QM.BussinessLogic.Concrete;
using QM.BussinessLogic.Concrete.Documents;
using QM.BussinessLogic.Concrete.FinalQualities;
using QM.BussinessLogic.Concrete.Notifications;
using QM.BussinessLogic.Concrete.Users;
using QM.BussinessLogic.Concrete.WorkOrders;
using QM.BussinessLogic.Interface;
using QM.BussinessLogic.Interface.Documents;
using QM.BussinessLogic.Interface.FinalQualities;
using QM.BussinessLogic.Interface.Notifications;
using QM.BussinessLogic.Interface.Users;
using QM.BussinessLogic.Interface.WorkOrders;

namespace QM.BussinessLogic.DIContainer
{
    public static class CustomExtensionsBll
    {
        public static void AddContainerWithDependenciesBll(this IServiceCollection services)
        {
            services.AddScoped<IAppRoleService, AppRoleManager>()
                    .AddScoped<IAppUserService, AppUserManager>()
                    .AddScoped<IWorkOrderService, WorkOrderManager>()
                    .AddScoped<IProductService, ProductManager>()
                    .AddScoped<IFinalQualityService, FinalQualityManager>()
                    .AddScoped<IFQControlService, FQControlManager>()
                    .AddScoped<IManuelScenarioService, ManuelScenarioManager>()
                    .AddScoped<IRevisionService, RevisionManager>()
                    .AddScoped<IFileService, FileManager>()
                    .AddScoped<IDocumentService, DocumentManager>()
                    .AddScoped<INotificationService, NotificationManager>()
                    .AddScoped<IUserNotificationService, UserNotificationManager>();

            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
}
