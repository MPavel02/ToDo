import { format } from 'date-fns';

/**
 * Стандартный паттерн формата даты.
 */
const StandardDateFormat = 'dd.MM.yyyy HH:mm';

export function getDateString(date: Date | undefined): string {
    return format(date ?? 0, StandardDateFormat);
}