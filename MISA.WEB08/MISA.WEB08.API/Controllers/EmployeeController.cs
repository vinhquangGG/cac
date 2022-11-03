using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;

namespace MISA.WEB08.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeeController : BasesController<Employee>
    {
        #region Field
        private IEmployeeBL _employeeBL;
        #endregion
        #region Property
        #endregion
        #region Contructer
        public EmployeeController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Lấy nhân viên có mã lớn nhất
        /// </summary>
        /// <returns>nhân viên có mã lớn nhất</returns>
        /// Created by: PQVINH(29/09/2022)
        [HttpGet("get-max-code")]
        public IActionResult GetEmployeeByCodeMax()
        {
            return StatusCode(StatusCodes.Status200OK, _employeeBL.GetEmployeeByCodeMax());
        }
        /// <summary>
        /// Filter nhân viên
        /// </summary>
        /// <param name="employeeFilter">tên hoặc mã nhân viên</param>
        /// <param name="pageSize">số lượng nhân viên 1 trang</param>
        /// <param name="pageNumber">Bắt đầu từ</param>
        /// <returns>Danh sách nhân viên </returns>
        [HttpPost("filter")]
        public IActionResult GetEmployeeByCondition([FromBody] Dictionary<string,object> param)
        {
            return StatusCode(StatusCodes.Status200OK, _employeeBL.GetEmployeeByCondition(param));
        }

        /// <summary>
        /// API xóa nhiều nhân viên
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        [HttpPut]  
        public IActionResult DeleteAllEmployeeById([FromBody] List<Guid> idEmployees)
        {
            return StatusCode(StatusCodes.Status200OK, _employeeBL.DeleteAllEmployeeById(idEmployees));
        }

        [HttpPut("not-in-id-emp")]
        public IActionResult GetAllEmployeeNotInById([FromBody] List<Guid> idEmployees)
        {
            return StatusCode(StatusCodes.Status200OK, _employeeBL.GetAllEmployeeNotInById(idEmployees));
        }
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// </summary>
        /// <returns>file nếu thành công</returns>
        [HttpGet("export")]
        public IActionResult ExcelExport()
        {
            var stream = _employeeBL.ExcelExport();
            string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
 
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }
        #endregion



    }
}
