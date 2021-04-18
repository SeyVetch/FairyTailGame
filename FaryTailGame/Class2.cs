using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaryTailGame
{
    static public class Instruct
    {
        static public List<Instructions> Open()
        {
            string txt = "";
            try
            {
                StreamReader sr = new StreamReader("C:\\Users\\1234\\source\\repos\\FaryTailGame\\FaryTailGame\\instructions.txt");
                string line = "";
                while (line != null)
                {
                    line = sr.ReadLine();
                    txt += line;
                }
                sr.Close();

                string[] lines = txt.Split('/');
                List<Instructions> inst = new List<Instructions>();

                foreach (string l in lines)
                {
                    string[] temp = l.Split('|');
                    if (temp[temp.Length - 1] != "end")
                    {
                        inst.Add(new Instructions(temp[0], temp[1]+"|"+temp[2]+"|"+temp[3], false));
                    }
                    else
                    {
                        inst.Add(new Instructions(temp[0], temp[1], true));
                    }
                }

                return inst;
            }
            catch (Exception e) { return null; }
        }
    }
}
