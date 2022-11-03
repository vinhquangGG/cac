import axios from "axios";
const HTTP = axios.create({
  baseURL: "https://localhost:44316/api/v1",
});
const headers = { 
  "Content-Type": "application/json",
};
export const getAxios = async (endpoint, query) => {
  return await HTTP.get(endpoint, {
    params: {
      ...query,
    },
  });
};

export const postAxios = async (endpoint, body) => {
  
  return await HTTP.post(
    endpoint,
    {
      ...body,
    },
    { headers: headers }
  );
};

export const putAxios = async (endpoint, body) => {
  return await HTTP.put(
    endpoint,
    {
      ...body,
    },
    { headers: headers }
  );
};

export const deleteAxios = async (endpoint) => {
  return await HTTP.delete(endpoint);
};

export const handleMultipleAxios = async (endpoint, body) => {
  return await HTTP.put(
    endpoint,
    [
      ...body,
    ],
    { headers: headers }
  );
};

export const getAllNotInAxios = async (endpoint, body) => {
  return await HTTP.put(
    endpoint,
    [
      ...body,
    ],
    { headers: headers }
  );
};

export const getFileAxios = async (endpoint) => {
  return await HTTP.get(endpoint, 
    {responseType : 'blob'},
  );
};

export default { getAxios, postAxios, putAxios, deleteAxios, handleMultipleAxios, getFileAxios, getAllNotInAxios };
