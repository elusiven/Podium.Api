import axios from 'axios';

var path = "/api/LoanCalculation/";
const headers = {
    'Content-Type': 'application/json',
};

export default {

    getMatchingLoansForUser(payload){
        return axios.post(path, payload, {headers: headers});
    }
}