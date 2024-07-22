'use client';
import React, { useState, useEffect } from 'react';
import CryptoJS from 'crypto-js';
import { useActiveAccount, useAutoConnect } from "thirdweb/react";
import { upload } from "thirdweb/storage";
import { useSendTransaction } from "thirdweb/react";
import { client } from '../client';
import { getContract, defineChain, prepareContractCall } from "thirdweb";
import { ethers } from 'ethers';
import Image from 'next/image'; 
import LogoWhite from '@public/logo-white.png';
import LogoAzul from '@public/logoazul.png';

export default function Page() {
    const [file, setFile] = useState<File | null>(null);
    const [symptoms, setSymptoms] = useState<string>('');
    const [balance, setBalance] = useState<ethers.BigNumber | null>(null);
    const { mutate: sendTransaction } = useSendTransaction();
    const chain = defineChain(1440002);
    const contract = getContract({
        client,
        chain: chain,
        address: "0x1e2C53a3E906da8890BaB18593cBeE1513b79096",
    });
    const activeAccount = useActiveAccount();
    console.log("Conta Ativa: ", activeAccount);

    const checkBalance = async (): Promise<boolean> => {
        if (!activeAccount) return false;
        const provider = new ethers.providers.JsonRpcProvider('https://rpc-evm-sidechain.xrpl.org'); // Use o URL RPC do seu projeto
        const balance = await provider.getBalance(activeAccount.address);
        const requiredBalance = ethers.utils.parseEther('0.01'); // Exemplo de valor necessário, ajuste conforme necessário
        return balance.gte(requiredBalance); // Verificar se o saldo é suficiente
    };

    useEffect(() => {
        const fetchBalance = async () => {
            const hasSufficientBalance = await checkBalance();
            setBalance(hasSufficientBalance ? ethers.utils.parseEther('0.01') : ethers.BigNumber.from(0));
        };
        fetchBalance();
    }, [activeAccount]);

    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        console.log("Conta Ativa ao Submeter: ", activeAccount);

        if (!file || !symptoms) return;

        const hasSufficientBalance = await checkBalance();
        if (!hasSufficientBalance) {
            alert("Saldo insuficiente para realizar o upload.");
            return;
        }

        try {
            const fileReader = new FileReader();
            fileReader.onloadend = async () => {
                const base64 = fileReader.result as string;
                const jsonData = {
                    dateTransacted: new Date().toISOString(),
                    symptoms: symptoms,
                    fileContent: base64,
                };

                console.log("Dados JSON Originais: ", jsonData);
                const encryptedData = CryptoJS.AES.encrypt(
                    JSON.stringify(jsonData),
                    activeAccount?.address || ""
                ).toString();
                console.log("Dados Criptografados: ", encryptedData);

                // Fazer o upload dos dados criptografados para o armazenamento
                console.log("Fazendo upload dos dados criptografados...");
                const uri = await upload({
                    client,
                    files: [new File([encryptedData], "biohacking.txt")],
                });

                console.log("URI do Upload: ", uri);

                // Registrar o upload na blockchain
                //await createRecord({ data: uri });
                const transaction = prepareContractCall({
                    contract,
                    method: "function createRecord(address _patient, string _data) returns (uint256)",
                    params: [activeAccount?.address || "", uri]
                });
                sendTransaction(transaction);
                const modal = document.getElementById('my_modal_2') as HTMLDialogElement;
                modal?.showModal();
            };
            fileReader.readAsDataURL(file);
        } catch (e: any) {
            // Tratar erros aqui
            console.error(e);
        }
    };

    const onFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.files && e.target.files.length > 0) {
            setFile(e.target.files[0]);
        }
    };

    const onSymptomsChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
        setSymptoms(e.target.value);
    };

    return (
        <div className="relative flex justify-center items-center min-h-screen bg-gradient-to-r from-purple-500 via-lilac-500 to-blue-500 p-4">
            {/* Logo branca visível apenas em telas grandes */}
            <div className="hidden md:block absolute top-4 left-4 z-10 p-4">
                <Image
                    src={LogoWhite}
                    alt="Logo"
                    width={220}
                    height={220}
                    className="w-[150px] sm:w-[180px] md:w-[220px] lg:w-[220px] xl:w-[220px] h-auto"
                />
            </div>

            <div className="bg-white shadow-md rounded-lg p-6 max-w-md w-full relative">
                {/* Logo azul visível apenas em telas pequenas */}
                <div className="block md:hidden absolute top-4 right-4 z-10 p-4">
                    <Image
                        src={LogoAzul}
                        alt="Logo Azul"
                        width={100}
                        height={100}
                        className="w-[80px] sm:w-[100px] h-auto"
                    />
                </div>
                
                <h1 className="text-2xl font-bold mb-6 text-center">Dados Médicos</h1>
                <form className="w-full mb-4" onSubmit={onSubmit}>
                    <div className="form-control w-full mb-4">
                        <label className="label">
                            <span className="label-text">Sintomas</span>
                        </label>
                        <textarea
                            id="txtSymptoms"
                            name="txtSymptoms"
                            className="textarea textarea-primary w-full h-32"
                            placeholder="Descreva seus sintomas aqui"
                            value={symptoms}
                            onChange={onSymptomsChange}
                        ></textarea>
                    </div>
                    <div className="form-control w-full mb-6">
                        <label className="label">
                            <span className="label-text">Upload de Exames</span>
                        </label>
                        <input
                            type="file"
                            id="txtExams"
                            name="txtExams"
                            className="file-input file-input-bordered w-full file-input-lg"
                            onChange={onFileChange}
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-full bg-gradient-to-r from-purple-500 via-lilac-500 to-blue-500 text-white hover:bg-gradient-to-r hover:from-purple-600 hover:via-lilac-600 hover:to-blue-600">
                        Enviar
                    </button>
                </form>
            </div>
            <dialog id="my_modal_2" className="modal">
                <div className="modal-box">
                    <h3 className="font-bold text-lg">Biohacking XRP</h3>
                    <p className="py-4">Upload realizado com sucesso</p>
                </div>
                <form method="dialog" className="modal-backdrop">
                    <button>fechar</button>
                </form>
            </dialog>
        </div>
    );
}
