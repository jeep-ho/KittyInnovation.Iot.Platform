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
     Time:2017/8/27 18:25:33
     Desc：
    ***************************/
    public interface ICallBackService
    {
        [OperationContract]
        void DisplayResult(int x, int y, int result);
    }
}
