using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Game
{
    public SFML.Graphics.RenderWindow window;
    public void init()
    {
        var mode = new SFML.Window.VideoMode((1280, 720));
        window = new SFML.Graphics.RenderWindow(mode, "Auto Card Battle");
        window.Closed += new EventHandler(OnClosed);
    }

    public void loop()
    {
        while (window.IsOpen)
        {
            window.DispatchEvents();
            window.Clear(SFML.Graphics.Color.Blue);
            window.Display();
        }
    }

    private static void OnClosed(object sender, EventArgs e)
    {
        var window = (RenderWindow)sender;
        window.Close();
    }
}