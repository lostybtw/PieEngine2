using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieEngine_2d_test.PieEngine2dtest
{
    public class Shape
    {
        public Vector2 pos = null;
        public Vector2 scale = null;
        public string tag = "";


        public Shape(Vector2 pos , Vector2 scale, string tag) 
        {
            this.pos = pos;
            this.scale = scale;
            this.tag = tag;

            Log.INFO($"[Shape] ({tag})  has been registered");
            PieEngine2d.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Log.INFO($"[Shape] ({tag})  has been destroyed");
            PieEngine2d.UnRegisterShape(this);
        }
    }
}
