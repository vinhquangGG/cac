using MISA.AMIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public interface IRequestDetailDL : IBaseDL<RequestDetail>
    {
        /// <summary>
        /// API lấy tất cả request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public IEnumerable<RequestDetail> GetAllRecordById(Guid id);
        /// <summary>
        /// API xóa nhiều request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public int DeleteAllRequestDetailById(List<Guid> idEmployees);
    }
}
