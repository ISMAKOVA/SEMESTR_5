import '@babel/polyfill'
import 'mutationobserver-shim'
import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import VueRouter from "vue-router";
import './plugins/bootstrap-vue'
import App from './App.vue'
import Statistics from "@/components/Statistics";

Vue.use(VueRouter);

const routes = [
    {
        path: "",
        component: Statistics,
    },
    {
        path: "/statistics",
        component: Statistics,
    },
];

const router = new VueRouter({
    routes,
    mode: "history",
});

Vue.use(VueAxios, axios);
Vue.config.productionTip = false


new Vue({
    router,
  render: h => h(App),
   axios
}).$mount('#app');

//npm run serve
