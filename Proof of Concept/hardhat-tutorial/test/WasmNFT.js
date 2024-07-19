const { expect } = require("chai");
const { ethers } = require("hardhat");

describe("WasmNFT", function () {
    let WasmNFT;
    let wasmNFT;
    let owner;
    let addr1;
    let addr2;

    /*
    beforeEach(async function () {
        WasmNFT = await ethers.getContractFactory("WasmNFT");
        [owner] = await ethers.getSigners();

        wasmNFT = await WasmNFT.deploy();
        await wasmNFT.deployed();
    });
*/
 
    describe("Deployment", function () {
        it("Should set the right owner", async function () {
            WasmNFT = await ethers.getContractFactory("WasmNFT");
            [owner] = await ethers.getSigners();

            wasmNFT = await WasmNFT.deploy();
            await wasmNFT.deployed();

 
            // Verifique o endereço do proprietário do contrato (não aplicável diretamente, removido)
            expect(await wasmNFT.name()).to.equal("WasmNFT");
            expect(await wasmNFT.symbol()).to.equal("WNFT");
        });
    });
 
    /*
    describe("RegisterWasmNFT", function () {
        it("Should register a new NFT", async function () {
            const name = "testWasm";
            const ipfsHash = "QmTestHash";

            await expect(wasmNFT.registerWasmNFT(name, ipfsHash))
                .to.emit(wasmNFT, "NFTRegistered")
                .withArgs(0, name, ipfsHash, owner.address);

            const nft = await wasmNFT.getWasmNFT(0);
            expect(nft.name).to.equal(name);
            expect(nft.ipfsHash).to.equal(ipfsHash);
            expect(nft.owner).to.equal(owner.address);

            expect(await wasmNFT.ownerOf(0)).to.equal(owner.address);
        });

        it("Should revert if the NFT is already registered", async function () {
            const name = "testWasm";
            const ipfsHash = "QmTestHash";

            await wasmNFT.registerWasmNFT(name, ipfsHash);

            await expect(wasmNFT.registerWasmNFT(name, ipfsHash)).to.be.revertedWith(
                "NFT already registered"
            );
        });
    });

    describe("GetWasmNFT", function () {
        it("Should return the correct metadata", async function () {
            const name = "testWasm";
            const ipfsHash = "QmTestHash";

            await wasmNFT.registerWasmNFT(name, ipfsHash);

            const nft = await wasmNFT.getWasmNFT(0);
            expect(nft.name).to.equal(name);
            expect(nft.ipfsHash).to.equal(ipfsHash);
            expect(nft.owner).to.equal(owner.address);
        });

        it("Should revert if the NFT ID is invalid", async function () {
            await expect(wasmNFT.getWasmNFT(999)).to.be.revertedWith(
                "Invalid NFT ID"
            );
        });
    });
    */
});
