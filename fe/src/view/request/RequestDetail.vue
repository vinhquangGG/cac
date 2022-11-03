<template>
  <div
    id="content-area"
    class="content-area-reduced m-l-255 m-l-0 content-area-trial"
  >
    <div id="main-content" class="content-wrapper">
      <div class="h-full container" style="padding: 16px 24px">
        <div class="content-header p-b-16">
          <div class="flex justify-between">
            <router-link
              to="/quan-li-don"
              class="flex"
              style="align-items: center"
            >
              <div class="mi-arrow-left m-r-12"></div>
              <h2>Thêm mới đăng ký làm thêm</h2>
            </router-link>
            <div class="flex">
              <div v-if="isShowByAdd" class="flex">
                <router-link to="/quan-li-don" class="flex items-center">
                  <button
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
                </router-link>
                <DxButton
                  id="save"
                  :width="80"
                  class="btn-save"
                  :height="36"
                  :on-click="btnSaveClick"
                >
                  <template #content>
                    <span>
                      <DxLoadIndicator
                        :visible="isLoadding"
                        class="button-indicator"
                      />
                      <span class="dx-button-text" v-if="!isLoadding">Lưu</span>
                    </span>
                  </template>
                </DxButton>
              </div>
              <div></div>
              <button
                v-show="isShowByEdit"
                class="ms-con-dropdown parent-dropdown"
                @click="isEdit"
              >
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
                    >Sửa</span
                  >
                </button>
              </button>
            </div>
          </div>
        </div>
        <div
          class="content-main"
          style="background: transparent; height: calc(100vh - 200px)"
        >
          <div class="h-full w-full ms-form">
            <div class="p-24 b-white">
              <div>
                <div
                  class="ms-row flex justify-between m-b-0"
                  style="
                    display: flex;
                    width: 100%;
                    line-height: 35px;
                    text-indent: 0px;
                    padding: 0px;
                    margin-bottom: 16px;
                  "
                >
                  <div class="ms-col">
                    <div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Người nộp đơn</b
                          ><span class="text-danger">*</span></label
                        >
                        <DxSelectBox
                          :data-source="employees"
                          v-model:value="selectedRequest.EmployeeID"
                          display-expr="FullName"
                          value-expr="EmployeeID"
                          placeholder=""
                          :search-enabled="true"
                          item-template="item"
                          @value-changed="onValueChangedName"
                          :disabled="isView"
                          :deferRendering="false"
                          :onContentReady="selectboxEmployee"
                        >
                          <DxValidator>
                            <DxRequiredRule message="Không được để trống" />
                          </DxValidator>
                          <template #item="{ data }">
                            <m-avata
                              :dataFullName="data.FullName"
                              :isWidth="28"
                              :isHeight="28"
                            ></m-avata>
                          </template>
                        </DxSelectBox>
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Đơn vị công tác</b></label
                        >
                        <DxTextBox
                          v-model:value="selectedDepartment"
                          :disabled="true"
                        />
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Ngày nộp đơn</b
                          ><span class="text-danger">*</span></label
                        >
                        <DxDateBox
                          v-model:value="selectedRequest.ApplicationDate"
                          type="datetime"
                          display-format="dd/MM/yyyy HH:mm"
                          :disabled="isView"
                          placeholder="DD/MM/YYYY HH:mm"
                        >
                          <DxValidator>
                            <DxRequiredRule
                              message="Ngày nộp đơn không được để trống"
                            />
                          </DxValidator>
                        </DxDateBox>
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Làm thêm từ</b
                          ><span class="text-danger">*</span></label
                        >
                        <DxDateBox
                          v-model:value="selectedRequest.WorkFrom"
                          type="datetime"
                          display-format="dd/MM/yyyy HH:mm"
                          :disabled="isView"
                          placeholder="DD/MM/YYYY HH:mm"
                        >
                          <DxValidator>
                            <DxRequiredRule
                              message="Làm thêm từ không được để trống"
                            />
                          </DxValidator>
                        </DxDateBox>
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Nghỉ giữa ca từ</b></label
                        >
                        <DxDateBox
                          v-model:value="selectedRequest.RestBetweenFrom"
                          type="datetime"
                          display-format="dd/MM/yyyy HH:mm"
                          :disabled="isView"
                          placeholder="DD/MM/YYYY HH:mm"
                        >
                          <DxValidator>
                            <DxRangeRule
                              :min="selectedRequest.WorkFrom"
                              message="Nghỉ giữa ca từ không được nhỏ hơn làm thêm từ"
                            />
                          </DxValidator>
                        </DxDateBox>
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Nghỉ giữa ca đến</b
                          ><span class="text-danger">*</span></label
                        >
                        <DxDateBox
                          v-model:value="selectedRequest.RestBetweenTo"
                          type="datetime"
                          display-format="dd/MM/yyyy HH:mm"
                          :disabled="isView"
                          placeholder="DD/MM/YYYY HH:mm"
                        >
                          <DxValidator>
                            <DxRequiredRule
                              v-if="
                                selectedRequest.RestBetweenFrom != null
                                  ? true
                                  : false
                              "
                              message="Nghỉ giữa ca đến không được để trống"
                            />
                            <DxRangeRule
                              :min="selectedRequest.RestBetweenFrom"
                              message="Nghỉ giữa ca đến không được nhỏ hơn nghỉ giữa ca từ"
                            />
                          </DxValidator>
                        </DxDateBox>
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Làm thêm đến</b></label
                        >
                        <DxDateBox
                          v-model:value="selectedRequest.WorkTo"
                          type="datetime"
                          display-format="dd/MM/yyyy HH:mm"
                          :disabled="isView"
                          placeholder="DD/MM/YYYY HH:mm"
                        >
                          <DxValidator>
                            <DxRangeRule
                              :min="selectedRequest.RestBetweenTo"
                              message="Làm thêm đến không được nhỏ hơn nghỉ giữa ca đến"
                            />
                          </DxValidator>
                        </DxDateBox>
                      </div>
                      <div class="w-full h-35 m-b-16 flex justify-between">
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Thời điểm làm thêm</b
                          ><span class="text-danger">*</span></label
                        >
                        <DxSelectBox
                          :dataSource="workTimeOptions"
                          v-model:value="selectedRequest.WorkTime"
                          display-expr="text"
                          value-expr="value"
                          placeholder=""
                          :search-enabled="true"
                          @value-changed="onValueChangedWorktime"
                          :disabled="isView"
                        >
                          <DxValidator>
                            <DxRequiredRule
                              message="Thời điểm làm thêm không được để trống"
                            />
                          </DxValidator>
                        </DxSelectBox>
                      </div>
                      <div
                        v-if="selectedRequest.WorkTime != '4' ? true : false"
                        class="w-full h-35 m-b-16 flex justify-between"
                      >
                        <label for="" class="p-r-8" style="height: 36px"
                          ><b class="text-form-add">Ca làm thêm</b
                          ><span class="text-danger">*</span></label
                        >
                        <DxSelectBox
                          :dataSource="
                            selectedRequest.WorkTime != null
                              ? overtimeOptions
                              : null
                          "
                          v-model:value="selectedRequest.OverTime"
                          display-expr="text"
                          value-expr="value"
                          placeholder=""
                          :search-enabled="true"
                          @value-changed="onValueChangedOvertime"
                          :disabled="isView"
                        >
                          <DxValidator>
                            <DxRequiredRule
                              message="Ca làm thêm không được để trống"
                            />
                          </DxValidator>
                        </DxSelectBox>
                      </div>
                    </div>
                  </div>
                  <div class="ms-col">
                    <div class="w-full h-35 m-b-16 flex justify-between">
                      <label for="" class="p-r-8" style="height: 36px"
                        ><b class="text-form-add">Lý do làm thêm</b
                        ><span class="text-danger">*</span></label
                      >

                      <DxTextArea
                        :height="89"
                        :max-length="maxLength"
                        v-model:value="selectedRequest.ReasonsWork"
                        :disabled="isView"
                        value-change-event="keyup"
                      >
                        <DxValidator>
                          <DxRequiredRule
                            message="Lí do làm thêm không được để trống"
                          />
                        </DxValidator>
                      </DxTextArea>
                    </div>
                    <div class="w-full h-35 m-b-16 flex justify-between">
                      <label for="" class="p-r-8" style="height: 36px"
                        ><b class="text-form-add">Người duyệt</b
                        ><span class="text-danger">*</span></label
                      >
                      <DxSelectBox
                        :dataSource="employees"
                        v-model:value="selectedRequest.ApprovedID"
                        display-expr="FullName"
                        placeholder=""
                        value-expr="EmployeeID"
                        item-template="item"
                        :disabled="isView"
                      >
                        <DxValidator>
                          <DxRequiredRule
                            message="Người duyệt không được để trống"
                          />
                        </DxValidator>
                        <template #item="{ data }">
                          <m-avata
                            :dataFullName="data.FullName"
                            :isWidth="24"
                            :isHeight="24"
                          ></m-avata>
                        </template>
                      </DxSelectBox>
                    </div>
                    <div
                      class="w-full h-35 m-b-16 flex justify-between edit-css-status"
                    >
                      <label for="" class="p-r-8" style="height: 36px"
                        ><b class="text-form-add">Trạng thái</b
                        ><span class="text-danger">*</span></label
                      >
                      <DxSelectBox
                        :dataSource="statusOptions"
                        v-model:value="selectedRequest.Status"
                        display-expr="text"
                        value-expr="status"
                        placeholder=""
                        :search-enabled="true"
                        @value-changed="onValueChangedStatus"
                        :focusStateEnabled="true"
                        :disabled="isView"
                      >
                        <DxValidator>
                          <DxRequiredRule
                            message="Trạng thái không được để trống"
                          />
                        </DxValidator>
                      </DxSelectBox>
                    </div>
                  </div>
                </div>
                <div class="w-full m-t-16 flex">
                  <div class="justify-between">
                    <h4>Danh sách nhân viên làm thêm</h4>
                  </div>
                  <div
                    v-if="selectedRecord.length > 0 ? true : false"
                    class="flex"
                  >
                    <div class="p-l-16">
                      <span class="f-z-14"
                        >Đã chọn
                        <strong>{{ selectedRecord.length }}</strong></span
                      >
                    </div>
                    <div class="p-l-16">
                      <span
                        @click="removeSelected"
                        class="f-z-14 c-blue"
                        style="padding-left: 8px"
                        >Bỏ chọn</span
                      >
                    </div>
                    <div
                      @click="deleteMultipleDetail"
                      class="p-l-16"
                      style="cursor: pointer"
                    >
                      <span class="f-z-14 c-red" style="padding-left: 8px"
                        >Loại bỏ</span
                      >
                    </div>
                  </div>
                </div>
                <div
                  class="flex justify-between items-center"
                  style="flex-grow: 1"
                >
                  <div class="flex content-nodata">
                    <div
                      v-if="employeeDetails.length == 0 ? true : false"
                      class="no-data"
                    >
                      Chưa có dữ liệu
                    </div>
                    <button
                      @click="showDetailEmployee"
                      class="ms-button btn-choose"
                      style="
                        width: auto !important;
                        height: 38px !important;
                        border-radius: 4px;
                        padding: 0px 16px 0px 12px;
                        min-width: 0px !important;
                        display: flex;
                        justify-content: center;
                        align-items: center;
                      "
                    >
                      <span
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
                        class="ms-icon ms-button--icon mi-plus-blue"
                        style="
                          font-size: 16px;
                          color: white;
                          cursor: pointer;
                          order: 0;
                          margin-right: 4px;
                          margin-left: 0px;
                        "
                      ></i>
                      <span
                        class="ms-button--text"
                        style="color: #ec554e; font-size: 14px"
                        >Thêm</span
                      >
                    </button>
                  </div>
                  <div class="totalRecord">
                    <span
                      v-show="employeeDetails.length > 0 ? true : false"
                      class="f-z-14"
                      >Tổng số bản ghi:
                      <strong>{{ employeeDetails.length }}</strong></span
                    >
                  </div>
                </div>
                <div class="ms-table--emp">
                  <m-grid-employee
                    v-if="employeeDetails.length > 0 ? true : false"
                    ref="gridDataDetail"
                    refText="refGridDetail"
                    @selectedEmployeesChanged="selectedEmployeesChanged"
                    @numberSelected="numberSelected"
                    :employeeList="employeeDetails"
                  ></m-grid-employee>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <request-detail-employee
      v-if="showFormAddEmployee"
      :idEmployees="idEmployees"
      @closeFormAddEmployee="closeFormAddEmployee"
    />
  </div>
</template>

<script>
import DxSelectBox from "devextreme-vue/select-box";
import DxTextBox from "devextreme-vue/text-box";
import DxDateBox from "devextreme-vue/date-box";
import { locale } from "devextreme/localization";
import RequestDetailEmployee from "@/view/request/RequestDetailEmployee.vue";
import MGridEmployee from "@/components/base/MGrid/MGridEmployee.vue";
import MField from "@/components/base/MField/MField.vue";
import MAvata from "@/components/base/MAvata/MAvata.vue";
import notify from "devextreme/ui/notify";
import { DxDropDownBox } from "devextreme-vue/drop-down-box";
import { DxScrollView } from "devextreme-vue/scroll-view";
import {
  DATA_GRID_TABLE,
  DATETIME_OPTIONS,
  STATUS_OPTIONS,
  WORKTIME_OPTION,
  OVERTIME_OPTION,
} from "@/js/resource";
import { getPositions } from "@/axios/positionController/positionController.js";
import { getDepartments } from "@/axios/departmentController/departmentController.js";
import {
  getRequestById,
  getRequests,
  postRequest,
  putRequest,
} from "@/axios/requestController/requestController.js";
import {
  getEmployees,
  getAllNotInEmployee,
} from "@/axios/employeeController/employeeController.js";
import { deleteMultipleRequestDetail } from "@/axios/requestDetailController/requestDetailController.js";
import {
  M_ENUM,
  ADD_SUCCESS,
  UPDATE_SUCCESS,
  DELETE_SUCCESS,
} from "@/js/enum.js";
import "devextreme/dist/css/dx.light.css";
import {
  DxValidator,
  DxRequiredRule,
  DxCustomRule,
  DxRangeRule,
} from "devextreme-vue/validator";
import DataSource from "devextreme/data/data_source";
import { DxButton } from "devextreme-vue";
import DxTextArea from "devextreme-vue/text-area";
import { DxLoadIndicator } from "devextreme-vue/load-indicator";
import {
  DxForm,
  DxGroupItem,
  DxSimpleItem,
  DxButtonItem,
  DxLabel,
  DxCompareRule,
  DxStringLengthRule,
  DxPatternRule,
  DxEmailRule,
  DxAsyncRule,
} from "devextreme-vue/form";
export default {
  components: {
    DxSelectBox,
    DxTextBox,
    DxDateBox,
    RequestDetailEmployee,
    MGridEmployee,
    MField,
    MAvata,
    DxForm,
    DxDropDownBox,
    DxScrollView,
    DxGroupItem,
    DxSimpleItem,
    DxButtonItem,
    DxLabel,
    DxCompareRule,
    DxStringLengthRule,
    DxPatternRule,
    DxEmailRule,
    DxLoadIndicator,
    DxAsyncRule,
    DxValidator,
    DxRequiredRule,
    DxCustomRule,
    DxRangeRule,
    DxButton,
    DxTextArea,
  },
  async created() {
    locale("vi");
    this.statusOptions = this.statusOptions.slice(1, 4);
    this.employees = (await getEmployees()).data;
    console.log(this.employees);
    this.departments = (await getDepartments()).data;
    this.requestList = (await getRequests()).data;
    if (this.$route.params.data == 0) {
      this.formSave = M_ENUM.MISA_TOOL.ADD;
      this.isShowByAdd = true;
      this.selectedRequest.Status = 2;
      // this.selectedRequest.ApplicationDate = new Date();
      // this.selectedRequest.WorkFrom = new Date();
      // this.selectedRequest.WorkTo = new Date();
    } else {
      this.isView = true;
      this.isShowByAdd = false;
      this.selectedRequest = (
        await getRequestById(this.$route.params.data)
      ).data;
      console.log();
      if (this.selectedRequest.Employees.length > 0) {
        this.isShowEmployeeDetail = true;
        this.employeeDetails = this.selectedRequest.Employees;
      }
      this.idEmployees = this.employeeDetails.map((x) => x.EmployeeID);
      this.isShowByEdit = true;
    }
  },
  props: {
    id: {
      type: String,
      required: true,
    },
  },
  watch: {},
  data() {
    return {
      searchMode: "constrain",
      showFormAddEmployee: false,
      requestList: [],
      singleEmployee: [],
      idEmployee: -1,
      isShowByAdd: false,
      isShowByUpdate: false,
      isShowNoEmployee: true,
      employeeDetails: [],
      selectedRecord: [],
      dateTimeOptions: DATETIME_OPTIONS,
      departments: [],
      selectedRequest: [],
      employees: [],
      selectedDepartment: "",
      statusOptions: STATUS_OPTIONS,
      selectedStatus: "",
      isView: false,
      workTimeOptions: WORKTIME_OPTION,
      overtimeOptions: OVERTIME_OPTION,
      formSave: M_ENUM.MISA_TOOL.ADD,
      idEmployees: [],
      isShowEmployeeDetail: false,
      idRequestDetails: [],
      requestDetails: [],
      isEmployeeChoose: [],
      idDeleteRequestDetail: [],
      addSuccess: ADD_SUCCESS,
      updateSuccess: UPDATE_SUCCESS,
      isLoadding: false,
    };
  },
  methods: {
    /**
     * Chức năng hiển thị form detailEmployee
     * Created: PQVINH(26/10/2022)
     */
    async showDetailEmployee() {
      this.showFormAddEmployee = true;
    },
    /**
     * Chức năng focus vào ô input
     * CreatedBy: PQVINH(1/11/2022)
     */
    selectboxEmployee(e) {
      this.$nextTick(() => e.component.focus());
    },
    /**
     * Chức năng lưu detail
     * Created: PQVINH(26/10/2022)
     */
    btnSaveClick(params) {
      let res = params.validationGroup.validate();
      if (res.isValid == true) {
        this.onSave();
      }
    },
    selectedEmployeesChanged(data) {
      console.log(data);
      this.employeeDetails = this.employeeDetails.filter((ele) => {
        return ele.EmployeeCode != data;
      });
      console.log(this.employeeDetails);
      this.idEmployees = this.employeeDetails.map((ele) => {
        return ele.EmployeeID;
      });
      console.log(this.idEmployees);
      this.selectedRequest.Employees = this.employeeDetails;
    },
    /**
     * Chức năng đóng form thêm nhân viên làm thêm
     * Created: PQVINH(30/10/2022)
     */
    async closeFormAddEmployee(data) {
      console.log(data);
      this.showFormAddEmployee = false;
      this.isShowEmployeeDetail = false;
      if (data) {
        this.employeeDetails.push(...data);
        this.employeeDetails = JSON.parse(JSON.stringify(this.employeeDetails));
        this.idEmployees = this.employeeDetails.map((x) => x.EmployeeID);
        this.selectedRequest.Employees = this.employeeDetails;
        console.log(this.idEmployees);
        console.log(this.selectedRequest);
      }
      if (this.employeeDetails) {
        this.isShowEmployeeDetail = true;
      }
    },
    /**
     * Chức năng thay đổi tên nhân viên làm thêm
     * Created: PQVINH(30/10/2022)
     */
    onValueChangedName(e) {
      this.employees.forEach((element) => {
        if (element.EmployeeID == e.value) {
          this.selectedDepartment = element.DepartmentName;
        }
      });
      // this.selectedRequest.EmployeeID = e.value;
    },
    /**
     * Chức năng lấy text trạng thái
     * Created: PQVINH(30/10/2022)
     */
    formatStatus(value) {
      if (value == 0) {
        return "Từ chối";
      }
      if (value == 1) {
        return "Đã duyệt";
      }
      return "Chờ duyệt";
    },
    /**
     * Chức năng lấy nhân viên làm thêm
     * Created: PQVINH(30/10/2022)
     */
    numberSelected(data) {
      this.selectedRecord = data;
    },
    /**
     * Chức năng bỏ chọn nhân viên làm thêm
     * Created: PQVINH(30/10/2022)
     */
    removeSelected() {
      this.$refs.gridDataDetail.clearSelection();
    },
    /**
     * Chức năng đóng form thêm nhân viên làm thêm
     * Created: PQVINH(30/10/2022)
     */
    // onValueEmployeeChanged(e) {
    //   console.log(
    //     this.employees.find((emp) => emp.EmployeeId == e.value).DepartmentId
    //   );
    //   this.selectedDepartment = this.employees.find(
    //     (emp) => emp.EmployeeId == e.value
    //   ).DepartmentId;
    // },
    /**
     * Chức năng lưu thêm mới và sửa
     * Created: PQVINH(30/10/2022)
     */
    async onSave() {
      this.isLoadding = true;
      if (this.formSave == M_ENUM.MISA_TOOL.ADD) {
        try {
          let res = await postRequest(this.selectedRequest);
          if (res) {
            console.log("XXXXX");
            this.toastMessage(this.addSuccess);
            this.$router.push({ name: "home" });
          }
          this.isLoadding = false;
        } catch (error) {
          console.log(error);
        }
      }
      if (this.formSave == M_ENUM.MISA_TOOL.EDIT) {
        try {
          if (this.selectedRequest.WorkTime === "4") {
            this.selectedRequest.OverTime = null;
          }
          let res = await putRequest(
            this.selectedRequest.RequestID,
            this.selectedRequest
          );
          this.toastMessage(this.updateSuccess);
          this.$router.push({ name: "home" });
          this.isLoadding = false;
        } catch (error) {
          console.log(error);
        }
      }
    },
    /**
     * Hiển thị thông thành công
     */
    toastMessage(message) {
      const positionToast = "bottom right";
      const directionToast = "left-push";
      notify(
        {
          message: message,
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
    },
    /**
     * Chức năng xem hoặc sửa
     * Created: PQVINH(30/10/2022)
     */
    isEdit() {
      this.isView = false;
      this.isShowByAdd = true;
      this.isShowByEdit = false;
      this.formSave = M_ENUM.MISA_TOOL.EDIT;
    },
    /**
     * Chức năng xóa nhiều request
     * Created: PQVINH(30/10/2022)
     */
    async deleteMultipleDetail() {
      for (let i = 0; i < this.selectedRecord.length; i++) {
        this.idDeleteRequestDetail.push(this.selectedRecord[i].EmployeeID);
      }
      console.log(this.selectedRecord[0].EmployeeID);
      const index = 0;
      this.employeeDetails = this.employeeDetails.filter((ele) => {
        return !this.idDeleteRequestDetail.includes(ele.EmployeeID);
      });
      this.idEmployees = this.employeeDetails.map((ele) => {
        return ele.EmployeeID;
      });
      this.selectedRequest.Employees = this.employeeDetails;
      this.idDeleteRequestDetail = [];
      this.selectedRecord = [];
    },
  },
};
</script>

<style>
.mi-arrow-left {
  width: 24px;
  height: 24px;
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-repeat: no-repeat;
  background-color: #666 !important;
  -webkit-mask-position: -48px -48px;
}
.content-main {
  overflow-x: hidden;
  overflow-y: auto;
  width: 100%;
  border-radius: 4px;
  display: flex;
}
.b-white {
  background: #fff;
  border-radius: 4px;
  min-height: 100%;
}
.p-24 {
  padding: 24px;
}
.w-full {
  width: 100%;
}
.p-l-16 {
  padding-left: 16px;
}
.ms-row {
  clear: both;
  flex-flow: wrap;
}
.m-b-0 {
  margin-bottom: 0 !important;
}
.ms-col {
  width: 46.6667%;
}
.text-danger {
  color: #ff0000;
  font-size: 14px;
  padding-left: 2px;
}
.m-b-16 {
  margin-bottom: 16px;
}
.text-form-add {
  color: #212121;
  font-size: 14px;
}
.m-t-16 {
  margin-top: 16px;
}
.content-nodata {
  margin-top: 8px;
}
.no-data {
  font-style: italic;
  color: #9fa4b4;
  padding-top: 8px;
  font-size: 14px;
}

.btn-choose {
  cursor: pointer;
  font-weight: 700;
  color: #ec554e;
}
.includeIcon {
  display: flex;
  -webkit-box-align: center;
  align-items: center;
  -webkit-box-pack: center;
  justify-content: center;
}
.mi-plus-blue {
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -192px -24px;
  background-color: #ec554e !important;
}
.ms-form .dx-texteditor.dx-editor-outlined {
  width: 66.6667% !important;
}
.ms-table--emp .dx-datagrid {
  height: 250px !important;
}
.dx-dropdowneditor-field-template-wrapper {
  padding: 0 8px !important;
  align-items: center !important;
}
.c-blue {
  color: #3c54f1;
}
button {
  cursor: pointer;
}
.dx-timeview-field .dx-numberbox {
  width: 70px !important;
}
.dx-calendar-navigator
  .dx-calendar-caption-button.dx-button
  .dx-button-content {
  color: #ec5504 !important;
}
.dx-list-item-content {
  display: flex;
  align-items: center;
  height: 60px;
}
.dx-list-item-content:hover {
  background-color: #ffede2;
}
.btn-save {
  background-color: #ec5504;
  color: #fff;
  width: 80px;
}
.btn-save:hover {
  background: #ec5504;
}
.dx-texteditor.dx-state-active.dx-editor-outlined {
  border-color: #ec5504 !important;
}
.dx-list-item-content {
  height: 36px !important;
}
.form {
  padding: 10px 0 0 10px;
}

.label {
  margin-bottom: 10px;
  font-size: 16px;
}

.label:not(:first-child) {
  margin-top: 30px;
}

#small-indicator,
#medium-indicator,
#large-indicator {
  vertical-align: middle;
  margin-right: 10px;
}

#save,
#save .dx-button-content {
  padding: 0;
}

#save .button-indicator {
  height: 32px;
  width: 32px;
  display: inline-block;
  vertical-align: middle;
  margin-right: 5px;
}

.indicators {
  display: flex;
  align-items: center;
}
.dx-widget.dx-button.dx-button-mode-contained.dx-button-normal.btn-save.dx-state-focused.dx-state-hover{
  background-color: #ec5504 !important;
  border: none !important;
}
</style>
