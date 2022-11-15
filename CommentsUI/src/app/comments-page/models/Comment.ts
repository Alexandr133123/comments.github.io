import { User } from "src/app/shared/models/User";
import { FileStorage } from "./FileStorage";

export class Comment {
    commentId: number;
    headCommentId: number | null;
    user: User;
    createdDate: Date;
    commentText: string;
    answers: Comment[];
    files: FileStorage[];

    constructor(){
        this.commentId = 0;
        this.user = new User();
        this.commentText = "";
        this.answers = new Array<Comment>();
        this.files = new Array<FileStorage>();
    }
}