import { classNames } from 'shared/lib/classNames/classNames';
import cls from './MainPage.module.scss';
import { useTranslation } from 'react-i18next';
import { memo } from 'react';
import { Page } from 'widgets/Page';

interface MainPageProps {
    className?: string;
}

const MainPage = memo((props: MainPageProps) => {
    const {
        className
    } = props;

    return (
        <Page className={classNames(cls.MainPage, {}, [className])}>
            {'Основная страница'}
        </Page>
    );
});

export default memo(MainPage);
