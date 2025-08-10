import { createAsyncThunk } from '@reduxjs/toolkit';
import { ThunkConfig } from 'app/providers/StoreProvider';
import { API_ENDPOINT_V1 } from 'shared/const/api';
import { User } from '../../types/user';
import { ApiError, handleAxiosError } from 'shared/api/apiError';

export const fetchUserDataByID = createAsyncThunk<
    User,
    string | undefined,
    ThunkConfig<ApiError>
>(
    'user/fetchUserDataByID',
    async (userID, thunkAPI) => {
        const {
            extra,
            rejectWithValue
        } = thunkAPI;

        try {
            const response = await extra.api.get<User>(API_ENDPOINT_V1 + `/users/${userID}`);

            if (!response.data) {
                throw new Error('Не удалось получить информацию о пользователе.');
            }

            return response.data;
        } catch (error) {
            return rejectWithValue(handleAxiosError(error));
        }
    },
);
