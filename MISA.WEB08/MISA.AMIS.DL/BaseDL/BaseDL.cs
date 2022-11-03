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
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Methods
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bàn ghi</returns>
        /// Created by: PQVINH(29/09/2022)
        public IEnumerable<T> GetAllRecords()
        {


            var storedProcedureName = String.Format(Resource.Proc_GetAllEmployee, typeof(T).Name);

            string connectionString = DataContext.MySqlConnectionString;
            using (var mysqlConnection = new MySqlConnection(connectionString))
            {

                var employees = mysqlConnection.Query<T>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                return employees;
            }

        }
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: PQVINH(29/09/2022)
        public Guid InsertRecord(T record)
        {
            // Chuẩn bị tham số đầu vào cho Proc
            var parameters = new DynamicParameters();
            var recordID = Guid.NewGuid();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                if (propertyName != "Employees")
                {
                    var value = property.GetValue(record, null);
                    object propertyvalue;
                    var primaryKetAttr = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));
                    if (primaryKetAttr != null)
                    {
                        propertyvalue = recordID;
                    }
                    else
                    {
                        propertyvalue = property.GetValue(record, null);
                    }

                    parameters.Add($"@v_{propertyName}", propertyvalue);
                }
            }
            // Tạo kết nối đến database
            string connectionString = DataContext.MySqlConnectionString;
            int numberOfAffectedRows = 0;
            using (var mysqlConnection = new MySqlConnection(connectionString))
            {
                // Khai báo Proc insert
                var storeProcedure = String.Format(Resource.Proc_InsertOne, typeof(T).Name);
                //Thực hiện gọi DB để chạy proc
                numberOfAffectedRows = mysqlConnection.Execute(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            // return dữ liệu trả về
            if (numberOfAffectedRows > 0)
            {
                return recordID;
            }
            return Guid.Empty;
        }

        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="recordID">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: PQVINH(29/09/2022)
        public T GetRecordById(Guid recordID)
        {
            string connectionString = DataContext.MySqlConnectionString;
            T record;
            using (var mysqlConnection = new MySqlConnection(connectionString))
            {
                var storedProcedureName = String.Format(Resource.Proc_SelectById, typeof(T).Name);
                DynamicParameters values = new DynamicParameters();
                values.Add("@v_value", recordID);
                record = mysqlConnection.QueryFirstOrDefault<T>(storedProcedureName, values, commandType: System.Data.CommandType.StoredProcedure);
            }
            return record;
        }
        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="record">Id bản ghi cần lấy</param>
        /// <returns>bản ghi vừa lấy</returns>
        /// Created by: PQVINH(29/09/2022)
        public T UpdateRecord(Guid recordID, T record)
        {
            // Chuẩn bị tham số đầu vào cho Proc
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                if (propertyName != "Employees")
                {
                    
                    object propertyvalue;
                    var primaryKetAttr = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));
                    if (primaryKetAttr != null)
                    {
                        propertyvalue = recordID;
                    }
                    else
                    {
                        propertyvalue = property.GetValue(record, null);
                    }
                    if (propertyName == "ModifiedDate")
                    {
                        propertyvalue = DateTime.Now;
                    }
                    if(propertyName == "OverTime")
                    {
                        if(propertyvalue == null)
                        {
                            propertyvalue = 0;
                        }
                    }
                    parameters.Add($"@v_{propertyName}", propertyvalue);

                }
            }
            // Tạo kết nối đến database
            string connectionString = DataContext.MySqlConnectionString;
            int numberOfAffectedRows = 0;
            using (var mysqlConnection = new MySqlConnection(connectionString))
            {
                // Khai báo Proc insert
                var storeProcedure = String.Format(Resource.Proc_UpdateById, typeof(T).Name);
                //Thực hiện gọi DB để chạy proc
                numberOfAffectedRows = mysqlConnection.Execute(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            // return dữ liệu trả về
            if (numberOfAffectedRows > 0)
            {
                return record;
            }
            return record;
        }
        /// <summary>
        /// Xóa nhân viên theo Id
        /// </summary>
        /// <param name="recordID">Id nhân viên lấy được</param>
        /// <returns></returns>
        /// Created by: PQVINH(29/09/2022)
        public int DeleteRecord(Guid recordID)
        {
            string connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);

            var storeProcedure = String.Format(Resource.Proc_DelelteById, typeof(T).Name);

            var parameters = new DynamicParameters();

            parameters.Add("@v_value", recordID);

            var success = mySqlConnection.Execute(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return success;
        }
        #endregion

    }
}
