'use client';
import { FC, useState } from "react";
import { ConnectButton } from "thirdweb/react";
import { client } from '../client';
import Footer from '../components/footer';
import { XMarkIcon, Bars3Icon } from '@heroicons/react/24/outline'; 
import { useRouter } from 'next/navigation'; 
import Comecar from '../components/comecar';

const AboutPage: FC = () => {
  const [isConnected, setIsConnected] = useState<boolean>(false);
  const [openModal, setOpenModal] = useState<string | null>(null);
  const [menuOpen, setMenuOpen] = useState<boolean>(false);
  const router = useRouter(); 

  const handleOpenModal = (modalName: string) => {
    setOpenModal(modalName);
  };

  const handleCloseModal = () => {
    setOpenModal(null);
  };

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  const handleStartNowClick = () => {
    if (isConnected) {
      // Se a wallet está conectada, redireciona para o componente signup
      router.push('/signup');
    } else {
      // Caso contrário, exibe o alerta
      alert("Por favor, conecte sua wallet para começar.");
    }
  };

  return (
    <main className="min-h-screen flex flex-col bg-gradient-to-b from-purple-500">
      {/* Vídeo em tamanho máximo */}
      <div className="relative w-full h-full flex flex-col flex-grow">
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

        {/* Ícone de menu e conteúdo do menu */}
        <div className="absolute top-16 right-4 z-10">
          <button onClick={toggleMenu} className="p-2 text-white bg-gray-800 rounded">
            <Bars3Icon className="h-8 w-8" />
          </button>
          {menuOpen && (
            <div className="bg-black bg-opacity-70 p-4 rounded mt-2 flex flex-col gap-2">
              <button
                className="text-white mb-2 block w-full text-left bg-gray-800 p-2 rounded bg-gray-800 p-2 rounded hover:bg-purple-500 transition duration-300"
                onClick={() => handleOpenModal('welcome')}
              >
                Sobre Nós
              </button>
              <button
                className="text-white mb-2 block w-full text-left bg-gray-800 p-2 rounded hover:bg-purple-500 transition duration-300"
                onClick={() => handleOpenModal('vision')}
              >
                Nossa Visão
              </button>
              <button
                className="text-white mb-2 block w-full text-left bg-gray-800 p-2 rounded hover:bg-purple-500 transition duration-300"
                onClick={() => handleOpenModal('howItWorks')}
              >
                Como Funciona
              </button>
              <button
                className="text-white mb-2 block w-full text-left bg-gray-800 p-2 rounded hover:bg-purple-500 transition duration-300"
                onClick={() => handleOpenModal('dataControl')}
              >
                Blockchain na Biohacking.ai
              </button>
              <button
                className="text-white mb-2 block w-full text-left bg-gray-800 p-2 rounded hover:bg-purple-500 transition duration-300"
                onClick={() => handleOpenModal('mission')}
              >
                Nossa Missão
              </button>
              <button
                className="text-white mb-2 block w-full text-left bg-gray-800 p-2 rounded hover:bg-purple-500 transition duration-300"
                onClick={() => handleOpenModal('joinUs')}
              >
                Junte-se a Nós
              </button>
            </div>
          )}
        </div>
      </div>

      {/* Botão "Começar agora" no canto inferior direito acima do footer */}
      <div className="fixed bottom-24 right-4 z-10">
        <button
          className="px-4 py-2 rounded shadow-lg bg-gradient-to-r from-purple-500 via-lilac-500 to-blue-500 text-white hover:bg-gradient-to-r hover:from-purple-600 hover:via-lilac-600 hover:to-blue-600"
          onClick={handleStartNowClick} 
        >
          Começar agora
        </button>
      </div>

     {/* Conteúdo dos modais */}
     {openModal && (
        <div className="fixed inset-0 bg-black bg-opacity-75 flex items-center justify-center z-20">
          <div className={`bg-gradient-to-b from-black via-gray-900 to-black p-6 rounded-lg max-w-lg mx-4 md:mx-0 relative ${openModal === 'welcome' ? 'max-h-[90vh] overflow-y-auto' : ''}`}>
            <button
              className="absolute top-2 right-2 text-white"
              onClick={handleCloseModal}
            >
              <XMarkIcon className="h-6 w-6" />
            </button>

            {openModal === 'welcome' && (
              <div className="text-white font-aldrich">
                <h2 className="text-2xl font-semibold mb-4">Sobre Nós</h2>
                <p className="text-lg mb-4">
                  Bem-vindo à Biohacking, uma plataforma que une blockchain e inteligência artificial (IA) para transformar o gerenciamento de dados médicos e fornecer diagnósticos precisos. Nosso propósito é otimizar a saúde do paciente para que ele alcance seu máximo potencial. Com tecnologia avançada que reduz erros médicos em mais de 90%, você pode enviar uma foto de uma mancha, machucado ou da sua feição para detectar sinais de depressão. Nossa IA identifica o especialista ideal para o seu caso, e o diagnóstico final é sempre realizado por um profissional de saúde, garantindo um atendimento personalizado e seguro. Experimente uma nova era de cuidados médicos com a Biohacking e tome o controle total da sua saúde hoje mesmo.
                </p>
                <div className="flex items-center mt-4">
                  <img src="ju.png" alt="Juliana Ianov" className="w-24 h-24 rounded-full mr-4" />
                  <div>
                    <h3 className="text-xl font-semibold">JULIANA IANOV</h3>
                    <p className="text-md">Graduanda em ADS pela Faculdade Católica Paulista. Desenvolvedora Full Stack blockchain e IA na Biohacking; Co-founder e Dev Full Stack na My Crypto Soccer DAO.</p>
                  </div>
                </div>
                <div className="flex items-center mt-4">
                  <img src="laercio1.jpeg" alt="Laercio" className="w-24 h-24 rounded-full mr-4" />
                  <div>
                    <h3 className="text-xl font-semibold">LAERCIO H. SIMÕES</h3>
                    <p className="text-md">Empreendedor no mercado de software. Profissional com uma experiência singular, tendo trabalhado em várias indústrias. Graduado na Singularity University - NASA, recebeu vários prêmios por seus projetos inovadores.</p>
                  </div>
                </div>
              </div>
            )}

            {openModal === 'vision' && (
              <div className="text-white font-aldrich max-h-[90vh] overflow-y-auto">
                <h2 className="text-2xl font-semibold mb-4">Nossa Visão</h2>
                <p className="text-lg mb-4">
                  Na Biohacking, acreditamos que cada indivíduo deve ter total autonomia sobre suas informações de saúde. Nossa plataforma foi projetada para garantir que seus dados médicos sejam seguros, transparentes e facilmente acessíveis, sem comprometer a privacidade. Usamos tecnologias de ponta para transformar seus dados médicos em registros seguros e imutáveis na blockchain, oferecendo uma maneira revolucionária de gerenciar e compartilhar essas informações.
                </p>
                <img src="maodna.jpg" alt="Vision" className="w-full h-auto rounded-lg shadow-lg mt-4" />
                <Comecar />
              </div>
            )}

            {openModal === 'howItWorks' && (
              <div className="text-white font-aldrich max-h-[90vh] overflow-y-auto">
                <h2 className="text-2xl font-semibold mb-4">Como Funciona</h2>
                <p className="text-lg mb-4">
                  <strong>Blockchain:</strong> A tecnologia blockchain é o coração da nossa plataforma. Ela garante que seus dados médicos sejam armazenados de maneira segura e imutável, protegidos contra adulterações e acessos não autorizados. Cada interação com seus dados é registrada, proporcionando total transparência e auditabilidade.
                </p>
                <p className="text-lg mb-4">
                  <strong>Upload de Dados Médicos:</strong> Usuários (pacientes ou profissionais de saúde) fazem o upload de informações médicas, como consultas, diagnósticos, receitas e prognósticos...
                </p>
                <p className="text-lg mb-4">
                  <strong>Registro na Blockchain:</strong> Cada upload de dados cria um registro único na blockchain...
                </p>
                <p className="text-lg mb-4">
                  <strong>Acesso e Controle de Dados:</strong> Pacientes mantêm o controle sobre seus dados médicos...
                </p>
                <p className="text-lg mb-4">
                  <strong>Consultas e Diagnósticos AI:</strong> A plataforma utiliza inteligência artificial para analisar os dados médicos carregados...
                </p>
                <img src="bh.jpg" alt="How It Works" className="w-full h-auto rounded-lg shadow-lg mt-4" />
              </div>
            )}

            {openModal === 'dataControl' && (
              <div className="text-white font-aldrich max-h-[90vh] overflow-y-auto">
                <h2 className="text-2xl font-semibold mb-4">A Importância do Controle de Dados Médicos</h2>
                <p className="text-lg mb-4">
                  Em um mundo cada vez mais digital, a segurança e a privacidade dos dados médicos são fundamentais. Ao colocar você no controle, a Biohacking oferece várias vantagens:
                  <ul className="list-disc pl-5">
                    <li><strong>Segurança:</strong> Seus dados são criptograficamente protegidos e armazenados de forma segura em nossa plataforma baseada em blockchain.</li>
                    <li><strong>Privacidade:</strong> Você decide quem pode acessar suas informações de saúde, garantindo que seus dados sejam compartilhados apenas com profissionais de confiança.</li>
                    <li><strong>Autonomia:</strong> Tenha acesso completo e contínuo aos seus registros médicos, facilitando a portabilidade entre diferentes provedores de saúde.</li>
                    <li><strong>Transparência:</strong> Todas as interações com seus dados são registradas e auditáveis, proporcionando uma visão clara de quem acessou e quando.</li>
                  </ul>
                </p>
                <img src="bio.jpg" alt="Data Control" className="w-full h-auto rounded-lg shadow-lg mt-4" />
              </div>
            )}

            {openModal === 'mission' && (
              <div className="text-white font-aldrich">
                <h2 className="text-2xl font-semibold mb-4">Nossa Missão</h2>
                <p className="text-lg mb-4">
                  Nossa missão é empoderar os pacientes, fornecendo ferramentas para gerenciar seus dados de saúde de forma segura e transparente. Acreditamos que a tecnologia deve servir para melhorar a vida das pessoas e promover uma maior autonomia no gerenciamento da saúde.
                </p>
                <img src="tablet.jpg" alt="Mission" className="w-full h-auto rounded-lg shadow-lg mt-4" />
              </div>
            )}

            {openModal === 'joinUs' && (
              <div className="text-white font-aldrich">
                <h2 className="text-2xl font-semibold mb-4">Junte-se a Nós</h2>
                <p className="text-lg mb-4">
                  Se você compartilha nossa visão de transformar a gestão dos dados médicos e deseja fazer parte dessa revolução, entre em contato conosco para oportunidades de parceria, investimentos ou qualquer outra forma de colaboração.
                </p>
                <img src="medi.jpg" alt="Join Us" className="w-full h-auto rounded-lg shadow-lg mt-4" />
              </div>
            )}
          </div>
        </div>
      )}
      <Footer />
    </main>
  );
};

export default AboutPage;
