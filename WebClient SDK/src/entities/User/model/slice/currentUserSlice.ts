import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { AuthResult, CurrentUserSchema } from '../types/user';
import { fetchUserData } from '../services/fetchUserData/fetchUserData';

const initialState: CurrentUserSchema = {
    isLoading: false,
    error: undefined
};

export const currentUserSlice = createSlice({
    name: 'user',
    initialState: initialState,
    reducers: {
        setAuthData: (state, action: PayloadAction<AuthResult>) => {
            state.authData = action.payload;
        },
        removeUserData: (state) => {
            state.userData = undefined;
            state.authData = undefined;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchUserData.pending, (state) => {
                state.error = undefined;
                state.isLoading = true;
            })
            .addCase(fetchUserData.fulfilled, (state, action) => {
                state.isLoading = false;
                state.userData = action.payload;
            })
            .addCase(fetchUserData.rejected, (state, action) => {
                state.isLoading = false;
                state.error = action.payload;
            });
    }
});

export const { actions: currentUserActions } = currentUserSlice;
export const { reducer: currentUserReducer } = currentUserSlice;
