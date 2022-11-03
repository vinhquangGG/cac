<template>
  <div>
    <DxPopover
      :min-width="112"
      :visible="value"
      target="#customheader"
      position="bottom"
      @hidden="close"
    >
      <!-- <draggable v-model="headers">
        <transition-group>
          <div v-for="item in headers" :key="item.Field">
            {{ item.Caption }}
          </div>
        </transition-group>
      </draggable> -->
      <div>

        <draggable 
          v-model="headers" 
          group="people" 
          @start="drag=true" 
          @end="drag=false" 
          item-key="id">
          <template #item="{element}">
            <div>{{element.Caption}}</div>
          </template>
        </draggable>
      </div>
    </DxPopover>
  </div>
</template>

<script>
import { DxPopover } from "devextreme-vue/popover";
import draggable from "vuedraggable";
export default {
  components: {
    DxPopover,draggable
  },
  props: {
    headers: {
      Type: Array,
      default: []
    },
    value: {
      Type: Boolean,
      default: false,
    },
  },
  data() {
    return{
    }
  },
  methods: {
    close(){
        this.value = false;
        this.$emit("update:value",false);
    }
  }
};
</script>

<style></style>
