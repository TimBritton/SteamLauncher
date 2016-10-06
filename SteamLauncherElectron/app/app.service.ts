// var child = require('child_process').execFile;
// var executablePath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";
// var parameters = ["--incognito"];

// child(executablePath, parameters, function(err, data) {
//      console.log(err)
//      console.log(data.toString());
// });

import * as child from 'child_process';
import * as fs from 'fs';
import {Game} from './app.models.ts';
import {GameList} from './app.models.ts';
export class GameService
{
    executeGameLookUp(){
        var executablePath: string = "./app/lib/SteamLauncherBackend.exe";
        var params: string[] = ["-export"];
        console.log("Exceputing the Lookup");
        
        var process: child.ChildProcess = child.spawn(executablePath, params, {detached: true});
        console.log(process.stdout);        
    }

     public  executeGame(game: Game) : Boolean
    {
        var executablePath: string = "./app/lib/SteamLauncherBackend.exe";
        var params: string[] = ["-start", (game.Id + "")];
        console.log("Excuting Game");
        
        var process: child.ChildProcess = child.spawn(executablePath, params, {detached: true});
        console.log(process.stdout);    
        return true;
    }


    readInGames() : Game[]{
        var objs:GameList = JSON.parse(fs.readFileSync('games.json', 'utf8'));
        var games: Game[] = objs.games;
        return  games;
    }

}