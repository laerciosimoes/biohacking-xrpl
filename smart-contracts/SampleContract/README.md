# Smart Contracts Design

## Table of Contents
1. [Introduction](#introduction)
2. [NFT Minting Contract](#nft-minting-contract)
3. [Licensing Contract](#licensing-contract)
4. [Payment Contract](#payment-contract)
5. [Conclusion](#conclusion)

## Introduction
This document provides a detailed design for the smart contracts needed for the NFT-based Clinical Decision Support (CDS) Protocol Payment System. The system leverages blockchain technology to tokenize CDS protocols into NFTs, enabling secure, transparent, and automated payments for protocol creators.

## NFT Minting Contract
**Purpose**: To mint NFTs representing CDS protocols and manage their ownership.

**Functions**:
- `mintNFT(address recipient, string metadataURI, uint256 licenseFee, uint256 royaltyPercentage)`: Mints a new NFT with specified metadata, license fee, and royalty percentage. Assigns ownership to the recipient.
- `transferNFT(address from, address to, uint256 tokenId)`: Transfers the ownership of an NFT from one user to another.
- `getNFTDetails(uint256 tokenId)`: Returns the details of a specific NFT, including metadata URI, license fee, and royalty percentage.

**Events**:
- `NFTMinted(uint256 tokenId, address recipient, string metadataURI, uint256 licenseFee, uint256 royaltyPercentage)`: Emitted when a new NFT is minted.
- `NFTTransferred(uint256 tokenId, address from, address to)`: Emitted when an NFT is transferred.

**Storage**:
- `mapping(uint256 => address) public nftOwners`: Maps NFT IDs to their owners.
- `mapping(uint256 => string) public nftMetadata`: Maps NFT IDs to their metadata URIs.
- `mapping(uint256 => uint256) public nftLicenseFees`: Maps NFT IDs to their license fees.
- `mapping(uint256 => uint256) public nftRoyaltyPercentages`: Maps NFT IDs to their royalty percentages.

## Licensing Contract
**Purpose**: To manage the licensing of CDS protocol NFTs, including payments and royalty distribution.

**Functions**:
- `licenseNFT(uint256 tokenId) payable`: Allows users to license an NFT by paying the specified license fee. The fee is distributed to the NFT owner and original creator based on the royalty percentage.
- `getLicenseDetails(uint256 tokenId)`: Returns the details of the licensing agreement for a specific NFT.

**Events**:
- `NFTLicensed(uint256 tokenId, address licensee, uint256 licenseFee, uint256 royaltyPaid)`: Emitted when an NFT is licensed.

**Storage**:
- `mapping(uint256 => address) public nftCreators`: Maps NFT IDs to their original creators.
- `mapping(uint256 => uint256) public nftLicenses`: Tracks the number of times an NFT has been licensed.

**Modifiers**:
- `onlyNFTOwner(uint256 tokenId)`: Ensures that certain functions can only be called by the owner of the NFT.
- `sufficientPayment(uint256 tokenId)`: Ensures that the license fee paid is sufficient.

## Payment Contract
**Purpose**: To handle the distribution of payments and royalties to NFT owners and creators.

**Functions**:
- `distributePayment(uint256 tokenId) payable`: Distributes the license fee between the NFT owner and the original creator based on the royalty percentage.
- `withdrawFunds()`: Allows users to withdraw their accumulated funds.

**Events**:
- `PaymentDistributed(uint256 tokenId, address owner, address creator, uint256 ownerShare, uint256 creatorShare)`: Emitted when a payment is distributed.

**Storage**:
- `mapping(address => uint256) public pendingWithdrawals`: Tracks the funds available for withdrawal by each user.

**Modifiers**:
- `validNFT(uint256 tokenId)`: Ensures that the NFT exists and is valid.

## Conclusion
These smart contracts provide the core functionality needed for minting NFTs, managing licenses, and handling payments and royalties in the NFT-based CDS Protocol Payment System. By leveraging XRPL Ledger and thirdweb.com, these contracts ensure secure and efficient transactions, fostering a reliable marketplace for CDS protocols.
