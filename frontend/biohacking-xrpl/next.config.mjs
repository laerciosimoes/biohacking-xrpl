import dotenv from 'dotenv';
dotenv.config();
/** @type {import('next').NextConfig} */
const nextConfig = {
    webpack: (config) => {
        config.externals.push("pino-pretty", "lokijs", "encoding");
        return config;
    },
    env: {
        ClientId: process.env.ClientId,
    },
};

export default nextConfig;
