<template>
  <div>
    {{ convertWorktime() }}
  </div>
</template>

<script>
export default {
  props: {
    dataCell: Object,
  },
  methods: {
    /**
     * Chức năng lấy text từ db
     * Created: PQVINH(25/10/2022)
     */
    convertWorktime() {
      if (this.dataCell.value == "1") {
        return "Trước ca";
      }
      if (this.dataCell.value == "2") {
        return "Sau ca";
      }
      if (this.dataCell.value == "3") {
        return "Nghỉ giữa ca";
      }
      if (this.dataCell.value == "4") {
        return "Ngày nghỉ";
      }
    },
  },
};
</script>

<style></style>
