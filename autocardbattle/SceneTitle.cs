using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class SceneTitle {
    public static void loop(Game game) {
        SceneTitle.render(game);
    }

    public static void render(Game game) {
        game.window.Clear(Color.White);
        game.rRect.FillColor = Color.Transparent;
        game.rRect.OutlineColor = Color.Black;
        game.rRect.OutlineThickness = 2.0f;
        game.rText.CharacterSize = 32;
        game.rText.FillColor = Color.Black;

        Render.RenderRect(game.window, game.rRect, UI.buttonStart);
        Render.RenderRect(game.window, game.rRect, UI.buttonCollection);
        Render.RenderText(game.window, game.rText, "Auto Card Battle", UI.textTitle);
        Render.RenderText(game.window, game.rText, "Start Game", UI.textStart);
        Render.RenderText(game.window, game.rText, "Collection", UI.textCollection);
        game.window.Display();
    }

    public static void MouseUp(Game game, Vector2i pos, string button) {
        if (Func.PointInsideRectUI(pos, UI.buttonStart)) {
            game.scene = "ready";
        }
    }
}