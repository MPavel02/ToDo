import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UserList.module.scss';
import { memo } from 'react';
import { UserLookup } from '../../model/types/user';
import { UserListItem } from '../UserListItem/UserListItem';
import { UserListItemSkeleton } from '../UserListItem/UserListItemSkeleton';

interface UserListProps {
    className?: string;
    users: UserLookup[];
    isLoading?: boolean;
}

const getSkeletons = () => {
    return new Array(3)
        .fill(0)
        .map((_, index) => (
            <UserListItemSkeleton
                className={cls.card}
                key={index}
            />
        ));
};

export const UserList = memo((props: UserListProps) => {
    const {
        className,
        users,
        isLoading
    } = props;

    const renderUser = (user: UserLookup) => {
        return (
            <UserListItem
                className={cls.card}
                user={user}
                key={user.id}
            />
        );
    };

    return (
        <div className={classNames(cls.UserList, {}, [className])}>
            {users.length > 0
                ? users.map(renderUser)
                : null}
            {isLoading && getSkeletons()}
        </div>
    );
});
