const { ethers } = require("hardhat");

async function main() {
    // Compila o contrato
    await hre.run('compile');

    // Obtém o contrato WasmNFT
    const WasmNFT = await ethers.getContractFactory("WasmNFT");
    const wasmNFT = await WasmNFT.deploy();
    await wasmNFT.deployed();

    console.log("WasmNFT deployed to:", wasmNFT.address);

    // Define um URL fictício para o metadata
    const metadataURI = "https://example.com/metadata/1";
    const newMetadataURI = "https://example.com/metadata/1-updated";

    // Registra um novo NFT
    console.log("Registering new NFT...");
    const tx = await wasmNFT.registerWasmNFT(metadataURI);
    await tx.wait();
    console.log("NFT registered");

    // Obtém o token ID do NFT registrado
    const tokenId = 1;

    // Obtém os metadados do NFT
    const metadata = await wasmNFT.getMetadataURI(tokenId);
    console.log("Current metadata URI:", metadata);

    // Atualiza o URL dos metadados
    console.log("Updating metadata URI...");
    const updateTx = await wasmNFT.updateMetadata(tokenId, newMetadataURI);
    await updateTx.wait();
    console.log("Metadata URI updated");

    // Obtém os metadados atualizados do NFT
    const updatedMetadata = await wasmNFT.getMetadataURI(tokenId);
    console.log("Updated metadata URI:", updatedMetadata);
}

// Executa o script
main().catch((error) => {
    console.error(error);
    process.exitCode = 1;
});
