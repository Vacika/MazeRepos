using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    [Serializable]
    public class Snake : ISerializable
    {
        public int hp { get; set; }
        public Point position { get; set; }
        public bool alive { get; set; }

        public Snake()
        {
            alive = true;
            hp = 100;
            position = new Point(10, 10);
        }
        public bool decreaseHP()
        {
            if (hp > 20)
            {
                hp -= 20;
            }
            else
            {
                alive = false;
            }
            return alive;
        }
        public bool addHP()
        {
            if (hp + 5 <= 100 && alive) // ako e ziva zmijata i ako hp<=95
            {
                hp += 5;
                return true;
            }
            return false;

        }

        public Snake(SerializationInfo info, StreamingContext context)
        {
            hp = (int)info.GetValue("hp", typeof(int));
            position = (Point)info.GetValue("position", typeof(Point));
            alive = (bool)info.GetValue("alive", typeof(bool));



        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("hp", hp);
            info.AddValue("position", position);
            info.AddValue("alive", alive);
        }
    }
}
