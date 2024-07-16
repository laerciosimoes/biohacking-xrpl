import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: 'Biohacking Creator',
  description: 'Biohacking Creator Frontend Example',
  metadataBase: new URL('https://creator.biohacking.ai'),
  openGraph: {
    title: 'Biohacking Creator',
    description: 'Biohacking Creator Frontend Example',
    url: 'https://creator.biohacking.ai',
    siteName: 'Biohacking Creator',
    images: '/biohacking.png',
  },
  alternates: {
    canonical: '/',
  },
  applicationName: 'Biohacking Creator',
  referrer: 'origin',
  keywords: ['Biohacking.ai', 'NFT', 'Laercio Simoes', 'XRP Ledger', 'Blockchain in Rio' ],
  authors: [{ name: 'Laercio Simoes' }],
  creator: 'Laercio Simoes',
  publisher: 'Laercio Simoes',
  formatDetection: {
    email: false,
    address: false,
    telephone: false,
  },
  icons: {
    icon: [
      { type: "image/png", sizes: "192x192", url: "/icons/android-icon-192x192.png" },
      { type: "image/png", sizes: "32x32", url: "/icons/favicon-32x32.png" },
      { type: "image/png", sizes: "96x96", url: "/icons/favicon-96x96.png" },
      { type: "image/png", sizes: "16x16", url: "/icons/favicon-16x16.png" }
    ],
    shortcut: ['/icons/apple-icon-60x60.png'],
    apple: [
      { url: '/apple-icon.png' },
      { url: '/apple-icon-x3.png', sizes: '180x180', type: 'image/png' },
      { sizes: "57x57", url: "/icons/apple-icon-57x57.png", type: 'image/png' },
      { sizes: "60x60", url: "/icons/apple-icon-60x60.png", type: 'image/png' },
      { sizes: "72x72", url: "/icons/apple-icon-72x72.png", type: 'image/png' },
      { sizes: "76x76", url: "/icons/apple-icon-76x76.png", type: 'image/png' },
      { sizes: "114x114", url: "/icons/apple-icon-114x114.png", type: 'image/png' },
      { sizes: "120x120", url: "/icons/apple-icon-120x120.png", type: 'image/png' },
      { sizes: "144x144", url: "/icons/apple-icon-144x144.png", type: 'image/png' },
      { sizes: "152x152", url: "/icons/apple-icon-152x152.png", type: 'image/png' },
      { sizes: "180x180", url: "/icons/apple-icon-180x180.png", type: 'image/png' },
    ],
  },
  twitter: {
    card: 'summary_large_image',
    title: 'Biohacking Creator Frontend Example',
    description: 'Biohacking Creator Frontend Example',
    images: ['/biohacking.png'],
  }
}

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>{children}</body>
    </html>
  );
}
