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

        public PieEngine2d(Vector2 screensize , string title)
        {
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
                    Console.WriteLine("Game is Loading...");
                }

            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Aqua);
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
    }
}
