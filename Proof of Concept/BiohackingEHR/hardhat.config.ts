import { HardhatUserConfig } from "hardhat/config";
import "@nomiclabs/hardhat-ethers";
import * as dotenv from "dotenv";
//import * from "@matterlabs/hardhat-zkSync-solc";
import { mine } from "@nomicfoundation/hardhat-network-helpers";

const XRPL_Private_Key = "10f83818970aadbe1ea73a6e3abd6ca12da1a3a1164e4e4cc1049924df98e6fc";

dotenv.config();

const xrplrpc = "https://rpc-evm-sidechain.xrpl.org";

const config: HardhatUserConfig = {
  zksolc: {
    version: "1.3.9",
    compilerSource: "binary",
    settings: {
      optimizer: {
        enabled: true,
      },
    },
  },
  networks: {
    zkSync_testnet: {
      url: "https://zksync2-testnet.zksync.dev",
      ethNetwork: "goerli",
      chainId: 324,
      zksync: true,
    },
  },
  paths: {
    artfacts: "./artifacts-zk",
    cache: ".cache-zk",
    sources: "./contracts",
    tests: "./test",
  },

  solidity: {
    version: '0.8.24',
    defaultNetwork: 'xrplevm',
    networks: {
      hardhat: {},
      xrplevm: {
        url: xrplrpc,
        accounts: [process.env.PRIVATE_KEY]
      }
    },
    settings: {
      optimizer: {
        enabled: true,
        runs: 200,
      },
    },
  },
};

export default config;
