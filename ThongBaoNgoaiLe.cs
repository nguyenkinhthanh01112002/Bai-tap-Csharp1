using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentGiaiDoan1
{
    internal class ThongBaoNgoaiLe : ApplicationException
    {
        public ThongBaoNgoaiLe(string? message) : base(message)
        {

        }
    }
}
