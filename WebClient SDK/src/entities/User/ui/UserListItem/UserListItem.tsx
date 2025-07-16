import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UserListItem.module.scss';
import { useTranslation } from 'react-i18next';
import { memo } from 'react';
import { getUserRole, UserLookup } from '../../model/types/user';
import { Card } from 'shared/ui/Card/Card';
import { Button } from 'shared/ui/Button/Button';
import { RoutePath } from 'shared/config/routeConfig/routeConfig';
import { Text } from 'shared/ui/Text/Text';

interface UserListItemProps {
    className?: string;
    user: UserLookup;
}

export const UserListItem = memo((props: UserListItemProps) => {
    const {
        className,
        user
    } = props;
    const { t } = useTranslation();

    return (
        <Button as={'link'} to={RoutePath.not_found} className={classNames(cls.UserListItem, {}, [className])}>
            <Card>
                <div className={cls.infoWrapper}>
                    <Text className={cls.infoTitle} text={t('Username') + ':'}/>
                    <Text text={user.username}/>
                </div>
                <div className={cls.infoWrapper}>
                    <Text className={cls.infoTitle} text={t('Role') + ':'}/>
                    <Text text={t(getUserRole(user.role))}/>
                </div>
            </Card>
        </Button>
    );
});
