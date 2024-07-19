// SPDX-License-Identifier: MIT
pragma solidity 0.8.24;

import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";
import "@openzeppelin/contracts/access/Ownable.sol";

contract WasmNFT is ERC721URIStorage, Ownable {
    struct Record {
        string data;
        uint256 timestamp;
    }

    mapping(address => Record[]) private records;
    mapping(address => mapping(address => bool)) private permissions;
    mapping(address => uint256) private patientTokenIds;
    uint256 private _tokenIdCounter;

    event RecordAdded(address indexed patient, uint256 index, string data, uint256 timestamp);
    event PermissionGranted(address indexed patient, address indexed grantee);
    event PermissionRevoked(address indexed patient, address indexed grantee);
    event TokenMinted(address indexed patient, uint256 tokenId);

    // Adicione um endereço inicial para o proprietário
    constructor(address initialOwner) 
        ERC721("WasmNFT", "WNFT") 
        Ownable(initialOwner) {
        transferOwnership(initialOwner);
    }

    modifier onlyPatient(address patient) {
        require(patient == msg.sender, "Access restricted to the patient only.");
        _;
    }

    modifier hasPermission(address patient) {
        require(
            msg.sender == patient || permissions[patient][msg.sender],
            "Access denied. No permission to view records."
        );
        _;
    }

    function addRecord(string memory _data) public {
        Record memory newRecord = Record({
            data: _data,
            timestamp: block.timestamp
        });
        records[msg.sender].push(newRecord);
        emit RecordAdded(msg.sender, records[msg.sender].length - 1, _data, block.timestamp);

        uint256 tokenId = patientTokenIds[msg.sender];
        if (tokenId != 0) {
            _setTokenURI(tokenId, _data);
        } else {
            _tokenIdCounter++;
            tokenId = _tokenIdCounter;
            _mint(msg.sender, tokenId);
            _setTokenURI(tokenId, _data);
            patientTokenIds[msg.sender] = tokenId;
            emit TokenMinted(msg.sender, tokenId);
        }
    }

    function grantPermission(address _address) public onlyPatient(msg.sender) {
        permissions[msg.sender][_address] = true;
        emit PermissionGranted(msg.sender, _address);
    }

    function revokePermission(address _address) public onlyPatient(msg.sender) {
        permissions[msg.sender][_address] = false;
        emit PermissionRevoked(msg.sender, _address);
    }

    function getRecords() public view hasPermission(msg.sender) returns (Record[] memory) {
        return records[msg.sender];
    }

    function getRecord(uint256 index) public view hasPermission(msg.sender) returns (string memory data, uint256 timestamp) {
        require(index < records[msg.sender].length, "Invalid record index.");
        Record storage record = records[msg.sender][index];
        return (record.data, record.timestamp);
    }
}
