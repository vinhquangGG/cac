<template>
  <div
    class="flex items-center justify-between w-full paging-navbar"
    style="
      position: sticky !important;
      background-color: #f5f5f5;
      height: 60px;
      width: 100%;
      z-index: 4;
    "
  >
    <div class="flex paging-left">
      <div class="total-record" style="font-size: 13px; padding-left: 12px">
        Tổng số:
        <b id="sumEmp"> {{ requestList.TotalRecord }} </b> bài ghi
      </div>
    </div>
    <div class="flex paging-right">
      <div class="record-paging">
        <div class="ms-cbx">
          <div class="combo-main-content">
            <div class="combobox" style="padding-right: 12px">
              <DxSelectBox
                width="40"
                :items="pageNumber"
                v-model:value="numberRecord"
                @value-changed="changeNumberPage"
              />
              <span style="padding: 0 16px"
                >Từ <b>{{ (pageCurrent - 1) * numberRecord + 1 }}</b> đến
                <b>{{
                  (pageCurrent - 1) * numberRecord + requestList.Data.length
                }}</b>
                bản ghi</span
              >
            </div>
          </div>
        </div>
      </div>
      <div class="flex" style="align-items: center">
        <div class="prev" style="cursor: pointer"></div>
        <div class="center flex"></div>
        <button
          :disabled="pageCurrent == 1"
          @click="pagePrev"
          class="mi-gd2 mi-24 mi-prev"
          style="border: none"
        ></button>
        <button
          :disabled="
            (pageCurrent - 1) * numberRecord +
              requestList.Data.length -
              ((pageCurrent - 1) * numberRecord + 1) <
              numberRecord - 1 || pageCurrent === requestList.TotalPage
              ? true
              : false
          "
          @click="pageNext"
          class="mi-gd2 mi-24 mi-next"
          style="border: none"
        ></button>
      </div>
    </div>
  </div>
</template>

<script>
import { NUMBER_PAGE } from "@/js/resource.js";
import DxSelectBox from "devextreme-vue/select-box";
export default {
  components: {
    DxSelectBox,
  },
  created() {
    this.pageCurrent = this.requestList.CurrentPage;
  },
  watch: {
    "requestList.Data.length": {
      handler() {
        this.pageCurrent = this.requestList.CurrentPage;
      },
      Immediate: true,
    },
  },
  props: {
    requestList: {
      type: Array,
      default: [],
    },
  },
  data() {
    return {
      pageCurrent: this.requestList.CurrentPage,
      numberRecord: 50,
      pageNumber: NUMBER_PAGE,
    };
  },
  methods: {
    /**
     * Chức năng chọn số trang hiển thị trang
     * Created: PQVINH(25/10/2022)
     */
    changeNumberPage(e) {
      console.log(e);
      this.numberRecord = e.value;
      this.pageCurrent = 1;
      this.$emit("totalRecordOfPage", e.value);
    },
    /**
     * Chức năng chọn trang trước
     * Created: PQVINH(25/10/2022)
     */
    pagePrev() {
      this.pageCurrent -= 1;
      this.$emit("pagenation", this.pageCurrent);
    },
    /**
     * Chức năng chọn trang sau
     * Created: PQVINH(25/10/2022)
     */
    pageNext() {
      this.pageCurrent += 1;
      this.$emit("pagenation", this.pageCurrent);
    },
  },
};
</script>

<style>
.ms-button-paging {
  background: #fff;
  border: none;
  cursor: pointer;
}
.pageChange {
  cursor: pointer;
  background: #fff;
  border: none;
  font-size: 13px;
}
.combobox {
  display: flex;
  align-items: center;
  justify-content: center;
}
.combobox .dx-texteditor.dx-editor-outlined {
  width: 75px !important;
}
.mi-prev {
  background-position: -223px 1px !important;
}
.mi-next {
  background-position: -239px 1px !important;
}
</style>
