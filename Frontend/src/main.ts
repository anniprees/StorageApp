import { createApp } from 'vue';
import App from './App.vue';
import './index.css';
import router from '@/router';
import NavBar from '@/components/NavBar.vue';

const app = createApp(App);
app.use(router).mount('#app');
app.component('default-layout', NavBar);
