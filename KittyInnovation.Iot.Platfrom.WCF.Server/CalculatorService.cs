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
     Time:2017/8/27 18:28:07
     Desc：
    ***************************/
    [ServiceBehavior(ConcurrencyMode =ConcurrencyMode.Multiple)]
    public class CalculatorService:ICalculatorService
    {
       
        public void Add(int x,int y)
        {
            var resu = x + y;
            try
            {
                ICallBackService callback = OperationContext.Current.GetCallbackChannel<ICallBackService>();
                callback.DisplayResult(x, y, resu);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //return resu;
        }
        
        //public void Add(int x,int y,int z)
        //{
        //    var resu = x + y + z;
        //    ICallBackService callback = OperationContext.Current.GetCallbackChannel<ICallBackService>();
        //    callback.DisplayResult(x, y, resu);
        //}
    }
}
