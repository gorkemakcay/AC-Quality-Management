using AutoMapper;
using QM.BussinessLogic.Interface.WorkOrders;
using QM.Common.ViewModels.WorkOrders.ProductViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Concrete.WorkOrders
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;

        public ProductManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddProduct(ProductAddViewModel model)
        {
            Add(_Mapper.Map<Product>(model));
            _Uow.SaveChange();
        }

        public ProductListViewModel GetProductInfoWithWorkOrder(int workOrderId)
        {
            return _Mapper.Map<ProductListViewModel>(GetFirstOrDefault(I => I.WorkOrderId == workOrderId));
        }

        public void UpdateProduct(ProductUpdateViewModel model)
        {
            Update(_Mapper.Map<Product>(model));
            _Uow.SaveChange();
        }
    }
}