using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Domain.Entities
{
    /**************************
     Author:hezp
     Time:2017/9/3 20:17:22
     Desc：
    ***************************/
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Email { get; set; }
        public virtual int IsSys { get; set; }
        public virtual string IP { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual DateTime? ModifyTime { get; set; }
    }
}
