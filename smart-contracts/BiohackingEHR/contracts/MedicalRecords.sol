// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract MedicalRecords {
    struct Record {
        string data;
        uint256 timestamp;
    }

    mapping(address => Record[]) private records;
    event RecordAdded(address indexed patient, uint256 index, string data, uint256 timestamp);

    // Modifier to ensure only the patient can access their records
    modifier onlyPatient(address patient) {
        require(patient == msg.sender, "Access restricted to the patient only.");
        _;
    }

    // Function to add a new medical record
    function addRecord(string memory _data) public {
        Record memory newRecord = Record({
            data: _data,
            timestamp: block.timestamp
        });
        records[msg.sender].push(newRecord);
        emit RecordAdded(msg.sender, records[msg.sender].length - 1, _data, block.timestamp);
    }

    // Function to get all medical records of the sender (patient)
    function getRecords() public view returns (Record[] memory) {
        return records[msg.sender];
    }

    // Function to get a specific medical record by index
    function getRecord(uint256 index) public view returns (string memory data, uint256 timestamp) {
        require(index < records[msg.sender].length, "Invalid record index.");
        Record storage record = records[msg.sender][index];
        return (record.data, record.timestamp);
    }
}
