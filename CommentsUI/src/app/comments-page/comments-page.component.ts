import { Component, OnDestroy, OnInit, AfterViewInit, ViewChild } from "@angular/core";
import { CommentsHttpService } from "./service/comment-http.service";
import { Comment } from "./models/Comment";
import { CommentsResponse } from "./models/CommentsResponse";
import { CommentEventService } from "./service/comment-event.service";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { CommentsPagination } from "./enums/CommentsPagination.enum";


@Component({
    selector: 'comments-page',
    templateUrl: 'comments-page.component.html',
    styleUrls: ['comments-page.component.scss']
})

export class CommentsPageComponent implements OnInit, OnDestroy, AfterViewInit {
    public comments?: Comment[];
    public isRequestPending: boolean = false;

    public paginatorEvent: PageEvent;
    public pageSizeOptions: number[] = [CommentsPagination.pageSize];

    @ViewChild('paginator') paginator: MatPaginator;

    constructor(private commentsHttpService: CommentsHttpService, private commentEventService: CommentEventService){

    }

    public ngOnInit(){
        this.commentEventService.commentsLoadInvoked.subscribe(e => this.loadComments());
        this.loadComments();
    }

    public ngAfterViewInit() {
    }

    public ngOnDestroy() {
        
    }

    public loadComments(){

        this.isRequestPending = true;

        const pageNumber = this.paginator?.pageIndex;

        this.commentsHttpService.getComments(pageNumber).pipe().subscribe((data: CommentsResponse) => {
            this.comments = data.comments;
            this.paginator.length = data.totalCount;
            this.isRequestPending = false;
        });
    }
}