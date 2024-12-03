<template>
  <nav class="navbar">
    <ul class="navbar-list">
      <li>
        <router-link to="/">Home</router-link>
      </li>
      <li>
        <router-link to="/employee">Employee Dashboard</router-link>
      </li>
      <li>
        <router-link to="/manager">Manager Dashboard</router-link>
      </li>
      <li>
        <router-link to="/hr">HR Manager Dashboard</router-link>
      </li>
      <li>
  <router-link to="/survey">Survey Form</router-link>
</li>

    </ul>
  </nav>
</template>

<script>
export default {
  name: 'AppNavbar',
};
</script>

<style scoped>
.navbar {
  background-color: #333;
  padding: 10px;
}
.navbar-list {
  display: flex;
  list-style: none;
  gap: 15px;
}
.navbar-list a {
  color: white;
  text-decoration: none;
}
.navbar-list a.router-link-active {
  font-weight: bold;
}
</style>
