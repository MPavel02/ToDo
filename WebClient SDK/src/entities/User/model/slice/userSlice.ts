import { createSlice } from '@reduxjs/toolkit';
import { UserSchema } from '../types/user';
import { fetchUserDataByID } from '../services/fetchUserDataByID/fetchUserDataByID';

const initialState: UserSchema = {
    isLoading: false,
    error: undefined
};

export const userSlice = createSlice({
    name: 'user',
    initialState: initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchUserDataByID.pending, (state) => {
                state.error = undefined;
                state.isLoading = true;
            })
            .addCase(fetchUserDataByID.fulfilled, (state, action) => {
                state.isLoading = false;
                state.userData = action.payload;
            })
            .addCase(fetchUserDataByID.rejected, (state, action) => {
                state.isLoading = false;
                state.error = action.payload;
            });
    }
});

export const { actions: userActions } = userSlice;
export const { reducer: userReducer } = userSlice;
