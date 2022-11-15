import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgxCaptchaService } from '@binssoft/ngx-captcha';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/shared/models/User';
import { Comment } from '../models/Comment';
import { CommentEventService } from '../service/comment-event.service';
import { CommentsHttpService } from '../service/comment-http.service';

@Component({
  selector: 'comment-add',
  templateUrl: './comment-add.component.html',
  styleUrls: ['./comment-add.component.scss']
})

export class CommentAddComponent implements OnInit {

  public comment: Comment;
  public user: User;
  public uploadedFile: File | null = null;
  @Input() headCommentId: number;
  @ViewChild('commentTextInput') private commenTextInput : ElementRef;

  public captchaConfig: any = {
    length: 6,
    cssClass: 'custom',
    back: {
      stroke:"#2F9688",
      solid:"#f2efd2"
    } ,
    font: {
      color:"#000000",
      size:"35px"
    }
  };

  public commentFormGroup: FormGroup;

  private captchaStatus: boolean;

  constructor(private commentsHttpService : CommentsHttpService, 
    private commentEventService: CommentEventService, 
    private captchaService: NgxCaptchaService,
    private toastrService: ToastrService) { }

  public ngOnInit(){
    this.user = new User();
    this.comment = new Comment();
    
    this.commentFormGroup = new FormGroup({
        "email": new FormControl(this.user.email, [Validators.email, Validators.required]),
        "userName": new FormControl(this.user.userName, [Validators.required]),
        "homePage": new FormControl(this.user.homePage, []),
        "commentText": new FormControl(this.comment.commentText, [Validators.required, 
          Validators
          .pattern(/([a-zA-Z0-9., ])*((<\s*a[^>]*href="(.*?)"\s?(title="(.*?)")?>(.*?)<\s*\/\s*a>)*(<i>(.*?)<\/i>)*(<code>(.*?)<\/code>)*(strong>(.*?)<\/strong>)*)([a-zA-Z0-9., ])/)])
    });

    this.captchaService.captchStatus.subscribe((status)=>{
      if (status == false) {
        this.captchaStatus = false;
      } else  if (status == true) {
        this.captchaStatus = true;
      }
    });
  }

  public postComment(){

    if(!this.captchaStatus){
        this.toastrService.error('Captcha is invalid!', 'Error');
      return;
    }

    this.comment.commentText = this.commentFormGroup.controls['commentText'].value;
    this.user.email = this.commentFormGroup.controls['email'].value;
    this.user.userName = this.commentFormGroup.controls['userName'].value;
    this.user.homePage = this.commentFormGroup.controls['homePage'].value;
    this.comment.user = this.user;

    if(this.headCommentId){
      this.comment.headCommentId = this.headCommentId;
    }   
    
    this.commentsHttpService.postComment(this.comment, this.uploadedFile).pipe()
      .subscribe(data => this.commentEventService.commentsLoadInvoked.next());
  }

  public setSelectedFile(files: FileList){
    this.uploadedFile = files.item(0)!; 
  }

  public postButton(){
    return this.headCommentId? 'Reply': 'Post'
  }

  public isActivePostButton(){
    return this.commentFormGroup.invalid;
  }

  public addTagOnSelectedText(tag: string)
  {
    const inputValue = this.commenTextInput.nativeElement.value;
    const selectedText = window.getSelection()!.toString();
    if (tag === 'a') {
      this.commentFormGroup.controls['commentText'].setValue(
      inputValue.replace(selectedText!, `<${tag} href="">` + selectedText + `</${tag}>`))
    } else {
      this.commentFormGroup.controls['commentText'].setValue(
      inputValue.replace(selectedText!, `<${tag}>` + selectedText + `</${tag}>`))
    }
  }
}
