<template>
  <div
    id="content-area"
    class="content-area-reduced m-l-255 m-l-0 content-area-trial"
  >
    <div id="main-content" class="content-wrapper">
      <div class="h-full container" style="padding: 16px 24px">
        <div class="content-header p-b-16">
          <div class="flex justify-between">
            <div class="flex" style="align-items: center">
              <h2>Đăng ký làm thêm</h2>
            </div>
            <div class="flex items-center">
              <router-link
                :to="{ name: 'edit', params: { data: 0 } }"
                class="ms-component ms-button ms-button-filled ms-button-primary"
                style="
                  width: auto !important;
                  height: 36px !important;
                  border-radius: 4px 0px 0px 4px;
                  padding: 0px 16px 0px 12px;
                  min-width: 0px !important;
                  display: flex;
                  justify-content: center;
                  align-items: center;
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
                <i
                  class="ms-icon ms-button--icon mi-plus-white"
                  style="
                    font-size: 16px;
                    color: #fff;
                    cursor: pointer;
                    order: 0;
                    margin-right: 4px;
                    margin-left: 0px;
                  "
                ></i>
                <span class="ms-button-text f-z-14"> Thêm </span>
              </router-link>
              <div class="flex items-center div-division">
                <div class="div-division-child"></div>
              </div>
              <button class="ms-con-dropdown parent-dropdown">
                <button
                  class="ms-component ms-button ms-button-filled ms-button-primary"
                  style="
                    width: 36px !important;
                    height: 36px !important;
                    border-radius: 0px 4px 4px 0px;
                    padding: 6px 5px;
                    min-width: 0px !important;
                  "
                >
                  <span
                    class="ms-button-backgroundx ms-button--background"
                    style="
                      opacity: 1;
                      left: 20px;
                      top: 20px;
                      width: 0px;
                      height: 0px;
                      transition: width 0.3s ease 0s, height 0.3s ease 0s,
                        opacity 0.3s ease 0s;
                    "
                  ></span>
                  <i
                    class="ms-icon notranslate icon-scale ms-button--icon feature mi-chevron-down-white 24px"
                    style="
                      font-size: 24px;
                      color: white;
                      cursor: pointer;
                      order: 0;
                      margin-right: 0px;
                      margin-left: 0px;
                    "
                  ></i>
                </button>
              </button>
            </div>
          </div>
        </div>
        <div class="content-grid">
          <div class="ms-grid-header">
            <div class="flex justify-between" style="width: 100%">
              <div class="ms-grid-left">
                <DxTextBox
                  placeholder="Tìm kiếm"
                  mode="search"
                  value-change-event="keyup"
                  @value-changed="valueChangedSearch"
                  v-show="requestSelected.length == 0 ? true : false"
                />
                <div
                  v-if="requestSelected.length > 0 ? true : false"
                  class="flex items-center"
                >
                  <div>
                    <span class="f-z-14"
                      >Đã chọn
                      <strong>{{ requestSelected.length }}</strong></span
                    >
                  </div>
                  <div style="cursor: pointer">
                    <span
                      @click="removeSelected"
                      class="f-z-14 c-red"
                      style="padding: 0 8px"
                      >Bỏ chọn</span
                    >
                  </div>
                  <button
                    class="ms-button btn-reject flex items-center p-r-8"
                    style="
                      width: auto !important;
                      height: 36px !important;
                      border-radius: 4px;
                      padding: 0px 16px 0px 12px;
                      min-width: 0px !important;
                    "
                    @click="rejectedSelection"
                  >
                    <i
                      class="ms-icon notranslate icon-scale ms-button--icon feature mi-rejected 24px"
                      style="
                        font-size: 24px;
                        color: white;
                        cursor: pointer;
                        order: 0;
                        margin-right: 0px;
                        margin-left: 0px;
                      "
                    ></i>
                    <span>Từ chối</span>
                  </button>
                  <button
                    class="ms-button btn-yes flex items-center p-r-8"
                    style="
                      width: auto !important;
                      height: 36px !important;
                      border-radius: 4px;
                      padding: 0px 16px 0px 12px;
                      min-width: 0px !important;
                    "
                    @click="approvedSelection"
                  >
                    <i
                      class="ms-icon notranslate icon-scale ms-button--icon feature mi-yes 24px"
                      style="
                        font-size: 24px;
                        color: white;
                        cursor: pointer;
                        order: 0;
                        margin-right: 0px;
                        margin-left: 0px;
                      "
                    ></i>
                    <span>Duyệt</span>
                  </button>
                  <!-- <button
                    class="ms-button btn-yes flex items-center p-r-8"
                    style="
                      width: auto !important;
                      height: 36px !important;
                      border-radius: 4px;
                      padding: 0px 16px 0px 12px;
                      min-width: 0px !important;
                    "
                  >
                    <i
                      class="ms-icon notranslate icon-scale ms-button--icon feature mi-yes 24px"
                      style="
                        font-size: 24px;
                        color: white;
                        cursor: pointer;
                        order: 0;
                        margin-right: 0px;
                        margin-left: 0px;
                      "
                    ></i>
                    <span>Xuất khẩu</span>
                  </button> -->
                  <button
                    class="ms-button btn-delete flex items-center"
                    style="
                      width: auto !important;
                      height: 36px !important;
                      border-radius: 4px;
                      padding: 0px 16px 0px 12px;
                      min-width: 0px !important;
                    "
                    @click="deleteMultipleRequests"
                  >
                    <i
                      class="ms-icon notranslate icon-scale ms-button--icon feature mi-delete 24px"
                      style="
                        font-size: 24px;
                        color: white;
                        cursor: pointer;
                        order: 0;
                        margin-right: 0px;
                        margin-left: 0px;
                      "
                    ></i>
                    <span>Xóa</span>
                  </button>
                </div>
              </div>
              <div
                class="ms-grid-right"
                v-show="requestSelected.length == 0 ? true : false"
              >
                <div class="ms-con-dropdown-status m-l-16">
                  <div class="flex align-center m-r-48">
                    <span
                      style="margin-right: 6px; color: gray; font-size: 14px"
                      >Trạng thái</span
                    >
                    <b style="font-size: 14px">Tất cả</b>
                    <div
                      class="mi-gd2 mi-16 mi-dropdown"
                      id="link1"
                      @click="toggleStatus"
                    >
                      <DxPopover
                        :min-width="112"
                        :visible="toggleStt"
                        target="#link1"
                        position="bottom"
                      >
                        <div
                          v-for="(item, index) in statusOptions"
                          :key="index"
                          class="flex items-center status"
                          :class="{
                            selected:
                              isSelected[index] ||
                              this.params.status == item.status,
                          }"
                        >
                          <span
                            @click="selectedStatus(item, index)"
                            class="p-d-8"
                            >{{ item.text }}</span
                          >
                          <span
                            class="icon-check"
                            :class="{
                              'mi-check-primary':
                                isSelected[index] ||
                                this.params.status == item.status,
                            }"
                          ></span>
                        </div>
                      </DxPopover>
                    </div>
                  </div>
                </div>
                <div class="ms-con-input-dropdown m-r-8">
                  <DxDropDownBox
                    v-model:value="params.departmentId"
                    v-model:opened="isTreeBoxOpened"
                    :show-clear-button="true"
                    :data-source="departments"
                    value-expr="DepartmentID"
                    display-expr="DepartmentName"
                    placeholder="Tất cả đơn vị"
                  >
                    <template #content="{}">
                      <DxTreeView
                        ref="treeView"
                        :items="departmentDataSource"
                        :select-by-click="true"
                        :search-enabled="true"
                        value-expr="DepartmentID"
                        display-expr="DepartmentName"
                        search-mode="contains"
                        selection-mode="single"
                        @content-ready="
                          $event.component.selectItem(params.departmentId)
                        "
                        :width="400"
                        @item-selection-changed="
                          treeView_itemSelectionChanged($event)
                        "
                        @item-click="onTreeItemClick($event)"
                      >
                        <DxSearchEditorOptions placeholder="Tìm kiếm" />
                      </DxTreeView>
                    </template>
                  </DxDropDownBox>
                </div>
                <div
                  @click="loadData"
                  class="ms-con-reload mi-36-con-icon m-r-8 flex"
                  id="reload"
                >
                  <div class="mi-reload"></div>
                </div>
                <DxTooltip
                  target="#reload"
                  show-event="dxhoverstart"
                  hide-event="dxhoverend"
                  contentTemplate="reload-tooltip"
                >
                  <template #reload-tooltip>
                    <p class="mi-tooltip">Tải lại</p>
                  </template>
                </DxTooltip>
                <!-- <div class="ms-con-filter mi-36-con-icon m-r-8 flex">
                  <div class="mi-filter"></div>
                </div> -->
                <div
                  @click="exportRequestData"
                  class="ms-con-export mi-36-con-icon m-r-8 flex"
                  id="export"
                >
                  <div class="mi-export"></div>
                </div>
                <DxTooltip
                  target="#export"
                  show-event="dxhoverstart"
                  hide-event="dxhoverend"
                  contentTemplate="export-tooltip"
                >
                  <template #export-tooltip>
                    <p class="mi-tooltip">Xuất khẩu</p>
                  </template>
                </DxTooltip>
                <!-- <m-custom-header
                  v-model:value="showCustomHeader"
                  :headers="headers"
                ></m-custom-header>
                <div
                  @click="openCustomHeader"
                  id="customheader"
                  class="ms-con-setting mi-36-con-icon flex"
                >
                  <div class="mi-setting"></div>
                </div> -->
              </div>
            </div>
          </div>
          <div class="ms-grid-container non-header">
            <m-grid-request
              @selectedRow="selectedRow"
              :requestList="requestList.Data"
              @deleteRequest="deleteRequest"
              @selectedSelection="selectedSelection"
              ref="gridDataRequest"
              refText="refGridRequest"
            ></m-grid-request>
            <m-paging
              @totalRecordOfPage="totalRecordOfPage"
              :requestList="requestList"
              @pagenation="pagenation"
            >
            </m-paging>
          </div>
        </div>
      </div>
    </div>
  </div>
  <DxLoadPanel
    :position="position"
    v-model:visible="isLoadding"
    :show-indicator="showIndicator"
    :show-pane="showPane"
    :shading="shading"
    :hide-on-outside-click="hideOnOutsideClick"
    :on-shown="onShown"
    :on-hidden="onHidden"
    shading-color="rgba(0,0,0,0.4)"
  />
</template>

<script>
import DxTextBox from "devextreme-vue/text-box";
import MGridRequest from "@/components/base/MGrid/MGridRequest.vue";
import MPaging from "@/components/base/MPaging/MPaging.vue";
import MStatus from "@/components/base/MStatus/MStatus.vue";
import MCustomHeader from "@/components/base/MGrid/MCustomHeader.vue";
import MHeaderCell from "@/components/base/MHeaderCell/MHeaderCell.vue";
import DxSelectBox from "devextreme-vue/select-box";
import RequestDetail from "@/view/request/RequestDetail.vue";
import { DxCheckBox } from "devextreme-vue/check-box";
import { DxDropDownBox } from "devextreme-vue/drop-down-box";
import { DxPopover } from "devextreme-vue/popover";
import { DxLoadPanel } from "devextreme-vue/load-panel";
import { DATA_GRID_TABLE, COUNT_HEADER, STATUS_OPTIONS } from "@/js/resource";
import { DEPARTMENTS_DROPDOWN } from "@/js/enum.js";
import { custom } from "devextreme/ui/dialog";
import notify from "devextreme/ui/notify";
import DxTreeView, { DxSearchEditorOptions } from "devextreme-vue/tree-view";
import { DxTooltip } from "devextreme-vue/tooltip";
import { getDepartments } from "@/axios/departmentController/departmentController.js";
import {
  getRequests,
  getRequestFilter,
  deleteRequest,
  deleteManyRequest,
  setStatusRejected,
  setStatusApproved,
  getRequestToExcel,
} from "@/axios/requestController/requestController.js";
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
    DxPopover,
    DxSelectBox,
    DxLoadPanel,
    DxDataGrid,
    DxPager,
    MCustomHeader,
    DxColumn,
    DxCheckBox,
    DxSelection,
    DxTooltip,
    DxScrolling,
    DxDropDownBox,
    DxColumnFixing,
    MGridRequest,
    RequestDetail,
    DxTreeView,
    DxSearchEditorOptions,
  },
  watch:{
    "params.departmentId":{
      handler(){
        this.params.pageNumber = 1;
        this.getRequest();
      }
    }
  },
  async created() {
    this.isLoadding = true;
    this.departments = (await getDepartments()).data;
    console.log(this.departments);
    this.departmentDataSource = DEPARTMENTS_DROPDOWN;
    console.log(this.departmentDataSource);
    console.log(this.departments);
    this.getRequest();
    this.isSelected = new Array(4).fill(false);
    this.isLoadding = true;
  },
  data() {
    return {
      requestList: [],
      showCustomHeader: false,
      params: {
        pageSize: 50,
        pageNumber: 1,
        requestFilter: "",
        status: -1,
        departmentId: null,
      },
      valueSearchInput: "",
      headers: DATA_GRID_TABLE,
      value: {},
      toggleStt: false,
      statusOptions: STATUS_OPTIONS,
      isSelected: [],
      employeeInfo: {},
      isLoadding: false,
      position: { of: "#content-area" },
      showIndicator: true,
      shading: true,
      showPane: true,
      hideOnOutsideClick: false,
      requestSelected: [],
      idRequests: [],
      isTreeBoxOpened: false,
      departmentDataSource: null,
      departments: [],
      isShowNav: true,
      isShowTool: false,
      positionToast: "bottom right",
      directionToast: "left-push",
    };
  },
  methods: {
    /**
     * Chức năng gọi API lấy data
     * Created: PQVINH(24/10/2022)
     */
    loadData() {
      this.getRequest();
    },
    /**
     * Chức năng gọi API lấy data
     * Created: PQVINH(24/10/2022)
     */
    async getRequest() {
      console.log(this.params);
      try {
        this.isLoadding = true;
        const res = await getRequestFilter(this.params);
        if (res) {
          this.requestList = res.data;
          console.log(this.requestList);
        }
        this.isLoadding = false;
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Chức năng lấy số bản ghi 1 trang
     * Created: PQVINH(24/10/2022)
     */
    totalRecordOfPage(data) {
      this.params.pageSize = data;
      this.params.pageNumber = 1;
      this.getRequest();
    },
    /**
     * Chức năng tìm kiếm
     * Created: PQVINH(24/10/2022)
     */
    valueChangedSearch: function (e) {
      this.params.requestFilter = e.value;
      this.params.pageNumber = 1;
      this.getRequest();
    },
    /**
     * Chức năng hiển thị trạng thái
     * Created: PQVINH(24/10/2022)
     */
    toggleStatus() {
      this.toggleStt = !this.toggleStt;
    },
    /**
     * Chức năng gọi API lấy data theo trạng thái
     * Created: PQVINH(24/10/2022)
     */
    selectedStatus(item, index) {
      this.toggleStt = false;
      this.isSelected = new Array(4).fill(false);
      this.isSelected[index] = true;
      this.params.status = item.status;
      this.params.pageNumber = 1;
      console.log(this.params.status);
      this.getRequest();
    },
    /**
     * Chức năng lấy số bản ghi trang hiện tại
     * Created: PQVINH(24/10/2022)
     */
    pagenation(curentPage) {
      this.params.pageNumber = curentPage;
      this.getRequest();
    },
    /**
     * Chức năng xóa request
     * Created: PQVINH(24/10/2022)
     */
    async deleteRequest(data) {
      try {
        this.isLoadding = true;
        let res = await deleteRequest(data);
        this.getRequest();
        const positionToast = "bottom right";
        const directionToast = "left-push";
        notify(
          {
            message: "Xóa thành công",
            height: 45,
            width: 250,
            minWidth: 150,
            type: "success",
            displayTime: 2000,
            animation: {
              show: {
                type: "fade",
                duration: 400,
                from: 0,
                to: 1,
              },
              hide: { type: "fade", duration: 40, to: 0 },
            },
          },
          { positionToast, directionToast }
        );
        this.isLoadding = false;
      } catch (error) {
        console.log(error);
      }
    },
    /**
     * Chức năng chọn bản ghi
     * Created: PQVINH(24/10/2022)
     */
    selectedSelection(data) {
      this.requestSelected = data;
    },
    /**
     * Chức năng bỏ chọn
     * Created: PQVINH(24/10/2022)
     */
    removeSelected() {
      this.$refs.gridDataRequest.clearSelection();
    },
    /**
     * Chức năng gọi API xóa nhiều
     * Created: PQVINH(31/10/2022)
     */
    deleteMultipleRequests: function () {
      this.$nextTick(function () {
        let myDialog = custom({
          title: "Cảnh báo",
          messageHtml: "<b>Bạn có chắc muốn xóa những đơn này không?</b>",
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
            try {
              this.isLoadding = true;
              this.requestSelected.forEach((element) => {
                this.idRequests.push(element.RequestID);
              });
              let res = await deleteManyRequest(this.idRequests);
              this.getRequest();
              const positionToast = "bottom right";
              const directionToast = "left-push";
              notify(
                {
                  message: "Xóa thành công",
                  height: 45,
                  width: 250,
                  minWidth: 150,
                  type: "success",
                  displayTime: 2000,
                  animation: {
                    show: {
                      type: "fade",
                      duration: 400,
                      from: 0,
                      to: 1,
                    },
                    hide: { type: "fade", duration: 40, to: 0 },
                  },
                },
                { positionToast, directionToast }
              );
              this.isLoadding = false;
            } catch (error) {
              console.log(error);
            }
          }
        });
      });
    },
    /**
     * Chức năng từ chối
     * Created: PQVINH(31/10/2022)
     */
    rejectedSelection: function () {
      this.$nextTick(function () {
        let myDialog = custom({
          title: "Cảnh báo",
          messageHtml: "<b>Bạn có chắc muốn từ chối những đơn này không?</b>",
          buttons: [
            {
              text: "Hủy",
              value: 0,
              onClick: (e) => {
                return { buttonText: e.component.option("value") };
              },
            },
            {
              text: "Từ chối",
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
            this.isLoadding = true;
            try {
              this.requestSelected.forEach((element) => {
                this.idRequests.push(element.RequestID);
              });
              let res = await setStatusRejected(this.idRequests);
              const positionToast = "bottom right";
              const directionToast = "left-push";
              notify(
                {
                  message: "Từ chối thành công",
                  height: 45,
                  width: 250,
                  minWidth: 150,
                  type: "success",
                  displayTime: 2000,
                  animation: {
                    show: {
                      type: "fade",
                      duration: 400,
                      from: 0,
                      to: 1,
                    },
                    hide: { type: "fade", duration: 40, to: 0 },
                  },
                },
                { positionToast, directionToast }
              );
              this.getRequest();
              this.isLoadding = false;
            } catch (error) {
              console.log(error);
            }
          }
        });
      });
    },
    /**
     * Chức năng duyệt
     * Created: PQVINH(31/10/2022)
     */
    approvedSelection: function () {
      this.$nextTick(function () {
        let myDialog = custom({
          title: "Cảnh báo",
          messageHtml: "<b>Bạn có chắc muốn duyệt những đơn này không?</b>",
          buttons: [
            {
              text: "Hủy",
              value: 0,
              onClick: (e) => {
                return { buttonText: e.component.option("value") };
              },
            },
            {
              text: "Duyệt",
              value: 1,
              type: "success",
              onClick: (e) => {
                return { buttonText: e.component.option("value") };
              },
            },
          ],
        });
        myDialog.show().then(async (dialogResult) => {
          if (dialogResult.buttonText == 1) {
            this.isLoadding = true;
            try {
              this.requestSelected.forEach((element) => {
                this.idRequests.push(element.RequestID);
              });
              let res = await setStatusApproved(this.idRequests);
              const positionToast = "bottom right";
              const directionToast = "left-push";
              notify(
                {
                  message: "Duyệt thành công",
                  height: 45,
                  width: 250,
                  minWidth: 150,
                  type: "success",
                  displayTime: 2000,
                  animation: {
                    show: {
                      type: "fade",
                      duration: 400,
                      from: 0,
                      to: 1,
                    },
                    hide: { type: "fade", duration: 40, to: 0 },
                  },
                },
                { positionToast, directionToast }
              );
              this.getRequest();
              this.isLoadding = false;
            } catch (error) {
              console.log(error);
            }
          }
        });
      });
    },
    /**
     * Chức năng selectBox
     * Created: PQVINH(31/10/2022)
     */
    treeView_itemSelectionChanged(e) {
      this.params.departmentId = e.itemData.DepartmentId;
      console.log(this.params.departmentId);
      this.params.pageNumber = 1;
      this.getRequest();
    },
    /**
     * Chức năng selectBox
     * Created: PQVINH(31/10/2022)
     */
    onTreeItemClick(e) {
      console.log(e);
      this.params.pageNumber = 1;
      this.isTreeBoxOpened = false;
    },
    async exportRequestData() {
      try {
        this.isloadding = true;
        var res = await getRequestToExcel();
        const url = URL.createObjectURL(new Blob([res.data]), {
          type: "application/vnd.ms-excel",
        });
        const link = document.createElement("a");
        link.href = url;
        const filename = `DanhSachDonLamThem.xlsx`;
        link.setAttribute("download", filename);
        document.body.appendChild(link);
        link.click();
        link.remove();
        this.isloadding = false;
      } catch (error) {
        console.log(error);
      }
    },
    openCustomHeader() {
      this.showCustomHeader = true;
    },
  },
};
</script>

<style>
@import url(@/css/main.css);
#content-area {
  top: 58px;
  position: relative;
  height: calc(100vh - 58px) !important;
}
.content-area-trial {
  height: calc(100% -50px) !important;
}
.m-l-0 {
  margin-left: 0px !important;
}
#content-area .content-wrapper {
  height: 100%;
}
#main-content {
  background-color: #eee;
}
.mi-plus {
  background-position: -192px -24px;
  background: #fff !important;
}
.ms-icon {
  color: #afb3c1;
  text-align: center;
  font-size: 16px;
}
.ms-button--icon {
  z-index: 10;
  display: block;
  position: relative;
  font-size: 20px;
}
.mi-chevron-down-white {
  background-position: -199px -9px;
  background-color: #fff !important;
}
.content-main {
  overflow-x: hidden;
  overflow-y: auto;
  width: 100%;
  border-radius: 4px;
  display: flex;
}

.content-grid {
  height: calc(100vh - 142px);
}
.content-grid .ms-grid-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 0 16px;
  height: 60px;
  background-color: #fff;
}
.ms-grid-header .ms-grid-left {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 36px;
}
.mi-plus-white {
  width: 24px;
  height: 24px;
  -webkit-mask-position: -192px -24px;
  -webkit-mask-repeat: no-repeat;
}
.mi-plus-white {
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  background-color: #fff !important;
}
.mi-chevron-down-white {
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  background-color: #fff !important;
}
.mi-chevron-down-white {
  width: 24px;
  height: 24px;
  -webkit-mask-position: -192px 0;
  -webkit-mask-repeat: no-repeat;
}
.ms-grid-header .ms-grid-right {
  display: flex;
  justify-content: center;
  align-items: center;
}
.m-l-16 {
  margin-left: 16px;
}
.mi-dropdown {
  background-position: -98px -50px;
}
.mi-16 {
  width: 16px;
  height: 16px;
}
.m-r-48 {
  margin-right: 48px;
}
.m-r-8 {
  margin-right: 8px;
}
.mi-36-con-icon {
  width: 36px;
  height: 36px;
  -webkit-box-pack: center;
  justify-content: center;
  border-radius: 4px;
  border: 1px solid #e0e0e0;
  align-items: center;
}
.mi-36-con-icon:hover {
  border-color: #ec554e !important;
}
.p-r-8 {
  margin-right: 8px !important;
}
.mi-check-primary {
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  background-color: #ec554e !important;
  width: 24px;
  height: 24px;
  -webkit-mask-position: -216px -48px;
  -webkit-mask-repeat: no-repeat;
}
.selected .icon-check {
  position: relative;
  right: 8px;
}
.mi-reload {
  background-color: #666 !important;
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -48px 0;
}
.dx-overlay-shader{
  background: rgba(0,0,0,.4) !important;
}
.mi-reload:hover {
  background-color: #ec554e !important;
}
.mi-filter {
  background-color: #666 !important;
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -240px -48px;
}
.mi-filter:hover {
  background-color: #ec554e !important;
}
.mi-export {
  background-color: #666 !important;
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -24px -24px;
}
.p-d-8 {
  padding: 0 8px;
}
.mi-export:hover {
  background-color: #ec554e !important;
}
.mi-setting {
  background-color: #666 !important;
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -216px -24px;
}
.mi-setting:hover {
  background-color: #ec554e !important;
}
.status {
  height: 37px !important;
  cursor: pointer;
}
.status:hover {
  background-color: #ffede2;
}
.selected {
  background-color: #ffede2;
  color: #ec554e;
}
.justify-center {
  justify-content: center;
}
.non-header {
  height: calc(100% - 68px);
  border: none !important;
  box-shadow: 0 2px 6px 0 rgb(0 0 0 / 6%);
}
.dx-popup-wrapper > .dx-overlay-content{
  /* width: 415px !important; */
  /* top: -66% !important; */
}
.dx-toolbar-label > div{
  color: #212121;
}
.custom-grid {
  display: flex;
  align-items: flex-end;
  width: 100%;
  height: calc(100% - 70px);
  max-width: 100% !important;
}
.dx-popup-content {
  padding: 8px !important;
}
.btn-reject {
  color: #f44336 !important;
  border: 1px solid #f44336 !important;
  background-color: #fff !important;
}
.mi-rejected {
  width: 24px;
  height: 24px;
  background: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg) -168px -96px
    no-repeat;
}
.dx-overlay-content.dx-popup-normal.dx-resizable.dx-popup-flex-height{
  width: 400px !important;
}
.dx-treeview-search.dx-show-invalid-badge.dx-textbox.dx-texteditor.dx-editor-outlined.dx-searchbox.dx-show-clear-button.dx-texteditor-empty.dx-widget{
  width: 350px !important;
}
.btn-yes {
  color: #00c853 !important;
  border: 1px solid #00c853 !important;
  background-color: #fff !important;
}
.mi-yes {
  width: 24px;
  height: 24px;
  background: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg) -192px -96px
    no-repeat;
}
.btn-delete {
  background-color: #fff;
  color: #ef292f;
  border: 1px solid #ef292f;
}
.mi-delete {
  width: 24px;
  height: 24px;
  background: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg) -168px -24px
    no-repeat;
}
.dx-treeview-item-without-checkbox.dx-state-focused > .dx-treeview-item {
  background-color: #ec5504;
  color: #fff;
}
</style>
