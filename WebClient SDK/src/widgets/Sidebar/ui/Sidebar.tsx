import cls from './Sidebar.module.scss';
import { classNames } from 'shared/lib/classNames/classNames';
import { memo } from 'react';
import { useTranslation } from 'react-i18next';
import {NavItem} from "shared/ui/NavItem/ui/NavItem";
import {RoutePath} from "shared/config/routeConfig/routeConfig";

interface SidebarProps {
    className?: string;
}

export const Sidebar = memo(({ className }: SidebarProps) => {
    const { t } = useTranslation('sidebar');

    return (
        <aside className={classNames(cls.Sidebar, {}, [className])}>
            <nav className={cls.nav}>
                <ul>
                    <NavItem
                        className={cls.nav__item}
                        to={RoutePath.notes}
                    >
                        {t('Notes')}
                    </NavItem>
                </ul>
            </nav>
        </aside>
    );
});
