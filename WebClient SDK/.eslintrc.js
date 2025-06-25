module.exports = {
    env: {
        browser: true,
        es2021: true,
        jest: true
    },
    extends: [
        'eslint:recommended',
        'plugin:@typescript-eslint/recommended',
        'plugin:react/recommended',
        'plugin:i18next/recommended',
        'plugin:storybook/recommended'
    ],
    overrides: [
        {
            env: {
                'node': true
            },
            files: [
                '.eslintrc.{js,cjs}',
                '**/src/**/*.{test,stories}.{ts,tsx}'
            ],
            parserOptions: {
                'sourceType': 'script'
            },
            rules: {
                'i18next/no-literal-string': 'off',
                'max-len': 'off'
            }
        }
    ],
    parser: '@typescript-eslint/parser',
    parserOptions: {
        'ecmaVersion': 'latest',
        'sourceType': 'module'
    },
    plugins: [
        '@typescript-eslint',
        'react',
        'i18next',
        'react-hooks'
    ],
    rules: {
        'linebreak-style': ['error', 'windows'],
        'quotes': ['error', 'single'],
        'semi': ['error', 'always'],
        indent: [2, 4,
            {
                SwitchCase: 1,
                MemberExpression: 1
            }
        ],
        'react/jsx-filename-extension': [
            2,
            { 'extensions': ['.js', '.jsx', '.tsx'] }
        ],
        'import/no-unresolved': 'off',
        'import/prefer-default-export': 'off',
        'no-unused-vars': 'off',
        '@typescript-eslint/no-unused-vars': [
            'error',
            { 'argsIgnorePattern': '^_' }
        ],
        'react-require-default-props': 'off',
        'react/react-in-jsx-scope': 'off',
        'react/jsx-props-no-spreading': 'warn',
        'react/function-component-definition': 'off',
        'no-shadow': 'off',
        'import/extensions': 'off',
        'import/no-extraneous-dependencies': 'off',
        'react/no-deprecated': 'off',
        'no-underscore-dangle': 'off',
        'i18next/no-literal-string': [
            'error',
            {
                markupOnly: true,
                ignoreAttribute: [
                    'to',
                    'target',
                    'as'
                ]
            }
        ],
        'max-len': ['error', { 'ignoreComments': true, code: 120 }],
        'react/display-name': 'off',
        'no-undef': 'off',
        '@typescript-eslint/no-var-requires': 'off',
        'jsx-a11y/no-static-element-interactions': 'off',
        'react-hooks/rules-of-hooks': 'error',
        'react-hooks/exhaustive-deps': 'error',
        'no-param-reassign': 'off',
        'object-curly-spacing': ['error', 'always'],
        '@typescript-eslint/no-explicit-any': ['off'],
        'react/no-array-index-key': 'off'
    },
    globals: {
        __IS_DEV__: true,
        __API__: true,
        __PROJECT__: true,
    },
    settings: {
        react: {
            version: 'detect'
        }
    }
};
