<template>
  <div id="form">
    <div class="form-group">
      <label>Property Value</label>
      <input type="text" class="form-control" v-model="propertyValue" />
    </div>
    <div class="form-group">
      <label>Deposit Amount</label>
      <input type="text" class="form-control" v-model="depositAmount" />
    </div>
  </div>
</template>

<script>
export default {
  name: "step-two-form",
  data: function() {
    return {
      propertyValue: 0.0,
      depositAmount: 0.0,
      uniqueId: ""
    };
  },
  methods: {
    submitForm() {
      alert("Submitting second stage form...");
    }
  }
};
</script>