import { Injectable } from "@angular/core";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";

@Injectable({
    providedIn: 'root'
})

export class CommentFileService {
    private imageSrc: SafeUrl;

    constructor(private sanitizer: DomSanitizer){            

    }

    public getFileFromBase64(base64File: string){
        const imageBlob = this.dataURItoBlob(base64File);
        const blobUrl = URL.createObjectURL(imageBlob);
        this.imageSrc = this.sanitizer.bypassSecurityTrustUrl(blobUrl);
        
        return this.imageSrc;
    }

    private dataURItoBlob(base64File: string) {
        const byteString = window.atob(base64File);
        const contentType = this.detectMimeType(base64File);

        const arrayBuffer = new ArrayBuffer(byteString.length);
        const int8Array = new Uint8Array(arrayBuffer);

        for (let i = 0; i < byteString.length; i++) {
          int8Array[i] = byteString.charCodeAt(i);
        }

        const blob = new Blob([int8Array], { type: contentType! }); 

        return blob;
    }

     private detectMimeType(base64: string) {
        switch (base64.charAt(0)) {
            case '/':
                return "image/jpeg";

            case 'R':
                return "image/gif";

            case '/':
                return "image/png";

            default: 
                return "text/plain";
        }
    }
}