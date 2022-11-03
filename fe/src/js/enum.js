export const M_ENUM = {
    MISA_TOOL: {
        ADD : 1,
        EDIT: 2,
        DELETE: 3,
        FILTER: 4
    },
    VALIDATE_FORM: {
        IsNotNull: {
            "VI": "Trường này không được để trống.",
            "EN": "Is not empty"
        }
    },
    LANGUAGES: {
        VI : "VI",
        EN: "EN"
    }
}

export const DEPARTMENTS_DROPDOWN = [
    {
      DepartmentId: '',
      DepartmentName: "Khối điều hành",
      expanded: true,
      items: [
        {
          DepartmentId: '469b3ece-744a-45d5-957d-e8c757976496',
          DepartmentName: " Phòng giám đốc ",
        },
        {
          DepartmentId: '142cb08f-7c31-21fa-8e90-67245e8b283e',
          DepartmentName: " Phòng phó giám đốc "
        },
        {
          DepartmentId: '148ed882-32b8-218e-9c20-39c2f00615e5',
          DepartmentName: ' Phó phòng '
        }
      ]
    },
    {
      DepartmentId: '',
      DepartmentName: "Khối quản trị doanh nghiệp",
      expanded: true,
      items: [
        {
          DepartmentId: '17120d02-6ab5-3e43-18cb-66948daf6128',
          DepartmentName: " Phòng hội thảo ",
        },
        {
          DepartmentId: '4e272fc4-7875-78d6-7d32-6a1673ffca7c',
          DepartmentName: "Phòng hành chính ",
        },
        {
          DepartmentId: '11452b0c-768e-5ff7-0d63-eeb1d8ed8cef',
          DepartmentName: "Phòng kế toán",
        }
      ]
    },
    {
      DepartmentId: '',
      DepartmentName: "Khối hành chính nhân sự",
      expanded: true,
      items: [
        {
          DepartmentId: '768f8e64-7d10-20c9-967d-e8c757976496',
          DepartmentName: " Phòng phỏng vấn ",
        }
  
      ]
    }
  ]

export const ADD_SUCCESS = "Thêm mới thành công";

export const UPDATE_SUCCESS = "Sửa thành công";

export const DELETE_SUCCESS = "Xóa thành công";