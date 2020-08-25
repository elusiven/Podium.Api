import axios from 'axios';

var path = "/api/UserDetail/";
const headers = {
    'Content-Type': 'application/json',
};

export default {

    getUserDetail(id){
        return axios.get(path + id)
            .then(response => {
                return response.data;
            });
    },

    getUserDetails(){
        return axios.get(path)
            .then(response => {
                return response.data;
            });
    },

    createUserDetail(payload){
        return axios.post(path, payload, {headers: headers});
    }
}