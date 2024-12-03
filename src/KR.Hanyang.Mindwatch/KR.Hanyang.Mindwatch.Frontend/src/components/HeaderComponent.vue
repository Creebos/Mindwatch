<template>
  <header class="app-header">
    <div class="logo">
      <img src="@/assets/logo.png" alt="Logo" />
      <h1>Mindwatch</h1>
    </div>
    <nav class="nav-menu">
      <router-link v-for="link in navLinks" :key="link.name" :to="link.path">
        {{ link.name }}
      </router-link>
    </nav>
  </header>
</template>

<script>
export default {
  name: 'HeaderComponent',
  data () {
    return {
      navLinks: [
        { name: 'Home', path: '/' },
        { name: 'About', path: '/about' },
        { name: 'Employee View', path: '/employee' },
        { name: 'Manager View', path: '/manager' },
        { name: 'HR Manager View', path: '/hrmanager' }
      ]
    }
  }
}
</script>

<style scoped>
.app-header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 1rem 2rem;
  background-color: #4caf50;
  color: white;
  font-family: Arial, sans-serif;
}
.logo {
  display: flex;
  align-items: center;
}
.logo img {
  height: 50px;
  margin-right: 10px;
}
.nav-menu {
  display: flex;
  gap: 20px;
}
.nav-menu a {
  text-decoration: none;
  color: white;
  font-weight: bold;
}
.nav-menu a:hover {
  text-decoration: underline;
}
</style>
