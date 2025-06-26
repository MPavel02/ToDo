import axios from 'axios';
import { getToken } from 'shared/api/token';

export const $api = axios.create({
    baseURL: __API__,
    withCredentials: true
});

$api.interceptors.request.use((config) => {
    const token = getToken();
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});
