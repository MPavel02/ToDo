import { classNames } from 'shared/lib/classNames/classNames';
import cls from './Page.module.scss';
import { MutableRefObject, ReactNode, useRef } from 'react';

interface PageProps {
    className?: string;
    children: ReactNode;
}

export const Page = (props: PageProps) => {
    const {
        className,
        children
    } = props;
    const wrapperRef = useRef() as MutableRefObject<HTMLDivElement>;

    return (
        <section
            ref={wrapperRef}
            className={classNames(cls.Page, {}, [className])}
        >
            {children}
        </section>
    );
};
