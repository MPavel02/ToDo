import { createSelector } from '@reduxjs/toolkit';
import { RoutePath } from 'shared/config/routeConfig/routeConfig';

import { SidebarItemType } from '../types/sidebar';
import { getUserRole, UserRole } from 'entities/User';
import { Notebook, ServerCrash, Users } from 'lucide-react';

export const getSidebarItems = createSelector(
    getUserRole,
    (userRole) => {
        const sidebarItemsList: SidebarItemType[] = [
            {
                path: RoutePath.notes,
                Icon: Notebook,
                text: 'Notes'
            }
        ];

        if (userRole === UserRole.Admin) {
            sidebarItemsList.push(
                {
                    path: RoutePath.logs,
                    Icon: ServerCrash,
                    text: 'Logs',
                    isAdmin: true
                },
                {
                    path: RoutePath.users,
                    Icon: Users,
                    text: 'Users',
                    isAdmin: true
                });
        }

        return sidebarItemsList;
    }
);
