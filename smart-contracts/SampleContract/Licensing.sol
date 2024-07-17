pragma solidity ^0.8.0;

import "./CDSNFT.sol";

contract Licensing is Ownable {
    CDSNFT private nftContract;

    mapping(uint256 => uint256) public nftLicenses;

    event NFTLicensed(uint256 tokenId, address licensee, uint256 licenseFee, uint256 royaltyPaid);

    constructor(address nftAddress) {
        nftContract = CDSNFT(nftAddress);
    }

    function licenseNFT(uint256 tokenId) public payable {
        ( , uint256 licenseFee, uint256 royaltyPercentage) = nftContract.getNFTDetails(tokenId);
        require(msg.value >= licenseFee, "Insufficient payment");

        uint256 royaltyPaid = (msg.value * royaltyPercentage) / 100;
        uint256 ownerShare = msg.value - royaltyPaid;

        address creator = nftContract.nftCreators(tokenId);
        address owner = nftContract.ownerOf(tokenId);

        payable(creator).transfer(royaltyPaid);
        payable(owner).transfer(ownerShare);

        nftLicenses[tokenId] += 1;

        emit NFTLicensed(tokenId, msg.sender, licenseFee, royaltyPaid);
    }

    function getLicenseDetails(uint256 tokenId) public view returns (uint256) {
        return nftLicenses[tokenId];
    }
}
