import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'; // Import Router
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.scss']
})
export class UpdateComponent implements OnInit {
  Hero: any = { name: '', power: '', imageUrl: '' };
  id: any;

  constructor(private act: ActivatedRoute, private _Shared: SharedService, private router: Router) { } // Inject Router

  ngOnInit(): void {
    this.id = this.act.snapshot.paramMap.get('id');
    this._Shared.GetHeroById(this.id).subscribe({
      next: (res: any) => {
        this.Hero = res;
        this.Hero.id = this.id; // Ensure the id is correctly set
        console.log("Hero data fetched successfully", res);
      },
      error: (error: any) => {
        console.error("Error fetching hero data", error);
      }
    });
  }

  Update(): void {
    this._Shared.UpdateHero(this.Hero).subscribe({
      next: (res: any) => {
        console.log("Hero updated successfully", res);
        this.router.navigate(['/List']); // Redirect to the list page upon successful update
      },
      error: (error: any) => {
        console.error("Error updating hero", error);
      }
    });
  }
}
