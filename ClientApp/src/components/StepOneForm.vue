<template>
  <div id="form">
    <div class="form-group">
      <label>First Name</label>
      <input type="text" class="form-control" v-model="firstName" />
    </div>
    <div class="form-group">
      <label>Last Name</label>
      <input type="text" class="form-control" v-model="lastName" />
    </div>
    <div class="form-group">
      <label>Date of Birth</label>
      <input type="date" class="form-control" v-model="dateOfBirth" />
    </div>
    <div class="form-group">
      <label>Email</label>
      <input type="email" class="form-control" v-model="email" />
    </div>
  </div>
</template>

<script>
export default {
  name: "step-one-form",
  data: function() {
    return {
      firstName: "",
      lastName: "",
      dateOfBirth: Date.now(),
      email: ""
    };
  },
  methods: {
    submitForm() {
      alert("Submitting first stage form...");
    }
  }
};
</script>