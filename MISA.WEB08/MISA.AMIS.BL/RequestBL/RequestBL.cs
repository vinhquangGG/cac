using MISA.AMIS.Common;
using MISA.AMIS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public class RequestBL : BaseBL<Request>, IRequestBL
    {
        #region Field
        private IRequestDL _requestDL;
        private IRequestDetailBL _requestDetailBL;
        #endregion
        #region Contructer
        public RequestBL(IRequestDL requestDL, IRequestDetailBL requestDetailBL) : base(requestDL)
        {
            _requestDL = requestDL;
            _requestDetailBL = requestDetailBL;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Filter nhân viên
        /// </summary>
        /// <param name="requestFilter">tên hoặc mã yêu cầu</param>
        /// <param name="pageSize">số lượng yêu cầu 1 trang</param>
        /// <param name="pageNumber">Bắt đầu từ</param>
        /// <returns>Danh sách các yêu cầu </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public ResultTotal<Request> GetRequestByCondition(string v_where, int v_limit, int v_offset, int status, Guid? departmentId)
        {
            return _requestDL.GetRequestByCondition(v_where, v_limit, v_offset, status, departmentId);
        }
        /// <summary>
        /// Xóa nhiều đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">Số mã đơn cần xóa</param>
        /// <returns>Thành công hoặc thất bại </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public int DeleteAllRequestById(List<Guid> idRequests)
        {
            return _requestDL.DeleteAllRequestById(idRequests);
        }
        /// <summary>
        /// Từ chối đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public int SetStatusRejected(List<Guid> idRequests)
        {
            return _requestDL.SetStatusRejected(idRequests);
        }
        /// <summary>
        /// Duyệt đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public int SetStatusApproved(List<Guid> idRequests)
        {
            return _requestDL.SetStatusApproved(idRequests);
        }
        #endregion

        /// <summary>
        /// Lấy request_detail
        /// </summary>
        /// <returns>List request_detail </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public override void GetDetailData(Request model)
        {
            List<RequestDetail> employees = new List<RequestDetail>();
            employees = (List<RequestDetail>)_requestDetailBL.GetAllRecordById(model.RequestID);
            model.Employees = employees;
        }
        /// <summary>
        /// Thêm request_detail
        /// </summary>
        /// <returns>List request_detail </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public override void InsertDetailData(Request request, Guid id)
        {
            var employees = request.Employees;
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    item.RequestID = id;
                    _requestDetailBL.InsertRecord(item);
                }
            }
        }
        /// <summary>
        /// Cập nhật request_detail
        /// </summary>
        /// <returns>List request_detail </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        public override void UpdateDetailData(Request request, Guid id)
        {
            //Xoas danh sasch cu
            _requestDetailBL.DeleteRecord(id);
            //Update danh sach moi
            var employees = request.Employees;
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    item.RequestID = id;
                    _requestDetailBL.InsertRecord(item);
                }

            }
        }
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// Author: PQVINH(04/10/2022)
        /// </summary>
        /// <returns></returns>
        public MemoryStream ExcelExport()
        {
            return _requestDL.ExcelExport();
        }
    }
}
