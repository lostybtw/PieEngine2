using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PieEngine_2d_test;

namespace PieEngine_2d_test.PieEngine2dtest
{
    class testGame : PieEngine2d
    {
        public testGame() : base(new Vector2(615,515), "Pie1")
        {

        }

        public override void OnDraw()
        {
           
        }

        public override void OnLoad()
        {
            Console.WriteLine("Bitch , It works");
        }
        int frame = 0;
        public override void OnUpdate()
        {
            if (frame % 10 == 0) { Console.WriteLine($"FrameCount: {frame}"); }
            frame++;
        }
    }
}
