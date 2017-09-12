using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyInnovation.Iot.Platform.Domain.Entities
{
    public class Log
    {
        public virtual int Id { get; set; }
        public virtual int UserId { get; set; }
        public virtual string Info { get; set; }
        public virtual string Ip { get; set; }
        public virtual DateTime LogTime { get; set; }
        public virtual User User { get; set; }
        

    }
}
