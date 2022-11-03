<template>
  <div class="dx-template-wrapper">
    <div class="grd-status" :class="status(data.value)">{{ statusText(data.value) }}</div>
  </div>
</template>

<script>
export default {
  props: {
    data: {
      Type: Object,
      default: "",
    },
  },
  methods: {
    /**
     * Chức năng lấy css theo trạng thái
     * Created: PQVINH(25/10/2022)
     */
    status(value) {
      if (value == 0) {
        return "rejected";
      }
      if (value == 1) {
        return "approved";
      }
      return "waiting";
    },
    /**
     * Chức năng lấy text theo trạng thái
     * Created: PQVINH(25/10/2022)
     */
    statusText(value) {
      if (value == 0) {
        return "Từ chối";
      }
      if (value == 1) {
        return "Đã duyệt";
      }
      return "Chờ duyệt";
    },
  },
};
</script>

<style>
.waiting {
  border: 1px solid #6153df;
  color: #6153df;
  background-color: #ebe9fb;
}
.rejected {
  border: 1px solid #ef292f;
  color: #ef292f;
  background-color: #fee8e7;
}
.approved {
  border: 1px solid #11aa7a;
  color: #11aa7a;
  background-color: #b9f8e4;
}
.grd-status {
  border-radius: 4px;
  text-align: center;
  width: fit-content;
  padding: 6px !important;
}
</style>
