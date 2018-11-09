import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import router from 'vue-router'
import vueDebounce from 'vue-debounce'
import "./filters/unique";
import "./filters/celsius";

Vue.use(require('vue-moment'));
Vue.config.productionTip = false
Vue.use(BootstrapVue);
Vue.use(vueDebounce);

const routes = [{
  path: '/',
  component: App
}
];

const vuerouter = new router
({
    mode: 'history',
    routes
})

Vue.use(router);

new Vue({
  //define the selector for the root component
    el: '#app',
    //pass the template to the root component
    template: '<App/>',
    //declare components that the root component can access
    components: { App },
    //pass in the router to the Vue instance
    vuerouter,
    render: h => h(App) 
  });