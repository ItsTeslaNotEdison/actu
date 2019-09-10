import Vue from 'vue';
import Router from 'vue-router';
// import Home from './views/core/Home.vue';
import MarkovRateInputValues from './views/entities/MarkovRateInputValues.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [

    {
      path: '/MarkovRateInputValues',
      name: 'MarkovRateInputValues',
      component: MarkovRateInputValues,
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      // component: () => import(/* webpackChunkName: "about" */ './views/entities/MarkovRateInputValues.vue'),
    },

    // {
    //   path: '/',
    //   name: 'home',
    //   component: Home,
    // },
    // {
    //   path: '/about',
    //   name: 'about',
    //   // route level code-splitting
    //   // this generates a separate chunk (about.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import(/* webpackChunkName: "about" */ './views/core/About.vue'),
    // },
    // {
    //   path: '/',
    //   name: 'MarkovStates',
    //   component: MarkovStates,
    //   // route level code-splitting
    //   // this generates a separate chunk (about.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   // component: () => import(/* webpackChunkName: "about" */ './views/entities/MarkovStates.vue'),
    // },

    {
      path: '/Benefits',
      name: 'Benefits',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/entities/Benefits.vue'),
    },

    {
      path: '/Yield',
      name: 'Yield',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/entities/Yield.vue'),
    },

    // {
    //   path: '/Models',
    //   name: 'Models',
    //   // route level code-splitting
    //   // this generates a separate chunk (about.[hash].js) for this route
    //   // which is lazy-loaded when the route is visited.
    //   component: () => import(/* webpackChunkName: "about" */ './views/entities/Models.vue'),
    // },

    {
      path: '/ModelPoints',
      name: 'ModelPoints',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/entities/ModelPoints.vue'),
    },
    {
      path: '/Product',
      name: 'Product',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/entities/Product.vue'),
    },
    {
      path: '/MarkovState',
      name: 'MarkovState',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/entities/Product/MarkovState.vue'),
    },
    {
      path: '/Transitions',
      name: 'Transitions',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/entities/Product/Transitions.vue'),
    }
    
  ],
});
