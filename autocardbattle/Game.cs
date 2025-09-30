using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public SFML.Graphics.RenderWindow window;
    uint width, height;
    public SFML.Graphics.RectangleShape rRect;
    public SFML.Graphics.Font neodgm;
    public SFML.Graphics.Text rText;

    public string scene = "title";
    public string state = "";
    public bool menu = false;

    public void init()
    {
        var monitor = SFML.Window.VideoMode.DesktopMode;
        if (monitor.Size.X > 2000) {
            width = 1920; height = 1080;
        } else {
            width = 1280; height = 720;
        }
        var mode = new SFML.Window.VideoMode((width, height));  
        window = new SFML.Graphics.RenderWindow(mode, "Auto Card Battle");
        var view = new View((640.0f, 360.0f), (1280.0f, 720.0f));
        window.SetView(view);
        rRect = new SFML.Graphics.RectangleShape((0.0f, 0.0f));
        neodgm = new SFML.Graphics.Font("font/neodgm.ttf");
        rText = new SFML.Graphics.Text(neodgm, "", 32);

        window.Closed += (_, _) => window.Close();
        window.MouseButtonReleased += OnMouseUp;
    }

    public void loop()
    {
        while (window.IsOpen)
        {
            window.DispatchEvents();

            if (scene == "title") {
                SceneTitle.loop(this);
            } else if (scene == "ready") {
                SceneReady.loop(this);
            }
        }
    }

    public void OnMouseUp(object? sender, MouseButtonEventArgs e) {
        var window = (SFML.Window.Window)sender;
        Vector2i pos = Mouse.GetPosition(window);
        string button = e.Button.ToString();
        pos.X = (int)(pos.X * 1280 / width);
        pos.Y = (int)(pos.Y * 720 / height);

        if (scene == "title") {
            SceneTitle.MouseUp(this, pos, button);
        } else if (scene == "ready") {
            SceneReady.MouseUp(this, pos, button);
        }
    }
}