
import Image from "next/image";
import { ConnectButton } from "thirdweb/react";
import thirdwebIcon from "@public/thirdweb.svg";
import { client } from "./client";
import Footer from './components/footer'; // Ajuste o caminho conforme necessário
export default async function Home() {
  return (
    <main className="relative min-h-screen bg-black">
      {/* Vídeo de Background */}
      <video
        autoPlay
        loop
        muted
        className="min-w-full min-h-full object-cover fixed top-0 left-0 z-[-1]"
        style={{
          maxHeight: "100vh",  // Define altura máxima como altura da tela
          maxWidth: "100vw",   // Define largura máxima como largura da tela
        }}
      >
        {/* Remova 'public/' do src */}
        <source src="/page1.mov" type="video/mp4" />
        Your browser does not support the video tag.
      </video>

      {/* Conteúdo da Página */}
      <div className="absolute inset-0 flex flex-col items-center justify-center">
        <div className="p-4 max-w-screen-lg mx-auto text-white">
          <div className="flex justify-end mb-6">
            <ConnectButton
              client={client}
            />
          </div>

          {/* Botão de Redirecionamento para Cadastro */}
          <div className="flex justify-center mb-6">
            <a
              href="/components/signup"
              className="p-4 bg-blue-500 text-white text-center rounded-md hover:bg-blue-600"
            >
              Cadastro
            </a>
          </div>
        </div>
        <Footer />
      </div>
    </main>
  );
}
