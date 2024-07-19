"use client";
import { ConnectButton } from "thirdweb/react";
import { createWallet, inAppWallet } from "thirdweb/wallets";
import { client } from "../client";
import { defineChain } from "thirdweb/chains";
import { prepareContractCall, getContract } from "thirdweb";
import { useSendTransaction } from "thirdweb/react";
import { useReadContract } from "thirdweb/react";



export default function Page() {
    const { mutate: sendTransaction } = useSendTransaction();

    // connect to your contract
    const contract = getContract({
        client,
        chain: defineChain(1440002),
        address: "0x688de2C645859D8988a8529B3dd473E89b1260CC"
    });

    let _data = "Hello World!";

    const onClick = () => {
        const transaction = prepareContractCall({
            contract,
            method: "function addRecord(string _data)",
            params: [_data]
        });
        sendTransaction(transaction);
    }

   

    return (
        <div>
            <h1>Page 1</h1>
            <ul>
                 <li>Contract: {contract.address}</li>
                <li><ConnectButton client={client} /></li>
                <li><button onClick={onClick} className="btn btn-primary m-2" >Add Record</button></li>
             </ul>
            
            
        </div>
        );
}