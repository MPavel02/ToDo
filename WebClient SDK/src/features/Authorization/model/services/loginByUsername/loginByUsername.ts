import { createAsyncThunk } from '@reduxjs/toolkit';
import { ThunkConfig } from 'app/providers/StoreProvider';
import { AuthResult } from 'entities/User/model/types/user';
import { currentUserActions } from 'entities/User';
import { API_ENDPOINT_V1 } from 'shared/const/api';
import { ApiError, handleAxiosError } from 'shared/api/apiError';

interface LoginProps {
    username: string;
    password: string;
}

export const loginByUsername
    = createAsyncThunk<AuthResult, LoginProps, ThunkConfig<ApiError>>(
        'loginByUsername/loginByUsername',
        async (authData, thunkAPI) => {
            const {
                extra,
                dispatch,
                rejectWithValue
            } = thunkAPI;

            try {
                const response = await extra.api.post<AuthResult>(
                    API_ENDPOINT_V1 + '/auth/login',
                    authData);

                if (!response.data) {
                    throw new Error();
                }

                dispatch(currentUserActions.setAuthData(response.data));

                return response.data;
            } catch (error) {
                return rejectWithValue(handleAxiosError(error));
            }
        },
    );
