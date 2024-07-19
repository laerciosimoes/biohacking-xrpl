'use client';
import React, { useState } from 'react';
import CryptoJS from 'crypto-js';


export default function Upload() {
    const [file, setFile] = useState<File | null>(null);
    const [symptoms, setSymptoms] = useState<string>('');


    const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()

        if (!file || !symptoms) return;

        try {
            const fileReader = new FileReader();
            fileReader.onloadend = async () => {
                const base64 = fileReader.result;
                const jsonData = {
                    symptoms: symptoms,
                    fileContent: base64,
                };
                console.log("Original JSON Data: ", jsonData);
                const encryptedData = CryptoJS.AES.encrypt(
                    JSON.stringify(jsonData),
                    'your-secret-key'
                ).toString();
                console.log("Encrypted Data: ", encryptedData);

                // Save encrypted data as a file
                const blob = new Blob([encryptedData], { type: 'text/plain' });
                const url = URL.createObjectURL(blob);
                const a = document.createElement('a');
                a.href = url;
                a.download = 'encryptedData.txt';
                document.body.appendChild(a);
                //a.style.display = 'none'; // Ensure the link is not visible
                a.click();
                document.body.removeChild(a);
               
            };
            fileReader.readAsDataURL(file);



        
        
        } catch (e: any) {
            // Handle errors here
            console.error(e)
        }
    }
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

                <form className=" w-full mb-4" onSubmit={onSubmit}>
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

                    <button
                        type="submit"
                        className="btn btn-primary w-full"
                    >
                        Submit
                    </button>
                </form>
            </div>
        </div>
    );
}
