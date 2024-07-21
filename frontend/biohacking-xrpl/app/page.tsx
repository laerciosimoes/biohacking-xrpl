'use client';
import Image from 'next/image';
import { ConnectButton } from "thirdweb/react";
import { client } from './client';
import Link from 'next/link';
import Footer from './components/footer';
import LogoWhite from "@public/logo-white.png";



export default function Home() {
  return (
    <main>
      <video
        autoPlay
        loop
        muted
        className="absolute inset-0 w-full h-full object-cover z-[-1]"
        style={{
          maxHeight: '100vh',
          maxWidth: '100vw',
        }}
      >
        <source src="/page1.mov" type="video/mp4" />
        Your browser does not support the video tag.
      </video>
      <div className="absolute top-4 right-4 z-10">
        <ConnectButton
          client={client}
          theme="light"
          connectModal={{ size: 'wide' }}
        />
      </div>

      <div className="absolute top-2 left-4 z-10">
        <Image
          src={LogoWhite}
          alt="Logo"
          width={250}
          height={250}
        />
      </div>
      <div className="flex items-center justify-center min-h-screen">
        <div className="p-6 bg-black bg-opacity-70 rounded-lg shadow-lg max-w-3xl text-left">
          <p className="text-white font-aldrich text-2xl mb-4">
            Desbloqueie o potencial dos seus dados médicos com a combinação poderosa de Blockchain e IA. Cadastre-se agora e aproveite o poder do biohacking!
          </p>
          <Link href="/signup" className="font-aldrich inline-block p-4 text-white text-center rounded-md bg-gradient-to-r from-gray-900 via-gray-700 to-gray-900 hover:from-gray-800 hover:via-gray-600 hover:to-gray-800">
            Cadastro
          </Link>
        </div>
      </div>

      <Footer />
    </main>
  );
}
