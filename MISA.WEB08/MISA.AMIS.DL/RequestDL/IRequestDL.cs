using MISA.AMIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public interface IRequestDL : IBaseDL<Request>
    {
        /// <summary>
        /// Filter nhân viên
        /// </summary>
        /// <param name="requestFilter">tên hoặc mã yêu cầu</param>
        /// <param name="pageSize">số lượng yêu cầu 1 trang</param>
        /// <param name="pageNumber">Bắt đầu từ</param>
        /// <returns>Danh sách các yêu cầu </returns>
        public ResultTotal<Request> GetRequestByCondition(string v_where, int v_limit, int v_offset, int status, Guid? departmentId);
        /// <summary>
        /// Xóa nhiều đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">Số mã đơn cần xóa</param>
        /// <returns>Thành công hoặc thất bại </returns>
        public int DeleteAllRequestById(List<Guid> idRequests);
        /// <summary>
        /// Từ chối đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        public int SetStatusRejected(List<Guid> idRequests);
        /// <summary>
        /// Duyệt đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        public int SetStatusApproved(List<Guid> idRequests);
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// Author: PQVINH(04/10/2022)
        /// </summary>
        /// <returns></returns>
        public MemoryStream ExcelExport();
    }
}
