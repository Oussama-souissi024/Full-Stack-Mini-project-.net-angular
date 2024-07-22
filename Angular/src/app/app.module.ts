import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';  // Import HttpClientModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FirstComponentComponent } from './first-component/first-component.component';
import { HeroComponent } from './hero/hero.component';
import { AddCardComponent } from './add-card/add-card.component';
import { ListCardsComponent } from './list-cards/list-cards.component';
import { SharedService } from './shared.service';
import { HeaderComponent } from './header/header.component';
import { UpdateComponent } from './update/update.component';


@NgModule({
  declarations: [
    AppComponent,
    FirstComponentComponent,
    HeroComponent,
    AddCardComponent,
    ListCardsComponent,
    HeaderComponent,
    UpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule  // Add HttpClientModule to imports
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
