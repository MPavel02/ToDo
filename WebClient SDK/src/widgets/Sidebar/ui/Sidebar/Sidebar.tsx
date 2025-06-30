import cls from './Sidebar.module.scss';
import { classNames } from 'shared/lib/classNames/classNames';
import { memo, useMemo } from 'react';
import { getSidebarItems } from '../../model/selectors/getSidebarItems';
import { useSelector } from 'react-redux';
import { SidebarItem } from '../SidebarItem/SidebarItem';

interface SidebarProps {
    className?: string;
}

export const Sidebar = memo(({ className }: SidebarProps) => {
    const sidebarItemsList = useSelector(getSidebarItems);

    const itemsList = useMemo(() => sidebarItemsList.map((item) => (
        <SidebarItem
            item={item}
            collapsed={false}
            key={item.path}
            className={cls.sidebar__item}
        />
    )), [sidebarItemsList]);

    return (
        <aside className={classNames(cls.Sidebar, {}, [className])}>
            <ul>
                {itemsList}
            </ul>
        </aside>
    );
});
