using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;
using MySqlConnector;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System.Data;
using System.IO;

namespace MISA.AMIS.DL
{
    public class EmployeeDL : BaseDL<Employee>,IEmployeeDL
    {
        
        #region Methods
        /// <summary>
        /// Lấy nhân viên có mã lớn nhất
        /// </summary>
        /// <returns>nhân viên có mã lớn nhất</returns>
        /// Created by: PQVINH(29/09/2022)
        public object GetEmployeeByCodeMax()
        {
            string connectionString = DataContext.MySqlConnectionString;
            var mysqlConnection = new MySqlConnection(connectionString);
            var storeProcedureName = String.Format(Resource.Proc_GetEmpCodeMax, typeof(Employee).Name);
            var employee = mysqlConnection.QueryFirstOrDefault(storeProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            return employee;
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

            string str = param["id"].ToString();
            var v_offset = (int.Parse(param["pageNumber"].ToString()) - 1) * int.Parse(param["pageSize"].ToString());
            var v_limit = int.Parse(param["pageSize"].ToString());
            string connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);

            var storeProcedure = String.Format(Resource.Proc_Filter, typeof(Employee).Name);

            var parameters = new DynamicParameters();

            parameters.Add("@v_where", (param["employeeFilter"].ToString()));
            parameters.Add("@v_limit", int.Parse(param["pageSize"].ToString()));
            parameters.Add("@v_offset", v_offset);
            parameters.Add("@v_IdEmployee", str);
            var response = mySqlConnection.QueryMultiple(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
            var employees = response.Read<Employee>().ToList();
            var totalRecord = response.Read<int>().First();
            var TotalPage = -1;
            if (totalRecord % v_limit == 0)
            {
                TotalPage = totalRecord / v_limit;
            }
            else
            {
                TotalPage = totalRecord / v_limit + 1;
            }
            return new ResultTotal<Employee>(TotalPage, totalRecord, v_offset / v_limit + 1, v_limit, employees);
        }
        /// <summary>
        /// API xóa nhiều nhân viên
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public int DeleteAllEmployeeById(List<Guid> idEmployees)
        {
            string str = "(";
            for (int i = 0; i < idEmployees.Count; i++)
            {
                if (i != idEmployees.Count - 1)
                {
                    str = str + "'" + idEmployees[i].ToString() + "',";
                }
                else
                {
                    str = str + "'" + idEmployees[i].ToString() + "')";
                }
            }
            var connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            var transaction = mySqlConnection.BeginTransaction();
            try
            {
                var storeProcedure = "Proc_employee_DeleteMany";
                var parameters = new Dictionary<string, object>();
                parameters.Add("v_where", str);
                mySqlConnection.Execute(storeProcedure, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);          
                transaction.Commit();
                return 1;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
            return 0;

        }

        public IEnumerable<Employee> GetAllEmployeeNotInById(List<Guid> idEmployees)
        {
            string str = "(";
            if(idEmployees.Count == 0)
            {
                str += "'')";
            }
            for (int i = 0; i < idEmployees.Count; i++)
            {
                if (i != idEmployees.Count - 1)
                {
                    str = str + "'" + idEmployees[i].ToString() + "',";
                }
                else
                {
                    str = str + "'" + idEmployees[i].ToString() + "')";
                }
            }
            var connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);

            var storeProcedure = "Proc_emloyee_SelectNotIn";
            var parameters = new Dictionary<string, object>();
            parameters.Add("v_where", str);
            var employees = mySqlConnection.Query<Employee>(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return employees;
        }
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// Author: PQVINH(04/10/2022)
        /// </summary>
        /// <returns>file nếu thành công</returns>
        public MemoryStream ExcelExport()
        {
            try
            {
                Employee employee = new Employee();

                var FileData = GetAllRecords();

                DataTable Dt = new DataTable();
                Dt.Columns.Add("STT", typeof(string));
                Dt.Columns.Add("Mã nhân viên", typeof(string));
                Dt.Columns.Add("Giới tính", typeof(string));
                Dt.Columns.Add("Ngày sinh", typeof(string));
                Dt.Columns.Add("Số CMND", typeof(string));
                Dt.Columns.Add("Chức danh", typeof(string));
                Dt.Columns.Add("Tên đơn vị", typeof(string));
                Dt.Columns.Add("Số tài khoản", typeof(string));
                Dt.Columns.Add("Tên ngân hàng", typeof(string));
                Dt.Columns.Add("Chi nhánh TK ngân hàng", typeof(string));
                int stt = 1;
                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = stt++;
                    row[1] = data.EmployeeCode;
                    row[2] = data.Gender;
                    row[3] = data.DateOfBirth;
                    row[4] = data.IdentityNumber;
                    row[5] = data.PositionName;
                    row[6] = data.DepartmentName;
                    row[7] = data.BankAccount;
                    row[8] = data.BankName;
                    row[9] = data.BankBranch;
                    Dt.Rows.Add(row);
                }

                var stream = new MemoryStream();
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromDataTable(Dt, true);
                    package.Save();
                }
                stream.Position = 0;
                string excelName = $"UserList-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                //return File(stream, "application/octet-stream", excelName);  
                //return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
                return stream;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //public object Download()
        //{

        //    if (Session["DownloadExcel_FileManager"] != null)
        //    {
        //        byte[] data = Session["DownloadExcel_FileManager"] as byte[];
        //        return File(data, "application/octet-stream", "FileManager.xlsx");
        //    }
        //    else
        //    {
        //        return new EmptyResult();
        //    }
        //}
        #endregion

    }
}
