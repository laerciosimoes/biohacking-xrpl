import { createThirdwebClient } from "thirdweb";

// Use a variável de ambiente exposta
const clientId = process.env.ClientId;

console.log("Client ID:", clientId);

if (!clientId) {
    throw new Error("No client ID provided");
}

export const client = createThirdwebClient({
    clientId: clientId,
});
