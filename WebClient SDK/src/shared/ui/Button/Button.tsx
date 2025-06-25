import { classNames, Mods } from 'shared/lib/classNames/classNames';
import cls from './Button.module.scss';
import { ButtonHTMLAttributes, memo, ReactNode } from 'react';
import { Link, LinkProps } from 'react-router-dom';

export enum ButtonTheme {
    CLEAR = 'clear',
    AUTH = 'auth'
}

export enum ButtonSize {
    M = 'size_m',
    L = 'size_l',
    XL = 'size_xl'
}

type BaseProps = {
    className?: string;
    children?: ReactNode;
    theme?: ButtonTheme;
    disabled?: boolean;
};

type ButtonAsButton = BaseProps & Omit<ButtonHTMLAttributes<HTMLButtonElement>, keyof BaseProps> & {
    as: 'button';
    size?: ButtonSize;
};

type ButtonAsLink = BaseProps & Omit<LinkProps, keyof BaseProps> & {
    as: 'link';
};

type ButtonProps =
    | ButtonAsButton
    | ButtonAsLink;

export const Button = memo((props: ButtonProps) => {
    if (props.as === 'button') {
        const {
            className,
            children,
            theme = ButtonTheme.CLEAR,
            disabled,
            size = ButtonSize.M,
            ...otherProps
        } = props;

        const mods: Mods = {
            [cls.disabled]: disabled
        };

        const additional: Array<string | undefined> = [
            className,
            cls[theme],
            cls[size]
        ];

        return (
            <button
                type='button'
                className={classNames(cls.Button, mods, additional)}
                disabled={disabled}
                {...otherProps}
            >
                {children}
            </button>
        );
    }

    const {
        to,
        className,
        children,
        theme = ButtonTheme.CLEAR,
        disabled,
        ...otherProps
    } = props;

    const mods: Mods = {
        [cls.disabled]: disabled
    };

    return (
        <Link
            to={to}
            className={classNames(cls.Button, mods, [className, cls[theme]])}
            {...otherProps}
        >
            {children}
        </Link>
    );
});
