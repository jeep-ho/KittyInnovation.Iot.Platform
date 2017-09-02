using KittyInnovation.Iot.Platform.WCF.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.WCF.Client
{
    /**************************
     Author:hezp
     Time:2017/8/27 18:46:14
     Desc：
    ***************************/
    public class CallBackService : ICallBackService
    {
        public void DisplayResult(int x, int y, int result)
        {
            Console.WriteLine("{0} + {1} ={2}", x, y, result);
        }
    }
}
