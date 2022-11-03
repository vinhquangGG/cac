<template>
  <DxDataGrid
    :data-source="requestList"
    key-expr="RequestID"
    :selection="{ mode: 'single' }"
    :column-auto-width="true"
    :allow-column-reordering="true"
    :show-borders="true"
    :hover-state-enabled="true"
    :ref="refText"
    :selected-row-keys="selectedRowKeys"
    @row-click="selectedRow"
    @selection-changed="selectedSelection"
  >
    <DxGrouping :context-menu-enabled="true" expand-mode="rowClick" />
    <!-- <DxGroupPanel
      :visible="true"
      empty-panel-text="Use the context menu of header columns to group data"
    /> -->
    <DxPaging :enabled="false" />

    <DxEditing :allow-updating="true" :allow-deleting="true"/>
    <DxSelection mode="multiple" />
    <!-- <DxColumnChooser :enabled="true" mode="select" /> -->
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
    ></DxColumn>
    
    <DxColumn type="buttons" :width="100" caption="">
      <DxButton
        name="edit"
        id="edit-button"
        icon="edit"
        @click="editRequest"
        css-class="command-button"
        :fixed="true"
        hint="Sửa"
      ></DxButton>
      <DxButton
        id="delete-button"
        icon="trash"
        @click="deleteRequest"
        css-class="command-button"
        :fixed="true"
        hint="Xóa"
      ></DxButton>
    </DxColumn>
    <template #grid-cell-status="{ data }">
      <m-status :data="data"></m-status>
    </template>
    <template #cell-application-people="{ data }">
      <m-avata
        :dataFullName="data.value"
        :isWidth="24"
        :isHeight="24"
      ></m-avata>
    </template>
    <template #cell-position="{ data }">
      <div>{{ getPositionName(data) }}</div>
    </template>
    <template #cell-department="{ data }">
      <div>{{ getDepartmentName(data) }}</div>
    </template>
    <template #header-cell="{ data }">
      <m-header-cell
        @pinColumnData="pinColumnData"
        :data="data"
        :isPin="getPinProps(data)"
      />
    </template>
    <template #grid-cell-worktime="{ data }">
      <m-worktime :dataCell="data"></m-worktime>
    </template>
    <template #grid-cell-overtime="{ data }">
      <m-overtime :dataCell="data"></m-overtime>
    </template>
    <DxScrolling column-rendering-mode="virtual" />
  </DxDataGrid>
</template>

<script>
import DxTextBox from "devextreme-vue/text-box";
import MStatus from "@/components/base/MStatus/MStatus.vue";
import MHeaderCell from "@/components/base/MHeaderCell/MHeaderCell.vue";
import MAvata from "@/components/base/MAvata/MAvata.vue";
import MWorktime from "@/components/base/MCellGrid/MWorktime.vue";
import MOvertime from "@/components/base/MCellGrid/MOvertime.vue";
import DxSelectBox from "devextreme-vue/select-box";
import { DATA_GRID_TABLE, COUNT_HEADER } from "@/js/resource";
import { getPositions } from "@/axios/positionController/positionController.js";
import { getDepartments } from "@/axios/departmentController/departmentController.js";
import { custom } from "devextreme/ui/dialog";
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
  DxRowDragging,
  DxGrouping,
  DxGroupPanel,
  DxColumnChooser,
} from "devextreme-vue/data-grid";
export default {
  components: {
    DxTextBox,
    MStatus,
    MHeaderCell,
    DxSelectBox,
    DxDataGrid,
    DxPager,
    DxEditing,
    DxRowDragging,
    MAvata,
    DxColumn,
    DxCheckBox,
    DxGrouping,
    DxGroupPanel,
    DxSelection,
    DxScrolling,
    DxColumnFixing,
    DxPaging,
    DxButton,
    MWorktime,
    MOvertime,
    DxColumnChooser,
  },
  props: {
    refText: String,
    employeeDetails: {
      type: Array,
      default: [],
    },
    requestList: {
      type: Array,
      default: [],
    },
  },
  watch: {
    "requestList.length": {
      handler() {
        console.log(this.requestList);
      },
    },
  },
  async created() {
    console.log(this.requestList);
    this.arrayPinColumn = new Array(COUNT_HEADER).fill(false);
    this.isShowPinIcon = new Array(COUNT_HEADER).fill(false);
    this.listHeaders = DATA_GRID_TABLE;
    this.dataPosition = (await getPositions()).data;
    this.dataDepartment = (await getDepartments()).data;
  },
  data() {
    return {
      searchMode: "searchMore",
      dataTable: DATA_GRID_TABLE,
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
      showDragIcons: true,
    };
  },
  watch: {},
  methods: {
    /**
     * Chức năng ghim cột
     * Created: PQVINH(18/10/2022)
     */
    pinColumnData(data) {
      if (data.showPin == false) {
        this.arrayPinColumn = new Array(COUNT_HEADER).fill(false);
        this.isShowPinIcon = new Array(COUNT_HEADER).fill(false);
      } else {
        this.arrayPinColumn = new Array(COUNT_HEADER).fill(false);
        this.isShowPinIcon = new Array(COUNT_HEADER).fill(false);
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
     * Chức năng gọi router để chuyển trang sang form detail
     * Created: PQVINH(23/10/2022)
     */
    selectedRow(e) {
      this.$router.push({ name: "edit", params: { data: e.key } });
    },
    /**
     * Chức năng selected bản ghi
     * Created: PQVINH(23/10/2022)
     */
    selectedSelection({ selectedRowsData }) {
      // if (!this.selectionChangedBySelectBox) {
      //   this.prefix = null;
      // }
      this.selectedRowsData = selectedRowsData;
      this.$emit("selectedSelection", selectedRowsData);
      // this.selectionChangedBySelectBox = false;
      console.log(selectedRowsData);
    },
    /**
     * Chức năng bỏ chọn bản ghi
     * Created: PQVINH(23/10/2022)
     */
    clearSelection() {
      const dataGrid = this.$refs[this.refText].instance;
      dataGrid.clearSelection();
    },
    /**
     * Chức năng gọi API lấy vị trí
     * Created: PQVINH(24/10/2022)
     */
    getPositionName(data) {
      if (this.dataPosition.find((p) => p.PositionID == data.value) != null) {
        return this.dataPosition.find((p) => p.PositionID == data.value)
          .PositionName;
      }
    },
    /**
     * Chức năng gọi API lấy phòng ban
     * Created: PQVINH(24/10/2022)
     */
    getDepartmentName(data) {
      if (
        this.dataDepartment.find((p) => p.DepartmentID == data.value) != null
      ) {
        return this.dataDepartment.find((p) => p.DepartmentID == data.value)
          .DepartmentName;
      }
    },
    /**
     * Chức năng click chọn request để edit
     * Created: PQVINH(24/10/2022)
     */
    editRequest(e) {
      this.$router.push({ name: "edit", params: { data: e.row.key } });
    },
    /**
     * Chức năng xóa request
     * Created: PQVINH(24/10/2022)
     */
    deleteRequest: function (e) {
      const requestID = e.row.key;
      console.log(e);
      this.$nextTick(function (e) {
        let myDialog = custom({
          title: "Cảnh báo",
          messageHtml: "<b>Bạn có chắc muốn xóa đơn này không?</b>",
          buttons: [
            {
              text: "Hủy",
              value: 0,
              onClick: (e) => {
                return { buttonText: e.component.option("value") };
              },
            },
            {
              text: "Xóa",
              value: 1,
              type: "danger",
              onClick: (e) => {
                return { buttonText: e.component.option("value") };
              },
            },
          ],
        });
        myDialog.show().then(async (dialogResult) => {
          if (dialogResult.buttonText == 1) {
            this.$emit("deleteRequest", requestID);
          } else {
          }
        });
      });
    },
    onReorder(e) {
      const visibleRows = e.component.getVisibleRows();
      const toIndex = this.requestList.findIndex(
        (item) => item.ID === visibleRows[e.toIndex].data.ID
      );
      const fromIndex = this.requestList.findIndex(
        (item) => item.ID === e.itemData.ID
      );
      const newrequestList = [...this.requestList];

      newrequestList.splice(fromIndex, 1);
      newrequestList.splice(toIndex, 0, e.itemData);

      this.requestList = newrequestList;
    },
  },
  computed: {
    /**
     * Chức năng chọn bản ghi
     * Created: PQVINH(24/10/2022)
     */
    selectedRowKeys() {
      return this.selectedRowsData.map((request) => request.RequestID);
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
.dx-datagrid-table .dx-data-row.dx-selection {
  background-color: #ffede2 !important;
}
.dx-datagrid-content .dx-datagrid-table .dx-row.dx-data-row.dx-selection td {
  background-color: #ffede2 !important;
  cursor: pointer;
  color: #333;
}
.dx-row.dx-selection:not(.dx-row-focused) td {
  background-color: #fff4e5 !important;
}
.dx-datagrid
  .dx-datagrid-content
  .dx-datagrid-table
  .dx-row
  .dx-command-edit-with-icons
  .dx-link {
  width: 24px !important;
  height: 24px !important;
  border-radius: 50% !important;
  background: #fff !important;
  padding-top: 4px;
  margin: 0 !important;
}

.dx-icon-edit::before {
  color: #000;
}
.dx-icon-trash::before {
  color: #ec554e;
}
.dx-command-edit {
  visibility: hidden;
}

.dx-data-row.dx-state-hover:not(.dx-row-inserted):not(.dx-row-removed):not(.dx-edit-row)
  > td:not(.dx-focused)
  .command-button,
.dx-data-row.dx-state-hover:not(.dx-row-inserted):not(.dx-row-removed):not(.dx-edit-row)
  .dx-command-edit {
  visibility: visible !important;
}
.dx-datagrid-headers {
  background-color: #f5f5f5 !important;
  
  border-bottom: none !important;
}
.dx-datagrid-borders > .dx-datagrid-headers {
    border-top: none !important;
}
</style>
