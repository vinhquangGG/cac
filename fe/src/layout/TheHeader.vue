<template>
  <header class="navbar">
    <div class="ms-navbar-header">
      <button class="ms-navbar--btn-responsive">
        <span class="btn-responseve-line line--1"></span>
        <span class="btn-responseve-line line--2"></span>
        <span class="btn-responseve-line line--3"></span>
      </button>
      <div class="app-info">
        <div class="container-ninedot">
          <div class="mi mi-24 mi-box"></div>
        </div>
        <a href="" class="router-link-active">
          <div class="logo flex items-center m-r-12">
            <div class="mi-gd2 mi-32 mi-logo"></div>
          </div>
        </a>
        <a href="" class="router-link-active">
          <div class="logo-text">Chấm công</div>
        </a>
      </div>
    </div>
    <div class="ms-navbar-items">
      <div class="flex">
        <ul>
          <div class="router-item m-l-8 m-r-24 f-z-14">
            <li>Tổng quan</li>
            <div class="bg-white"></div>
          </div>
          <div class="router-item m-l-8 m-r-24 f-z-14">
            <li>Chấm công</li>
            <div class="bg-white"></div>
          </div>

          <div class="router-item m-l-8 m-r-24 f-z-14">
            <li>Ca làm việc</li>
            <div class="bg-white"></div>
          </div>
          <router-link to="/quan-li-don" class="router-item m-l-8 m-r-24 f-z-14">
            <li>Quản lí đơn</li>
            <div class="border-active bg-white"></div>
          </router-link>
          <div class="router-item m-l-8 m-r-24 f-z-14">
            <li>Báo cáo</li>
            <div class="bg-white"></div>
          </div>
          <div class="router-item m-l-8 m-r-24 f-z-14">
            <li>Thiết lập</li>
            <div class="bg-white"></div>
          </div>
        </ul>
      </div>
    </div>
</header>
<div class="account-box flex">
  <div class="flex items-center m-r-24">
    <div class="ms-navbar--item">
      <li class="mi-gd2 mi-24 mi-bell"></li>
    </div>
  </div>
  <div class="flex items-center m-r-24">
    <div class="ms-navbar--item">
      <li class="mi-gd2 mi-24 mi-question"></li>
    </div>
  </div>
  <div class="flex items-center m-r-24">
    <div class="ms-navbar--item">
      <li class="mi-gd2 mi-24 mi-menu"></li>
    </div>
  </div>
</div>
</template>

<script>
export default {};
</script>

<style>
@import url(../css/main.css);
.ms-navbar {
  display: flex;
  align-items: center;
}
.ms-navbar--btn-responsive {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 40px;
  height: 40px;
  position: relative;
  border: 0;
  background: transparent;
  align-items: center;
  padding: 10px 0;
  margin-left: 5px;
  cursor: pointer;
  transition: all 0.25s ease;
  overflow: hidden;
  display: none;
}
.ms-navbar-header {
  display: flex;
  margin-right: 35px;
  width: 200px;
}
.btn-responseve-line {
  width: 20px;
  height: 2px;
  background: rgba(0, 0, 0, 0.6);
  position: relative;
  display: block;
  transition: all 0.2s ease;
}
.app-info {
  display: flex;
  align-items: center;
  height: 36px;
}
.mi-box {
  background-position: -1157px -26px !important;
}
.mi-logo {
  background-position: 0 -72px !important;
}
.mi-bell {
  background-position: -267px -2px;
}
.mi-question{
    background-position:-290px -170px;
}
.mi-menu{
    background-position:-146px -194px;
}
.logo-text {
  font-size: 18px;
  color: #000;
  font-weight: 700;
  width: 100px;
}
.container-ninedot {
  width: 36px;
  height: 36px;
  padding: 6px;
  margin: 0 10px;
}
a {
  text-decoration: none;
}

.ms-con-items {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
}
ul {
  display: flex;
  list-style-type: none;
}
li {
  list-style-type: none;
}
ul .router-item {
  border-radius: 32px;
  border: 1px solid transparent;
}
.border-active {
  height: 4px;
  width: 100%;
  background: #ec5504;
  position: relative;
  top: 17px;
}
.account-box {
  height: 56px;
  display: -webkit-box;
  display: -ms-flexbox;
  display: flex;
  position: absolute;
  right: 0;
  z-index: 99999;
}
.ms-navbar--item {
  display: block;
  position: relative;
  -webkit-transition: all 0.25s ease;
  transition: all 0.25s ease;
  z-index: 1000;
}
.f-z-14{
  font-size: 14px;
}
</style>
