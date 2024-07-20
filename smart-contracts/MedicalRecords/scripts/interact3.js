// scripts/interact.js
async function main() {
    const [owner, addr1, addr2, addr3] = await ethers.getSigners();
    const MedicalNFT = await ethers.getContractFactory("MedicalNFT");
    const medicalNFT = await MedicalNFT.attach("0x68B1D87F95878fE05B998F19b66F4baba5De1aed");

    let tx = await medicalNFT.createRecord(owner, "data1");
    await tx.wait();

    console.log("NFT created with token ID:", tx);

    let tx1 = await medicalNFT.getRecords(owner);
    console.log("Get Records:", tx1);

    let tx2 = await medicalNFT.createRecord(owner, "data2");
    await tx.wait();

    console.log("NFT created with token ID:", tx2);

    let tx3 = await medicalNFT.getRecords(owner);
    console.log("Get Records:", tx3);

    let tx4 = await medicalNFT.createRecord(addr1, "data3");
    await tx.wait();

    console.log("NFT created with token ID:", tx4);

    let tx5 = await medicalNFT.getRecords(owner);
    console.log("Get Records:", tx5);

    let tx6 = await medicalNFT.getRecords(addr1);
    console.log("Get Records:", tx6);

}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });
