import { StateSchema } from 'app/providers/StoreProvider';
import { UserRole } from '../types/user';

export const getAuthToken = (state: StateSchema) => state.user.authData?.token ?? '';
export const getUserRole = (state: StateSchema) => state.user.userData?.role ?? UserRole.User;
