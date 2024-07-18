import React from 'react';

export default function Patient() {
  return (
    <main className="min-h-screen flex items-center justify-center bg-gray-100">
      <div className="w-full max-w-md p-6 bg-white shadow-md rounded-md">
        <h1 className="text-2xl font-semibold mb-6 text-center">Cadastro de Paciente</h1>
        {/* Formulário de Cadastro de Paciente */}
        <form>
          <input type="text" placeholder="Nome" className="w-full p-2 mb-4 border rounded-md" />
          <input type="email" placeholder="Email" className="w-full p-2 mb-4 border rounded-md" />
          <input type="password" placeholder="Senha" className="w-full p-2 mb-4 border rounded-md" />
          <button type="submit" className="w-full p-2 bg-blue-500 text-white rounded-md hover:bg-blue-600">
            Cadastrar
          </button>
        </form>
      </div>
    </main>
  );
}
