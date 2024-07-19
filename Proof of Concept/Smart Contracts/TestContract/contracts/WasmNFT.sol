// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract WasmNFT is ERC721 {
    // Estrutura para armazenar os metadados do NFT
    struct WasmMetadata {
        string name; // Nome do arquivo Wasm
        string ipfsHash; // Hash IPFS do arquivo Wasm
        address owner; // Endereço do proprietário atual
    }

    // Array de metadados dos NFTs registrados
    WasmMetadata[] public wasmNFTs;

    // Mapeamento de hash IPFS para ID do NFT
    mapping(string => uint256) ipfsToTokenId;

    // Evento emitido quando um novo NFT é registrado
    event NFTRegistered(uint256 tokenId, string name, string ipfsHash, address owner);

    constructor() ERC721("WasmNFT", "WNFT") {}

    // Função para registrar um novo NFT
    function registerWasmNFT(string memory _name, string memory _ipfsHash) external {
        require(ipfsToTokenId[_ipfsHash] == 0, "NFT already registered");

        // Incrementa o ID do NFT
        uint256 tokenId = wasmNFTs.length + 1;

        // Cria um novo NFT com os metadados fornecidos
        wasmNFTs.push(WasmMetadata({
            name: _name,
            ipfsHash: _ipfsHash,
            owner: msg.sender
        }));

        // Mapeia o hash IPFS para o ID do NFT
        ipfsToTokenId[_ipfsHash] = tokenId;

        // Emite o evento de registro do NFT
        emit NFTRegistered(tokenId, _name, _ipfsHash, msg.sender);

        // Cria o NFT usando o ERC721
        _mint(msg.sender, tokenId);
    }

    // Função para obter os metadados de um NFT pelo seu ID
    function getWasmNFT(uint256 _tokenId) external view returns (string memory name, string memory ipfsHash, address owner) {
        require(_tokenId > 0 && _tokenId <= wasmNFTs.length, "Invalid NFT ID");
        
        WasmMetadata storage nft = wasmNFTs[_tokenId - 1];
        return (nft.name, nft.ipfsHash, nft.owner);
    }
}