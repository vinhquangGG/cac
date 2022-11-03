namespace MISA.AMIS.Common
{
    /// <summary>
    /// thông tin phòng ban
    /// </summary>
    public class Department
    {
        /// <summary>
        /// ID phòng ban
        /// </summary>
        [PrimaryKey]
        public Guid DepartmentID { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [IsNotNullOrEmpty("Mã phòng ban không được để trống")]
        [Duplicate("Mã phòng ban đã tồn tại trong hệ thống")]
        public string? DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [IsNotNullOrEmpty("Tên phòng ban không được để trống")]
        public string? DepartmentName { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}
