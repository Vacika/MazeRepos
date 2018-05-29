using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGame
{
    [Serializable]
    
    public class Game : ISerializable
    {
        public Stopwatch stopwatch { get; set; }
        public StringBuilder events { get; set; }
        public int hits { get; set; }
        public Snake snake { get; set; }
        public TimeSpan ts { get; set; } = new TimeSpan(); 
        public Game()
        {
            stopwatch = new Stopwatch();
            hits = 0;
            snake = new Snake();
            ts = new TimeSpan(0,0,0);
            events = new StringBuilder();
        }
        public TimeSpan getTimespan()
        {
            return ts + stopwatch.Elapsed;
        }
        public Game(SerializationInfo info, StreamingContext context)
        {
            hits = (int)info.GetValue("hits", typeof(int));
            snake = (Snake)info.GetValue("snake", typeof(Snake));
            ts = (TimeSpan)info.GetValue("ts",typeof(TimeSpan));
            events = (StringBuilder)info.GetValue("events", typeof(StringBuilder));
            stopwatch = new Stopwatch();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ts += stopwatch.Elapsed;
            info.AddValue("ts", ts);
            info.AddValue("hits", hits);
            info.AddValue("snake", snake);
            info.AddValue("events", events);
        }
    }
}
