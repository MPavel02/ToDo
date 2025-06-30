export interface User {
    id: string;
    username: string;
    role: UserRole;
    createdAt: Date;
    updatedAt: Date;
    notes: [];
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
    error?: string;
}
