// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract WasmNFT is ERC721 {
    struct WasmMetadata {
        string name;
        string ipfsHash;
        address owner;
    }

    WasmMetadata[] public wasmNFTs;
    mapping(string => uint256) private ipfsToTokenId;

    event NFTRegistered(uint256 indexed tokenId, string name, string ipfsHash, address owner);

    constructor() ERC721("WasmNFT", "WNFT") {}

    function registerWasmNFT(string memory _name, string memory _ipfsHash) external {
        require(ipfsToTokenId[_ipfsHash] == 0, "NFT already registered");

        uint256 tokenId = wasmNFTs.length;

        wasmNFTs.push(WasmMetadata({
            name: _name,
            ipfsHash: _ipfsHash,
            owner: msg.sender
        }));

        ipfsToTokenId[_ipfsHash] = tokenId;

        emit NFTRegistered(tokenId, _name, _ipfsHash, msg.sender);

        _mint(msg.sender, tokenId);
    }

    function getWasmNFT(uint256 _tokenId) external view returns (string memory name, string memory ipfsHash, address owner) {
        require(_tokenId < wasmNFTs.length, "Invalid NFT ID");
        
        WasmMetadata storage nft = wasmNFTs[_tokenId];
        return (nft.name, nft.ipfsHash, nft.owner);
    }
}
