import { createAsyncThunk } from '@reduxjs/toolkit';
import { ThunkConfig } from 'app/providers/StoreProvider';
import { API_ENDPOINT_V1 } from 'shared/const/api';
import { User } from '../../types/user';

export const fetchUserData = createAsyncThunk<
    User,
    void,
    ThunkConfig<string>
>(
    'user/fetchUserData',
    async (_, thunkAPI) => {
        const {
            extra,
            rejectWithValue
        } = thunkAPI;

        try {
            const response = await extra.api.get<User>(API_ENDPOINT_V1 + '/users/info');

            if (!response.data) {
                throw new Error('Не удалось получить информацию о пользователе.');
            }

            return response.data;
        } catch (e) {
            const error = e as Error;
            return rejectWithValue(error.message);
        }
    },
);
