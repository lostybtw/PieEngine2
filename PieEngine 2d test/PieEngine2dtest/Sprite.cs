using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PieEngine_2d_test.PieEngine2dtest
{
    public class Sprite
    {
        public Vector2 pos = null;
        public Vector2 scale = null;
        public string directory = "";
        public string tag = "";


        public Sprite(Vector2 pos, Vector2 scale, string tag, string directory)
        {
            this.pos = pos;
            this.scale = scale;
            this.directory = directory;
            this.tag = tag;

          

            Log.INFO($"[Shape] ({tag})  has been registered");
            PieEngine2d.RegisterSprite(this);
        }

        public void DestroySelf()
        {
            Log.INFO($"[Shape] ({tag})  has been destroyed");
            PieEngine2d.UnRegisterSprite(this);
        }
    }
}
