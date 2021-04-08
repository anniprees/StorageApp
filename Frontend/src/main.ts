import { createApp } from 'vue';
import App from './App.vue';
import './index.css';
import { setApiUrl } from './modules/api';
import VueRouter from '@/router';
import NavBar from '@/components/NavBar.vue';

const getRuntimeConfig = async () => {
  const runtimeConfig = await fetch('/config/runtime-config.json');
  return await runtimeConfig.json();
};
const app = createApp(App);
getRuntimeConfig().then((json) => {
  setApiUrl(json.API_URL);
  app.use(VueRouter).mount('#app');
  app.component('default-layout', NavBar);
});
