import { createThirdwebClient } from "thirdweb";

// Use a variável de ambiente exposta
const clientId = 'af2f7933e8f5c9fd195dfebf30d20d1d';

console.log("Client ID:", clientId);

if (!clientId) {
    throw new Error("No client ID provided");
}

export const client = createThirdwebClient({
    clientId: clientId,
});
