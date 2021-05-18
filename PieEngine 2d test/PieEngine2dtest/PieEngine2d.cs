using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace PieEngine_2d_test.PieEngine2dtest
{

    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class PieEngine2d
    {
        private Vector2 screensize = new Vector2(512, 512);
        private string title = "New Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;


        private static List<Shape> Allshapes = new List<Shape>();
        public Color Bg = Color.White;
        public int delay = 1;


        public PieEngine2d(Vector2 screensize , string title)
        {
            Log.INFO("Game is starting"); 
            this.screensize = screensize;
            this.title = title;

            Window = new Canvas();
            Window.Size = new Size((int)this.screensize.x , (int)this.screensize.y);
            Window.Text = this.title;
            Window.Paint += Renderer;

           
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        public static void RegisterShape(Shape shape)
        {
            Allshapes.Add(shape);
        }

        public static void UnRegisterShape(Shape shape)
        {
            Allshapes.Remove(shape);
        }

        void GameLoop()
        {
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }

                catch
                {
                    Log.Error("Window not found , waiting " + ""); 

                }

            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Bg);

            foreach(Shape shape in Allshapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red) , shape.pos.x,shape.pos.y,shape.scale.x,shape.scale.y);
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();

    }
}
