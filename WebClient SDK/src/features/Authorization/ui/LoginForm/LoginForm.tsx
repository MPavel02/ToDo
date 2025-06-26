import { classNames } from 'shared/lib/classNames/classNames';
import cls from './LoginForm.module.scss';
import { useTranslation } from 'react-i18next';
import { Button, ButtonSize } from 'shared/ui/Button/Button';
import { Input } from 'shared/ui/Input/Input';
import { useSelector } from 'react-redux';
import { memo, useCallback, useEffect } from 'react';
import { loginActions, loginReducer } from '../../model/slice/loginSlice';
import { loginByUsername } from 'features/Authorization/model/services/loginByUsername/loginByUsername';
import { Text, TextTheme } from 'shared/ui/Text/Text';
import { DynamicModuleLoader, ReducersList } from 'shared/lib/components/DynamicModuleLoader/DynamicModuleLoader';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { getLoginError, getLoginIsLoading, getLoginPassword, getLoginUsername } from 'features/Authorization';
import { useAuth } from 'shared/lib/hooks/useAuth/useAuth';
import { getUserToken } from 'entities/User';

export interface LoginFormProps {
    className?: string;
    onSuccess: () => void;
}

const initialReducers: ReducersList = {
    loginForm: loginReducer
};

const LoginForm = ({ className, onSuccess }: LoginFormProps) => {
    const { t } = useTranslation('loginForm');
    const dispatch = useAppDispatch();

    const { login } = useAuth();

    const username = useSelector(getLoginUsername);
    const password = useSelector(getLoginPassword);
    const isLoading = useSelector(getLoginIsLoading);
    const error = useSelector(getLoginError);
    const token = useSelector(getUserToken);

    const onChangeUsername = useCallback((value: string) => {
        dispatch(loginActions.setUsername(value));
    }, [dispatch]);

    const onChangePassword = useCallback((value: string) => {
        dispatch(loginActions.setPassword(value));
    }, [dispatch]);

    const onLoginClick = useCallback(async () => {
        const result = await dispatch(loginByUsername({ username, password }));
        if (result.meta.requestStatus === 'fulfilled') {
            onSuccess();
        }
    }, [dispatch, onSuccess, password, username]);

    useEffect(() => {
        login(token);
    }, [login, token]);

    return (
        <DynamicModuleLoader
            reducers={initialReducers}
        >
            <div className={classNames(cls.LoginForm, {}, [className])}>
                <Text title={t('FormAuthorization')}/>
                {error && <Text text={t('NotValidAuthData')} theme={TextTheme.ERROR}/>}
                <div className={cls.authInputWrapper}>
                    <p className={cls.placeholder}>
                        {t('LoginPlaceholder')}
                    </p>
                    <Input
                        type={'text'}
                        className={cls.input}
                        autofocus={true}
                        onChange={onChangeUsername}
                        value={username}
                    />
                </div>
                <div className={cls.authInputWrapper}>
                    <p className={cls.placeholder}>
                        {t('PasswordPlaceholder')}
                    </p>
                    <Input
                        type={'password'}
                        className={cls.input}
                        onChange={onChangePassword}
                        value={password}
                    />
                </div>
                <Button
                    className={cls.loginBtn}
                    as={'button'}
                    size={ButtonSize.M}
                    onClick={onLoginClick}
                    disabled={isLoading}
                >
                    {t('LoginFormEnterBtn')}
                </Button>
            </div>
        </DynamicModuleLoader>
    );
};

export default memo(LoginForm);
