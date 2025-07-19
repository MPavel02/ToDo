import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UserDetails.module.scss';
import { DynamicModuleLoader, ReducersList } from 'shared/lib/components/DynamicModuleLoader/DynamicModuleLoader';
import { fetchUserDataByID, getUser, userReducer } from 'entities/User';
import { Card } from 'shared/ui/Card/Card';
import { useTranslation } from 'react-i18next';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { useEffect } from 'react';
import { Text } from 'shared/ui/Text/Text';
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
                <Text title={user?.username} className={cls.details__title}/>
                <div className={cls.property__row}>
                    <Text text={tCommon('Role')} />
                    <p>-</p>
                    <Text text={tRoles(getUserRole(user?.role))}/>
                </div>
                <div className={cls.property__row}>
                    <Text text={tCommon('CreatedAt')} />
                    <p>-</p>
                    <Text text={getDateString(user?.createdAt)}/>
                </div>
                {user?.updatedAt && <div className={cls.property__row}>
                    <Text text={tCommon('UpdatedAt')} />
                    <p>-</p>
                    <Text text={getDateString(user?.updatedAt)}/>
                </div>}
            </Card>
        </DynamicModuleLoader>
    );
};