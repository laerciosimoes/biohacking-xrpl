"use client";
import React, { useContext, createContext, ReactNode } from 'react';
import { useAddress, useContract, useMetamask, useContractWrite } from '@thirdweb-dev/react';

interface StateContextProps {
  address: string | undefined;
  contract: any;
  connect: () => Promise<void>;
  createRecord: (form: { data: string }) => Promise<void>;
  getRecords: () => Promise<any[]>;
}

const StateContext = createContext<StateContextProps | undefined>(undefined);

interface StateContextProviderProps {
  children: ReactNode;
}

export const StateContextProvider = ({ children }: StateContextProviderProps) => {
  const { contract } = useContract('0x1e2C53a3E906da8890BaB18593cBeE1513b79096'); 
  const { mutateAsync: createRecord } = useContractWrite(contract, 'createRecord');

  const address = useAddress();
  const connect = useMetamask();

  const publishRecord = async (form: { data: string }) => {
    try {
      const data = await createRecord({
        args: [
          address, // paciente
          form.data, // dados médicos
        ],
      });

      console.log("Chamada de contrato bem-sucedida", data);
    } catch (error) {
      console.log("Falha na chamada de contrato", error);
    }
  }

  // Função para obter registros
  const getRecords = async () => {
    try {
      const records = await contract.call('getRecords', [address]);

      const parsedRecords = records.map((record: any, i: number) => ({
        patient: record.patient,
        data: record.data,
        id: i,
      }));

      return parsedRecords;
    } catch (error) {
      console.log("Erro ao obter registros", error);
      return [];
    }
  }

  return (
    <StateContext.Provider
      value={{ 
        address,
        contract,
        connect,
        createRecord: publishRecord,
        getRecords
      }}
    >
      {children}
    </StateContext.Provider>
  );
}

export const useStateContext = () => {
  const context = useContext(StateContext);
  if (!context) {
    throw new Error('useStateContext must be used within a StateContextProvider');
  }
  return context;
};
