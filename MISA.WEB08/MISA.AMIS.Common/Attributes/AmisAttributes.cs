using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common
{
    /// <summary>
    /// Attribute dùng để xác định 1 property là khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {

    }

    /// <summary>
    /// Attribute dùng để xác định 1 property là khóa chính
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DuplicateAttribute : Attribute
    {
        #region Field
        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string ErrorMessage;
        #endregion

        #region Contructer
        public DuplicateAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion
    }

    /// <summary>
    /// Attribute dùng để xác định 1 property không được để trống
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsNotNullOrEmptyAttribute : Attribute
    {
        #region Field
        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string ErrorMessage;
        #endregion

        #region Contructer
        public IsNotNullOrEmptyAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion


    }
    /// <summary>
    /// Attribute dùng để xác định 1 property phải kiểu ngày tháng
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IsDateTime : Attribute
    {
        #region Field
        /// <summary>
        /// Message lỗi trả về cho client
        /// </summary>
        public string ErrorMessage;
        #endregion
        #region Contructer
        public IsDateTime(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        #endregion
    }
}
