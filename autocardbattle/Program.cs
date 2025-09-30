using System;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.init();
        game.loop();
    }
}