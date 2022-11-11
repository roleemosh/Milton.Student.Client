const colors = require('tailwindcss/colors')


module.exports = {
    mode: 'jit',
    content: [
        // Example content paths...
        './**/*.html',
        './**/*.razor',
        './**/*.css'
    ],
    darkMode: 'class',
    theme: {
        extend: {
            colors: {
                colorPrimary: {
                    light: "#1B6FAD",
                    DEFAULT: "#1B6FAD",
                    dark: "#1B6FAD",
                },
                colorPrimaryDark: {
                    light: "#005FA6",
                    DEFAULT: "#005FA6",
                    dark: "#005FA6",
                },
                colorAccent: {
                    light: "#005FA6",
                    DEFAULT: "#005FA6",
                    dark: "#005FA6",
                },
                colorControlHighlight: {
                    light: "#00487D",
                    DEFAULT: "#00487D",
                    dark: "#00487D",
                },              
                colorControlActivated: {
                    light: "#2A72A7",
                    DEFAULT: "#2A72A7",
                    dark: "#2A72A7",
                },
            },
            fontFamily: {
                'sans': ['Roboto Regular', 'sans-serif'],
                'materialIconFont': ["Material Icons, sans-serif"],
                'bariolFont': ['"Bariol"', 'serif'],
                'robotoBoldFont': ["Roboto Bold, sans-serif"],
                'robotoMediumFont': ["Roboto Medium, sans-serif"],
                'prodHostIconFont': ["prodHost Icons, sans-serif"],
                'robotoBlackFont': ["Roboto Black, sans-serif"],
                'robotoLightFont': ["Roboto Light, sans-serif"],
            },
            gridTemplateRows: {
                'mainlayout': 'auto 1fr auto',
            },
            gridTemplateColumns: {
                'full': '100%',
            },
            width: {
                '1/10': '10%',
                '2/10': '20%',
                '3/10': '30%',
                '4/10': '40%',
                '5/10': '50%',
                '6/10': '60%',
                '7/10': '70%',
                '8/10': '80%',
                '9/10': '90%',
                '10/10': '100%',
            },
            height: {
                '1/10': '10%',
                '2/10': '20%',
                '3/10': '30%',
                '4/10': '40%',
                '5/10': '50%',
                '6/10': '60%',
                '7/10': '70%',
                '8/10': '80%',
                '9/10': '90%',
                '10/10': '100%',
            },
            inset: {
                '1/10': '10%',
                '2/10': '20%',
                '3/10': '30%',
                '4/10': '40%',
                '5/10': '50%',
                '6/10': '60%',
                '7/10': '70%',
                '8/10': '80%',
                '9/10': '90%',
                '10/10': '100%',
            },
            minWidth: {
                '1/10': '10%',
                '2/10': '20%',
                '3/10': '30%',
                '4/10': '40%',
                '5/10': '50%',
                '6/10': '60%',
                '7/10': '70%',
                '8/10': '80%',
                '9/10': '90%',
                '10/10': '100%',
            },

        },
    },
}
