<template>
  <div class="flex items-center bg-item-selectbox">
    <div class="flex m-r-8 items-center justify-center">
      <div class="flex items-center justify-center wrap-avata" :style="{ backgroundColor: randomBackground[Math.floor(Math.random() * 4)], width: isWidth+'px', height: isHeight+'px'}"><span style="">{{nickName}}</span></div>
      <div style="padding-left: 12px">{{ dataFullName }}</div>
    </div>
  </div>
</template>
<script>
export default {
  props: {
    dataFullName: Object,
    isWidth: Number,
    isHeight: Number
  },
  created() {
    // console.log(this.dataFullName);
    this.nickName = this.dataFullName.split(" ")[0][0]+ this.dataFullName.split(" ")[this.dataFullName.split(" ").length-1][0];
  },
  data() {
    return {
      randomBackground: ["#FAD2E0", "#B052C0", "#39AC66", "#FFAD33"],
      nickName: ""
    };
  },
  methods: {},
};
</script>

<style>
.wrap-avata {
  border-radius: 50%;
  color: #fff;
  font-weight: normal;
  font-size: 14px;
}
.bg-item-selectbox:hover{
  background-color: #ffede2;
}
.dx-overlay-wrapper{
  
}
</style>
