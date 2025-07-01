import { classNames } from 'shared/lib/classNames/classNames';
import cls from './Checkbox.module.scss';
import { memo } from 'react';

interface CheckboxProps {
    className?: string;
    id: string;
    label: string;
    checked: boolean;
    onChange: (checked: boolean) => void;
}

export const Checkbox = memo((props: CheckboxProps) => {
    const {
        className,
        id,
        label,
        checked,
        onChange
    } = props;

    return (
        <label className={classNames(cls.checkbox__label, {}, [className])}>
            <input
                type="checkbox"
                id={id}
                checked={checked}
                onChange={(e) => onChange(e.target.checked)}
                className={cls.checkbox__input}
            />
            {label}
        </label>
    );
});
