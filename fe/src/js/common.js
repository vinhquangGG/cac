import moment from 'moment/moment';
export let common = {
  // format date
  formatDate(dob) {
    if (dob == null) {
      return null;
    }
    else if(dob > new Date()){
      return moment(new Date()).format("YYYY-MM-DDTHH:mm:ss");
    }
    else {
      return moment(dob).format("YYYY-MM-DDTHH:mm:ss");
    }
  },
  formatDateByText(dob){
    if (dob == null) {
      return null;
    }
    else{
      return moment(dob).format("DD-MM-YYYY");
    }
  }
};
