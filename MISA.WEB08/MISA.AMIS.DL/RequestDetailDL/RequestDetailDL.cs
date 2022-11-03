using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public class RequestDetailDL : BaseDL<RequestDetail>, IRequestDetailDL
    {
        /// <summary>
        /// API lấy tất cả request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public IEnumerable<RequestDetail> GetAllRecordById(Guid recordID)
        {
            string connectionString = DataContext.MySqlConnectionString;
            using (var mysqlConnection = new MySqlConnection(connectionString))
            {
                var storedProcedureName = "Proc_RequestDetail_Detail";
                DynamicParameters values = new DynamicParameters();
                values.Add("@v_value", recordID);
                var record = mysqlConnection.Query<RequestDetail>(storedProcedureName, values, commandType: System.Data.CommandType.StoredProcedure);
                return record;
            }
        }
        /// <summary>
        /// API xóa nhiều request_detail
        /// </summary>
        /// <param name="idEmployees">List id của nhân viên</param>
        /// <returns>1 nếu thành công</returns>
        public int DeleteAllRequestDetailById(List<Guid> idEmployees)
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
                var storeProcedure = "Proc_RequestDetail_DeleteMany";
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
    }
}
