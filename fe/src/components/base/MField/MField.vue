<template>
  <div style="display: inline-block">
    {{ formatStatus(fieldData.Status) }}
  </div>
</template>

<script>
export default {
  props: {
    fieldData: Object,
  },
  data() {
    return {};
  },
  methods: {
    /**
     * Chức năng lấy text từ db
     * Created: PQVINH(25/10/2022)
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
  },
};
</script>

<style></style>
