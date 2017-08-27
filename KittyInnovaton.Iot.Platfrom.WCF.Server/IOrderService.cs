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
     Time:2017/8/27 14:43:14
     Desc：
    ***************************/
    [ServiceContract]
    public interface IOrderService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns>订单编号</returns>
        [OperationContract]
        void CreateOrder(string orderNo);
    }
}
