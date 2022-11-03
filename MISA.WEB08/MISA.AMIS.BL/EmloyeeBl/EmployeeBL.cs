using MISA.AMIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.AMIS.DL;
using MISA.AMIS.Common.Resources;
using System.Data;

namespace MISA.AMIS.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {


        #region Field
        private IEmployeeDL _employeeDL;
        #endregion

        #region Contructer
        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy nhân viên có mã lớn nhất
        /// </summary>
        /// <returns>nhân viên có mã lớn nhất</returns>
        /// Created by: PQVINH(29/09/2022)
        public object GetEmployeeByCodeMax()
        {
            return _employeeDL.GetEmployeeByCodeMax();
        }
        /// <summary>
        /// Filter nhân viên
        /// </summary>
        /// <param name="v_where">tên hoặc mã nhân viên</param>
        /// <param name="v_limit">số lượng nhân viên 1 trang</param>
        /// <param name="v_offset">Bắt đầu từ</param>
        /// <returns>Danh sách nhân viên </returns>
        public ResultTotal<Employee> GetEmployeeByCondition(Dictionary<string, object> param)
        {
            return _employeeDL.GetEmployeeByCondition(param);
        }
        /// <summary>
        /// API xóa nhiều nhân viên
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public int DeleteAllEmployeeById(List<Guid> idEmployees)
        {
            return _employeeDL.DeleteAllEmployeeById(idEmployees);
        }
        public IEnumerable<Employee> GetAllEmployeeNotInById(List<Guid> idEmployees)
        {
            return _employeeDL.GetAllEmployeeNotInById(idEmployees);
        }
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// Author: PQVINH(04/10/2022)
        /// </summary>
        /// <returns></returns>
        public MemoryStream ExcelExport()
        {
            return _employeeDL.ExcelExport();
        }
        #endregion
    }
}
