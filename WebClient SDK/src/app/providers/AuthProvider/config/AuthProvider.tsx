import React, { createContext, ReactNode, useCallback, useEffect, useState } from 'react';
import { AuthToken } from 'shared/const/api';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { userActions } from 'entities/User';

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

    const dispatch = useAppDispatch();

    const login = (newToken: string) => {
        localStorage.setItem(AuthToken, newToken);
        setToken(newToken);
    };

    const logout = useCallback(() => {
        localStorage.removeItem(AuthToken);
        setToken(null);
        dispatch(userActions.removeUserData());
    }, [dispatch]);

    const value: AuthContextType = {
        token,
        isAuthenticated: !!token,
        login,
        logout
    };

    useEffect(() => {
        const handleStorageChange = (event: StorageEvent) => {
            if (event.key === AuthToken) {
                if (!event.newValue) {
                    logout();
                }

                setToken(event.newValue);
            }
        };

        window.addEventListener('storage', handleStorageChange);

        return () => {
            window.removeEventListener('storage', handleStorageChange);
        };
    }, [logout]);

    return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};
