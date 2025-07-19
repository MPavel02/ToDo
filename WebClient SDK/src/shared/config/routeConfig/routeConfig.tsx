import { RouteProps } from 'react-router-dom';
import { NotFoundPage } from 'pages/NotFoundPage';
import { NotesPage } from 'pages/NotesPage';
import { MainPage } from 'pages/MainPage';
import { LogsPage } from 'pages/LogsPage';
import { UsersPage } from 'pages/UsersPage';
import { UserDetailsPage } from 'pages/UserDetailsPage';

export type AppRoutesProps = RouteProps & {
    authOnly?: boolean;
};

export enum AppRoutes {
    MAIN = 'main',
    LOGS = 'logs',
    USERS = 'users',
    USER_DETAILS = 'user_details',
    NOTES = 'notes',
    NOTE_DETAILS = 'note_details',
    NOTE_CREATE = 'note_create',
    NOTE_EDIT = 'note_edit',

    // Комментарий является разделителем, так как NotFoundPage будет отрисовываться,
    // когда пользователь будет пытаться попасть на страницу с несуществующим адресом
    NOT_FOUND = 'not_found'
}

export const RoutePath: Record<AppRoutes, string> = {
    [AppRoutes.MAIN]: '/',
    [AppRoutes.LOGS]: '/logs',
    [AppRoutes.USERS]: '/users',
    [AppRoutes.USER_DETAILS]: '/users/',
    [AppRoutes.NOTES]: '/notes',
    [AppRoutes.NOTE_DETAILS]: '/notes/',
    [AppRoutes.NOTE_CREATE]: '/notes/create',
    [AppRoutes.NOTE_EDIT]: '/notes/:id/edit',

    // Комментарий является разделителем, так как NotFoundPage будет отрисовываться,
    // когда пользователь будет пытаться попасть на страницу с несуществующим адресом
    [AppRoutes.NOT_FOUND]: '*'
};

export const routeConfig: Record<AppRoutes, AppRoutesProps> = {
    [AppRoutes.MAIN]: {
        path: RoutePath.main,
        element: <MainPage/>,
        authOnly: false
    },
    [AppRoutes.LOGS]: {
        path: RoutePath.logs,
        element: <LogsPage/>,
        authOnly: true
    },
    [AppRoutes.USERS]: {
        path: RoutePath.users,
        element: <UsersPage/>,
        authOnly: true
    },
    [AppRoutes.USER_DETAILS]: {
        path: `${RoutePath.user_details}:id`,
        element: <UserDetailsPage/>,
        authOnly: true
    },
    [AppRoutes.NOTES]: {
        path: RoutePath.notes,
        element: <NotesPage/>,
        authOnly: true
    },
    [AppRoutes.NOTE_DETAILS]: {
        path: `${RoutePath.note_details}:id`,
        element: '',
        authOnly: true
    },
    [AppRoutes.NOTE_CREATE]: {
        path: RoutePath.note_create,
        element: '',
        authOnly: true
    },
    [AppRoutes.NOTE_EDIT]: {
        path: RoutePath.note_edit,
        element: '',
        authOnly: true
    },

    // Комментарий является разделителем, так как NotFoundPage будет отрисовываться,
    // когда пользователь будет пытаться попасть на страницу с несуществующим адресом
    [AppRoutes.NOT_FOUND]: {
        path: RoutePath.not_found,
        element: <NotFoundPage/>
    }
};
