using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common
{
    public class RequestDetail
    {
        [PrimaryKey]
        public Guid RequestDetailID { get; set; }
        public Guid? RequestID { get; set; }

        public string? EmployeeCode { get; set; }
        public string? FullName { get; set; }
        public string? PositionName { get; set; }
        public string? DepartmentName { get; set; }
        public string? Phone { get; set; }
        public Guid EmployeeID { get; set; }

    }
}
