import webpack from 'webpack';
import { buildWebpackConfig } from './config/build/buildWebpackConfig';
import { BuildEnv, BuildPaths } from './config/build/types/config';
import path from 'path';

export default (env: BuildEnv) => {
    const paths: BuildPaths = {
        entry: path.resolve(__dirname, 'src', 'index.tsx'),
        build: path.resolve(__dirname, 'build'),
        html: path.resolve(__dirname, 'public', 'index.html'),
        src: path.resolve(__dirname, 'src')
    };

    const mode = env.mode || 'development';
    const PORT = env.port || 3000;
    const isDev = mode === 'development';
    const apiUrl = env.apiUrl || 'https://localhost:7276';

    const config: webpack.Configuration = buildWebpackConfig({
        mode,
        paths,
        isDev,
        port: PORT,
        apiUrl: apiUrl
    });

    return config;
};
