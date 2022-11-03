using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;

namespace MISA.WEB08.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field
        private IBaseBL<T> _baseBL;
        #endregion
        #region Property
        #endregion
        #region Contructer
        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Created by: PQVINH(29/09/2022)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            try
            {
                var employees = _baseBL.GetAllRecords();
                return StatusCode(StatusCodes.Status200OK, employees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                AmisErrorCode.Exception,
                Resource.DevMsg_Exception,
                Resource.UserMsg_Exception,
                Resource.MoreInfo_InsertFailed,
                HttpContext.TraceIdentifier));
            }
        }
        
        /// <summary>
        /// API thêm mới 1 bản ghi
        /// </summary>
        /// <param name="employee">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID đối tượng bản ghi</returns>
        /// Author: PQVINH(28/09/2022)
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T record)
        {
            try
            {
                var result = _baseBL.InsertRecord(record);
                if (result.Success == true)
                {
                    return StatusCode(StatusCodes.Status201Created, result.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            result.Data
                            ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.MoreInfo_InsertFailed,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed
                            ));
            }
        }
        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="recordID">Mã bản ghi lấy được</param>
        /// <returns>Nhân viên theo id</returns>
        /// Created by: PQVINH(29/09/2022)
        [HttpGet("{recordID}")]
        public IActionResult GetRecordById([FromRoute] Guid recordID)
        {
            try
            {
                var record = _baseBL.GetRecordById(recordID);
                return StatusCode(StatusCodes.Status200OK, record);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.MoreInfo_InsertFailed,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed
                            ));
            }
        }
        /// <summary>
        /// Chỉnh sửa nhân viên theo Id
        /// </summary>
        /// <param name="recordID">Mã nhân viên lấy được</param>
        /// <param name="record">đối tượng nhân viên</param>
        /// <returns></returns>
        /// Created by: PQVINH(29/09/2022)
        [HttpPut("{recordID}")]
        public IActionResult UpdateRecord([FromRoute] Guid recordID, [FromBody] T record)
        {
            try
            {
                var employeePut = _baseBL.UpdateRecord(recordID, record);
                if (employeePut.Success == true)
                {
                    return StatusCode(StatusCodes.Status201Created, employeePut.Data);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            employeePut.Data
                            ));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.MoreInfo_InsertFailed,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed
                            ));
            }
        }
        /// <summary>
        /// Xóa nhân viên theo Id
        /// </summary>
        /// <param name="recordID">Id nhân viên lấy được</param>
        /// <returns></returns>
        /// Created by: PQVINH(29/09/2022)
        [HttpDelete("{recordID}")]
        public IActionResult DeleteRecord(Guid recordID)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, _baseBL.DeleteRecord(recordID));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.MoreInfo_InsertFailed,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed
                            ));
            }
        }
        #endregion
    }
}
