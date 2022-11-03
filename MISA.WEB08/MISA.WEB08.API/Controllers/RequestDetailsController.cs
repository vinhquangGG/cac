using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;

namespace MISA.WEB08.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RequestDetailsController : BasesController<RequestDetail>
    {
        #region Field
        private readonly IRequestDetailBL _requestDetailBL;

        public RequestDetailsController(IRequestDetailBL requestDetailBL) : base(requestDetailBL)
        {
            _requestDetailBL = requestDetailBL;
        }
        #endregion
        /// <summary>
        /// API xóa nhiều request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        [HttpPut]
        public IActionResult DeleteAllRequestDetailById([FromBody] List<Guid> idEmployees)
        {
            return StatusCode(StatusCodes.Status200OK, _requestDetailBL.DeleteAllRequestDetailById(idEmployees));
        }
    }
}
