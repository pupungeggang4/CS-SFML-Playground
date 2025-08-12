using System;
using System.Runtime.InteropServices;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
public class Program {
    static void Main()
    {
        Console.WriteLine(P2.a);
        var gameWindowSettings = GameWindowSettings.Default;
        var nativeWindowSettings = NativeWindowSettings.Default;
        nativeWindowSettings.StartVisible = false;
        var gameWindow = new GameWindow(gameWindowSettings, nativeWindowSettings);

        var contextSettings = new ContextSettings();
        contextSettings.DepthBits = 24;

        RenderWindow window = new RenderWindow(new VideoMode(1280, 720), "SFML graphics with OpenGL", Styles.Default, contextSettings);
        window.SetVerticalSyncEnabled(true);

        Texture image = new Texture("img/test.png");
        Sprite sprite = new Sprite(image);

        window.Closed += new EventHandler(OnClosed);
        window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
        window.Resized += new EventHandler<SizeEventArgs>(OnResized);
        window.SetActive();

        // Enable Z-buffer read and write
        GL.Enable(EnableCap.DepthTest);
        GL.DepthMask(true);
        GL.ClearDepth(1);

        // Disable lighting
        GL.Disable(EnableCap.Lighting);

        // Configure the viewport (the same size as the window)
        GL.Viewport(0, 0, (int)window.Size.X, (int)window.Size.Y);

        // Setup a perspective projection
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();

        var cube = new float[]
        {
            // positions    // texture coordinates
            -0.2F, -0.2F, -0.2F,  0, 0,
            -0.2F,  0.2F, -0.2F,  1, 0,
            -0.2F, -0.2F,  0.2F,  0, 1,
            -0.2F, -0.2F,  0.2F,  0, 1,
            -0.2F,  0.2F, -0.2F,  1, 0,
            -0.2F,  0.2F,  0.2F,  1, 1,

            0.2F, -0.2F, -0.2F,  0, 0,
            0.2F,  0.2F, -0.2F,  1, 0,
            0.2F, -0.2F,  0.2F,  0, 1,
            0.2F, -0.2F,  0.2F,  0, 1,
            0.2F,  0.2F, -0.2F,  1, 0,
            0.2F,  0.2F,  0.2F,  1, 1,

            -0.2F, -0.2F, -0.2F,  0, 0,
            0.2F, -0.2F, -0.2F,  1, 0,
            -0.2F, -0.2F,  0.2F,  0, 1,
            -0.2F, -0.2F,  0.2F,  0, 1,
            0.2F, -0.2F, -0.2F,  1, 0,
            0.2F, -0.2F,  0.2F,  1, 1,

            -0.2F,  0.2F, -0.2F,  0, 0,
            0.2F,  0.2F, -0.2F,  1, 0,
            -0.2F,  0.2F,  0.2F,  0, 1,
            -0.2F,  0.2F,  0.2F,  0, 1,
            0.2F,  0.2F, -0.2F,  1, 0,
            0.2F,  0.2F,  0.2F,  1, 1,

            -0.2F, -0.2F, -0.2F,  0, 0,
            0.2F, -0.2F, -0.2F,  1, 0,
            -0.2F,  0.2F, -0.2F,  0, 1,
            -0.2F,  0.2F, -0.2F,  0, 1,
            0.2F, -0.2F, -0.2F,  1, 0,
            0.2F,  0.2F, -0.2F,  1, 1,

            -0.2F, -0.2F,  0.2F,  0, 0,
            0.2F, -0.2F,  0.2F,  1, 0,
            -0.2F,  0.2F,  0.2F,  0, 1,
            -0.2F,  0.2F,  0.2F,  0, 1,
            0.2F, -0.2F,  0.2F,  1, 0,
            0.2F,  0.2F,  0.2F,  1, 1
        };

        // Enable position and texture coordinates vertex components
        GL.EnableClientState(ArrayCap.VertexArray);
        GL.DisableClientState(ArrayCap.TextureCoordArray);
        GL.VertexPointer(3, VertexPointerType.Float, 5 * sizeof(float), Marshal.UnsafeAddrOfPinnedArrayElement(cube, 0));

        // Start game loop
        while (window.IsOpen)
        {
            window.DispatchEvents();
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.DrawArrays(OpenTK.Graphics.OpenGL.PrimitiveType.Triangles, 0, 36);
            window.PushGLStates();
            window.Draw(sprite);
            window.PopGLStates();
            window.Display();
        }
    }

    /// <summary>
    /// Function called when the window is closed
    /// </summary>
    static void OnClosed(object sender, EventArgs e)
    {
        RenderWindow window = (RenderWindow)sender;
        window.Close();
    }

    /// <summary>
    /// Function called when a key is pressed
    /// </summary>
    static void OnKeyPressed(object sender, KeyEventArgs e)
    {
        RenderWindow window = (RenderWindow)sender;
        if (e.Code == Keyboard.Key.Escape)
        {
            window.Close();
        }
    }
    static void OnResized(object sender, SizeEventArgs e)
    {
        GL.Viewport(0, 0, (int)e.Width, (int)e.Height);
    }
}