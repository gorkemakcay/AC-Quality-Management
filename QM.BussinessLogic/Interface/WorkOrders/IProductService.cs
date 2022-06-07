using QM.Common.ViewModels.WorkOrders.ProductViewModels;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.BussinessLogic.Interface.WorkOrders
{
    public interface IProductService : IGenericService<Product>
    {
        void AddProduct(ProductAddViewModel model);
        ProductListViewModel GetProductInfoWithWorkOrder(int workOrderId);
        void UpdateProduct(ProductUpdateViewModel model);
    }
}
