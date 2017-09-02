using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.WCF.Server
{
    /**************************
     Author:hezp
     Time:2017/8/27 14:44:03
     Desc：
    ***************************/
    /// <summary>
    /// 订单管理服务实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderService : IOrderService
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns>订单编号</returns>
        public void CreateOrder(string orderNo)
        {
            Console.WriteLine(orderNo);
        }
    }
}
