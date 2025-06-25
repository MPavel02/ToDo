import { Suspense } from 'react';
import { classNames } from 'shared/lib/classNames/classNames';
import { AppRouter } from 'app/providers/router';
import {Header} from "widgets/Header";
import {Sidebar} from "widgets/Sidebar";

function App() {
    return (
        <div className={classNames('app', {}, [])}>
            <Suspense fallback="">
                <Header/>
                <div className={'app__container'}>
                    <Sidebar/>
                    <AppRouter />
                </div>
            </Suspense>
        </div>);
}

export default App;
