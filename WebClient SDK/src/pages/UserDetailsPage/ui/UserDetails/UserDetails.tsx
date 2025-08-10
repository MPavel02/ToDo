import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UserDetails.module.scss';
import { DynamicModuleLoader, ReducersList } from 'shared/lib/components/DynamicModuleLoader/DynamicModuleLoader';
import { fetchUserDataByID, getUser, userReducer } from 'entities/User';
import { Card } from 'shared/ui/Card/Card';
import { useTranslation } from 'react-i18next';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { useEffect } from 'react';
import { Text, TextTheme } from 'shared/ui/Text/Text';
import { useSelector } from 'react-redux';
import { getUserRole } from 'entities/User/model/types/user';
import { getDateString } from 'shared/const/date';

interface UserDetailsProps {
    className?: string;
    id: string;
}

const reducers: ReducersList = {
    user: userReducer
};

export const UserDetails = (props: UserDetailsProps) => {
    const {
        className,
        id
    } = props;

    const { t: tCommon } = useTranslation();
    const { t: tRoles } = useTranslation('roles');

    const dispatch = useAppDispatch();

    const user = useSelector(getUser);

    useEffect(() => {
        dispatch(fetchUserDataByID(id));
    }, [dispatch, id]);

    return (
        <DynamicModuleLoader reducers={reducers}>
            <Card className={classNames(cls.UserDetails, {}, [className])}>
                <div className={cls.details__title__container}>
                    <Text title={user?.username} className={cls.details__title}/>
                </div>
                <div className={cls.details__body__container}>
                    <div className={cls.property__row}>
                        <Text theme={TextTheme.SECONDARY} text={tCommon('Role') + ':'} />
                        <Text theme={TextTheme.SECONDARY} text={tRoles(getUserRole(user?.role))}/>
                    </div>
                    <div className={cls.property__row}>
                        <Text theme={TextTheme.SECONDARY} text={tCommon('CreatedAt') + ':'} />
                        <Text theme={TextTheme.SECONDARY} text={getDateString(user?.createdAt)}/>
                    </div>
                    {user?.updatedAt && <div className={cls.property__row}>
                        <Text theme={TextTheme.SECONDARY} text={tCommon('UpdatedAt') + ':'} />
                        <Text theme={TextTheme.SECONDARY} text={getDateString(user?.updatedAt)}/>
                    </div>}
                </div>
            </Card>
        </DynamicModuleLoader>
    );
};
