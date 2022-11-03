using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Resources;
using MISA.AMIS.DL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field
        private IBaseDL<T> _baseDL;
        #endregion

        #region Contructer
        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }
        #endregion
        /// <summary>
        /// Lấy tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bàn ghi</returns>
        /// Created by: PQVINH(29/09/2022)
        public IEnumerable<T> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }
        /// <summary>
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: PQVINH(29/09/2022)
        public ServiceResponse InsertRecord(T record)
        {
            var validateResult = ValidateRequestData(record);
            if (validateResult != null && validateResult.Success == true)
            {
                var newRecordID = _baseDL.InsertRecord(record);
                InsertDetailData(record, newRecordID);
                if (newRecordID != Guid.Empty)
                {
                    return new ServiceResponse
                    {
                        Success = true,
                        Data = newRecordID
                    };
                }
                else
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            Resource.MoreInfo_InsertFailed
                            )
                    };
                }
            }
            return validateResult;
        }
        public virtual void InsertDetailData(T model, Guid id) { }
        /// <summary>
        /// Validate dữ liệu truyền từ API
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần Validate</param>
        /// <returns>Đối tượng ServiceResponse mô tả validate thành công hay thất bại</returns>
        /// Author: PQVinh(28/09/2022)
        private ServiceResponse ValidateRequestData(T record)
        {
            var properties = typeof(T).GetProperties();
            var ValidateFaileds = new List<string>();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                var propertyValue = property.GetValue(record, null);
                var isNotNullOrEmptyAttribute = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));
                var isPrimaryKey = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));
                var isDuplicate = (DuplicateAttribute?)Attribute.GetCustomAttribute(property, typeof(DuplicateAttribute));
                var isDateTime = (IsDateTime?)Attribute.GetCustomAttribute(property, typeof(IsDateTime));
                if (isNotNullOrEmptyAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    ValidateFaileds.Add(isNotNullOrEmptyAttribute.ErrorMessage);
                }
                if (isPrimaryKey != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    ValidateFaileds.Add(isPrimaryKey.ToString());
                }
                if (isDuplicate != null && !string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    var result = CheckDuplicate((string)propertyValue);
                    if (result != null)
                    {
                        ValidateFaileds.Add(isDuplicate.ErrorMessage);
                    }
                }
                if (isDateTime != null && !string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    var isDate = checkDatetime((DateTime)propertyValue);
                    if (isDate == 0)
                    {
                        ValidateFaileds.Add("Ngày tháng không được lớn hơn ngày hiện tại");
                    }
                }
            }
            if (ValidateFaileds.Count > 0)
            {
                return new ServiceResponse
                {
                    Success = false,
                    Data = new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            ValidateFaileds
                            )
                };
            }
            return new ServiceResponse
            {
                Success = true
            };
        }
        private T CheckDuplicate(string codeEmp)
        {
            string connectionString = DataContext.MySqlConnectionString;

            var mySqlConnection = new MySqlConnection(connectionString);

            var storeProcedure = string.Format(Resource.Proc_Duplicate, typeof(T).Name);

            var parameters = new DynamicParameters();

            parameters.Add("@v_code", codeEmp);

            var success = mySqlConnection.QueryFirstOrDefault<T>(storeProcedure, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return success;
        }
        private int checkDatetime(DateTime date)
        {
            int compare = DateTime.Compare(date, DateTime.Now);
            if (compare > 0)
            {
                return 0;
            }
            return 1;
        }
        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="record">Đối tượng bản ghi cần thêm mới</param>
        /// <returns>ID bản ghi vừa thêm mới</returns>
        /// Created by: PQVINH(29/09/2022)
        public T GetRecordById(Guid record)
        {
            var model = _baseDL.GetRecordById(record);
            GetDetailData(model);
            return model;
        }

        public virtual void GetDetailData(T model)
        {

        }
        /// <summary>
        /// Lấy 1 bản ghi
        /// </summary>
        /// <param name="record">Id bản ghi cần lấy</param>
        /// <returns>bản ghi vừa lấy</returns>
        /// Created by: PQVINH(29/09/2022)
        public ServiceResponse UpdateRecord(Guid recordID, T record)
        {
            var properties = typeof(T).GetProperties();
            var ValidateFaileds = new List<string>();
            var isId = "";
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                var propertyValue = property.GetValue(record, null);
                var isPrimaryKey = (PrimaryKeyAttribute?)Attribute.GetCustomAttribute(property, typeof(PrimaryKeyAttribute));
                var isNotNullOrEmptyAttribute = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));
                var isDuplicate = (DuplicateAttribute?)Attribute.GetCustomAttribute(property, typeof(DuplicateAttribute));
                var isDateTime = (IsDateTime?)Attribute.GetCustomAttribute(property, typeof(IsDateTime));
                if (isPrimaryKey != null)
                {
                    isId = property.Name;
                }
                if (isDuplicate != null && !string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    var result = CheckDuplicate((string)propertyValue);

                    if (result != null && (Guid)result.GetType().GetProperty(isId).GetValue(result, null) != recordID)
                    {
                        return new ServiceResponse
                        {
                            Success = false,
                            Data = new ErrorResult(
                            AmisErrorCode.Exception,
                            Resource.DevMsg_ValidateFailed,
                            Resource.UserMsg_ValidateFailed,
                            "Mã nhân viên đã tồn tại trong hệ thống"
                            )
                        };
                    }
                    else
                    {
                        if (isDateTime != null && !string.IsNullOrEmpty(propertyValue?.ToString()))
                        {
                            var isDate = checkDatetime((DateTime)propertyValue);
                            if (isDate == 0)
                            {
                                ValidateFaileds.Add("Ngày tháng không được lớn hơn ngày hiện tại");
                            }
                        }
                        if (isNotNullOrEmptyAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                        {
                            ValidateFaileds.Add(isNotNullOrEmptyAttribute.ErrorMessage);
                        }
                        if (ValidateFaileds.Count > 0)
                        {
                            return new ServiceResponse
                            {
                                Success = false,
                                Data = new ErrorResult(
                                        AmisErrorCode.Exception,
                                        Resource.DevMsg_ValidateFailed,
                                        Resource.UserMsg_ValidateFailed,
                                        ValidateFaileds
                                        )
                            };
                        }
                    }
                    
                    return new ServiceResponse
                    {
                        Success = true,
                        Data = _baseDL.UpdateRecord(recordID, record)
                    };
                }
            }
            var model = _baseDL.UpdateRecord(recordID, record);
            UpdateDetailData(model, recordID);
            return new ServiceResponse
            {
                Success = true,
                Data = _baseDL.UpdateRecord(recordID, record)
            };
        }
        public virtual void UpdateDetailData(T model, Guid id) { }
        /// <summary>
        /// Xử lí sql injection
        /// Author: VINHPQ(10/10/2022)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public ServiceResponse ValidateSqlInject(string str)
        {
            var regexItem = new Regex("^[aAàÀảẢãÃáÁạẠăĂằẰẳẲẵẴắẮặẶâÂầẦẩẨẫẪấẤậẬbBcCdDđĐeEèÈẻẺẽẼéÉẹẸêÊềỀểỂễỄếẾệỆfFgGhHiIìÌỉỈĩĨíÍịỊjJkKlLmMnNoOòÒỏỎõÕóÓọỌôÔồỒổỔỗỖốỐộỘơƠờỜởỞỡỠớỚợỢpPqQrRsStTuUùÙủỦũŨúÚụỤưƯừỪửỬữỮứỨựỰvVwWxXyYỳỲỷỶỹỸýÝỵỴzZ0-9@.,\r\n ]*$");
            if (str != null)
            {
                if (regexItem.IsMatch(str))
                {
                    return new ServiceResponse { Success = true, Data = null };
                }
                else
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Data = new ErrorResult(AmisErrorCode.InvalidInput,
                                Resource.DevMsg_ValidateFailed,
                                Resource.UserMsg_ValidateFailed,
                                "",
                                "")
                    };

                }
            }

            return new ServiceResponse { Success = true, Data = null };
        }

        public virtual List<object> BaseValidateSave(T model)
        {

            return new List<object>();
        }
        /// <summary>
        /// Xóa nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id nhân viên lấy được</param>
        /// <returns></returns>
        /// Created by: PQVINH(29/09/2022)
        public int DeleteRecord(Guid recordID)
        {
            return _baseDL.DeleteRecord(recordID);
        }

    }
}
