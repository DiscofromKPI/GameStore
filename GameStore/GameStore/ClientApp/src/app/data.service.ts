import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Game } from './game';

@Injectable()
export class DataService {

  private url = "/api/games";

  constructor(private http: HttpClient) {
  }

  getGames() {
    return this.http.get(this.url);
  }

  getGame(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createGame(game: Game) {
    return this.http.post(this.url, game);
  }
  updateGame(game: Game) {

    return this.http.put(this.url, game);
  }
  deleteGame(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
