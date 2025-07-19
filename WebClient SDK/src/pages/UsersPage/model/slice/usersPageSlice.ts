import { createEntityAdapter, createSlice } from '@reduxjs/toolkit';
import { StateSchema } from 'app/providers/StoreProvider';
import { UsersPageSchema } from 'pages/UsersPage';
import { fetchUserList } from 'pages/UsersPage/model/services/fetchUserList/fetchUserList';
import { UserLookup } from 'entities/User';

const usersAdapter = createEntityAdapter<UserLookup>({
    selectId: (user) => user.id
});

export const getUsers = usersAdapter.getSelectors<StateSchema>(
    (state) => state.usersPage || usersAdapter.getInitialState()
);

const usersPageSlice = createSlice({
    name: 'usersPageSlice',
    initialState: usersAdapter.getInitialState<UsersPageSchema>({
        isLoading: false,
        error: undefined,
        ids: [],
        entities: {}
    }),
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchUserList.pending, (state) => {
                state.error = undefined;
                state.isLoading = true;
            })
            .addCase(fetchUserList.fulfilled, (
                state,
                action
            ) => {
                state.isLoading = false;
                usersAdapter.setAll(state, action.payload.users);
            })
            .addCase(fetchUserList.rejected, (
                state,
                action
            ) => {
                state.isLoading = false;
                state.error = action.payload;
            });
    }
});

export const { reducer: usersPageReducer } = usersPageSlice;
export const { actions: usersPageActions } = usersPageSlice;
