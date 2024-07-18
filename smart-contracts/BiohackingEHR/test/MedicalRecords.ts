
import { ethers } from "hardhat";
import { Contract, Signer } from "ethers";

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
