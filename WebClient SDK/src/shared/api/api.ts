import axios from 'axios';
import {useAuth} from "shared/lib/hooks/useAuth/useAuth";

export const $api = axios.create({
    baseURL: __API__,
    withCredentials: true
});

$api.interceptors.request.use((config) => {
    const { token } = useAuth();
    if (token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
});
