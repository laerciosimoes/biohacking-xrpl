import { createThirdwebClient } from "thirdweb";

const clientId  = process.env.ClientId || "";
const secretKey  = process.env.SecretKey || "";

export const client = createThirdwebClient(
    secretKey
        ? { secretKey }
        : {
            clientId,
        }
);