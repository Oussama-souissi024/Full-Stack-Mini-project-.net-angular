import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-list-cards',
  templateUrl: './list-cards.component.html',
  styleUrls: ['./list-cards.component.scss']
})
export class ListCardsComponent implements OnInit {

  heroes: any[] = [];

  constructor(private sharedService: SharedService) { }

  ngOnInit(): void {
    this.sharedService.GetAllHeros()
      .subscribe(
        (heroes: any[]) => {
          console.log(heroes);
          this.heroes = heroes;
        },
        (error: any) => {
          console.error("Error Getting Heroes", error);
        }
      );
  }

  DeleteHero(id: any) {
    this.sharedService.DeleteHero(id)
      .subscribe(
        (res: any) => {
          console.log("Hero Deleted Successfully", res);
          this.ngOnInit(); // Refresh the list after deletion
        },
        (error: any) => {
          console.error("Error Deleting Hero", error);
        }
      );
  }
}
