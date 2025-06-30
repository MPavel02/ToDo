import { AuthToken } from 'shared/const/api';

export const getToken = (): string | null => {
    return localStorage.getItem(AuthToken);
};

export const setToken = (token: string): void => {
    localStorage.setItem(AuthToken, token);
};

export const removeToken = (): void => {
    localStorage.removeItem(AuthToken);
};
