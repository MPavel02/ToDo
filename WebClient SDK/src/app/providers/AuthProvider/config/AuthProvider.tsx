import React, { createContext, ReactNode, useState } from 'react';
import { AuthToken } from 'shared/const/api';

interface AuthState {
    token: string | null;
    isAuthenticated: boolean;
}

export interface AuthContextType extends AuthState {
    login: (token: string) => void;
    logout: () => void;
}

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

interface AuthProviderProps {
    children: ReactNode;
}

export const AuthProvider: React.FC<AuthProviderProps> = ({ children }) => {
    const [token, setToken] = useState<string | null>(localStorage.getItem(AuthToken));

    const login = (newToken: string) => {
        localStorage.setItem(AuthToken, newToken);
        setToken(newToken);
    };

    const logout = () => {
        localStorage.removeItem(AuthToken);
        setToken(null);
    };

    const value: AuthContextType = {
        token,
        isAuthenticated: !!token,
        login,
        logout,
    };

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
