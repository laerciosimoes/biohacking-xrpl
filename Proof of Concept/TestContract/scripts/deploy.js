// scripts/deploy.js

async function main() {
    const [deployer] = await ethers.getSigners();
    const initialOwner = "0x09242EFACfD9d258dC3Ea1fE10387351121F72BA"; // Endereço inicial

    console.log("Deploying contracts with the account:", deployer.address);

    const WasmNFT = await ethers.getContractFactory("WasmNFT");
    const wasmNFT = await WasmNFT.deploy(); // Verifique se o construtor do contrato não requer argumentos

    console.log("WasmNFT deployed to:", wasmNFT.address);

    // Set initial owner
    const tx = await wasmNFT.transferOwnership(initialOwner);
    await tx.wait();

    console.log("Ownership transferred to:", initialOwner);
}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });