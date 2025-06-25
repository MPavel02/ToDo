import {classNames} from "shared/lib/classNames/classNames";
import {useLocation} from "react-router-dom";
import {Button} from "shared/ui/Button/Button";
import React, {memo} from "react";

interface NavItemProps {
    className?: string;
    to: string;
    children?: React.ReactNode;
}

export const NavItem = memo((props: NavItemProps) => {
    const {
        className,
        to,
        children
    } = props;

    const location = useLocation();
    const isActive = location.pathname === to;

    return (
        <li className={classNames('', {}, [className])}>
            <Button
                className={isActive ? 'active' : ''}
                as={'link'}
                to={to}
            >
                {children}
            </Button>
        </li>
    );
});
