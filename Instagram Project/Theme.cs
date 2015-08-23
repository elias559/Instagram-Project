using System;
using System.Drawing;
using System.Windows.Forms;

//Sidewinder Theme.
//Made by AeroRev9.
//Converted by LaPanthere
public static class Helpers
{

    public enum MouseState : byte
    {
        None = 0,
        Over = 1,
        Down = 2
    }

    public static Rectangle FullRectangle(Size S, bool Subtract)
    {
        if (Subtract)
        {
            return new Rectangle(0, 0, S.Width - 1, S.Height - 1);
        }
        else
        {
            return new Rectangle(0, 0, S.Width, S.Height);
        }
    }

    public static Color GreyColor(uint G)
    {
        return Color.FromArgb((int)G, (int)G, (int)G);
    }

    public static void CenterString(Graphics G, string T, Font F, Color C, Rectangle R)
    {
        SizeF TS = G.MeasureString(T, F);

        using (SolidBrush B = new SolidBrush(C))
        {
            G.DrawString(T, F, B, new Point(R.Width / 2 - (((int)TS.Width) / 2), ((int)R.Height) / 2 - (((int)TS.Height) / 2)));
        }
    }


    public static void FillRoundRect(Graphics G, Rectangle R, int Curve, Color C)
    {
        using (SolidBrush B = new SolidBrush(C))
        {
            G.FillPie(B, R.X, R.Y, Curve, Curve, 180, 90);
            G.FillPie(B, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
            G.FillPie(B, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
            G.FillPie(B, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
            G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), R.Y, R.Width - Curve, Convert.ToInt32(Curve / 2));
            G.FillRectangle(B, R.X, Convert.ToInt32(R.Y + Curve / 2), R.Width, R.Height - Curve);
            G.FillRectangle(B, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height - Curve / 2), R.Width - Curve, Convert.ToInt32(Curve / 2));
        }

    }


    public static void DrawRoundRect(Graphics G, Rectangle R, int Curve, Color C)
    {
        using (Pen P = new Pen(C))
        {
            G.DrawArc(P, R.X, R.Y, Curve, Curve, 180, 90);
            G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), R.Y, Convert.ToInt32(R.X + R.Width - Curve / 2), R.Y);
            G.DrawArc(P, R.X + R.Width - Curve, R.Y, Curve, Curve, 270, 90);
            G.DrawLine(P, R.X, Convert.ToInt32(R.Y + Curve / 2), R.X, Convert.ToInt32(R.Y + R.Height - Curve / 2));
            G.DrawLine(P, Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + Curve / 2), Convert.ToInt32(R.X + R.Width), Convert.ToInt32(R.Y + R.Height - Curve / 2));
            G.DrawLine(P, Convert.ToInt32(R.X + Curve / 2), Convert.ToInt32(R.Y + R.Height), Convert.ToInt32(R.X + R.Width - Curve / 2), Convert.ToInt32(R.Y + R.Height));
            G.DrawArc(P, R.X, R.Y + R.Height - Curve, Curve, Curve, 90, 90);
            G.DrawArc(P, R.X + R.Width - Curve, R.Y + R.Height - Curve, Curve, Curve, 0, 90);
        }

    }

    public enum Direction : byte
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    public static void DrawTriangle(Graphics G, Rectangle Rect, Direction D, Color C)
    {
        int halfWidth = Rect.Width / 2;
        int halfHeight = Rect.Height / 2;
        Point p0 = Point.Empty;
        Point p1 = Point.Empty;
        Point p2 = Point.Empty;

        switch (D)
        {
            case Direction.Up:
                p0 = new Point(Rect.Left + halfWidth, Rect.Top);
                p1 = new Point(Rect.Left, Rect.Bottom);
                p2 = new Point(Rect.Right, Rect.Bottom);

                break;
            case Direction.Down:
                p0 = new Point(Rect.Left + halfWidth, Rect.Bottom);
                p1 = new Point(Rect.Left, Rect.Top);
                p2 = new Point(Rect.Right, Rect.Top);

                break;
            case Direction.Left:
                p0 = new Point(Rect.Left, Rect.Top + halfHeight);
                p1 = new Point(Rect.Right, Rect.Top);
                p2 = new Point(Rect.Right, Rect.Bottom);

                break;
            case Direction.Right:
                p0 = new Point(Rect.Right, Rect.Top + halfHeight);
                p1 = new Point(Rect.Left, Rect.Bottom);
                p2 = new Point(Rect.Left, Rect.Top);

                break;
        }

        using (SolidBrush B = new SolidBrush(C))
        {
            G.FillPolygon(B, new Point[] {
                p0,
                p1,
                p2
            });
        }

    }

}

public class SideWinderTab : TabControl
{

    #region " Helpers "



    #endregion

    #region " Drawing "
    private Graphics G;
    private Rectangle Rect;
    private int LastIndex;

    private Color BackgroundC = Color.FromArgb(102, 105, 112);
    private int _Index = -1;
    private int Index
    {
        get { return _Index; }
        set
        {
            _Index = value;
            Invalidate();
        }
    }

    public SideWinderTab()
    {
        DoubleBuffered = true;
        ItemSize = new Size(40, 170);
        Alignment = TabAlignment.Left;
        SizeMode = TabSizeMode.Fixed;
        Dock = DockStyle.Fill;
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        base.OnControlAdded(e);
        e.Control.BackColor = Color.White;
        e.Control.ForeColor = Color.FromArgb(72, 75, 82);
        e.Control.Font = new Font("Segoe UI", 10);
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;
        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        base.OnPaint(e);

        G.Clear(Color.FromArgb(72, 75, 82));


        for (int i = 0; i <= TabPages.Count - 1; i++)
        {
            Rect = GetTabRect(i);


            if (string.IsNullOrEmpty((string)TabPages[i].Tag))
            {

                if (SelectedIndex == i)
                {
                    //Fill selected
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(90, 93, 100)))
                    {
                        G.FillRectangle(B, new Rectangle(Rect.X, Rect.Y + 2, Rect.Width, Rect.Height));
                    }

                    //Triangles
                    Helpers.DrawTriangle(G, new Rectangle(Rect.X + 158, (int)(Rect.Y + 8.5), 16, 25), Helpers.Direction.Left, Color.FromArgb(62, 65, 72));
                    Helpers.DrawTriangle(G, new Rectangle(Rect.X + 160, (int)(Rect.Y + 8.5), 16, 25), Helpers.Direction.Left, TabPages[i].BackColor);


                }
                else
                {
                    //Fill not selected
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(72, 75, 82)))
                    {
                        G.FillRectangle(B, Rect);
                    }

                }

                //OverFill not selected

                if (!(Index == -1) & !(SelectedIndex == Index))
                {
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(82, 85, 92)))
                    {
                        G.FillRectangle(B, GetTabRect(Index));
                    }

                    //OverText
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(218, 220, 217)))
                    {
                        G.DrawString(TabPages[Index].Text, new Font("Segoe UI", 10), B, new Point(GetTabRect(Index).X + 55, GetTabRect(Index).Y + 12));
                    }

                    //Images
                    if ((ImageList != null))
                    {
                        if (!(TabPages[Index].ImageIndex < 0))
                        {
                            G.DrawImage(ImageList.Images[TabPages[Index].ImageIndex], new Rectangle(GetTabRect(Index).X + 25, GetTabRect(Index).Y + ((GetTabRect(Index).Height / 2) - 9), 18, 18));
                        }
                    }

                }


                if (!(i == Index))
                {
                    //Texts
                    using (SolidBrush B = new SolidBrush(Color.FromArgb(218, 220, 217)))
                    {
                        G.DrawString(TabPages[i].Text, new Font("Segoe UI", 10), B, new Point(Rect.X + 55, Rect.Y + 12));
                    }

                    //Images
                    if ((ImageList != null))
                    {
                        if (!(TabPages[i].ImageIndex < 0))
                        {
                            G.DrawImage(ImageList.Images[TabPages[i].ImageIndex], new Rectangle(Rect.X + 25, Rect.Y + ((Rect.Height / 2) - 9), 18, 18));
                        }
                    }

                }
            }
            else
            {
                //Headers
                using (SolidBrush B = new SolidBrush(Color.FromArgb(158, 160, 157)))
                {
                    G.DrawString(TabPages[i].Text.ToUpper(), new Font("Segoe UI semibold", 9), B, new Point(Rect.X + 25, Rect.Y + 18));
                }

            }

        }

    }

    protected override void OnSelecting(TabControlCancelEventArgs e)
    {
        base.OnSelecting(e);

        if ((e.TabPage != null))
        {
            if (!string.IsNullOrEmpty((string)e.TabPage.Tag))
            {
                e.Cancel = true;
            }
            else
            {
                Index = -1;
            }
        }

    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        for (int i = 0; i <= TabPages.Count - 1; i++)
        {
            if (GetTabRect(i).Contains(e.Location) & !(SelectedIndex == i) & string.IsNullOrEmpty((string)TabPages[i].Tag))
            {
                Index = i;
                break; // TODO: might not be correct. Was : Exit For
            }
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        Index = -1;
    }

    #endregion

}

public class SideWinderProgress : Control
{

    #region " Drawing "

    private int _Val = 0;
    private int _Min = 0;

    private int _Max = 100;
    public int Value
    {
        get { return _Val; }
        set
        {
            _Val = value;
            Invalidate();
        }
    }

    public int Minimum
    {
        get { return _Min; }
        set
        {
            _Min = value;
            Invalidate();
        }
    }

    public int Maximum
    {
        get { return _Max; }
        set
        {
            _Max = value;
            Invalidate();
        }
    }

    public SideWinderProgress()
    {
        DoubleBuffered = true;
    }


    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;
        //G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        base.OnPaint(e);

        G.Clear(Color.White);

        if (!(Value == 0))
        {
            Helpers.FillRoundRect(G, new Rectangle(0, 0, Value / (Maximum * Width) - 1, Height - 1), 8, Color.FromArgb(213, 228, 150));
        }

        Helpers.DrawRoundRect(G, Helpers.FullRectangle(Size, true), 8, Color.FromArgb(232, 235, 242));

    }

    #endregion

}

public class SideWinderAlert : Control
{

    #region " Drawing "

    private Graphics G;

    private Style _Alert;
    public bool Centered { get; set; }
    public bool Field { get; set; }

    public enum Style : byte
    {
        Notice = 0,
        Informations = 1,
        Warning = 2,
        Success = 3
    }

    public Style Alert
    {
        get { return _Alert; }
        set
        {
            _Alert = value;
            Invalidate();
        }
    }

    public SideWinderAlert()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;
        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        base.OnPaint(e);

        G.Clear(Parent.BackColor);

        switch (Alert)
        {

            case Style.Notice:

                if (Field)
                {
                    Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(217, 237, 247));
                    Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(188, 232, 241));

                    Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(188, 232, 241));
                    Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(217, 237, 247));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), new Rectangle(20, 0, Width, Height));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                        }
                    }

                }
                else
                {
                    Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(217, 237, 247));
                    Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(188, 232, 241));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(58, 135, 173), Helpers.FullRectangle(Size, false));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(58, 135, 173)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                        }
                    }
                }

                break;

            case Style.Informations:

                if (Field)
                {
                    Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(252, 248, 227));
                    Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(251, 238, 213));

                    Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(251, 238, 213));
                    Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(252, 248, 227));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), new Rectangle(20, 0, Width, Height));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                        }
                    }

                }
                else
                {
                    Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(252, 248, 227));
                    Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(251, 238, 213));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(192, 152, 83), Helpers.FullRectangle(Size, false));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(192, 152, 83)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                        }
                    }
                }

                break;
            case Style.Warning:

                if (Field)
                {
                    Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(242, 222, 222));
                    Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(238, 211, 215));

                    Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(238, 211, 215));
                    Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(242, 222, 222));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), new Rectangle(20, 0, Width, Height));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                        }
                    }

                }
                else
                {
                    Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(242, 222, 222));
                    Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(238, 211, 215));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(185, 74, 72), Helpers.FullRectangle(Size, false));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(185, 74, 72)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                        }
                    }
                }

                break;
            default:

                if (Field)
                {
                    Helpers.FillRoundRect(G, new Rectangle(20, 0, Width - 20, Height - 1), 4, Color.FromArgb(223, 240, 216));
                    Helpers.DrawRoundRect(G, new Rectangle(20, 0, Width - 21, Height - 1), 4, Color.FromArgb(214, 233, 198));

                    Helpers.DrawTriangle(G, new Rectangle(0, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(214, 233, 198));
                    Helpers.DrawTriangle(G, new Rectangle(2, 7, 20, 20), Helpers.Direction.Left, Color.FromArgb(223, 240, 216));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), new Rectangle(20, 0, Width, Height));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(35, 9));
                        }
                    }

                }
                else
                {
                    Helpers.FillRoundRect(G, Helpers.FullRectangle(Size, true), 4, Color.FromArgb(223, 240, 216));
                    Helpers.DrawRoundRect(G, new Rectangle(0, 0, Width - 1, Height - 1), 4, Color.FromArgb(214, 233, 198));

                    if (Centered)
                    {
                        Helpers.CenterString(G, Text, new Font("Segoe UI", 10), Color.FromArgb(70, 136, 71), Helpers.FullRectangle(Size, false));
                    }
                    else
                    {
                        using (SolidBrush B = new SolidBrush(Color.FromArgb(70, 136, 71)))
                        {
                            G.DrawString(Text, new Font("Segoe UI", 10), B, new Point(12, 9));
                        }
                    }
                }
                break;
        }

    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (!Field)
        {
            Height = 37;
        }
    }

    #endregion

}

public class SideWinderBlock : GroupBox
{

    #region " Drawing "


    private Graphics G;
    public SideWinderBlock()
    {
        DoubleBuffered = true;
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        SetStyle(ControlStyles.UserPaint, true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;
        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        base.OnPaint(e);

        G.Clear(Color.White);

        using (Pen P = new Pen(Color.FromArgb(220, 220, 220)) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
        {

            G.DrawRectangle(P, Helpers.FullRectangle(Size, true));
        }

    }


    #endregion


}

public class SideWinderSeparator : Control
{

    #region " Drawing "


    private Graphics G;
    public SideWinderSeparator()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;
        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        base.OnPaint(e);

        using (Pen P = new Pen(Color.FromArgb(232, 235, 242)) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash })
        {
            G.DrawLine(P, new Point(0, 0), new Point(Width, 0));
        }

    }

    #endregion

}

public class SideWinderBlockQuote : Control
{

    #region " Drawing "


    private Graphics G;
    public string Title { get; set; }

    public string Description { get; set; }

    public SideWinderBlockQuote()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        G = e.Graphics;
        G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

        base.OnPaint(e);

        using (Pen P = new Pen(Color.FromArgb(102, 105, 112), 3))
        {
            G.DrawLine(P, new Point(3, 0), new Point(3, Height));
        }

        if (!string.IsNullOrEmpty(Title))
        {
            using (SolidBrush B = new SolidBrush(Color.FromArgb(112, 115, 122)))
            {
                G.DrawString(Title.ToUpper(), new Font("Segoe UI semibold", 11), B, new Point(13, 0));
            }
        }

        using (SolidBrush B = new SolidBrush(Color.FromArgb(92, 95, 112)))
        {
            G.DrawString(Description, new Font("Segoe UI", 10), B, new Point(13, 23));
        }

    }

    #endregion

}