import axios from "../baseAxios.js";
import { ENDPOINTS } from "../endpoints.js";

export async function getPositions(){
    var endpoint = ENDPOINTS.POSITIONS;
    return axios.getAxios(endpoint);
}