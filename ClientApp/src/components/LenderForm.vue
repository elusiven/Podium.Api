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
            <input
              type="text"
              class="form-control"
              v-model="propertyUserDetail.propertyDetail.propertyValue"
            />
          </div>
          <div class="form-group">
            <label>Deposit Amount</label>
            <input
              type="text"
              class="form-control"
              v-model="propertyUserDetail.propertyDetail.depositAmount"
            />
          </div>
        </div>
        <div id="results" v-if="step === 3">
          <table class="table table-sm">
            <thead>
              <tr>
                <th scope="col">Lender</th>
                <th scope="col">Interest Rate</th>
                <th scope="col">Fixed/Variable</th>
                <th scope="col">Loan-to-value</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="lender in lenders" :key="lender.id">
                <th scope="row">{{lender.lender}}</th>
                <td>{{lender.interestRate}}</td>
                <td>{{lender.loanType}}</td>
                <td>{{lender.loanToValue | toPercentage}}</td>
              </tr>
            </tbody>
          </table>
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
            v-if="step < 3"
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
        propertyDetail: {
          propertyValue: 0.0,
          depositAmount: 0.0,
        },
      },
      lenders: [],
      isLoading: false,
      fullPage: true,
    };
  },
  filters: {
    toPercentage(number) {
      return parseFloat(number).toFixed(2) + "%";
    },
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
            this.propertyUserDetail.userId = response.data.id;
          })
          .catch((error) => {
            console.log(error.response);
          })
          .finally(() => (this.isLoading = false));
      }

      if (this.step === 2) {
        this.isLoading = true;
        LoanCalculationApiService.getMatchingLoansForUser(
          JSON.stringify(this.propertyUserDetail)
        )
          .then((response) => {
            this.lenders = response.data;
            this.step = 3;
          })
          .catch((error) => {
            console.log(error.response);
          })
          .finally(() => (this.isLoading = false));
      }
    },
    previousStep() {
      if (this.step >= 1) this.step--;
    },
  },
};
</script>
