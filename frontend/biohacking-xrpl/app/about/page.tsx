'use client';
import { FC, useState } from "react";
import { ConnectButton } from "thirdweb/react";
import { client } from '../client';

const AboutPage: FC = () => {
  const [isConnected, setIsConnected] = useState(false);

  return (
    <main className="min-h-screen flex flex-col bg-gradient-to-b from-purple-500 to-black">
      {/* Vídeo em tamanho máximo */}
      <div className="relative w-full h-screen">
        <video
          src="/movies/mov3.webm"
          autoPlay
          loop
          muted
          className="absolute inset-0 w-full h-full object-cover"
        >
          Your browser does not support the video tag.
        </video>

        {/* Botão de conexão no canto superior direito */}
        <div className="absolute top-4 right-4 z-10">
          <ConnectButton
            onConnect={() => setIsConnected(true)}
            onDisconnect={() => setIsConnected(false)}
            client={client}
            theme="light"
            connectModal={{ size: 'wide' }}
          />
        </div>

        {/* Botão "Começar agora" no canto superior direito */}
        <div className="absolute top-4 right-24 z-10">
          <button
            className="bg-purple-700 text-white px-4 py-2 rounded shadow-lg hover:bg-purple-600 transition duration-300"
          >
            Começar agora
          </button>
        </div>
      </div>

      {/* Conteúdo sobre a Biohacking */}
      <div className="relative p-6 bg-black bg-opacity-70 text-white">
        <div className="max-w-screen-lg mx-auto">
          <h1 className="text-4xl font-aldrich mb-6">Sobre Nós</h1>
          <section className="mb-6">
            <h2 className="text-2xl font-semibold">Bem-vindo à Biohacking</h2>
            <p className="text-lg">
              Bem-vindo à Biohacking, uma plataforma inovadora que utiliza blockchain e inteligência artificial (IA) para dar aos pacientes o controle total sobre seus dados médicos. Nossa missão é transformar a maneira como os dados de saúde são gerenciados e utilizados, colocando o poder nas mãos de quem realmente importa: você, o paciente.
            </p>
          </section>
          <section className="mb-6">
            <h2 className="text-2xl font-semibold">Nossa Visão</h2>
            <p className="text-lg">
              Na Biohacking, acreditamos que cada indivíduo deve ter total autonomia sobre suas informações de saúde. Nossa plataforma foi projetada para garantir que seus dados médicos sejam seguros, transparentes e facilmente acessíveis, sem comprometer a privacidade. Usamos tecnologias de ponta para transformar seus dados médicos em NFTs (Tokens Não Fungíveis), oferecendo uma maneira revolucionária de gerenciar e compartilhar essas informações.
            </p>
          </section>
          <section className="mb-6">
            <h2 className="text-2xl font-semibold">Como Funciona</h2>
            <p className="text-lg">
              <strong>Blockchain:</strong> A tecnologia blockchain é o coração da nossa plataforma. Ela garante que seus dados médicos sejam armazenados de maneira segura e imutável, protegidos contra adulterações e acessos não autorizados. Cada interação com seus dados é registrada, proporcionando total transparência e auditabilidade.
            </p>
            <p className="text-lg">
              <strong>Inteligência Artificial:</strong> Nossa IA avançada ajuda a analisar e interpretar seus dados médicos, oferecendo insights personalizados e recomendações de saúde. Com isso, você pode tomar decisões mais informadas sobre seu bem-estar e tratamento.
            </p>
            <p className="text-lg">
              <strong>NFTs Médicos:</strong> Transformamos seus dados médicos em NFTs, o que significa que você possui um registro digital único e inalterável de suas informações de saúde. Esses NFTs permitem que você compartilhe seus dados com profissionais de saúde de forma segura e controlada, garantindo que apenas pessoas autorizadas tenham acesso.
            </p>
          </section>
          <section className="mb-6">
            <h2 className="text-2xl font-semibold">A Importância do Controle de Dados Médicos</h2>
            <p className="text-lg">
              Em um mundo cada vez mais digital, a segurança e a privacidade dos dados médicos são fundamentais. Ao colocar você no controle, a Biohacking oferece várias vantagens:
            </p>
            <ul className="list-disc pl-5">
              <li><strong>Segurança:</strong> Seus dados são criptograficamente protegidos e armazenados de forma segura em nossa plataforma baseada em blockchain.</li>
              <li><strong>Privacidade:</strong> Você decide quem pode acessar suas informações de saúde, garantindo que seus dados sejam compartilhados apenas com profissionais de confiança.</li>
              <li><strong>Autonomia:</strong> Tenha acesso completo e contínuo aos seus registros médicos, facilitando a portabilidade entre diferentes provedores de saúde.</li>
              <li><strong>Transparência:</strong> Todas as interações com seus dados são registradas e auditáveis, proporcionando uma visão clara de quem acessou e quando.</li>
            </ul>
          </section>
          <section>
            <h2 className="text-2xl font-semibold">Nossa Missão</h2>
            <p className="text-lg">
              Na Biohacking, nossa missão é capacitar você com ferramentas e tecnologias que garantam a segurança, privacidade e integridade dos seus dados médicos. Estamos comprometidos em criar um sistema de saúde mais transparente e eficiente, onde o paciente é o principal protagonista.
            </p>
          </section>
          <section className="mt-6">
            <h2 className="text-2xl font-semibold">Junte-se a Nós</h2>
            <p className="text-lg">
              Se você valoriza a segurança, privacidade e controle sobre suas informações de saúde, junte-se à Biohacking e experimente uma nova era de gestão de dados médicos. Transforme a maneira como você interage com o sistema de saúde e tome o controle do seu bem-estar.
            </p>
            <p className="font-bold mt-2">Biohacking – Seu Saúde, Seus Dados, Seu Controle.</p>
            
            {/* Botão "Começar agora" na parte de baixo */}
            <div className="mt-4">
              <button
               
                className="bg-purple-700 text-white px-4 py-2 rounded shadow-lg hover:bg-purple-600 transition duration-300"
              >
                Começar agora
              </button>
            </div>
          </section>
        </div>
      </div>
    </main>
  );
};

export default AboutPage;
