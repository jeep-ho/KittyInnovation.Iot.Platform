using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovaton.Iot.Platfrom.WCF.Server
{
    /**************************
     Author:hezp
     Time:2017/8/27 14:45:35
     Desc：
    ***************************/
    [ServiceContract]
    public interface IProductService
    {
        /// <summary>
        /// 获取商品集
        /// </summary>
        /// <returns>商品集</returns>
        [OperationContract]
        string GetProducts();

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <param name="productName">商品名称</param>
        /// <returns>商品Id</returns>
        [OperationContract]
        Guid CreateProduct(string productName);
    }
}
