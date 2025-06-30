import { ApiError } from 'shared/api/apiError';

export interface LoginSchema {
    username: string;
    password: string;
    isLoading: boolean;
    error?: ApiError;
}
