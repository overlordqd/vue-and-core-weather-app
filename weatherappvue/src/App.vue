<template>    
  <div class="App">
    <nav class="App__nav navbar fixed-top navbar-dark bg-dark sticky-top">
      <a class="navbar-brand" href="#">The Doodly Weather Doodle</a>
      <router-link to="/">Home</router-link>
      <router-link to="/history">History</router-link>
    </nav>
    <main class="App__main container">
      <router-view/>
    </main>
    <footer class="App__footer">
      &copy; Doodly Company
    </footer>
  </div>
</template>

<script>
export default {
  name: "app",
}
</script>

<style>
footer {
  position: fixed;
  bottom: 0;
}
</style>