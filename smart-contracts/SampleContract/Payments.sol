pragma solidity ^0.8.0;

import "./CDSNFT.sol";

contract Payments is Ownable {
    CDSNFT private nftContract;

    mapping(address => uint256) public pendingWithdrawals;

    event PaymentDistributed(uint256 tokenId, address owner, address creator, uint256 ownerShare, uint256 creatorShare);

    constructor(address nftAddress) {
        nftContract = CDSNFT(nftAddress);
    }

    function distributePayment(uint256 tokenId) public payable {
        ( , uint256 licenseFee, uint256 royaltyPercentage) = nftContract.getNFTDetails(tokenId);
        require(msg.value >= licenseFee, "Insufficient payment");

        uint256 royaltyPaid = (msg.value * royaltyPercentage) / 100;
        uint256 ownerShare = msg.value - royaltyPaid;

        address creator = nftContract.nftCreators(tokenId);
        address owner = nftContract.ownerOf(tokenId);

        pendingWithdrawals[creator] += royaltyPaid;
        pendingWithdrawals[owner] += ownerShare;

        emit PaymentDistributed(tokenId, owner, creator, ownerShare, royaltyPaid);
    }

    function withdrawFunds() public {
        uint256 amount = pendingWithdrawals[msg.sender];
        require(amount > 0, "No funds to withdraw");

        pendingWithdrawals[msg.sender] = 0;
        payable(msg.sender).transfer(amount);
    }

    function validNFT(uint256 tokenId) internal view returns (bool) {
        address owner = nftContract.ownerOf(tokenId);
        return owner != address(0);
    }
}
