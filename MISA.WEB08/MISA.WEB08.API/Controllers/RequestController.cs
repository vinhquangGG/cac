using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;

namespace MISA.WEB08.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RequestController : BasesController<Request>
    {
        #region Field
        private readonly IRequestBL _requestBL;

        public RequestController(IRequestBL requestBL) : base(requestBL)
        {
            _requestBL = requestBL;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Filter đơn yêu cầu
        /// </summary>
        /// <param name="requestFilter">tên hoặc mã yêu cầu</param>
        /// <param name="pageSize">số lượng yêu cầu 1 trang</param>
        /// <param name="pageNumber">Bắt đầu từ</param>
        /// <returns>Danh sách các yêu cầu </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        [HttpGet("filter")]
        public IActionResult GetEmployeeByCondition([FromQuery] string requestFilter, int pageSize, int pageNumber, int status, Guid? departmentId)
        {
           return StatusCode(StatusCodes.Status200OK, _requestBL.GetRequestByCondition(requestFilter, pageSize, pageNumber, status, departmentId));
        }
        /// <summary>
        /// Xóa nhiều đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">Số mã đơn cần xóa</param>
        /// <returns>Thành công hoặc thất bại </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        [HttpPut]
        public IActionResult DeleteAllRequestById([FromBody] List<Guid> idRequests)
        {
            return StatusCode(StatusCodes.Status200OK, _requestBL.DeleteAllRequestById(idRequests));
        }
        /// <summary>
        /// Từ chối đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        [HttpPut("request-rejected")]
        public IActionResult SetStatusRejected([FromBody] List<Guid> idRequests)
        {
            return StatusCode(StatusCodes.Status200OK, _requestBL.SetStatusRejected(idRequests));
        }
        /// <summary>
        /// Duyệt đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        /// CreatedBy: PQVINH(29/10/2022)
        [HttpPut("request-approved")]
        public IActionResult SetStatusApproved([FromBody] List<Guid> idRequests)
        {
            return StatusCode(StatusCodes.Status200OK, _requestBL.SetStatusApproved(idRequests));
        }
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// </summary>
        /// <returns>file nếu thành công</returns>
        [HttpGet("export")]
        public IActionResult ExcelExport()
        {
            var stream = _requestBL.ExcelExport();
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion

    }
}
