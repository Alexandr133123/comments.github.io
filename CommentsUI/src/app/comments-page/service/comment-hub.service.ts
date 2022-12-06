import { Injectable } from "@angular/core";
import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { environment } from "src/environments/environment";


@Injectable({
    providedIn: 'root'
})

export class CommentHubService{
    public commentsHubConnection : HubConnection
    private hubUrl = environment.hubUrl + 'comments';

    constructor(){
        this.commentsHubConnection = new HubConnectionBuilder()
            .configureLogging(LogLevel.Trace)
            .withAutomaticReconnect()
            .withUrl(this.hubUrl)
            .build();

        this.commentsHubConnection.start().then(() => {console.log("SignalR connected")});
    }
}