import { classNames } from 'shared/lib/classNames/classNames';
import cls from './Header.module.scss';
import React, { useCallback, useState } from 'react';
import { Button, ButtonTheme } from 'shared/ui/Button/Button';
import { LoginModal } from 'features/Authorization';
import { useTranslation } from 'react-i18next';
import { useAuth } from 'shared/lib/hooks/useAuth/useAuth';

interface HeaderProps {
    className?: string;
}

export const Header = ({ className }: HeaderProps) => {
    const { t } = useTranslation('header');

    const { isAuthenticated, logout } = useAuth();

    const [isAuthModal, setIsAuthModal] = useState(false);

    const onCloseModal = useCallback(() => {
        setIsAuthModal(false);
    }, []);

    const onShowModal = useCallback(() => {
        setIsAuthModal(true);
    }, []);

    const onAuthClick = isAuthenticated
        ? () => logout()
        : onShowModal;

    return (
        <header className={classNames(cls.Header, {}, [className])}>
            <Button
                className={cls.auth__btn}
                as={'button'}
                theme={ButtonTheme.AUTH}
                onClick={onAuthClick}
            >
                {isAuthenticated ? t('Logout') : t('Login')}
            </Button>
            <LoginModal
                isOpen={isAuthModal}
                onClose={onCloseModal}
            />
        </header>
    );
};
