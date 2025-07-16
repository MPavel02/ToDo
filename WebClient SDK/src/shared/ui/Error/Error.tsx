import { classNames } from 'shared/lib/classNames/classNames';
import cls from './Error.module.scss';
import { useTranslation } from 'react-i18next';
import { memo } from 'react';
import { Text } from 'shared/ui/Text/Text';
import { ApiError } from 'shared/api/apiError';

interface ErrorProps {
    className?: string;
    apiError?: ApiError;
}

export const Error = memo((props: ErrorProps) => {
    const {
        className,
        apiError
    } = props;
    const { t } = useTranslation();

    return (
        <div className={classNames(cls.Error, {}, [className])}>
            <Text title={t('ErrorMessage')} text={apiError?.response.message}/>
            <Text title={t('ErrorDetails')} text={apiError?.response.description}/>
            <Text title={t('ErrorStatusCode')} text={apiError?.statusCode.toString()}/>
        </div>
    );
});
