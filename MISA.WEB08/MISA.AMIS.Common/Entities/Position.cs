namespace MISA.AMIS.Common
{
    /// <summary>
    /// Thông tin vị trí
    /// </summary>
    public class Position
    {
        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid PositionID { get; set; }
        /// <summary>
        /// Mã vị trí
        /// </summary>
        public string PositionCode { get; set; }
        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
