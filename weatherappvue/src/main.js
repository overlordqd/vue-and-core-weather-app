import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import vueDebounce from 'vue-debounce'
import "./filters/unique";
import "./filters/celsius";
import moment from 'vue-moment'
import router from './router'

Vue.use(moment);
Vue.config.productionTip = false
Vue.use(BootstrapVue);
Vue.use(vueDebounce);
Vue.use(router);

new Vue({
  el: '#app',
  template: '<App/>',
  components: { App },
  router,
  render: h => h(App) 
});