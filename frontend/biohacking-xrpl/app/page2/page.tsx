"use client";
import { ConnectButton } from "thirdweb/react";
import { createWallet, inAppWallet } from "thirdweb/wallets";
import { client } from "../client";
import { defineChain } from "thirdweb/chains";
import { prepareContractCall, getContract } from "thirdweb";
import { useSendTransaction } from "thirdweb/react";
import { useReadContract } from "thirdweb/react";


/*
const wallets = [
    inAppWallet(),
    createWallet("io.metamask"),
    createWallet("com.coinbase.wallet"),
    createWallet("me.rainbow"),
];
*/
const wallets = [createWallet("io.metamask"),];

export default function Page() {
    const { mutate: sendTransaction } = useSendTransaction();

    // connect to your contract
    const contract = getContract({
        client,
        chain: defineChain(1440002),
        address: "0x688de2C645859D8988a8529B3dd473E89b1260CC"
    });

    let _data = "Hello World!";
    const { data, isLoading } = useReadContract({
        contract,
        method: "function getRecords() view returns ((string data, uint256 timestamp)[])",
        params: []
    });
    console.log(isLoading, data);


    return (
        <div>
            <h1>Page 1</h1>
            <ul>
                <li>Wallets: {wallets.map((wallet) => wallet.type).join(", ")}</li>
                <li>Contract: {contract.address}</li>
            </ul>


        </div>
    );
}