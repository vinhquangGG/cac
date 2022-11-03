<template>
  <DxDataGrid
    :data-source="employeeList"
    key-expr="EmployeeCode"
    :selection="{ mode: 'single' }"
    :column-auto-width="true"
    :show-borders="true"
    :hover-state-enabled="true"
    :ref="refText"
    :selected-row-keys="selectedRowKeys"
    @selection-changed="selectedRow"
  >
    <DxPaging :enabled="false"/>
    <DxSelection mode="multiple"/>
    <DxEditing :allow-deleting="true" />
    <DxColumnFixing :enabled="true" />
    <DxColumn
      v-for="(item, index) in dataTable"
      :key="index"
      :data-field="item.Field"
      :caption="item.Caption"
      :Width="item.Width"
      :format="item.dataformat ? item.dataformat(item.Field) : null"
      :dataType="item.Type"
      :cell-template="item.Cell"
      :header-cell-template="item.HeaderCell"
      :fixed="arrayPinColumn[index]"
      :title="item.Title"
    ></DxColumn>
    <DxColumn type="buttons" :width="100" caption="">
      <DxButton
        id="delete-button"
        icon="trash"
        @click="deleteRequestDetail"
        css-class="command-button"
        :fixed="true"
        hint="Xóa"
      ></DxButton>
    </DxColumn>
    <template #header-cell="{ data }">
      <m-header-cell
        @pinColumnData="pinColumnData"
        :data="data"
        :isPin="getPinProps(data)"
      />
    </template>
    <DxScrolling column-rendering-mode="virtual" />
  </DxDataGrid>
</template>

<script>
import DxTextBox from "devextreme-vue/text-box";
import MStatus from "@/components/base/MStatus/MStatus.vue";
import MHeaderCell from "@/components/base/MHeaderCell/MHeaderCell.vue";
import DxSelectBox from "devextreme-vue/select-box";
import {
  DATA_GRID_TABLE,
  COUNT_HEADER_EMPLOYEES,
  DATA_GRID_TABLE_EMPLOYEES,
} from "@/js/resource";
import { getPositions } from "@/axios/positionController/positionController.js";
import { getDepartments } from "@/axios/departmentController/departmentController.js";
import { DxCheckBox } from "devextreme-vue/check-box";
import {
  DxDataGrid,
  DxColumn,
  DxSelection,
  DxPager,
  DxScrolling,
  DxColumnFixing,
  DxPaging,
  DxEditing,
  DxButton,
} from "devextreme-vue/data-grid";
export default {
  components: {
    DxTextBox,
    MStatus,
    MHeaderCell,
    DxSelectBox,
    DxDataGrid,
    DxPager,
    DxColumn,
    DxCheckBox,
    DxSelection,
    DxScrolling,
    DxColumnFixing,
    DxPaging,
    DxEditing,
    DxButton,
  },
  props: {
    isRenderEmployeeList: {
      type: Boolean,
      default: false,
    },
    refText: String,
    employeeList: {
      type: Array,
      default: [],
    },
  },
  watch: {
  },
  async created() {
    this.arrayPinColumn = new Array(COUNT_HEADER_EMPLOYEES).fill(false);
    this.isShowPinIcon = new Array(COUNT_HEADER_EMPLOYEES).fill(false);
    this.listHeaders = DATA_GRID_TABLE_EMPLOYEES;
    this.dataPosition = (await getPositions()).data;
    this.dataDepartment = (await getDepartments()).data;
  },
  data() {
    return {
      searchMode: "searchMore",
      dataTable: DATA_GRID_TABLE_EMPLOYEES,
      tmpEmployees: [],
      dataCell: "",
      arrayPinColumn: [],
      isShowPinIcon: [],
      listHeaders: [],
      selectedRowsData: [],
      selectionChangedBySelectBox: false,
      prefix: "",
      dataPosition: [],
      dataDepartment: [],
      // employees: []
    };
  },
  methods: {
    /**
     * Chức năng ghim cột
     * Created: PQVINH(18/10/2022)
     */
    pinColumnData(data) {
      if (data.showPin == false) {
        this.arrayPinColumn = new Array(COUNT_HEADER_EMPLOYEES).fill(false);
        this.isShowPinIcon = new Array(COUNT_HEADER_EMPLOYEES).fill(false);
      } else {
        this.arrayPinColumn = new Array(COUNT_HEADER_EMPLOYEES).fill(false);
        this.isShowPinIcon = new Array(COUNT_HEADER_EMPLOYEES).fill(false);
        for (let i = 0; i < this.arrayPinColumn.length; i++) {
          if (i < data.pinding) {
            this.arrayPinColumn[i] = true;
            if (i == data.pinding - 1) {
              this.isShowPinIcon[i] = true;
            }
          }
        }
      }
    },
    /**
     * Chức năng ghim cột
     * Created: PQVINH(18/10/2022)
     */
    getPinProps(data) {
      const idx = this.listHeaders.findIndex(
        (ele) => ele.Field == data.column.name
      );
      if (this.isShowPinIcon[idx] === true) {
        return true;
      } else return false;
    },
    /**
     * Chức năng chọn bản ghi
     * Created: PQVINH(22/10/2022)
     */
    selectedRow({ selectedRowsData }) {
      console.log(selectedRowsData);
      if (!this.selectionChangedBySelectBox) {
        this.prefix = null;
      }

      this.selectedRowsData = selectedRowsData;
      this.selectionChangedBySelectBox = false;
      console.log(this.selectedRowsData);
      this.$emit("numberSelected", this.selectedRowsData);
      // if(this.isRenderEmployeeList == true){
      //   this.$router.push({name: 'edit', params: {data: selectedRowsData[0].ID}})
      // }
    },
    /**
     * Chức năng bỏ chọn bản ghi
     * Created: PQVINH(22/10/2022)
     */
    clearSelection() {
      const dataGrid = this.$refs[this.refText].instance;
      dataGrid.clearSelection();
    },
    /**
     * Chức năng gọi api lấy vị trí
     * Created: PQVINH(22/10/2022)
     */
    getPositionName(data) {
      if (this.dataPosition.find((p) => p.PositionID == data.value) != null) {
        return this.dataPosition.find((p) => p.PositionID == data.value)
          .PositionName;
      }
    },
    /**
     * Chức năng gọi api lấy phòng ban
     * Created: PQVINH(22/10/2022)
     */
    getDepartmentName(data) {
      if (
        this.dataDepartment.find((p) => p.DepartmentID == data.value) != null
      ) {
        return this.dataDepartment.find((p) => p.DepartmentID == data.value)
          .DepartmentName;
      }
    },
    deleteRequestDetail(e) {
      console.log(e);
      // this.employees = this.employees.filter(ele => {
      //   return ele.EmployeeId !== e.row.key;
      // })
      this.$emit('selectedEmployeesChanged', e.row.key);
    },
  },
  computed: {
    /**
     * Chức năng chọn bản ghi
     * Created: PQVINH(22/10/2022)
     */
    selectedRowKeys() {
      return this.selectedRowsData.map((employee) => employee.EmployeeCode);
    },
  },
};
</script>

<style>
.dx-checkbox.dx-state-focused .dx-checkbox-icon {
  border: 1px solid #ec554e !important;
}
.dx-checkbox.dx-state-hover .dx-checkbox-icon:hover {
  border: 1px solid #ec554e !important;
}
.dx-checkbox-checked .dx-checkbox-icon {
  font: 16px/1em DXIcons;
  color: #ec554e;
  text-align: center;
}
.dx-checkbox-indeterminate .dx-checkbox-icon::before {
  background-color: #ec554e !important;
}
.dx-datagrid-table
  .dx-data-row.dx-state-hover:not(.dx-selection):not(.dx-row-inserted):not(.dx-row-removed):not(.dx-edit-row):not(.dx-row-focused)
  > td:not(.dx-focused) {
  background-color: #ffede2 !important;
}
.dx-datagrid-content .dx-datagrid-table .dx-row.dx-data-row.dx-state-hover td {
  background-color: #ffede2 !important;
  cursor: pointer;
  color: #333;
}
.dx-datagrid-content .dx-datagrid-table .dx-row.dx-data-row.dx-state-hover td {
  background-color: #ffede2 !important;
  cursor: pointer;
  color: #333;
}
.dx-row.dx-selection:not(.dx-row-focused) td {
  background-color: #fff4e5 !important;
}
</style>

