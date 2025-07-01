import { classNames, Mods } from 'shared/lib/classNames/classNames';
import cls from './Card.module.scss';
import { HTMLAttributes, ReactNode } from 'react';

interface CardProps extends HTMLAttributes<HTMLDivElement> {
    className?: string;
    children: ReactNode;
}

export const Card = (props: CardProps) => {
    const {
        className,
        children,
        ...otherProps
    } = props;

    const mods: Mods = {};

    return (
        <div
            className={classNames(cls.Card, mods, [className])}
            {...otherProps}
        >
            {children}
        </div>
    );
};