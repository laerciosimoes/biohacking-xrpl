import React from 'react';

const StartNowButton = () => {
  const handleStartNowClick = () => {
    // Adicione aqui a lógica para o que deve acontecer quando o botão é clicado.
    console.log('Começar agora clicado');
  };

  return (
    <div className="fixed bottom-16 right-4 z-10">
      <button
        className="px-4 py-2 rounded shadow-lg bg-gradient-to-r from-purple-500 via-lilac-500 to-blue-500 text-white hover:bg-gradient-to-r hover:from-purple-600 hover:via-lilac-600 hover:to-blue-600 font-aldrich"
        onClick={handleStartNowClick}
      >
        Começar agora
      </button>
    </div>
  );
};

export default StartNowButton;
