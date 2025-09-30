using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class SceneReady {
    public static void loop(Game game) {
        SceneReady.render(game);
    }

    public static void render(Game game) {
        game.window.Clear(Color.White);
        game.window.Display();
    }

    public static void MouseUp(Game game, Vector2i pos, string button) {
        
    }
}