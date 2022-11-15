import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { CommentsPageComponent } from "./comments-page.component";
import { MatListModule } from "@angular/material/list"; 
import { MatInputModule} from "@angular/material/input";
import { CommentsListComponent } from "./comments-list/comments-list.component";
import { CommentListElementComponent } from "./comments-list/comment-list-element/comment-list-element.component";
import { CommentAddComponent } from './comment-add/comment-add.component';
import { MatButtonModule} from "@angular/material/button";
import { NgxCaptchaModule } from "@binssoft/ngx-captcha";
import { MatPaginatorModule }  from "@angular/material/paginator";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
    imports:[
        BrowserModule,
        FormsModule,
        MatListModule,
        MatInputModule,
        MatButtonModule,
        ReactiveFormsModule,
        NgxCaptchaModule,
        MatPaginatorModule
                
    ],

    declarations: [
        CommentsPageComponent,
        CommentsListComponent,
        CommentListElementComponent,
        CommentAddComponent
    ]
})

export class CommentsPageModule{
    
}