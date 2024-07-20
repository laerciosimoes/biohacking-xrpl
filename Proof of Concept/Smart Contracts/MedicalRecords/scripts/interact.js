// scripts/interact.js
async function main() {
    const [owner] = await ethers.getSigners();
    const MedicalNFT = await ethers.getContractFactory("MedicalNFT");
    const medicalNFT = await MedicalNFT.attach("0x5FbDB2315678afecb367f032d93F642f64180aa3");

    const tokenURI = "https://ipfs.io/ipfs/Qm..."; // URL para os metadados do token
    let tx = await medicalNFT.createNFT(tokenURI);
    await tx.wait();

    console.log("NFT created with token ID:", tx.value);
    // Obter o ID do novo token
    const tokenId = await medicalNFT.tokenCounter;
    console.log("NFT created with token ID:", tokenId.toNumber() - 1); // Subtrair 1, pois o contador foi incrementado após a mintagem

}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });
