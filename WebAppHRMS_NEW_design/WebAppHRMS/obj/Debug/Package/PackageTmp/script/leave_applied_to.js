class leaveAPP {
    constructor() {
        this.encryptionKey = "";
        this.host = window.location.hostname;
        if (this.host == "localhost") {
            this.baseUrl = "/leave";
        }
        else if (this.host == "uatapp.mactech.net.in") {
            this.baseUrl = "https://uatapp.mactech.net.in/Dot%20NET%202022/leave";
        }
        else if (this.host == "nextgen.mactech.net.in") {
            this.baseUrl = "https://nextgen.mactech.net.in/MacomHrms/leave";
        }
        this.init();
        this.bindEvents();
       
    }
    async init() {
        await this.loadEncryptionKey();
        await this.bindHiddenValues();
    }
    bindEvents() {
        document.getElementById("txt_ecode").addEventListener('change', (e) => this.handleUseridChange());

    }
   
    async bindHiddenValues() {
        var cont = loanno.split("txt")
        let empcode = document.getElementById("txt_ecode");
        empcode.value = await this.decrypt(document.getElementById(cont[0] + "hdnEcode").value);

        let empName = document.getElementById("txt_ename");
        empName.value = await this.decrypt(document.getElementById(cont[0] + "hdnEname").value);
    }

    async encrypt(text) {
        if (!this.encryptionKey) {
            throw new Error('Encryption key not loaded');
        }
        const encoder = new TextEncoder();
        const data = encoder.encode(text);
        const key = await crypto.subtle.importKey(
            'raw',
            encoder.encode(this.encryptionKey),
            { name: 'AES-GCM' },
            false,
            ['encrypt']
        );
        const iv = crypto.getRandomValues(new Uint8Array(12));
        const encrypted = await crypto.subtle.encrypt(
            { name: 'AES-GCM', iv: iv },
            key,
            data
        );
        const combined = new Uint8Array(iv.length + encrypted.byteLength);
        combined.set(iv);
        combined.set(new Uint8Array(encrypted), iv.length);
        return btoa(String.fromCharCode(...combined));
    }


    async decrypt(base64Input) {
        if (!this.encryptionKey) {
            throw new Error('Encryption key not loaded');
        }

        // Decode Base64 back to bytes
        const binary = atob(base64Input);
        const combined = new Uint8Array(binary.length);
        for (let i = 0; i < binary.length; i++) {
            combined[i] = binary.charCodeAt(i);
        }

        // Extract IV (first 12 bytes)
        const ivLength = 12;
        const iv = combined.slice(0, ivLength);

        // Ciphertext + tag (remaining bytes)
        const cipherPlusTag = combined.slice(ivLength);

        // Import AES-GCM key
        const encoder = new TextEncoder();
        const key = await crypto.subtle.importKey(
            'raw',
            encoder.encode(this.encryptionKey),
            { name: 'AES-GCM' },
            false,
            ['decrypt']
        );

        // Decrypt
        const decrypted = await crypto.subtle.decrypt(
            { name: 'AES-GCM', iv },
            key,
            cipherPlusTag
        );

        // Convert plaintext back to string
        const decoder = new TextDecoder();
        return decoder.decode(decrypted);
    }

    async loadEncryptionKey() {
        try {
            const headers = {
                'X-API-Key': 'SPA-API-KEY-2024',
                'Content-Type': 'application/json; charset=utf-8'
            };

            // In WebForms, WebMethods are invoked via POST to Page.aspx/MethodName
            const response = await fetch(this.baseUrl + '/leave_appli_to.aspx/GetKey', {
                method: 'POST',
                headers: headers,
                body: '{}'   // WebMethods expect a JSON body, even if empty
            });

            if (response.ok) {
                const data = await response.json();
                // ASPX WebMethods wrap the result in "d"
                const encryptedKey = data.d.key;
                this.encryptionKey = this.decryptKey(encryptedKey);
            } else {
                console.error('Unauthorized or failed request');
            }
        } catch (error) {
            console.error('Failed to load encryption key', error);
        }
    }
    decryptKey(encryptedKey) {
        const xorKey = 'XOR2024';
        const decoded = atob(encryptedKey);
        return Array.from(decoded)
            .map((c, i) => String.fromCharCode(c.charCodeAt(0) ^ xorKey.charCodeAt(i % xorKey.length)))
            .join('');
    }
}
document.addEventListener("DOMContentLoaded", () => new leaveAPP());