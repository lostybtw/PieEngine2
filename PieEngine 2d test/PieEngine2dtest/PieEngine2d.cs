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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(379, 261);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }
    }
    public abstract class PieEngine2d
    {
        private Vector2 screensize = new Vector2(512, 512);
        private string title = "New Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;


        private static List<Shape> Allshapes = new List<Shape>();
        private static List<Sprite> Allsprites = new List<Sprite>();
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

        public static void RegisterSprite(Sprite sprite)
        {
            Allsprites.Add(sprite);
        }

        public static void UnRegisterSprite(Sprite sprite)
        {
            Allsprites.Remove(sprite);
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
                    Log.Error("Game not found"); 

                    Thread.Sleep(1);
                    
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }

                catch
                {
                    Environment.Exit(0);

                }



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

            foreach(Sprite sprite in Allsprites)
            {
                g.DrawImage(sprite.sprite, sprite.pos.x, sprite.pos.y, sprite.scale.x, sprite.scale.y);
            }
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();

    }
}
