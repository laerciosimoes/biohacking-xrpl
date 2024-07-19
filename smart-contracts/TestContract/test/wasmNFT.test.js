const { expect } = require("chai");
const { ethers } = require("hardhat");

describe("WasmNFT", function () {
  let WasmNFT, wasmNFT, owner, addr1, addr2;

  beforeEach(async function () {
    WasmNFT = await ethers.getContractFactory("WasmNFT");
    [owner, addr1, addr2] = await ethers.getSigners();
    wasmNFT = await WasmNFT.deploy();
    await wasmNFT.deployed();
  });

  it("Should mint an NFT when adding a record", async function () {
    const tokenURI = "Initial medical data";
    await wasmNFT.addRecord(tokenURI);

    const newItemId = await wasmNFT.tokenURI(1);
    expect(newItemId).to.equal(tokenURI);

    const records = await wasmNFT.getRecords();
    expect(records.length).to.equal(1);
    expect(records[0].data).to.equal(tokenURI);
  });

  it("Should update the NFT URI when adding subsequent records", async function () {
    const tokenURI1 = "Initial medical data";
    const tokenURI2 = "Updated medical data";
    await wasmNFT.addRecord(tokenURI1);
    await wasmNFT.addRecord(tokenURI2);

    const newItemId = await wasmNFT.tokenURI(1);
    expect(newItemId).to.equal(tokenURI2);

    const records = await wasmNFT.getRecords();
    expect(records.length).to.equal(2);
    expect(records[0].data).to.equal(tokenURI1);
    expect(records[1].data).to.equal(tokenURI2);
  });

  it("Should set the right owner", async function () {
    expect(await wasmNFT.owner()).to.equal(owner.address);
  });

  it("Should grant and revoke permission", async function () {
    await wasmNFT.grantPermission(addr1.address);
    expect(await wasmNFT.permissions(owner.address, addr1.address)).to.equal(true);

    await wasmNFT.revokePermission(addr1.address);
    expect(await wasmNFT.permissions(owner.address, addr1.address)).to.equal(false);
  });

  it("Should only allow the owner to add records and mint tokens", async function () {
    const tokenURI = "Non-owner medical data";
    await expect(wasmNFT.connect(addr1).addRecord(tokenURI)).to.be.revertedWith("Access restricted to the patient only.");
  });

  it("Should only allow viewing records with permission", async function () {
    await wasmNFT.addRecord("Owner medical data");
    await expect(wasmNFT.connect(addr1).getRecords()).to.be.revertedWith("Access denied. No permission to view records.");

    await wasmNFT.grantPermission(addr1.address);
    const records = await wasmNFT.connect(addr1).getRecords();
    expect(records.length).to.equal(1);
  });
});
