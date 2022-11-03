namespace MISA.AMIS.Common
{   
    /// <summary>
    /// Các danh sách max lỗi khi gọi API
    /// </summary>
    public enum AmisErrorCode
    {
        /// <summary>
        /// Lỗi do Exception
        /// </summary>
        Exception = 1,
        /// <summary>
        /// Lỗi do trùng mã
        /// </summary>
        DuplicateCode = 2,
        /// <summary>
        /// Lỗi do bị để trống
        /// </summary>
        EmptyCode = 3,
        /// <summary>
        /// Gọi insert vào Db thất bại
        /// </summary>
        InsertFailed = 4,
        /// <summary>
        /// Dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidInput = 5

    }
}
