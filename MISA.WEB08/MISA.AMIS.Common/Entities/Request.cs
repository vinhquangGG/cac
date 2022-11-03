using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common
{
    public class Request
    {
        /// <summary>
        /// ID đơn
        /// </summary>
        [PrimaryKey]
        public Guid RequestID { get; set; }
        /// <summary>
        /// ID nhân viên
        /// </summary>
        [IsNotNullOrEmpty("Tên nhân viên không được để trống")]
        public Guid EmployeeID { get; set; }
        /// <summary>
        /// Id Người duyệt
        /// </summary>
        [IsNotNullOrEmpty("Tên người duyệt không được để trống")]
        public Guid ApprovedID { get; set; }
        // Ngày nộp đơn
        [IsNotNullOrEmpty("Ngày nộp đơn không được để trống")]
        public DateTime ApplicationDate { get; set; }
        // Làm thêm từ
        [IsNotNullOrEmpty("Làm thêm từ không được để trống")]
        public DateTime WorkFrom { get; set; }
        // Làm thêm đến
        public DateTime WorkTo { get; set; }
        // Nghỉ giữa ca từ
        public DateTime RestBetweenFrom { get; set; }
        // Nghỉ giữa ca đến
        public DateTime RestBetweenTo { get; set; }
        // Thời điểm làm thêm
        [IsNotNullOrEmpty("Thời điểm làm thêm không được để trống")]
        public string? WorkTime { get; set; }
        // Ca làm thêm
        public string? OverTime { get; set; }
        // Lí do
        [IsNotNullOrEmpty("Lí do làm thêm không được để trống")]
        public string? ReasonsWork { get; set; }
        // Trạng thái
        [IsNotNullOrEmpty("Trạng thái không được để trống")]
        public int? Status { get; set; }
        // Người tạo
        public string CreatedBy { get; set; }
        // Ngày tạo
        public DateTime CreatedDate { get; set; }
        // Người sửa
        public string ModifiedBy { get; set; }
        // Sửa ngày
        public DateTime ModifiedDate { get; set; }
        // Id phòng ban
        public Guid? DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        // Id vị trí
        public Guid? PositionID { get; set; }
        public string? PositionName { get; set; }
        // Tên người duyệt
        public string? ApprovedName { get; set; }
        // Tên nhân viên
        public string? FullName { get; set; }
        // Mã nhân viên
        public string? EmployeeCode { get; set; }
        // List request_detail
        public List<RequestDetail>? Employees { get; set; }
    }
}
