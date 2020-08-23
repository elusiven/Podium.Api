<template>
  <div>
    <div class="row">
      <div class="col-md-6 mx-auto">
        <h2 v-if="step === 1">Enter your personal details</h2>
        <h2 v-if="step === 2">Enter your property details</h2>
      </div>
    </div>
    <div class="row">
      <div class="col-md-6 mx-auto">
        <step-one-form v-if="step === 1" ref="stageOneForm"/>
        <step-two-form v-if="step === 2" ref="stageTwoForm"/>
        <div class="form-group">
          <button
            type="button"
            class="btn btn-primary"
            @click="previousStep"
            v-if="step > 1"
          >Previous</button>
        </div>
        <div class="form-group">
          <button
            type="button"
            class="btn btn-primary"
            v-show="stepButtonText"
            @click="nextStep"
          >{{ stepButtonText }}</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import StepOneForm from "@/components/StepOneForm.vue";
import StepTwoForm from "@/components/StepTwoForm.vue";

export default {
  name: "LenderForm",
  data: function() {
    return {
      step: 1
    };
  },
  computed: {
    stepButtonText() {
      return this.step === 1 ? "Continue" : "Calculate";
    }
  },
  methods: {
    nextStep() {
      if (this.step >= 1 && this.step < 3) this.step++;

      if (this.step === 2) this.$refs.stageOneForm.submitForm();
      if (this.step === 3) this.$refs.stageTwoForm.submitForm();
    },
    previousStep() {
      if (this.step >= 1) this.step--;
    }
  },
  components: {
    StepOneForm,
    StepTwoForm
  }
};
</script>
