import { EntityState } from '@reduxjs/toolkit';
import { ApiError } from 'shared/api/apiError';
import { UserLookup } from 'entities/User';

export interface UsersPageSchema extends EntityState<UserLookup> {
    isLoading?: boolean;
    error?: ApiError;
}
