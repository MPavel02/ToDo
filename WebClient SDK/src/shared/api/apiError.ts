import axios, { AxiosError } from 'axios';

interface ApiErrorResponse {
    message: string;
    description?: string;
}

export interface ApiError {
    statusCode: number;
    response: ApiErrorResponse;
}

export function handleAxiosError(error: unknown): ApiError {
    if (axios.isAxiosError(error)) {
        const axiosError = error as AxiosError;

        if (axiosError.response?.data) {
            const apiErrorResponse = axiosError.response.data as ApiErrorResponse;

            return {
                statusCode: axiosError.response.status,
                response: apiErrorResponse
            };
        } else if (axiosError.request) {
            return {
                statusCode: 444,
                response: {
                    message: 'Сервер не отвечает'
                }
            };
        } else {
            return {
                statusCode: 400,
                response: {
                    message: 'Некорректный запрос'
                }
            };
        }
    } else if (error instanceof Error) {
        return {
            statusCode: 400,
            response: {
                message: error.message,
                description: `Name: ${error.name}, stackTrace: ${error.stack}`
            }
        };
    } else {
        return {
            statusCode: 400,
            response: {
                message: 'Неизвестная ошибка'
            }
        };
    }
}
