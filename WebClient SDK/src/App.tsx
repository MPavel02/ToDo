import { Suspense, useEffect } from 'react';
import { classNames } from 'shared/lib/classNames/classNames';
import { AppRouter } from 'app/providers/router';
import { Header } from 'widgets/Header';
import { Sidebar } from 'widgets/Sidebar';
import { fetchUserData } from 'entities/User';
import { useAppDispatch } from 'shared/lib/hooks/useAppDispatch/useAppDispatch';
import { useAuth } from 'shared/lib/hooks/useAuth/useAuth';

const App = () => {
    const { token } = useAuth();

    const dispatch = useAppDispatch();

    useEffect(() => {
        if (!token) {
            return;
        }

        dispatch(fetchUserData());
    }, [dispatch, token]);

    return (
        <div className={classNames('app', {}, [])}>
            <Suspense fallback="">
                <Header/>
                <div className={'app__container'}>
                    <Sidebar/>
                    <AppRouter/>
                </div>
            </Suspense>
        </div>);
};

export default App;
