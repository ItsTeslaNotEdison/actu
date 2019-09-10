<template>
  <div id="app">
   <b-navbar fixed sticky type="light" variant="light">
      <b-container>       
        <!-- <b-navbar-nav class="mr-auto"> 
          <b-nav-item :to="{ name: 'MarkovRateInputValues' }">Markov Rate </b-nav-item>
          <b-nav-item :to="{ name: 'Benefits' }">Benefits</b-nav-item>
          <b-nav-item :to="{ name: 'Yield' }">Yield Curve</b-nav-item>          
          <b-nav-item :to="{ name: 'ModelPoints' }">Model Points</b-nav-item>  
        </b-navbar-nav> -->
        <b-navbar-nav class="mr-auto"> 
          <b-nav-item :to="{ name: 'Product' }">Product Creation</b-nav-item>
          </b-navbar-nav>
        <b-navbar-nav class="ml-auto">
          <h4>Actuarial Valuations Portal</h4>
        </b-navbar-nav>
      </b-container>
    </b-navbar>
    <br />
    <router-view/>
  </div>
</template>

<style lang="scss">

  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    color: #2c3e50;
  }

  #nav {
    padding: 55px;
    a {
      font-weight: bold;
      color: #2c3e50;
      &.router-link-exact-active {
        color: #42b983;
      }
    }
  }

  .divider {
    width: 5px;
    height: auto;
    display: inline-block;
  }

  /* Override default toastr opacity */
  body #toast-container > div {
    opacity: 1;
  }

  th {
    white-space: nowrap;
  }
</style>
