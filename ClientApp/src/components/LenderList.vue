<template>
  <div id="results">
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
          <td>{{lender.interestRate | toPercentage}}</td>
          <td>{{lender.loanType}}</td>
          <td>{{lender.loanToValue | toPercentage}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "lender-list",
  props: ['lenders'],
  filters: {
    toPercentage(number) {
      return parseFloat(number).toFixed(2) + "%";
    },
  },
};
</script>
