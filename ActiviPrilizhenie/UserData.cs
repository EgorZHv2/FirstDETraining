using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviPrilizhenie
{
    public enum UserRole
    {
        None,
        Abonent,
        Operator
    }
    public static class UserData
    {
        public static UserRole Role { get; set; }
        public static Guid UserId { get; set; } 
    }
}
