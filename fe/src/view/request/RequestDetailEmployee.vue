<template>
  <div class="ms-component con-ms-popup popup--choose-employee">
    <div class="ms-popup--background">
      <div
        class="ms-popup flex flex-col"
        style="
          background: rgb(255, 255, 255);
          width: 900px;
          height: 665px;
          top: 50%;
          left: 50%;
          transform: translate(-50%, -50%);
        "
      >
        <div
          class="container"
          style="padding: 16px 24px; height: calc(100% - 68px) !important"
        >
          <div class="content-header p-b-16">
            <div class="flex justify-between">
              <div class="flex" style="align-items: center">
                <h2>Chọn nhân viên</h2>
              </div>
              <div
                @click="closeFormAddEmployee"
                class="hover-show flex justify-between items-center"
              >
                <i
                  class="ms-popup-close ms-icon mi-close"
                  style="color: rgb(145, 151, 175) !important; cursor: pointer"
                ></i>
              </div>
            </div>
          </div>
          <div class="content-grid">
            <div class="ms-grid-header" style="padding: 0">
              <div class="ms-grid-left">
                <div class="tool-search">
                  <DxTextBox
                    placeholder="Tìm kiếm"
                    mode="search"
                    value-change-event="keyup"
                    @value-changed="valueChangedSearchEmp"
                  />
                </div>
                <!-- <div class="ms-con-input-dropdown m-r-8">
                  <DxSelectBox
                    :items="['contains', 'startsWith', 'equals']"
                    v-model:value="searchMode"
                    placeholder="Tất cả đơn vị"
                  />
                </div> -->
                <div
                  v-if="SelectedRecord.length > 0 ? true : false"
                  class="flex"
                >
                  <div>
                    <span class="f-z-14"
                      >Đã chọn
                      <strong>{{ SelectedRecord.length }}</strong></span
                    >
                  </div>
                  <div>
                    <span
                      @click="removeSelected"
                      class="f-z-14 c-red"
                      style="padding-left: 8px"
                      >Bỏ chọn</span
                    >
                  </div>
                </div>
              </div>
            </div>
            <div class="ms-grid-container non-header">
              <m-grid-employee
                ref="gridDataDetailEmpl"
                refText="refGridDetailEmpl"
                :employeeList="employeeList.Data"
                @numberSelected="numberSelected"
              ></m-grid-employee>
              <m-paging
                @totalRecordOfPage="totalRecordOfPage"
                :requestList="employeeList"
                @pagenation="pagenation"
              >
              </m-paging>
            </div>
          </div>
        </div>
        <div class="ms-popup--footer borderFooter">
          <button
            @click="closeFormAddEmployee"
            class="ms-component ms-button ms-button-filled ms-button-primary"
            style="
              width: 80px !important;
              height: 36px !important;
              border-radius: 4px;
              padding: 0px 16px;
              min-width: 0px !important;
              background-color: #fff !important;
              color: #212121;
              border: 1px solid #ddddeb;
              margin-right: 8px;
            "
          >
            <span
              class="ms-button-backgroundx ms-button--background"
              style="
                opacity: 1;
                left: 22px;
                top: 13px;
                width: 0px;
                height: 0px;
                transition: width 0s ease 0s, height 0s ease 0s,
                  opacity 0s ease 0s;
              "
            ></span>
            <span class="ms-button-text"> Hủy </span>
          </button>
          <div @click="renderSelectedEmployee" style="cursor: pointer">
            <button disabled="true" class="ms-con-dropdown parent-dropdown">
              <button
                class="ms-component ms-button ms-button-filled ms-button-primary"
                style="
                  width: 80px !important;
                  height: 36px !important;
                  border-radius: 4px;
                  padding: 0px 16px;
                  min-width: 0px !important;
                "
              >
                <span
                  class="ms-button-backgroundx ms-button--background f-z-14"
                  style="
                    opacity: 1;
                    left: 20px;
                    top: 20px;
                    width: 0px;
                    height: 0px;
                    transition: width 0.3s ease 0s, height 0.3s ease 0s,
                      opacity 0.3s ease 0s;
                  "
                  >Chọn</span
                >
              </button>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DxTextBox from "devextreme-vue/text-box";
import MGridEmployee from "@/components/base/MGrid/MGridEmployee.vue";
import MPaging from "@/components/base/MPaging/MPaging.vue";
import MStatus from "@/components/base/MStatus/MStatus.vue";
import MHeaderCell from "@/components/base/MHeaderCell/MHeaderCell.vue";
import DxSelectBox from "devextreme-vue/select-box";
import RequestDetail from "@/view/request/RequestDetail.vue";
import { DATA_GRID_TABLE_EMPLOYEES } from "@/js/resource";
import { DxCheckBox } from "devextreme-vue/check-box";
import {
  getEmployees,
  getAllNotInEmployee,
  getEmployeesFilter,
} from "@/axios/employeeController/employeeController.js";
import {
  DxDataGrid,
  DxColumn,
  DxSelection,
  DxPager,
  DxScrolling,
  DxColumnFixing,
} from "devextreme-vue/data-grid";
export default {
  components: {
    DxTextBox,
    MPaging,
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
    MGridEmployee,
    RequestDetail,
  },
  async created() {
    this.params.id = "('" + this.idEmployees.join("','") + "')";
    this.getEmployees();
    // this.employeeList = (await getAllNotInEmployee(this.idEmployees)).data;
  },
  props: {
    idEmployees: {
      type: Array,
      default: [],
    },
  },
  data() {
    return {
      isChoose: false,
      SelectedRecord: [],
      employeeList: [],
      params: {
        pageSize: 50,
        pageNumber: 1,
        employeeFilter: "",
        id: []
      },
    };
  },
  methods: {
    /**
     * Chức năng đóng form thêm nhân viên làm thêm
     * Created: PQVINH(30/10/2022)
     */
    closeFormAddEmployee() {
      this.$emit("closeFormAddEmployee");
    },
    async getEmployees() {
      try {
        this.isLoadding = true;
        const res = await getEmployeesFilter(this.params);
        this.employeeList = res.data;
        console.log(this.employeeList);
        this.isLoadding = false;
      } catch (error) {
        console.log(error);
      }
    },
    pagenation(curentPage){
      this.params.pageNumber = curentPage;
      this.getEmployees();
    },
    totalRecordOfPage(data) {
      this.params.pageSize = data;
      this.params.pageNumber = 1;
      this.getEmployees();
    },
    /**
     * Chức năng đóng form thêm nhân viên làm thêm và số nhân viên đã chọn
     * Created: PQVINH(30/10/2022)
     */
    renderSelectedEmployee() {
      this.$emit("closeFormAddEmployee", this.SelectedRecord);
    },
    /**
     * Chức năng chọn nhân viên
     * Created: PQVINH(30/10/2022)
     */
    numberSelected(data) {
      this.SelectedRecord = data;
    },
    /**
     * Chức năng bỏ chọn nhân viên
     * Created: PQVINH(30/10/2022)
     */
    removeSelected() {
      this.$refs.gridDataDetailEmpl.clearSelection();
    },
    
  },
};
</script>

<style>
.ms-popup--background {
  width: 100%;
  background: rgba(0, 0, 0, 0.4);
  position: absolute;
  top: 0;
  height: 100%;
  z-index: 10;
  -webkit-transition: all 0.25s ease;
  transition: all 0.25s ease;
  opacity: 1;
}
.con-ms-popup .ms-popup {
  position: relative;
  -webkit-transition: all 0.2s;
  transition: all 0.2s;
  z-index: 100;
  width: 600px;
  margin: 10px;
  max-width: calc(100% - 30px);
  max-height: calc(100% - 30px);
  border-radius: 6px;
  -webkit-box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  background: #fff;
  -webkit-animation: rebound-data-v-8c0c0dc4 0.3s;
  animation: rebound-data-v-8c0c0dc4 0.3s;
  overflow: visible;
}
.flex-col {
  flex-direction: column !important;
}
.popup-choose-employee {
  z-index: 9999999 !important;
}
.con-ms-popup {
  -webkit-transition: all 0.2s;
  transition: all 0.2s;
  width: 100%;
  height: 100%;
  position: fixed;
  top: 0;
  z-index: 11;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  -webkit-box-align: start;
  -ms-flex-align: start;
  align-items: flex-start;
  padding-top: 70px;
  -webkit-box-pack: center;
  -ms-flex-pack: center;
  justify-content: center;
  opacity: 1;
}
.ms-popup--background
  .dx-gridbase-container
  > .dx-datagrid-rowsview.dx-scrollable {
  height: 385.6667px !important;
}
.borderFooter {
  border-top: 1px solid #dadce3;
}
.ms-popup--footer {
  display: flex;
  -webkit-box-pack: end;
  justify-content: flex-end;
  padding: 16px 24px;
  border-radius: 0 0 4px 4px;
  height: 68px;
  background-color: #f2f2f2;
}
.ms-popup--background .dx-datagrid {
  height: 385.6667px;
}
.ms-popup--background .dx-texteditor.dx-editor-outlined {
  margin-right: 10px;
}
.ms-popup-close {
  transition: all 0.23s ease 0.1s;
  position: relative;
  border-radius: 4px;
  font-size: 24px;
}
.mi-close {
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -24px -48px;
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  background-color: #666 !important;
}
.hover-show {
  padding: 6px;
}
.hover-show:hover {
  background: rgb(228, 230, 238);
  border-radius: 50%;
}
.tool-search .dx-texteditor.dx-editor-outlined {
  width: 240px !important;
}
.c-red {
  color: #f84856;
}
</style>
