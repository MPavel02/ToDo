import { classNames } from 'shared/lib/classNames/classNames';
import cls from './MainPage.module.scss';
import { memo } from 'react';
import { Page } from 'widgets/Page';
import { useTranslation } from 'react-i18next';

interface MainPageProps {
    className?: string;
}

const MainPage = memo((props: MainPageProps) => {
    const {
        className
    } = props;

    const { t } = useTranslation('main');

    return (
        <Page className={classNames(cls.MainPage, {}, [className])}>
            {t('Main')}
        </Page>
    );
});

export default memo(MainPage);
