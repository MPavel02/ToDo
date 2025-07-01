import { ThunkConfig } from 'app/providers/StoreProvider';
import { createAsyncThunk } from '@reduxjs/toolkit';
import { API_ENDPOINT_V1 } from 'shared/const/api';
import { ApiError, handleAxiosError } from 'shared/api/apiError';
import { UserLookupList } from 'entities/User';

export const fetchUsersList = createAsyncThunk<
    UserLookupList,
    void,
    ThunkConfig<ApiError>
>(
    'usersPage/fetchUsersList',
    async (_, thunkAPI) => {
        const {
            extra,
            rejectWithValue
        } = thunkAPI;

        try {
            const response = await extra.api.get<UserLookupList>(API_ENDPOINT_V1 + '/users');

            if (!response.data) {
                throw new Error('Не удалось получить список пользователей.');
            }

            return response.data;
        } catch (error) {
            return rejectWithValue(handleAxiosError(error));
        }
    },
);
