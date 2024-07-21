require('dotenv').config({ path: './test/.env' });
const { expect } = require("chai");
const { ethers } = require("hardhat");

describe("WasmNFT", function () {
    let WasmNFT, wasmNFT, owner, addr1, addr2;

    beforeEach(async function () {
        WasmNFT = await ethers.getContractFactory("WasmNFT");
        [owner, addr1, addr2] = await ethers.getSigners();
        /*
        console.log('owner:', owner.address);
        console.log('addr1', addr1.address);
        console.log('aadr2', addr2.address);
        */
        // Deploy do contrato com o endereço do signatário como o proprietário inicial
        wasmNFT = await WasmNFT.deploy(owner.address);
        //-await wasmNFT.deployed(); // Aguarde a conclusão do deploy
    });

    it("Should mint an NFT when adding a record", async function () {
        const tokenURI = "Initial medical data";
        await wasmNFT.addRecord(tokenURI);

        // Verifique o URI do token
        const tokenId = await wasmNFT.getPatientTokenId(owner.address); // Use getPatientTokenId para obter o tokenId
        const newItemId = await wasmNFT.tokenURI(tokenId);
        expect(newItemId).to.equal(tokenURI);

        // Verifique os registros
        const records = await wasmNFT.getRecords();
        expect(records.length).to.equal(1);
        expect(records[0].data).to.equal(tokenURI);
    });

    it("Should update the NFT URI when adding subsequent records", async function () {
        const tokenURI1 = "Initial medical data";
        const tokenURI2 = "Updated medical data";
        await wasmNFT.addRecord(tokenURI1);
        await wasmNFT.addRecord(tokenURI2);

        // Verifique o URI atualizado do token
        const tokenId = await wasmNFT.getPatientTokenId(owner.address); // Use getPatientTokenId para obter o tokenId
        const newItemId = await wasmNFT.tokenURI(tokenId);
        expect(newItemId).to.equal(tokenURI2);

        // Verifique os registros
        const records = await wasmNFT.getRecords();
        expect(records.length).to.equal(2);
        expect(records[0].data).to.equal(tokenURI1);
        expect(records[1].data).to.equal(tokenURI2);
    });

    

    it("Should set the right owner", async function () {
        // Verifique se o proprietário está correto
        expect(await wasmNFT.owner()).to.equal(owner.address);
    });

    it("Should grant and revoke permission", async function () {
        // Testa a concessão de permissão
        await wasmNFT.grantPermission(addr1.address);
        const hasPermission = await wasmNFT.checkPermission(owner.address, addr1.address);
        expect(hasPermission).to.equal(true);

        // Testa a revogação de permissão
        await wasmNFT.revokePermission(addr1.address);
        const hasPermissionRevoked = await wasmNFT.checkPermission(owner.address, addr1.address);
        expect(hasPermissionRevoked).to.equal(false);
    });

    it("Should update different  NFT URI when adding subsequent records", async function () {
        const tokenURI1 = "Initial medical data";
        const tokenURI2 = "Updated medical data";
        const tokenURI3 = "Final medical data";
        await wasmNFT.addRecord(tokenURI1);
        await wasmNFT.addRecord(tokenURI2);
        await wasmNFT.addRecord(tokenURI3);

        // Verifique os registros
        const records = await wasmNFT.getRecords();
        expect(records.length).to.equal(3);
        expect(records[0].data).to.equal(tokenURI1);
        expect(records[1].data).to.equal(tokenURI2);
        expect(records[2].data).to.equal(tokenURI3);

        WasmNFT = await ethers.getContractFactory("WasmNFT");
        [owner, addr1, addr2] = await ethers.getSigners();
      
        wasmNFT = await WasmNFT.deploy(addr2.address);
        const tokenURI11 = "Initial medical data 11";
        const tokenURI12 = "Updated medical data 12";
        const tokenURI13 = "Final medical data 13";
        await wasmNFT.addRecord(tokenURI11);
        await wasmNFT.addRecord(tokenURI12);
        await wasmNFT.addRecord(tokenURI13);
        // Verifique os registros
        const records1 = await wasmNFT.getRecords();
        expect(records1.length).to.equal(3);
        expect(records1[0].data).to.equal(tokenURI11);
        expect(records1[1].data).to.equal(tokenURI12);
        expect(records1[2].data).to.equal(tokenURI13);
    });



    it("Should only allow the owner to add records and mint tokens", async function () {
        const tokenURI = "Non-owner medical data";

        // Verifica que apenas o proprietário pode adicionar registros
        await expect(wasmNFT.connect(addr2).addRecord(tokenURI))
            .to.be.revertedWith("Access restricted to the patient only.");
    });


         
    it("Should only allow viewing records with permission", async function () {
        // Adiciona um registro
        await wasmNFT.addRecord("Owner medical data");
        // Verifica que sem permissão o acesso é negado
        await expect(wasmNFT.connect(addr1)["getRecords(address)"](owner.address)).to.be.revertedWith("Access denied. No permission to view records.");

        // Concede permissão e verifica se o acesso é permitido
        await wasmNFT.grantPermission(addr1.address);
        const records = await wasmNFT.connect(addr1)["getRecords(address)"](owner.address);
        expect(records.length).to.equal(1);
    });
   
});