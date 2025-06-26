import { classNames } from 'shared/lib/classNames/classNames';
import cls from './NotesPage.module.scss';
import { useTranslation } from 'react-i18next';
import { memo } from 'react';
import { DynamicModuleLoader, ReducersList } from 'shared/lib/components/DynamicModuleLoader/DynamicModuleLoader';
import { Page } from 'widgets/Page';

interface NotesPageProps {
    className?: string;
}

const reducers: ReducersList = {
};

const NotesPage = ({ className }: NotesPageProps) => {
    const { t } = useTranslation();

    return (
        <DynamicModuleLoader reducers={reducers} removeAfterUnmount={false}>
            <Page className={classNames(cls.NotesPage, {}, [className])}>
                {'Заметки'}
            </Page>
        </DynamicModuleLoader>
    );
};

export default memo(NotesPage);
