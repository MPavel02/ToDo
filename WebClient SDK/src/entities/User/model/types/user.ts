import { ApiError } from 'shared/api/apiError';
import { BaseEntity } from 'entities/BaseEntity';

export interface UserLookup extends BaseEntity {
    username: string;
    role: UserRole;
}

export interface User extends UserLookup {
    notes: [];
}

export interface UserLookupList {
    users: UserLookup[];
}

export enum UserRole {
    Admin,
    User
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
