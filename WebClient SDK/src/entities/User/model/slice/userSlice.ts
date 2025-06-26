import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AuthResult, UserSchema } from '../types/user';

const initialState: UserSchema = {
    _inited: false
};

export const userSlice = createSlice({
    name: 'user',
    initialState,
    reducers: {
        setAuthData: (state, action: PayloadAction<AuthResult>) => {
            state.authData = action.payload;
        },
        initAuthData: (state) => {
            state._inited = true;
        }
    }
});

export const { actions: userActions } = userSlice;
export const { reducer: userReducer } = userSlice;
