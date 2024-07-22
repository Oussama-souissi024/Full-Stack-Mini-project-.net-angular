import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-first-component',
  templateUrl: './first-component.component.html',
  styleUrls: ['./first-component.component.scss']
})
export class FirstComponentComponent implements OnInit {

  User = {
    Name: 'Oussama Souissi',
    Age: 33,
    Image: 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdhHe79aHGHO5SfYZ01rniGOn7--_yPBXC4HIlynkunrmLLU3rli-La4uyaHQq76-ywBUL6RDQ_qzZ4FxW39LM4ERCN9balNn4FJwRUQ'
  };

  Display = true;

  ChangeMessiImage() {
    this.User.Image = "https://img.olympics.com/images/image/private/t_1-1_300/f_auto/v1687307644/primary/cqxzrctscdr8x47rly1g";
  }

  ChangeRonaldoImage() {
    this.User.Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRdhHe79aHGHO5SfYZ01rniGOn7--_yPBXC4HIlynkunrmLLU3rli-La4uyaHQq76-ywBUL6RDQ_qzZ4FxW39LM4ERCN9balNn4FJwRUQ";
  }

  ImageZlatanUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzDl4hbkhWwtSfRimzfdv9Ie--H71FWnthBg&s";

  ImageStatus: boolean = true;

  ChangeImageStatus() {
    this.ImageStatus = !this.ImageStatus;
  }

  Cars = [
    'Toyota',
    'BMW',
    'Mercedes',
    'Range Rover'
  ];

  Students = [
    {
      Name: 'Hamdi',
      Age: 36
    },
    {
      Name: 'Khalil',
      Age: 26
    },
    {
      Name: 'Mohamed',
      Age: 24
    }
  ];

  Color = 'Green';

  Employee = {
    name: 'Hejer',
    age: 38,
    bg: 'red',
    color: 'blue'
  };

  ngOnInit(): void {}
}
