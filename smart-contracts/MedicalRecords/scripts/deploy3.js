// scripts/deploy.js
async function main() {
    const [deployer] = await ethers.getSigners();

    console.log("Deploying contracts with the account:", deployer.address);

    const MedicalNFT = await ethers.getContractFactory("MedicalNFT");
    const medicalNFT = await MedicalNFT.deploy();

    console.log("Waiting for MedicalNFT deployment...");
    await medicalNFT.waitForDeployment();

    console.log("MedicalNFT deployed to:", await medicalNFT.getAddress());
}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });
