import { createAsyncThunk } from '@reduxjs/toolkit';
import { ThunkConfig } from 'app/providers/StoreProvider';
import { AuthResult } from 'entities/User/model/types/user';
import { userActions } from 'entities/User';
import { API_ENDPOINT_V1 } from 'shared/const/api';

interface LoginProps {
    username: string;
    password: string;
}

export const loginByUsername
    = createAsyncThunk<AuthResult, LoginProps, ThunkConfig<string>>(
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

                dispatch(userActions.setAuthData(response.data));

                return response.data;
            } catch (e) {
                console.log(e);
                return rejectWithValue('error');
            }
        },
    );
