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
        Shape player;
        public testGame() : base(new Vector2(615,515), "Pie1")
        {

        }

        public override void OnLoad()
        {
            Bg = Color.BlueViolet;

            player = new Shape(new Vector2(10, 10), new Vector2(10, 10),"test");
        }

        public override void OnDraw()
        {
            
        }


        int frame = 0;
        int time = 0;
        float x = 1;
        float y = 1;
        public override void OnUpdate()
        {
           
            if (frame % delay == 0) { frame++; }
            
            if(player != null)
            {
                 player.pos.x += x;
                 player.pos.y += y;

                 player.scale.x += x;
                 player.scale.y += y;
            }


            if(time > 400)
            {
                if(player != null)
                {
                        player.DestroySelf();
                        player = null;
                }

            }

            time++;
        }
    }
}
