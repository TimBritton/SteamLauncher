import * as child from 'child_process';

export class Game
{
 Id: Number;
 Name: string;
 
 constructor(){}

}

export class GameList
{
    games: Game[];

    public getGames() : Game[]
    {
        return this.games;
    }

     

    constructor() {}
}