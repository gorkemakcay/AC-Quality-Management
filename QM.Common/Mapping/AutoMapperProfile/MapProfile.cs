using AutoMapper;
using QM.Common.ViewModels.Documents.DocumentViewModels;
using QM.Common.ViewModels.FinalQualities.FinalQualityViewModels;
using QM.Common.ViewModels.FinalQualities.FQControlViewModels;
using QM.Common.ViewModels.FinalQualities.RevisionViewModels;
using QM.Common.ViewModels.Notifications.NotificationViewModels;
using QM.Common.ViewModels.Notifications.UserNotificationViewModels;
using QM.Common.ViewModels.Users.AppRoleViewModels;
using QM.Common.ViewModels.Users.AppUserViewModels;
using QM.Common.ViewModels.WorkOrders.ManuelScenarioViewModels;
using QM.Common.ViewModels.WorkOrders.ProductViewModels;
using QM.Common.ViewModels.WorkOrders.WorkOrderViewModels;
using QM.Entities.Concrete.Documents;
using QM.Entities.Concrete.FinalQualities;
using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.Users;
using QM.Entities.Concrete.WorkOrders;

namespace QM.Common.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region AppRole
            CreateMap<AppRole, AppRoleListViewModel>().ReverseMap();
            CreateMap<AppRole, AppRoleAddViewModel>().ReverseMap();
            CreateMap<AppRole, AppRoleUpdateViewModel>().ReverseMap();
            #endregion

            #region AppUser
            CreateMap<AppUser, AppUserListViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserAddViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateViewModel>().ReverseMap();
            CreateMap<AppUser, AppUserLogInViewModel>().ReverseMap();
            #endregion

            #region FinalQuality
            CreateMap<FinalQuality, FinalQualityListViewModel>().ReverseMap();
            CreateMap<FinalQuality, FinalQualityAddViewModel>().ReverseMap();
            CreateMap<FinalQuality, FinalQualityUpdateViewModel>().ReverseMap();
            #endregion

            #region FQControl
            CreateMap<FQControl, FQControlAddViewModel>().ReverseMap();
            CreateMap<FQControl, FQControlListViewModel>().ReverseMap();
            CreateMap<FQControl, FQControlUpdateViewModel>().ReverseMap();
            #endregion

            #region Revision
            CreateMap<Revision, RevisionListViewModel>().ReverseMap();
            CreateMap<Revision, RevisionAddViewModel>().ReverseMap();
            CreateMap<Revision, RevisionUpdateViewModel>().ReverseMap();
            #endregion

            #region WorkOrder

            #region WorkOrder
            CreateMap<WorkOrder, WorkOrderAddViewModel>().ReverseMap();
            CreateMap<WorkOrder, WorkOrderListViewModel>().ReverseMap();
            CreateMap<WorkOrder, WorkOrderUpdateViewModel>().ReverseMap();
            #endregion

            #region WorkOrder
            CreateMap<Product, ProductAddViewModel>().ReverseMap();
            CreateMap<Product, ProductListViewModel>().ReverseMap();
            CreateMap<Product, ProductUpdateViewModel>().ReverseMap();
            #endregion

            #region ManuelScenario
            CreateMap<ManuelScenario, ManuelScenarioAddViewModel>().ReverseMap();
            CreateMap<ManuelScenario, ManuelScenarioListViewModel>().ReverseMap();
            CreateMap<ManuelScenario, ManuelScenarioUpdateViewModel>().ReverseMap();
            #endregion

            #endregion

            #region Document
            CreateMap<Document, DocumentUploadViewModel>().ReverseMap();
            CreateMap<Document, DocumentListViewModel>().ReverseMap();
            #endregion

            #region Notification
            CreateMap<Notification, NotificationListViewModel>().ReverseMap();
            CreateMap<Notification, NotificationAddViewModel>().ReverseMap();
            CreateMap<Notification, NotificationUpdateViewModel>().ReverseMap();
            #endregion

            #region UserNotification
            CreateMap<UserNotification, UserNotificationListViewModel>().ReverseMap();
            CreateMap<UserNotification, UserNotificationAddViewModel>().ReverseMap();
            CreateMap<UserNotification, UserNotificationUpdateViewModel>().ReverseMap();
            #endregion
        }
    }
}
