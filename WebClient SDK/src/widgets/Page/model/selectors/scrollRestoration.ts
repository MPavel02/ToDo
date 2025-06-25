import { StateSchema } from 'app/providers/StoreProvider';
import { createSelector } from '@reduxjs/toolkit';

export const getScrollRestorationObject = (state: StateSchema) => state.scrollRestoration.scroll;
export const getScrollRestorationByPath = createSelector(
    getScrollRestorationObject,
    (_: StateSchema, path: string) => path,
    (scroll, path) => scroll[path] || 0,
);
