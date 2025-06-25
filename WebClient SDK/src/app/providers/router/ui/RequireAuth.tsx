import { Navigate, useLocation } from 'react-router-dom';
import { RoutePath } from 'shared/config/routeConfig/routeConfig';
import { JSX } from 'react';
import {useAuth} from "shared/lib/hooks/useAuth/useAuth";

export function RequireAuth({ children }: { children: JSX.Element }) {
    const { isAuthenticated } = useAuth();
    const location = useLocation();

    if (!isAuthenticated) {
        return <Navigate to={RoutePath.main} state={{ from: location }} replace />;
    }

    return children;
}
