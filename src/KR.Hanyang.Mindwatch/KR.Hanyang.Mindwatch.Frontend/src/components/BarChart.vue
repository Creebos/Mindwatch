<template>
    <v-card outlined class="pa-4">
      <v-card-title>Survey Responses</v-card-title>
      <v-card-text>
        <canvas ref="chart"></canvas>
      </v-card-text>
    </v-card>
  </template>
  
  <script>
  import {
    Chart,
    BarElement,
    BarController,
    CategoryScale,
    LinearScale,
    Title,
    Tooltip,
    Legend,
  } from "chart.js";
  
  // Register Chart.js components
  Chart.register(
    BarElement,
    BarController,
    CategoryScale,
    LinearScale,
    Title,
    Tooltip,
    Legend
  );
  
  export default {
    name: "BarChart",
    props: {
      labels: {
        type: Array,
        required: true,
      },
      data: {
        type: Array,
        required: true,
      },
    },
    mounted() {
      const ctx = this.$refs.chart.getContext("2d");
      new Chart(ctx, {
        type: "bar",
        data: {
          labels: this.labels,
          datasets: [
            {
              label: "Responses",
              data: this.data,
              backgroundColor: ["#42A5F5", "#66BB6A", "#FFA726"],
            },
          ],
        },
        options: {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              position: "top",
            },
          },
        },
      });
    },
  };
  </script>
  
  <style scoped>
  canvas {
    height: 300px;
  }
  </style>
  