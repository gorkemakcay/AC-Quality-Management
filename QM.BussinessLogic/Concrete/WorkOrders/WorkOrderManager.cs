using AutoMapper;
using QM.BussinessLogic.Interface.WorkOrders;
using QM.Common.ViewModels.WorkOrders.WorkOrderViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Concrete.WorkOrders
{
    public class WorkOrderManager : GenericManager<WorkOrder>, IWorkOrderService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        public WorkOrderManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddWorkOrder(WorkOrderAddViewModel model)
        {
            Add(_Mapper.Map<WorkOrder>(model));
            _Uow.SaveChange();
        }

        public List<WorkOrderListViewModel> GetAllWorkOrders()
        {
            return _Mapper.Map<List<WorkOrderListViewModel>>(GetAll());
        }

        public List<WorkOrderListViewModel> GetWorkOrder(int workOrderId)
        {
            return _Mapper.Map<List<WorkOrderListViewModel>>(GetAll(I => I.Id == workOrderId));
        }

        public WorkOrderListViewModel GetWorkOrderDetail(int workOrderId)
        {
            return _Mapper.Map<WorkOrderListViewModel>(GetFirstOrDefault(I => I.Id == workOrderId));
        }

        public WorkOrderUpdateViewModel GetWorkOrderInfo(int workOrderId)
        {
            return _Mapper.Map<WorkOrderUpdateViewModel>(GetById(workOrderId));
        }

        public void UpdateWorkOrder(WorkOrderUpdateViewModel model)
        {
            Update(_Mapper.Map<WorkOrder>(model));
            _Uow.SaveChange();
        }

        public Task DeleteWorkOrder(int workOrderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kullanıcının Proje Sorumlusu olarak bulunduğu İş Emirleri
        /// </summary>
        /// <param name="appUserId"></param>
        /// <returns></returns>
        public List<WorkOrderListViewModel> GetOwnedWorkOrderBll(int appUserId)
        {
            try
            {
                return _Mapper.Map<List<WorkOrderListViewModel>>(GetAll(I => I.OwnerId == appUserId).ToList());
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {

            }
        }

        public List<WorkOrderListViewModel> GetWorkOrderCount(string status)
        {
            try
            {
                return _Mapper.Map<List<WorkOrderListViewModel>>(GetAll(I => I.Status == status).ToList());
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {

            }
        }


        /// <summary>
        /// Kullanıcının içinde montaj personeli olarak bulunduğu iş emirleri çeker.
        /// Business logic katmanı.
        /// </summary>
        /// <param name="appUserId">Sisteme giriş yapan kullanıcı Id'si.</param>
        /// <returns>Proje listesi.</returns>
        public List<WorkOrderListViewModel> GetMontageWorkOrderBll(int appUserId)
        {
            try
            {
                return _Mapper.Map<List<WorkOrderListViewModel>>(GetAll(I => I.MontageTechnicianId == appUserId).ToList());
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}