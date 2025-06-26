import 'app/styles/index.scss';
import 'shared/config/i18n/i18n';
import App from './App';
import { StoreProvider } from 'app/providers/StoreProvider';
import { AuthProvider } from 'app/providers/AuthProvider';
import { BrowserRouter } from 'react-router-dom';
import { ErrorBoundary } from 'app/providers/ErrorBoundary';
import { render } from 'react-dom';

render(
    <BrowserRouter>
        <StoreProvider>
            <ErrorBoundary>
                <AuthProvider>
                    <App/>
                </AuthProvider>
            </ErrorBoundary>
        </StoreProvider>
    </BrowserRouter>,
    document.getElementById('root')
);
