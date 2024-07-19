import type { Config } from "tailwindcss";
import daisyui from "daisyui";

const config: Config = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}", // Adiciona o diretório de componentes
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",      // Adiciona o diretório de páginas
  ],
  theme: {
    extend: {
      colors: {
        'purple-700': '#6b46c1',
        'black': '#000000',
      },
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic': 'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
        'gradient-to-b-purple-black': 'linear-gradient(to bottom, #6b46c1, #000000)',
      },
      fontFamily: {
        aldrich: ['Aldrich', 'sans-serif'],
      },
    },
  },
  plugins: [daisyui],
};

export default config;
