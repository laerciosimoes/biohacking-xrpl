
import {    time,    loadFixture,} from "@nomicfoundation/hardhat-toolbox/network-helpers";
import { anyValue } from "@nomicfoundation/hardhat-chai-matchers/withArgs";
import { expect } from "chai";
import { ethers } from "hardhat"


console.log("MedicalRecords test");

describe("MedicalRecords", function () {
    // We define a fixture to reuse the same setup in every test.
    // We use loadFixture to run this setup once, snapshot that state,
    // and reset Hardhat Network to that snapshot in every test.
    async function deployNftFixture() {
        // Contracts are deployed using the first signer/account by default
        const [owner, otherAccount] = await ethers.getSigners();

        const MedicalRecords = await ethers.getContractFactory("MedicalRecords");
        const medicalRecords = await MedicalRecords.deploy();

        return { medicalRecords, owner, otherAccount };
    }

    describe("Deployment", function () {
        it("Should set the righ owner", async function () {
            const { medicalRecords, owner, otherAccount } = await loadFixture(deployNftFixture);

            expect(await medicalRecords.owner()).to.equal(owner);
        });
    });


});


describe("MedicalRecords", function () {
    let MedicalRecords: Contract;
    let medicalRecords: Contract;
    let owner: Signer;


    beforeEach(async function () {
        const MedicalRecordsFactory = await ethers.getContractFactory("MedicalRecords");
        [owner] = await ethers.getSigners();
        medicalRecords = await MedicalRecordsFactory.deploy();
        await medicalRecords.deployed();
    });

    it("Should add a new medical record", async function () {
        const recordData = "Patient has a mild fever.";
        await medicalRecords.addRecord(recordData);

        const records = await medicalRecords.getRecords();
        expect(records.length).to.equal(1);
        expect(records[0].data).to.equal(recordData);
    });

    it("Should retrieve the correct medical record by index", async function () {
        const recordData1 = "Patient has a mild fever.";
        const recordData2 = "Patient is recovering well.";

        await medicalRecords.addRecord(recordData1);
        await medicalRecords.addRecord(recordData2);

        const record = await medicalRecords.getRecord(1);
        expect(record[0]).to.equal(recordData2);
    });

    it("Should emit an event when a new record is added", async function () {
        const recordData = "Patient has a mild fever.";

        await expect(medicalRecords.addRecord(recordData))
            .to.emit(medicalRecords, "RecordAdded")
            .withArgs(await owner.getAddress(), 0, recordData, anyValue);
    });
});
