pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/access/Ownable.sol";

contract CDSNFT is ERC721, Ownable {
    uint256 private _tokenIdCounter;
    
    struct NFTDetails {
        string metadataURI;
        uint256 licenseFee;
        uint256 royaltyPercentage;
    }

    mapping(uint256 => NFTDetails) public nftDetails;
    mapping(uint256 => address) public nftCreators;

    event NFTMinted(uint256 tokenId, address recipient, string metadataURI, uint256 licenseFee, uint256 royaltyPercentage);

    constructor() ERC721("CDSNFT", "CDS") {}

    function mintNFT(address recipient, string memory metadataURI, uint256 licenseFee, uint256 royaltyPercentage) public onlyOwner {
        require(royaltyPercentage <= 100, "Royalty percentage cannot exceed 100");

        uint256 tokenId = _tokenIdCounter;
        _mint(recipient, tokenId);

        nftDetails[tokenId] = NFTDetails(metadataURI, licenseFee, royaltyPercentage);
        nftCreators[tokenId] = recipient;

        emit NFTMinted(tokenId, recipient, metadataURI, licenseFee, royaltyPercentage);

        _tokenIdCounter++;
    }

    function transferNFT(address from, address to, uint256 tokenId) public {
        safeTransferFrom(from, to, tokenId);
    }

    function getNFTDetails(uint256 tokenId) public view returns (string memory, uint256, uint256) {
        NFTDetails memory details = nftDetails[tokenId];
        return (details.metadataURI, details.licenseFee, details.royaltyPercentage);
    }
}
