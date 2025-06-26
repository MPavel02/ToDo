export interface User {
    id: string;
    username: string;
}

export interface AuthResult {
    success: boolean;
    token: string;
    error?: string;
    userID: string;
}

export interface UserSchema {
    authData?: AuthResult;

    _inited: boolean;
}
