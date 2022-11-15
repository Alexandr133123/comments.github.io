import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { CommentsPageModule } from './comments-page/comments-page.module';
import { ToastrModule } from "ngx-toastr";

@NgModule({
  imports: [
    BrowserModule, 
    HttpClientModule, 
    BrowserAnimationsModule,
    AppRoutingModule,
    CommentsPageModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-right'
    })
  ],
  
  declarations: [
    AppComponent
  ],
  
  bootstrap: [AppComponent]
})
export class AppModule { }
