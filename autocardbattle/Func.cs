using System;
using System.Runtime.InteropServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

class Func {
    public static bool PointInsideRect(Vector2i pos, IntRect rect) {
        return pos.X > rect.Position.X && pos.X < rect.Position.X + rect.Size.X && pos.Y > rect.Position.Y && pos.Y < rect.Position.Y + rect.Size.Y;
    }

    public static bool PointInsideRectUI(Vector2i pos, int[] rect) {
        return pos.X > rect[0] && pos.X < rect[0] + rect[2] && pos.Y > rect[1] && pos.Y < rect[1] + rect[3];
    }
}