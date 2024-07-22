'use client';
import Image from 'next/image';
import './globals.css';
import { ConnectButton } from 'thirdweb/react';
import { client } from './client';
import Link from 'next/link';
import Footer from './components/footer';
import LogoWhite from '@public/logo-white.png';
import TypingEffect from './components/TypingEffect';
 

export default function Home() {
  return (
    <main className="relative">
      <video
        autoPlay
        loop
        muted
        className="absolute inset-0 w-full h-full object-cover z-[-1] max-h-screen max-w-screen"
      >
        <source src="/page1.mov" type="video/mp4" />
        Your browser does not support the video tag.
      </video>
      <div className="absolute top-4 right-4 z-10 p-4">
        <ConnectButton
          client={client}
          theme="light"
          connectModal={{ size: 'wide' }}
        />
      </div>
      <div className="absolute top-4 left-4 z-10 p-4">
        <Image
          src={LogoWhite}
          alt="Logo"
          width={220}
          height={220}
          className="w-[150px] sm:w-[180px] md:w-[220px] lg:w-[220px] xl:w-[220px] h-auto"/>
      </div>
      <div className="flex items-center justify-center min-h-screen px-4 py-8">
        <div className="neon-box p-4 md:p-6 bg-black bg-opacity-70 rounded-lg shadow-lg max-w-lg md:max-w-3xl text-center">
          <h1 className="text-white font-aldrich text-lg md:text-2xl mb-4">
            <TypingEffect
              text="Desbloqueie o potencial dos seus dados médicos com a combinação poderosa de Blockchain e IA."
              speed={100} // Ajuste a velocidade conforme necessário
            />
          </h1>
          <Link href="/about" className="font-aldrich inline-block p-3 md:p-4 text-white text-center rounded-md bg-gradient-to-r from-gray-900 via-gray-700 to-gray-900 hover:from-gray-800 hover:via-gray-600 hover:to-gray-800">
            Saiba Mais
          </Link>
        </div>
      </div>

      <Footer />
    </main>
  );
}
