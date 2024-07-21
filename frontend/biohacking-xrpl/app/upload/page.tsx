'use client';
import React, { useState } from 'react';
import CryptoJS from 'crypto-js';
import { useActiveAccount, useAutoConnect } from "thirdweb/react";
import { upload } from "thirdweb/storage";

import { TransactionButton } from "thirdweb/react";
//import { useAddress, useContract, useMetamask, useContractWrite } from 'thirdweb/react';
import { client } from '../client';
import { getContract, defineChain, prepareContractCall } from "thirdweb";


export default function Upload() {
    const [file, setFile] = useState<File | null>(null);
    const [symptoms, setSymptoms] = useState<string>('');
    ///const { contract } = useContract('0x1e2C53a3E906da8890BaB18593cBeE1513b79096'); 
    const chain = defineChain(1440002);
    const contract = getContract({
        client,
        chain: chain, 
        address: "0x1e2C53a3E906da8890BaB18593cBeE1513b79096'); ",
    });

    // const { address, createRecord } = useStateContext(); // Remova 'connect' aqui, pois a conexão já foi feita
    const activeAccount = useActiveAccount();
    console.log("Active Account: ", activeAccount);
    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        console.log("Active Account on Submit: ", activeAccount);

        if (!file || !symptoms) return;

        try {
            const fileReader = new FileReader();
            fileReader.onloadend = async () => {
                const base64 = fileReader.result as string;
                const jsonData = {
                    dateTransacted: new Date().toISOString(),
                    symptoms: symptoms,
                    fileContent: base64,
                };

                console.log("Original JSON Data: ", jsonData);
                const encryptedData = CryptoJS.AES.encrypt(
                    JSON.stringify(jsonData),
                    activeAccount?.address || ""
                ).toString();
                console.log("Encrypted Data: ", encryptedData);

                // Upload encrypted data to storage
                console.log("Uploading encrypted data to storage...");
                //const uri = await upload({
                //    files: [new File([encryptedData], "biohacking.txt")],
                //});

                //console.log("Uploaded URI: ", uri);

                // Registrar o upload na blockchain
                //await createRecord({ data: uri });

            };
            fileReader.readAsDataURL(file);
        } catch (e: any) {
            // Handle errors here
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
        <div className="flex justify-center items-center min-h-screen bg-gray-100 p-4">
            <div className="bg-white shadow-md rounded-lg p-6 max-w-md w-full">
                <h1 className="text-2xl font-bold mb-6 text-center">Upload</h1>
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
                            <span className="label-text">Upload Exams</span>
                        </label>
                        <input
                            type="file"
                            id="txtExams"
                            name="txtExams"
                            className="file-input file-input-bordered w-full file-input-lg"
                            onChange={onFileChange}
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-full">
                        Submit
                    </button>
                    {/* 
                    
                    <TransactionButton
                        transaction={() => {
                            // Create a transaction object and return it
                            const tx = prepareContractCall({
                                contract,
                                chain: chain,
                                method: "mint",
                                params: [11, 1],
                            });
                            return tx;
                        }}
                        onTransactionSent={(result) => {
                            console.log("Transaction submitted", result.transactionHash);
                        }}
                        onTransactionConfirmed={(receipt) => {
                            console.log("Transaction confirmed", receipt.transactionHash);
                        }}
                        onError={(error) => {
                            console.error("Transaction error", error);
                        }}
                    >
                        Confirm Transaction
                    </TransactionButton>
                    
                    
                    
                    */
                    
                    
                    
                    }
                    
                </form>
            </div>
        </div>
    );
}
