export class User {
    userId?: number;
    userName: string;
    email: string;
    homePage: string

    constructor(){
        this.userId = 0;
        this.userName = "";
        this.email = "";
        this.homePage = "";
    }
}