import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule,  HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import {GamesComponent} from "./games/games.component";
import { GameComponent } from './game/game.component';
import { OrderComponent } from './order/order.component';
import {ErrorHandlerService} from "../shared/services/error-handler.service";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    GamesComponent,
    GameComponent,
    OrderComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'home', component: GamesComponent, pathMatch: 'full' },
      {path:'authentication', loadChildren: () => import('./authentication/authentication.module').then(x => x.AuthenticationModule)},
      //{path: '404', component: NotFoundComponent},
      {path: '', redirectTo: '/home', pathMatch: 'full'},
      {path: '**', redirectTo: '/404', pathMatch: 'full'}
    ])
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass:ErrorHandlerService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
