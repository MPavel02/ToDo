import { classNames, Mods } from 'shared/lib/classNames/classNames';
import cls from './SidebarItem.module.scss';
import { useTranslation } from 'react-i18next';
import React, { memo } from 'react';
import { SidebarItemType } from '../../model/types/sidebar';
import { Button, ButtonTheme } from 'shared/ui/Button/Button';
import { getUserRole, UserRole } from 'entities/User';
import { useLocation } from 'react-router-dom';
import { useSelector } from 'react-redux';

interface SidebarItemProps {
    item: SidebarItemType;
    collapsed: boolean;
    className?: string;
}

export const SidebarItem = memo((props: SidebarItemProps) => {
    const {
        item,
        collapsed,
        className
    } = props;

    const { t } = useTranslation('sidebar');

    const location = useLocation();
    const isActive = location.pathname === item.path;

    const userRole = useSelector(getUserRole);

    if (item.isAdmin && userRole !== UserRole.Admin) {
        return null;
    }

    const mods: Mods = {
        [cls.collapsed]: collapsed
    };

    return (
        <li className={classNames('', mods, [className])}>
            <Button
                className={cls.sidebar__item__container}
                as={'link'}
                to={item.path}
                active={isActive}
                theme={ButtonTheme.SIDEBAR}
            >
                <item.Icon/>
                <span className={cls.sidebar__item__text}>
                    {t(item.text)}
                </span>
            </Button>
        </li>
    );
});
