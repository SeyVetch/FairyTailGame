using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaryTailGame
{
    public class Instructions
    {
        public string img { get; set; }
        public string text { get; set; }
        public bool ending { get; set; }
        Instructions[] next = new Instructions[2];
        public Instructions(string i, string t, bool e)
        {
            img = imageurl(i);
            text = t;
            ending = e;
        }
        static public string imageurl(string img)
        {
            return "/images/" + img;
        }
        public string Image()
        {
            return img;
        }
        public string Text()
        {
            return text;
        }
        public bool Ending()
        {
            return ending;
        }
    }
}
