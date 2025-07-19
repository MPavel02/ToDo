import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UsersPage.module.scss';
import { memo, useEffect } from 'react';
import { Page } from 'widgets/Page';
import { useSelector } from 'react-redux';
import { DynamicModuleLoader, ReducersList } from 'shared/lib/components/DynamicModuleLoader/DynamicModuleLoader';
import { fetchUserList } from 'pages/UsersPage/model/services/fetchUserList/fetchUserList';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { useTranslation } from 'react-i18next';
import { Text } from 'shared/ui/Text/Text';
import { UserList } from 'entities/User/ui/UserList/UserList';
import { getUsers, usersPageReducer } from '../model/slice/usersPageSlice';
import { getUsersPageError, getUsersPageIsLoading } from '../model/selectors/usersPageSelectors';
import { Error } from 'shared/ui/Error/Error';

interface UsersPageProps {
    className?: string;
}

const reducers: ReducersList = {
    usersPage: usersPageReducer
};

const UsersPage = (props: UsersPageProps) => {
    const {
        className
    } = props;

    const { t } = useTranslation('users');

    const dispatch = useAppDispatch();
    const users = useSelector(getUsers.selectAll);
    const isLoading = useSelector(getUsersPageIsLoading);
    const error = useSelector(getUsersPageError);

    useEffect(() => {
        dispatch(fetchUserList());
    }, [dispatch]);

    return (
        <DynamicModuleLoader reducers={reducers}>
            <Page className={classNames('', {}, [className])}>
                {error
                    ? <Error apiError={error}/>
                    : <>
                        <Text title={t('UsersListTitle')}/>
                        <UserList
                            className={cls.list}
                            users={users}
                            isLoading={isLoading}
                        />
                    </> }
            </Page>
        </DynamicModuleLoader>
    );
};

export default memo(UsersPage);
