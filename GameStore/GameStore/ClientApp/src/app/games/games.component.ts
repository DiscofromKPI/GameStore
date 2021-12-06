import {Component, OnInit} from '@angular/core';
import {DataService} from "../data.service";
import {Game} from "../game";

@Component({
  selector: 'games', // connect to the html
  templateUrl: './games.component.html',
  providers: [DataService]
})

export class GamesComponent implements OnInit {
  game: Game = new Game();
  games: Game[];
  tableMode: boolean = true;

  constructor(private dataService: DataService) {
  }

  ngOnInit() {
    this.loadGames();
  }

  loadGames() {
    this.dataService.getGames().subscribe((data: Game[]) => this.games = data);
  }

  save() {
    if (this.game.id == null) {
      this.dataService.createGame(this.game).subscribe((data: Game) => this.games.push(data));
    } else {
      this.dataService.updateGame(this.game).subscribe(data => this.loadGames());
    }
    this.cancel();
  }
  editGame(game:Game){
    this.game = game;
  }
  cancel(){
    this.game = new Game();
    this.tableMode = true;
  }
  delete(game: Game){
    this.dataService.deleteGame(game.id).subscribe(data => this.loadGames());
  }
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
