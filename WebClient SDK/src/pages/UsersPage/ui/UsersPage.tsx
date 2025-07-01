import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UsersPage.module.scss';
import { memo, useEffect, useState } from 'react';
import { Page } from 'widgets/Page';
import { Checkbox } from 'shared/ui/Checkbox/Checkbox';
import { useSelector } from 'react-redux';
import { getUsers, usersPageReducer } from 'pages/UsersPage';
import { DynamicModuleLoader, ReducersList } from 'shared/lib/components/DynamicModuleLoader/DynamicModuleLoader';
import { fetchUsersList } from 'pages/UsersPage/model/services/fetchUsersList/fetchUsersList';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { useTranslation } from 'react-i18next';
import { Text } from 'shared/ui/Text/Text';

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
    //const isLoading = useSelector(getUsersPageIsLoading);
    //const error = useSelector(getUsersPageError);

    const [selectedUsers, setSelectedUsers] = useState<Set<string>>(new Set());

    const handleToggle = (id: string) => {
        const newSelected = new Set(selectedUsers);
        if (newSelected.has(id)) {
            newSelected.delete(id);
        } else {
            newSelected.add(id);
        }
        setSelectedUsers(newSelected);
    };

    useEffect(() => {
        dispatch(fetchUsersList());
    }, [dispatch]);

    return (
        <DynamicModuleLoader reducers={reducers} removeAfterUnmount={false}>
            <Page className={classNames('', {}, [className])}>
                <Text title={t('UsersListTitle')}/>
                <ul className={cls.list__container}>
                    {users.map((item) => (
                        <li key={item.id} className={cls.list__item}>
                            <Checkbox
                                id={item.id}
                                label={item.username}
                                checked={selectedUsers.has(item.id)}
                                onChange={() => handleToggle(item.id)}
                            />
                        </li>
                    ))}
                </ul>
            </Page>
        </DynamicModuleLoader>
    );
};

export default memo(UsersPage);
