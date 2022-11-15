import { Component, Input, OnInit } from "@angular/core";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";
import { Comment } from "../../models/Comment";
import { FileStorage } from "../../models/FileStorage";
import { CommentEventService } from "../../service/comment-event.service";
import { CommentFileService } from "./service/comment-file.service";

@Component({
    selector: 'comment-list-element',
    templateUrl: 'comment-list-element.component.html',
    styleUrls: ['comment-list-element.component.scss']
})

export class CommentListElementComponent implements OnInit {
    @Input() comment!: Comment;
    imageSrcs: SafeUrl[] = new Array<SafeUrl>();
    showReplyForm: boolean = false;


    constructor(private commentFileService: CommentFileService){            
    }

    ngOnInit(){
        if(this.comment.files.length > 0){
            this.comment.files.forEach((file: FileStorage) => {
                const imageSrc = this.commentFileService.getFileFromBase64(file.fileData);
                this.imageSrcs.push(imageSrc);
            });              
        }
    }

    public toggleReplyForm(){
        this.showReplyForm = !this.showReplyForm;
    }
}
