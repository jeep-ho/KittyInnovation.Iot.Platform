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
     Time:2017/8/27 18:22:44
     Desc：
    ***************************/
    [ServiceContract(CallbackContract =typeof(ICallBackService))]
    public interface ICalculatorService
    {
        [OperationContract(IsOneWay =true)]
        void Add(int x, int y);

        //[OperationContract(Name ="Add-Three")]
        //void Add(int x, int y, int z);
    }
}
