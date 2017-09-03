using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.WCF.Server
{
    /**************************
     Author:hezp
     Time:2017/9/3 17:51:17
     Desc：
    ***************************/
    [DataContract]
    public class CustomException
    {
        [DataMember]
        public string Title;
        [DataMember]
        public string ExceptionMessage;
        [DataMember]
        public string InnerException;
        [DataMember]
        public string StackTrace;
    }
}
