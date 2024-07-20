// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;
import "hardhat/console.sol";

contract MedicalNFT {
    struct MedicalRecord {
        address patient;
        string data;
    }

    mapping(uint256 => MedicalRecord) public medicalRecords;

    uint256 public numberOfRecords = 0;

    function createRecord(
        address _patient,
        string memory _data
    ) public returns (uint256) {
        MedicalRecord storage medicalRecord = medicalRecords[numberOfRecords];

        medicalRecord.patient = _patient;
        medicalRecord.data = _data;

        numberOfRecords++;

        return numberOfRecords - 1;
    }

    function getRecords(
        address _patient
    ) public view returns (MedicalRecord[] memory) {
        uint256 totalItems = 0;
        for (uint i = 0; i < numberOfRecords; i++) {
            if (medicalRecords[i].patient == _patient) {
                totalItems++;
            }
        }
        console.log("totalItems: %d", totalItems);  
        MedicalRecord[] memory allRecords = new MedicalRecord[](totalItems);
        uint256 j = 0;
        for (uint i = 0; i < numberOfRecords; i++) {
            MedicalRecord storage item = medicalRecords[i];
            
            if (medicalRecords[i].patient == _patient) {
                console.log("j: %d", j);  
                allRecords[j] = item;
                j++;
            }
            
        }

        return allRecords;
    }
}
