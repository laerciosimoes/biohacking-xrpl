require("@matterlabs/hardhat-zkSync-solc");
const xrplrpc = "https://rpc-evm-sidechain.xrpl.org";
const XRPL_Private_Key = "10f83818970aadbe1ea73a6e3abd6ca12da1a3a1164e4e4cc1049924df98e6fc";


/** @type import('hardhat/config').HardhatUserConfig */
module.exports = {
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
    version: '0.8.20',
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