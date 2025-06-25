import {classNames} from 'shared/lib/classNames/classNames';
import cls from './Header.module.scss';
import React from 'react';
import {Button, ButtonTheme} from "shared/ui/Button/Button";

interface HeaderProps {
    className?: string;
}

export const Header = ({ className }: HeaderProps) => {
    return (
        <header className={classNames(cls.Header, {}, [className])}>
            <div className={cls.header__container}>
                <Button as={'button'} theme={ButtonTheme.AUTH}>
                    Авторизоваться
                </Button>
            </div>
        </header>
    );
};
