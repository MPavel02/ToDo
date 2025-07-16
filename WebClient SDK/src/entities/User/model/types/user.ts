import { ApiError } from 'shared/api/apiError';
import { BaseEntity } from 'entities/BaseEntity';

export enum UserRole {
    Admin,
    User
}

export function getUserRole(role: UserRole): string {
    switch (role) {
        case UserRole.Admin:
            return 'Admin';
        case UserRole.User:
            return 'User';
        default:
            return 'Not found role';
    }
}

export interface UserLookup extends BaseEntity {
    username: string;
    role: UserRole;
}

export interface UserLookupList {
    users: UserLookup[];
}

export interface User extends UserLookup {
    notes: [];
}

export interface AuthResult {
    token: string;
}

export interface UserSchema {
    authData?: AuthResult;
    userData?: User;

    isLoading: boolean;
    error?: ApiError;
}
