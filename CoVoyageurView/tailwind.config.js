/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors')

module.exports = {
    mode: 'jit',
    content: ["./**/*.{razor,html,cshtml}"],
    theme: {
        colors: {
            'primary': {
                50: '#e9faf5',
                100: '#baefde',
                200: '#98e8cf',
                300: '#6addb9',
                400: '#4dd6ab',
                500: '#20cc96',
                600: '#1dba89',
                700: '#17916b',
                800: '#127053',
                900: '#0d563f',
            },
        },
    },
    plugins: [],
}