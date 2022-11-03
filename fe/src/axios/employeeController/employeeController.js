import axios from "../baseAxios.js";
import {ENDPOINTS} from '../endpoints.js'

export async function getEmployees() {
  const endpoint = ENDPOINTS.EMPLOYEES;
  return await axios.getAxios(endpoint);
}

/**
 * hàm lấy danh sách nhân viên theo filter
 * author: vinhpq(23/09/2022)
 * @param {params: {pageSize, pageNumber, employeeFilter} } params
 * @returns
 */
export async function getEmployeesFilter(params) {
  const endpoint = ENDPOINTS.EMPLOYEES_FILTER;
  return await axios.postAxios(endpoint, params);
}

/**
 * hàm xoá nhân viên theo id
 * author: vinhpq(23/09/2022)
 * @param {id} params  
 * @returns 
 */
export async function deleteEmployee(id) {
  const endpoint = ENDPOINTS.EMPLOYEES + '/' + id;
  return await axios.deleteAxios(endpoint);
}


export async function deleteManyEmployee(params){
  const endpoint = ENDPOINTS.EMPLOYEES;
  return await axios.handleMultipleAxios(endpoint, params);
}

export async function getAllNotInEmployee(params){
  const endpoint = ENDPOINTS.NOT_IN_EMPLOYEE;
  return await axios.getAllNotInAxios(endpoint, params);
}

export async function getNextEmployee() {
  const endpoint = ENDPOINTS.NEW_EMPLOYEE_CODE;
  return await axios.getAxios(endpoint);
}

export async function postEmployee(body) {
  const endpoint = ENDPOINTS.EMPLOYEES;
  return await axios.postAxios(endpoint, body);
}

export async function putEmployee(id, body) {
  const endpoint = ENDPOINTS.EMPLOYEES + '/' + id;
  return await axios.putAxios(endpoint, body);
}

export async function getMaxCodeEmployee(){
  const endpoint = ENDPOINTS.EMPLOYEES_Get_MAX_CODE;
  return await axios.getAxios(endpoint);
}

export async function getEmployeeToExcel(){
  const endpoint = ENDPOINTS.EMPLOYEE_EXPORT;
  return await axios.getFileAxios(endpoint);
}