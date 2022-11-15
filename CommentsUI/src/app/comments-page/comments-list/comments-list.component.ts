import { Component, Input, OnInit, ViewChild } from "@angular/core";
import { Comment } from "../models/Comment";

@Component({
    selector: 'comments-list',
    templateUrl: 'comments-list.component.html',
    styleUrls: ['comments-list.component.scss']
})

export class CommentsListComponent implements OnInit {
    @Input() comments: Comment[];
    @Input() cascadeList: boolean = false;

    constructor(){
        
    }

    ngOnInit(){
        
    }
}