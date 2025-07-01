import React from 'react';

export type TableColumn<T> = {
    key: keyof T | 'actions';
    label: string;
    render?: (item: T) => React.ReactNode;
};
