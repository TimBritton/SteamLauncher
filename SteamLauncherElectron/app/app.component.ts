import {Component, Input} from '@angular/core';
import {GameService} from './app.service.ts';
import {Observable} from 'rxjs/Observable';
import 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';
// import 'rxjs/add/operator/interval';
import {Game} from './app.models.ts';

@Component({
    selector: 'myapp',
    template: `<h1>Angular 2 app inside a desktop app</h1> 
    
    <div *ngIf="games != null">
    <ul class="list-group">
    <li class="list-group-item" *ngFor="let game of games">
        <div>
            <p>Game Name: {{game.Name}}</p>
            <p>Game Id: {{game.Id}}</p>
            <button class="btn btn-large btn-positive" (click)="execute(game.Id)">Start</button>
        </div>
     </li>
     </ul>
     </div>
     `
})

export class AppComponent {
    games: Game[] = null
    gameService: GameService;
    constructor(gameService: GameService) {
        this.gameService = gameService;
        gameService.executeGameLookUp();

        this.refresh();
    }

    refresh() {
        console.log("refreshing the data");
        // this.json = this.gameService.readInGames();

        this.games = this.gameService.readInGames();

        console.log(this.games);

    }

    execute(gameId: Number) {
        this.games.forEach(element => {
            if (element.Id == gameId) {
               var bool: Boolean = this.gameService.executeGame(element);
               console.log("launched: " + bool);
            }
        });

    }
}


// @Component({
//   selector: 'mybutton',
//   template: ` `
// })
// export class MyButton {      

//     gameService: GameService;

//   constructor(gameService: GameService) {
//       this.gameService = gameService;
//   } 

//   launch(id: Number)
//   {
//       this.gameService.excuteGame(id);
//   }
// }
