using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;
using MySqlConnector;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public class RequestDL : BaseDL<Request>, IRequestDL
    {
        /// <summary>
        /// Filter nhân viên
        /// </summary>
        /// <param name="requestFilter">tên hoặc mã yêu cầu</param>
        /// <param name="pageSize">số lượng yêu cầu 1 trang</param>
        /// <param name="pageNumber">Bắt đầu từ</param>
        /// <returns>Danh sách các yêu cầu </returns>
        public ResultTotal<Request> GetRequestByCondition(string requestFilter, int pageSize, int pageNumber, int status, Guid? departmentId)
        {
            var v_offset = (pageNumber - 1) * pageSize;
            var v_limit = pageSize;
            string connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);

            var storeProcedure = String.Format(Resource.Proc_Filter, typeof(Request).Name);

            var parameters = new DynamicParameters();

            parameters.Add("@v_where", requestFilter);
            parameters.Add("@v_limit", pageSize);
            parameters.Add("@v_offset", v_offset);
            parameters.Add("@v_status", status);
            parameters.Add("@v_departmentId", departmentId);
            var response = mySqlConnection.QueryMultiple(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
            var requests = response.Read<Request>().ToList();
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
            return new ResultTotal<Request>(TotalPage, totalRecord, v_offset / v_limit + 1, v_limit, requests);
        }
        /// <summary>
        /// Xóa nhiều đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">Số mã đơn cần xóa</param>
        /// <returns>Thành công hoặc thất bại </returns>
        public int DeleteAllRequestById(List<Guid> idRequests)
        {
            string str = "(";
            for (int i = 0; i < idRequests.Count; i++)
            {
                if (i != idRequests.Count - 1)
                {
                    str = str + "'" + idRequests[i].ToString() + "',";
                }
                else
                {
                    str = str + "'" + idRequests[i].ToString() + "')";
                }
            }
            var connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            var transaction = mySqlConnection.BeginTransaction();
            try
            {
                var storeProcedure = "Proc_Request_DeleteMany";
                var parameters = new DynamicParameters();
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
        /// <summary>
        /// Từ chối đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        public int SetStatusRejected(List<Guid> idRequests)
        {
            string str = "(";
            for (int i = 0; i < idRequests.Count; i++)
            {
                if (i != idRequests.Count - 1)
                {
                    str = str + "'" + idRequests[i].ToString() + "',";
                }
                else
                {
                    str = str + "'" + idRequests[i].ToString() + "')";
                }
            }
            var connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            var transaction = mySqlConnection.BeginTransaction();
            try
            {
                var storeProcedure = "Proc_request_Rejected";
                var parameters = new DynamicParameters();
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
        /// <summary>
        /// Duyệt đơn yêu cầu
        /// </summary>
        /// <param name="idRequests">id đơn yêu cầu</param>
        /// <returns>Thành công hoặc thất bại </returns>
        public int SetStatusApproved(List<Guid> idRequests)
        {
            string str = "(";
            for (int i = 0; i < idRequests.Count; i++)
            {
                if (i != idRequests.Count - 1)
                {
                    str = str + "'" + idRequests[i].ToString() + "',";
                }
                else
                {
                    str = str + "'" + idRequests[i].ToString() + "')";
                }
            }
            var connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);
            mySqlConnection.Open();
            var transaction = mySqlConnection.BeginTransaction();
            try
            {
                var storeProcedure = "Proc_request_Approved";
                var parameters = new DynamicParameters();
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
        /// <summary>
        /// API xuất dữ liệu ra file excel
        /// Author: PQVINH(04/10/2022)
        /// </summary>
        /// <returns>file nếu thành công</returns>
        public MemoryStream ExcelExport()
        {
            try
            {
                Request request = new Request();

                var FileData = GetAllRecords();

                DataTable Dt = new DataTable();
                Dt.Columns.Add("Mã nhân viên", typeof(string));
                Dt.Columns.Add("Người nộp đơn", typeof(string));
                Dt.Columns.Add("Vị trí công việc", typeof(string));
                Dt.Columns.Add("Đơn vị công tác", typeof(string));
                Dt.Columns.Add("Ngày nộp đơn", typeof(string));
                Dt.Columns.Add("Làm thêm từ", typeof(string));
                Dt.Columns.Add("Làm thêm đến", typeof(string));
                Dt.Columns.Add("Thời điểm làm thêm", typeof(string));
                Dt.Columns.Add("Ca làm thêm", typeof(string));
                Dt.Columns.Add("Lí do làm thêm", typeof(string));
                Dt.Columns.Add("Người duyệt", typeof(string));
                Dt.Columns.Add("Ghi chú", typeof(string));
                Dt.Columns.Add("Trạng thái", typeof(string));
                int stt = 1;
                foreach (var data in FileData)
                {
                    DataRow row = Dt.NewRow();
                    row[0] = stt++;
                    row[1] = data.EmployeeCode;
                    row[2] = data.FullName;
                    row[3] = data.PositionName;
                    row[4] = data.DepartmentName;
                    row[5] = data.ApplicationDate;
                    row[6] = data.WorkFrom;
                    row[7] = data.WorkTo;
                    row[8] = data.WorkTime;
                    row[9] = data.OverTime;
                    row[10] = data.ReasonsWork;
                    row[11] = data.ApprovedName;
                    row[12] = data.Status;
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
    }
}
