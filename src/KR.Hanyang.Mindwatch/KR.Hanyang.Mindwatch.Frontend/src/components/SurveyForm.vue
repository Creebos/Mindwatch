<template>
    <div class="survey-form">
      <h2>Health Assessment Survey</h2>
      <form @submit.prevent="submitForm">
        <div>
          <label for="name">Name:</label>
          <input type="text" id="name" v-model="name" required />
        </div>
        <div>
          <label for="email">Email:</label>
          <input type="email" id="email" v-model="email" required />
        </div>
        <div>
          <label for="response">Your Response:</label>
          <textarea id="response" v-model="response" required></textarea>
        </div>
        <button type="submit">Submit</button>
      </form>
    </div>
  </template>

<script>
export default {
  data () {
    return {
      name: '',
      email: '',
      response: ''
    }
  },
  methods: {
    submitForm () {
      console.log('Form submitted:', this.name, this.email, this.response)
    }
  }
}
</script>

  <style>
  .survey-form {
    max-width: 600px;
    margin: 2rem auto;
    padding: 1rem;
    border: 1px solid #ccc;
    border-radius: 8px;
  }
  .survey-form div {
    margin-bottom: 1rem;
  }
  .survey-form label {
    display: block;
    margin-bottom: 0.5rem;
  }
  </style>
