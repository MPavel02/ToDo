import { classNames, Mods } from 'shared/lib/classNames/classNames';
import cls from './Button.module.scss';
import { ButtonHTMLAttributes, memo, ReactNode } from 'react';
import { Link, LinkProps } from 'react-router-dom';
import { Loader2 } from 'lucide-react';

export enum ButtonTheme {
    CLEAR = 'clear',
    AUTH = 'auth',
    SIDEBAR = 'sidebar',
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
    active?: boolean;
};

type ButtonAsButton = BaseProps & Omit<ButtonHTMLAttributes<HTMLButtonElement>, keyof BaseProps> & {
    as: 'button';
    size?: ButtonSize;
    loading?: boolean;
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
            loading = false,
            ...otherProps
        } = props;

        const mods: Mods = {
            [cls.disabled]: disabled,
            [cls.loading]: loading
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
                <div className={cls.btnContainer}>
                    {loading && <Loader2 className={cls.loader} size={16}/>}
                    {children}
                </div>
            </button>
        );
    }

    const {
        to,
        className,
        children,
        theme = ButtonTheme.CLEAR,
        disabled,
        active,
        ...otherProps
    } = props;

    const mods: Mods = {
        [cls.disabled]: disabled,
        [cls.active]: active
    };

    const additional: Array<string | undefined> = [
        className,
        cls[theme]
    ];

    return (
        <Link
            to={to}
            className={classNames(cls.Button, mods, additional)}
            {...otherProps}
        >
            {children}
        </Link>
    );
});
