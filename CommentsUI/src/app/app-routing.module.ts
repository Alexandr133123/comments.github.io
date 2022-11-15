import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { CommentsPageComponent } from "./comments-page/comments-page.component";


const routes: Routes = [
    {path: '', redirectTo: 'comments', pathMatch: 'full'},
    {path: 'comments', component: CommentsPageComponent}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    
    exports: [RouterModule]
})

export class AppRoutingModule{

}