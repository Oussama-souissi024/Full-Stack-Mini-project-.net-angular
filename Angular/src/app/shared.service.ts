import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private url = 'https://localhost:7082/api/Hero';

  constructor(private http: HttpClient) { }

  CreateNewHero(hero: any) {
    return this.http.post(this.url, hero);
  }

  GetAllHeros() {
    return this.http.get<any[]>(this.url);
  }

  DeleteHero(id: any) {
    return this.http.delete(`${this.url}/${id}`);
  }

  GetHeroById(id: any) {
    return this.http.get(`${this.url}/${id}`);
  }

  UpdateHero(hero: any) {
    return this.http.put(`${this.url}/${hero.id}`, hero);
  }
}
