import { StateSchema } from 'app/providers/StoreProvider';

export const getUsersPageIsLoading = (state: StateSchema) => state.usersPage?.isLoading || false;
export const getUsersPageError = (state: StateSchema) => state.usersPage?.error;
