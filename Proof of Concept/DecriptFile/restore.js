document.getElementById('restoreButton').addEventListener('click', async () => {
    const fileInput = document.getElementById('fileInput');
    if (fileInput.files.length === 0) {
        alert('Please select an encryptedData.txt file.');
        return;
    }

    const file = fileInput.files[0];
    const reader = new FileReader();

    reader.onload = function (e) {
        const encryptedData = e.target.result;
        try {
            const bytes = CryptoJS.AES.decrypt(encryptedData, 'your-secret-key');
            const decryptedDataString = bytes.toString(CryptoJS.enc.Utf8);
            const decryptedData = JSON.parse(decryptedDataString);

            console.log("Decrypted JSON Data:", decryptedData);

            // Decode base64 PDF content
            const base64Content = decryptedData.fileContent.split(',')[1];
            const byteCharacters = atob(base64Content);
            const byteNumbers = new Array(byteCharacters.length);
            for (let i = 0; i < byteCharacters.length; i++) {
                byteNumbers[i] = byteCharacters.charCodeAt(i);
            }
            const byteArray = new Uint8Array(byteNumbers);

            // Create a Blob from the PDF content and trigger download
            const blob = new Blob([byteArray], { type: 'application/pdf' });
            const url = URL.createObjectURL(blob);
            const a = document.createElement('a');
            a.href = url;
            a.download = 'restoredFile.pdf';
            document.body.appendChild(a);
            a.style.display = 'none'; // Ensure the link is not visible
            a.click();
            document.body.removeChild(a);

            // Save the decrypted JSON as a file (optional)
            const jsonBlob = new Blob([JSON.stringify(decryptedData)], { type: 'application/json' });
            const jsonUrl = URL.createObjectURL(jsonBlob);
            const jsonA = document.createElement('a');
            jsonA.href = jsonUrl;
            jsonA.download = 'restoredData.json';
            document.body.appendChild(jsonA);
            jsonA.style.display = 'none'; // Ensure the link is not visible
            jsonA.click();
            document.body.removeChild(jsonA);
        } catch (err) {
            console.error('Error decrypting the file:', err);
        }
    };

    reader.readAsText(file);
});
