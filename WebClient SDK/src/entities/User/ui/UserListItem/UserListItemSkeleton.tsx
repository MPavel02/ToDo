import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UserListItem.module.scss';
import { memo } from 'react';
import { Skeleton } from 'shared/ui/Skeleton/Skeleton';
import { Card } from 'shared/ui/Card/Card';
import { Text } from 'shared/ui/Text/Text';
import { useTranslation } from 'react-i18next';

interface UserListItemSkeletonProps {
    className?: string;
}

export const UserListItemSkeleton = memo((props: UserListItemSkeletonProps) => {
    const {
        className
    } = props;
    const { t } = useTranslation();

    return (
        <div className={classNames(cls.UserListItem, {}, [className])}>
            <Card>
                <div className={cls.infoWrapper}>
                    <Text className={cls.infoTitle} text={t('Username') + ':'}/>
                    <Skeleton width={100} height={30} border={'10%'} className={cls.infoWrapper}/>
                </div>
                <div className={cls.infoWrapper}>
                    <Text className={cls.infoTitle} text={t('Role') + ':'}/>
                    <Skeleton width={100} height={30} border={'10%'} className={cls.infoWrapper}/>
                </div>
            </Card>
        </div>
    );
});
