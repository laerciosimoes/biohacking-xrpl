// scripts/interact.js
async function main() {
    const [owner] = await ethers.getSigners();
    const MedicalNFT = await ethers.getContractFactory("CrowdFunding");
    const medicalNFT = await MedicalNFT.attach("0xA51c1fc2f0D1a1b8494Ed1FE312d7C3a78Ed91C0");

    const tokenURI = "https://ipfs.io/ipfs/Qm..."; // URL para os metadados do token
    let tx = await medicalNFT.createCampaign(owner, "title", "description", 0, 0, "image");
    await tx.wait();

    console.log("NFT created with token ID:", tx);

    let tx1 = await medicalNFT.getCampaigns();

    console.log("Get Campaigns:", tx1);

}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });
