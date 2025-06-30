import { classNames } from 'shared/lib/classNames/classNames';
import cls from './LogsPage.module.scss';
import { memo } from 'react';

interface LogsPageProps {
    className?: string;
}

const LogsPage = ({ className }: LogsPageProps) => {
    return (
        <div className={classNames(cls.LogsPage, {}, [className])}>
            Логи
        </div>
    );
};

export default memo(LogsPage);
