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
        <div id="form-1" v-if="step === 1">
          <loading :active.sync="isLoading" :is-full-page="fullPage"></loading>
          <div class="form-group">
            <label>First Name</label>
            <input type="text" class="form-control" v-model="userDetail.firstName" />
          </div>
          <div class="form-group">
            <label>Last Name</label>
            <input type="text" class="form-control" v-model="userDetail.lastName" />
          </div>
          <div class="form-group">
            <label>Date of Birth</label>
            <input type="date" class="form-control" v-model="userDetail.dateOfBirth" />
          </div>
          <div class="form-group">
            <label>Email</label>
            <input type="email" class="form-control" v-model="userDetail.email" />
          </div>
        </div>
        <div id="form-2" v-if="step === 2">
          <div class="form-group">
            <label>Property Value</label>
            <input type="text" class="form-control" v-model="propertyUserDetail.propertyDetail.propertyValue" />
          </div>
          <div class="form-group">
            <label>Deposit Amount</label>
            <input type="text" class="form-control" v-model="propertyUserDetail.propertyDetail.depositAmount" />
          </div>
        </div>
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
import UserDetailApiService from "@/services/api/UserDetails";
import LoanCalculationApiService from "@/services/api/LoanCalculations";
import Loading from "vue-loading-overlay";
import "vue-loading-overlay/dist/vue-loading.css";

export default {
  name: "LenderForm",
  data: function () {
    return {
      step: 1,
      userDetail: {
        firstName: "",
        lastName: "",
        dateOfBirth: Date.now(),
        email: "",
      },
      propertyUserDetail: {
        userId: "",
        propertyDetail:{
          propertyValue: 0.0,
          depositAmount: 0.0
        }
      },
      isLoading: false,
      fullPage: true,
    };
  },
  computed: {
    stepButtonText() {
      return this.step === 1 ? "Continue" : "Calculate";
    },
  },
  components: {
    Loading,
  },
  methods: {
    nextStep() {
      if (this.step === 1) {
        this.isLoading = true;
        UserDetailApiService.createUserDetail(JSON.stringify(this.userDetail))
          .then((response) => {
            if (this.step >= 1 && this.step < 3) this.step++;
            console.log(response);
            this.propertyUserDetail.userId = response.data.id;
          })
          .finally(() => (this.isLoading = false));
      }

      if (this.step === 2) {
        this.isLoading = true;
        LoanCalculationApiService.getMatchingLoansForUser(JSON.stringify(this.propertyUserDetail))
          .then((response) => {
            console.log(response);
          })
          .finally(() => this.isLoading = false);
      }
    },
    previousStep() {
      if (this.step >= 1) this.step--;
    },
  },
};
</script>
