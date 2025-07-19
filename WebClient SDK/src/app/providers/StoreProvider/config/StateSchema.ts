import { AnyAction, CombinedState, EnhancedStore, Reducer, ReducersMapObject } from '@reduxjs/toolkit';
import { AxiosInstance } from 'axios';
import { ScrollRestorationSchema } from 'widgets/Page';
import { LoginSchema } from 'features/Authorization';
import { UsersPageSchema } from 'pages/UsersPage';
import { CurrentUserSchema, UserSchema } from 'entities/User';

export interface StateSchema {
    currentUser: CurrentUserSchema;
    scrollRestoration: ScrollRestorationSchema;

    // Асинхронные редюсеры
    loginForm?: LoginSchema;
    usersPage?: UsersPageSchema;
    user?: UserSchema;
}

export type StateSchemaKey = keyof StateSchema;

export interface ReducerManager {
    getReducerMap: () => ReducersMapObject<StateSchema>;
    reduce: (state: StateSchema, action: AnyAction) => CombinedState<StateSchema>;
    add: (key: StateSchemaKey, reducer: Reducer) => void;
    remove: (key: StateSchemaKey) => void;
}

export interface ReduxStoreWithManager extends EnhancedStore<StateSchema> {
    reducerManager: ReducerManager;
}

export interface ThunkExtraArg {
    api: AxiosInstance;
}

export interface ThunkConfig<T> {
    rejectValue: T;
    extra: ThunkExtraArg;
    state: StateSchema;
}
