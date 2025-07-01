import { getUsersPageError, getUsersPageIsLoading } from './model/selectors/usersPageSelectors';
import { getUsers, usersPageReducer } from './model/slice/usersPageSlice';
import { UsersPageSchema } from './model/types/usersPageSchema';
import { UsersPageAsync } from './ui/UsersPage.async';

export {
    UsersPageAsync as UsersPage,
    UsersPageSchema,
    usersPageReducer,
    getUsers,
    getUsersPageIsLoading,
    getUsersPageError
};
