import React from "react";
import Image from "next/image";
import Link from "next/link";

export default function Signup() {
  return (
    <main className="min-h-screen flex items-center justify-center bg-gray-100">
      <div className="relative w-full max-w-md p-6 bg-white shadow-md rounded-md">
        {/* Imagem no canto superior direito */}
        <div className="absolute top-4 right-4">
          <Image src="/maodna.jpg" alt="Imagem Maodna" width={100} height={100} className="rounded-full" />
        </div>
        
        {/* Opções de cadastro */}
        <div className="mt-16">
          <h1 className="text-2xl font-semibold mb-6 text-center">Cadastro</h1>
          <div className="flex flex-col space-y-4">
            <Link href="/patient" className="p-4 bg-blue-500 text-white text-center rounded-md hover:bg-blue-600">
                Paciente
            </Link>
            <Link href="/doctor" className="p-4 bg-green-500 text-white text-center rounded-md hover:bg-green-600">
                Médico
            </Link>
          </div>
        </div>
      </div>
    </main>
  );
}
