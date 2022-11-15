import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";
import { Comment } from "../models/Comment";
import { CommentsResponse } from "../models/CommentsResponse";


@Injectable({
    providedIn: 'root'
})

export class CommentsHttpService{

    private apiUrl = environment.apiUrl + 'Comments/';

    constructor(private http: HttpClient){
        
    }

    public getComments(pageNumber: number){

        return this.http.get<CommentsResponse>(this.apiUrl + 'GetComments', {
            params: { 'pageNumber': pageNumber ? pageNumber : 0 }
        });
    }

    public postComment(comment: Comment, uploadedFile: File | null){
        const data = new FormData();
        data.append('commentString', JSON.stringify(comment));

        if(uploadedFile){
            data.append('uploadedFiles', uploadedFile)
        }

        return this.http.post(this.apiUrl + 'WriteComment', data);
    }
}