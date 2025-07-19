import { StateSchema } from 'app/providers/StoreProvider';

export const getCurrentUserAuthToken = (state: StateSchema) => state.currentUser.authData?.token ?? '';
export const getCurrentUser = (state: StateSchema) => state.currentUser.userData;
export const getUser = (state: StateSchema) => state.user?.userData;