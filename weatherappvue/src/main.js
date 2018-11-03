import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import router from 'vue-router'

Vue.config.productionTip = false
Vue.use(BootstrapVue);
Vue.use(router);

new Vue({
  render: h => h(App)
}).$mount('#app');