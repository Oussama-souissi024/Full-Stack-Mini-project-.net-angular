import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  private baseUrl = 'https://localhost:7082/api/Hero'; 
                             
  constructor(private http: HttpClient) { }

  upload(hero: any, file: File): Observable<any> {
    const formData: FormData = new FormData();
    formData.append('Name', hero.name);
    formData.append('Power', hero.power.toString());
    formData.append('ImageFile', file, file.name);

    return this.http.post(this.baseUrl, formData);
  }
}
