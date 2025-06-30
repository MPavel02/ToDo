import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UsersPage.module.scss';
import { memo } from 'react';

interface UsersPageProps {
    className?: string;
}

const UsersPage = ({ className }: UsersPageProps) => {
    return (
        <div className={classNames(cls.UsersPage, {}, [className])}>
            Пользователи
        </div>
    );
};

export default memo(UsersPage);
