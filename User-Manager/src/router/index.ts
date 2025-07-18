import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'login',
      component: ()=>import('@/views/user/loginView.vue'),
    },
    {
      path: '/signUp',
      name: 'signUp',
      component: () => import('@/views/user/signView.vue'),
    },
    {
      path: '/userAdmin',
      name: 'userAdmin',
      component: () => import('@/views/user/userAdminView.vue'),
    }
  ],
})

export default router
