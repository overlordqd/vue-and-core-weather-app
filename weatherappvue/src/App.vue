<template>    
  <div class="App">
    <nav class="App__nav navbar fixed-top navbar-dark bg-dark sticky-top">
      <a class="navbar-brand" href="#">The Doodly Weather Doodle</a>
      <ul class="nav justify-content-end nav-pills">
        <li class="nav-item">
          <router-link to="/" class="nav-link" exact-active-class="active">Home</router-link>
        </li>
        <li class="nav-item">
          <router-link to="/history" class="nav-link" exact-active-class="active">History</router-link>
        </li>
      </ul>
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