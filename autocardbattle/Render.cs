using System;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Render {
    public static void RenderRect(RenderWindow window, RectangleShape rRect, int[] rect) {
        rRect.Position = (rect[0], rect[1]);
        rRect.Size = (rect[2], rect[3]);
        window.Draw(rRect);
    }

    public static void RenderText(RenderWindow window, Text text, string str, int[] pos) {
        text.Position = (pos[0], pos[1] - text.CharacterSize / 4);
        text.DisplayedString = str;
        window.Draw(text);
    }
}