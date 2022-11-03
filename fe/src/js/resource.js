import { common } from "@/js/common.js";
import ArrayStore from "devextreme/data/array_store";
export const DATA_GRID_TABLE = [
  {
    Caption: "Mã nhân viên",
    Field: "EmployeeCode",
    Width: 126,
    Type: "string",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Người nộp đơn",
    Field: "FullName",
    Width: 250,
    Type: "string",
    Cell: "cell-application-people",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Vị trí công việc",
    Field: "PositionID",
    Width: 150,
    Type: "string",
    Cell: "cell-position",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Đơn vị công tác",
    Field: "DepartmentID",
    Width: 190,
    Type: "string",
    Cell: "cell-department",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Ngày nộp đơn",
    Field: "ApplicationDate",
    dataformat: function (dob) {
      return "MM/dd/yyyy hh:mm";
    },
    Width: 150,
    Type: "date",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Làm thêm từ",
    Field: "WorkFrom",
    dataformat: function (dob) {
      return "MM/dd/yyyy hh:mm";
    },
    Width: 150,
    Type: "date",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Làm thêm đến",
    Field: "WorkTo",
    dataformat: function (dob) {
      return "MM/dd/yyyy hh:mm";
    },
    Width: 150,
    Type: "date",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Thời điểm làm thêm",
    Field: "WorkTime",
    Width: 150,
    Type: "string",
    Cell: "grid-cell-worktime",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Ca làm thêm",
    Field: "OverTime",
    Width: 150,
    Type: "string",
    Cell: "grid-cell-overtime",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Lý do làm thêm",
    Field: "ReasonsWork",
    Width: 196,
    Type: "string",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Người duyệt",
    Field: "ApprovedName",
    Width: 150,
    Type: "string",
    HeaderCell: "header-cell",
  },
  { Caption: "Ghi chú", Field: "", Width: 196, Type: "string" },
  {
    Caption: "Trạng thái",
    Field: "Status",
    Width: 102,
    Type: "number",
    Cell: "grid-cell-status",
    HeaderCell: "header-cell",
  },
  {
    Caption: "",
    Width: 102,
    HeaderCell: "header-cell",
  },
];
export const DATA_GRID_TABLE_EMPLOYEES = [
  {
    Caption: "Mã nhân viên",
    Field: "EmployeeCode",
    Width: 150,
    Type: "string",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Tên nhân viên",
    Field: "FullName",
    Width: 250,
    Type: "string",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Đơn vị công tác",
    Field: "DepartmentName",
    Width: 250,
    Type: "string",
    HeaderCell: "header-cell",
  },
  {
    Caption: "Vị trí công tác",
    Field: "PositionName",
    Width: 190,
    Type: "string",
    HeaderCell: "header-cell",
  },
  {
    Caption: "ĐT di động",
    Field: "PhoneNumber",
    Width: 150,
    HeaderCell: "header-cell",
    Title: "Điện thoại di động"
  },
  {
    Caption: "Email cơ quan",
    Field: "Email",
    Width: 250,
    HeaderCell: "header-cell",
  }
];
export const COUNT_HEADER = DATA_GRID_TABLE.length;

export const COUNT_HEADER_EMPLOYEES = DATA_GRID_TABLE_EMPLOYEES.length;

export const NUMBER_PAGE = [15, 25, 50, 100];

export const DATETIME_OPTIONS = {
  cancelButtonText: "Huỷ",
  applyButtonText: "Lưu",
  dateOutOfRangeMessage: "Giá trị không hợp lệ",
  displayFormat: "dd/MM/yyyy HH:mm",
  invalidDateMessage: "Giá trị không hợp lệ",
  type: "datetime",
};

export const STATUS_OPTIONS = [
  { text: "Tất cả", status: -1 },
  { text: "Chờ duyệt", status: 2 },
  { text: "Đã duyệt", status: 1 },
  { text: "Từ chối", status: 0 },
];

export const WORKTIME_OPTION = [
  {text: "Trước ca", value: "1"},
  {text: "Sau ca", value: "2"},
  {text: "Nghỉ giữa ca", value: "3"},
  {text: "Ngày nghỉ", value: "4"}
]

export const OVERTIME_OPTION = [
  {text: "Ca chấm 1 lần", value: "1"}
]

