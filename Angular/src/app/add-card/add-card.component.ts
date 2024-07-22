import { Component } from '@angular/core';
import { SharedService } from '../shared.service';
import { UploadService } from '../upload.service';
import { ActivatedRoute, Router } from '@angular/router'; // Import Router

@Component({
  selector: 'app-add-card',
  templateUrl: './add-card.component.html',
  styleUrls: ['./add-card.component.scss']
})
export class AddCardComponent {
  Hero = {
    name: '',
    power: 0
  };

  selectedFile?: File;

  constructor(
    private sharedService: SharedService,
    private uploadService: UploadService,
    private router: Router // Inject Router here
  ) { }

  onFileChanged(event: any) {
    this.selectedFile = event.target.files[0];
    console.log("File selected successfully");
  }

  Ajout() {
    if (this.selectedFile instanceof File) {
      this.uploadService.upload(this.Hero, this.selectedFile).subscribe(
        (response: any) => {
          console.log("Hero Angular Added Successfully", response);
          this.router.navigate(['/List']); // Redirect to the list page upon successful update
        },
        (error: any) => {
          console.error("Error Angular Adding Hero", error);
        }
      );
    } else {
      console.error("No file selected");
    }
  }
}
