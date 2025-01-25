import { API_MONOLITH_URL } from "@/lib/config"
import axios from "axios"

export const monolithInstance = axios.create({
    baseURL:API_MONOLITH_URL
})