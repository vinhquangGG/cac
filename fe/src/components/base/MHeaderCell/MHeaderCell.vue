<template>
  <div
    class="dx-datagrid-text-content"
    @mouseenter="showHoverPin"
    @mouseleave="isShowPin = false"
  >
    <div class="justify-flexstart header-title">
      <div class="p-r-8">
        {{ data.column.caption }}
      </div>
      <div
        @click.prevent.stop="pinColumn($event)"
        v-show="isShowPin || isPin"
        class="mi-unpin mi-unpin-icon-right"
        :class="{ 'mi-pin': isPin }"
      ></div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    data: {
      type: Object,
      default: "",
    },
    isPin: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      isShowPin: false,
    };
  },
  methods: {
    /**
     * Chức năng hover vào tr hiển thị ghim
     * Created: PQVINH(19/10/2022)
     */
    showHoverPin() {
      this.isShowPin = !this.isShowPin;
    },
    /**
     * Chức năng ghim cột
     * Created: PQVINH(19/10/2022)
     */
    pinColumn(e) {
      console.log(this.isPin);
      // this.isShowPin = true;
      if (this.isPin == true) {
        this.$emit("pinColumnData", {
          pinding: e.path[3].offsetParent.cellIndex,
          showPin: false,
        });
      } else {
        this.$emit("pinColumnData", {
          pinding: e.path[3].offsetParent.cellIndex,
          showPin: true,
        });
      }
    },
  },
};
</script>

<style>
.dx-datagrid-text-content .header-title {
  height: 100%;
  width: 100%;
  display: flex;
  -webkit-box-align: center;
  align-items: center;
  white-space: normal;
  text-align: center;
}
.header-title {
  font-weight: 700;
  letter-spacing: 0.14px;
  color: #212121;
}
.header-title {
  font-size: 14px;
  overflow: hidden;
  text-overflow: ellipsis;
}
.dx-datagrid-text-content .header-title .mi-pin-icon-right {
  display: none;
}
.dx-datagrid-text-content .header-title .mi-pin-icon-right {
  position: absolute;
  top: calc(50% - 12px);
  right: 12px;
}
.mi-unpin {
  transform: rotate(-45deg);
}
.mi-unpin {
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  mask-repeat: no-repeat;
  background-color: #686c7b;
}
.mi-unpin {
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -216px -120px;
}
.mi-pin {
  width: 24px;
  height: 24px;
  -webkit-mask-repeat: no-repeat;
  background-color: #ec554e !important;
}
.mi-pin {
  -webkit-mask-image: url(https://testcdnamisapp.misa.vn/apps/timesheet/static/img/Icon.b444e1e.svg);
  -webkit-mask-position: -216px -120px;
}
</style>
