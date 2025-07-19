import { classNames } from 'shared/lib/classNames/classNames';
import cls from './UserDetailsPage.module.scss';
import { memo,  } from 'react';
import { Page } from 'widgets/Page';
import { useParams } from 'react-router-dom';
import { UserDetails } from '../UserDetails/UserDetails';

interface UserDetailsPageProps {
    className?: string;
}

const UserDetailsPage = memo((props: UserDetailsPageProps) => {
    const {
        className
    } = props;
    const { id = '1' } = useParams<{ id: string }>();

    return (
        <Page className={classNames(cls.UserDetailsPage, {}, [className])}>
            <UserDetails id={id}/>
        </Page>
    );
});

export default memo(UserDetailsPage);