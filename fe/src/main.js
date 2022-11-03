import 'devextreme/dist/css/dx.common.css';
import 'devextreme/dist/css/dx.light.css';
import RequestList from "./view/request/RequestList";
import RequestDetail from "./view/request/RequestDetail";
import { createApp } from 'vue'
import {createRouter, createWebHistory} from 'vue-router';
import App from './App.vue'
// Định nghĩa các router
const routers = [
    {path: "/quan-li-don", name: "home",component: RequestList},
    {path: "/quan-li-don/:data", name: "edit",component: RequestDetail, props: true},
]
// Khởi tạo router
const router = createRouter({
    history:createWebHistory(),
    routes: routers
})
const app = createApp(App);
app.use(router);
app.mount('#app');
// createApp(App).mount('#app')
