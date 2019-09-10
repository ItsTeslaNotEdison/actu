import moment from 'moment';

export default (value: any, date: string) => {
  if (value) {
    return moment(value).format("DD/MM/YYYY HH:MM:SS");
  }
};