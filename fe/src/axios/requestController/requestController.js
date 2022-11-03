import axios from "../baseAxios.js";
import {ENDPOINTS} from '../endpoints.js'

export async function getRequests() {
  const endpoint = ENDPOINTS.REQUESTS;
  return await axios.getAxios(endpoint);
}

/**
 * hàm lấy danh sách nhân viên theo filter
 * author: vinhpq(23/09/2022)
 * @param {params: {pageSize, pageNumber, employeeFilter} } params
 * @returns
 */
export async function getRequestFilter(params) {
  const endpoint = ENDPOINTS.REQUESTS_FILTER;
  return await axios.getAxios(endpoint, params);
}

/**
 * hàm xoá nhân viên theo id
 * author: vinhpq(23/09/2022)
 * @param {id} params 
 * @returns 
 */
export async function deleteRequest(id) {
  const endpoint = ENDPOINTS.REQUESTS + '/' + id;
  return await axios.deleteAxios(endpoint);
}

export async function getRequestById(id){
  const endpoint = ENDPOINTS.REQUESTS + '/' + id;
  return await axios.getAxios(endpoint);
}

export async function deleteManyRequest(params){
  const endpoint = ENDPOINTS.REQUESTS;
  return await axios.handleMultipleAxios(endpoint, params);
}

export async function setStatusRejected(params){
  const endpoint = ENDPOINTS.REQUEST_REJECTED;
  return await axios.handleMultipleAxios(endpoint, params);
}

export async function setStatusApproved(params){
  const endpoint = ENDPOINTS.REQUEST_APPROVED;
  return await axios.handleMultipleAxios(endpoint, params);
}

export async function getNextEmployee() {
  const endpoint = ENDPOINTS.NEW_EMPLOYEE_CODE;
  return await axios.getAxios(endpoint);
}

export async function postRequest(body) {
  const endpoint = ENDPOINTS.REQUESTS;
  return await axios.postAxios(endpoint, body);
}

export async function putRequest(id, body) {
  const endpoint = ENDPOINTS.REQUESTS + '/' + id;
  return await axios.putAxios(endpoint, body);
}


export async function getRequestToExcel(){
  const endpoint = ENDPOINTS.REQUEST_EXPORT;
  return await axios.getFileAxios(endpoint);
}