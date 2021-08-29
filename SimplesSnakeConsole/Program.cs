using System;

namespace SimplesSnakeConsole {
     public class Program {
        static void Main(string[] args) {
            Game G =  new Game();
            G.Msg();


            while (G.Continue) {              
            G.WriteBoard();
            G.Input();
            G.Logic();
           
            }

        }
    }
}
