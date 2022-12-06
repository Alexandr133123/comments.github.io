import { Component, Input, OnInit, ViewChild } from "@angular/core";
import { Comment } from "../models/Comment";
import { CommentHubService } from "../service/comment-hub.service";

@Component({
    selector: 'comments-list',
    templateUrl: 'comments-list.component.html',
    styleUrls: ['comments-list.component.scss']
})

export class CommentsListComponent implements OnInit {
    @Input() comments: Comment[];
    @Input() cascadeList: boolean = false;

    constructor(private commentsHubService: CommentHubService){
        
    }

    ngOnInit(){                
        this.commentsHubService.commentsHubConnection.on("updateComments", (comment: Comment) => {
           this.updateComments(comment); 
        });
    }

    updateComments(comment: Comment){
        this.comments
        .find(c => c.commentId == comment.headCommentId 
            || c.commentId == comment.commentId)
        ?.answers
        .push(comment);
    }
}