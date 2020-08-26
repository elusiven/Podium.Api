import Vue from 'vue';
import App from './App.vue';
import router from './router';
import 'bootstrap'; 
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';

axios.defaults.baseURL = "https://localhost:44308"

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app');
