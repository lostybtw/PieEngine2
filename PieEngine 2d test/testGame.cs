using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieEngine_2d_test;
using System.Drawing;
using System.Threading;

namespace PieEngine_2d_test.PieEngine2dtest
{
    class testGame : PieEngine2d
    { 
        Sprite player;
        public testGame() : base(new Vector2(615,515), "Pie1")
        {

        }

        public override void OnLoad()
        {
            Bg = Color.BlueViolet;

            //player = new Shape(new Vector2(10, 10), new Vector2(10, 10),"test");
            player = new Sprite(new Vector2(10, 10), new Vector2(200,200), "player", "freeknight/png/Idle (1).png");
        }

        public override void OnDraw()
        {
            
        }

        private static int lastTick;
        public static int lastFrameRate;
        private static int frameRate;
        public override void OnUpdate()
        {
                if (System.Environment.TickCount - lastTick >= 1000)
                {
                    lastFrameRate = frameRate;
                    frameRate = 0;
                    lastTick = System.Environment.TickCount;
                }

            frameRate++;
            Console.WriteLine(frameRate);
        }
    }
}
