import React from 'react';

export interface SidebarItemType {
    path: string;
    text: string;
    Icon: React.VFC;
    isAdmin?: boolean;
}
