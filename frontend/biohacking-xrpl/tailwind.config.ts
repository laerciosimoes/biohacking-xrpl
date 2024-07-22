import type { Config } from "tailwindcss";
import daisyui from "daisyui";

const config: Config = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      colors: {
        'purple-500': '#6D28D9', // Novo tom de roxo
        'lilac-500': '#A78BFA',  // Novo tom de lilás
        'blue-500': '#3B82F6',   // Novo tom de azul
        'black': '#000000',
      },
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic': 'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
        'gradient-to-b-purple-black': 'linear-gradient(to bottom, #6b46c1, #000000)',
        'gradient-to-r-purple-lilac-blue': 'linear-gradient(to right, #6D28D9, #A78BFA, #3B82F6)', // Novo gradiente
      },
      fontFamily: {
        aldrich: ['Aldrich', 'sans-serif'],
      },
    },
  },
  plugins: [daisyui],
};

export default config;
