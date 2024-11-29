<script>
export default {
  data() {
    return {
      weatherForecasts: [],
    };
  },
  mounted() {
    fetch("https://localhost:8081/weatherforecast")
      .then((response) => response.json())
      .then((data) => {
        this.weatherForecasts = data;
      })
      .catch((error) => console.error("Error fetching weather data:", error));
  },
};
</script>

<template>
  <div>
    <h1>Weather Forecast</h1>
    <ul>
      <li v-for="(forecast, index) in weatherForecasts" :key="index">
        {{ forecast.date }}: {{ forecast.temperatureC }}°C - {{ forecast.summary }}
      </li>
    </ul>
  </div>
</template>

<style scoped>
ul {
  list-style: none;
  padding: 0;
}
li {
  margin: 5px 0;
}
</style>
