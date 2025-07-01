import { classNames } from 'shared/lib/classNames/classNames';
import cls from './LogsPage.module.scss';
import { memo } from 'react';
import { Page } from 'widgets/Page';
import { useTranslation } from 'react-i18next';

interface LogsPageProps {
    className?: string;
}

const LogsPage = ({ className }: LogsPageProps) => {
    const { t } = useTranslation('logs');

    return (
        <Page className={classNames(cls.LogsPage, {}, [className])}>
            {t('Logs')}
        </Page>
    );
};

export default memo(LogsPage);
