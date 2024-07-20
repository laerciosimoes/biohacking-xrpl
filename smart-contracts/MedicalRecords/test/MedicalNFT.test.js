require('dotenv').config({ path: './test/.env' });
const { expect } = require("chai");
const { ethers } = require("hardhat");

describe("MedicalNFT", function () {
    let WasmNFT, wasmNFT, owner, addr1, addr2;

    beforeEach(async function () {
        MedicalNFT = await ethers.getContractFactory("MedicalNFT");
        [owner, addr1, addr2] = await ethers.getSigners();
      
        // Deploy do contrato com o endereço do signatário como o proprietário inicial
        medicalNFT = await MedicalNFT.deploy(owner);
        await medicalNFT.waitForDeployment();

    });

    it("Should Create a Record for Address 1", async function () {
        let data2 = "data2";
        await medicalNFT.createRecord(addr1, data2);


        let records = await medicalNFT.getRecords(addr1);
        expect(records.length).to.equal(1);
        expect(records[0].data).to.equal(data2);
    });

    it("Should Create 3 Record for Address 1", async function () {
        let data12 = "data12";
        let data22 = "data22";
        let data32 = "data32";
        await medicalNFT.createRecord(addr1, data12);
        await medicalNFT.createRecord(addr1, data22);
        await medicalNFT.createRecord(addr1, data32);


        let records = await medicalNFT.getRecords(addr1);
        expect(records.length).to.equal(3);
        expect(records[0].data).to.equal(data12);
        expect(records[1].data).to.equal(data22);
        expect(records[2].data).to.equal(data32);
    });

    it("Should Create 3 Record for Address 1 and 2 to Address 2", async function () {

        let data12 = "data12";
        let data22 = "data22";
        let data23 = "data23";
        let data11 = "data11";
        let data21 = "data21";

        await medicalNFT.createRecord(addr2, data21);
        await medicalNFT.createRecord(addr1, data11);
        await medicalNFT.createRecord(addr2, data22);
        await medicalNFT.createRecord(addr2, data23);
        await medicalNFT.createRecord(addr1, data12);

        let records = await medicalNFT.getRecords(addr1);
        expect(records.length).to.equal(2);
        expect(records[0].data).to.equal(data11);
        expect(records[1].data).to.equal(data12);

        let records2 = await medicalNFT.getRecords(addr2);
        expect(records2.length).to.equal(3);
        expect(records2[0].data).to.equal(data21);
        expect(records2[1].data).to.equal(data22);
        expect(records2[2].data).to.equal(data23);
    });
});