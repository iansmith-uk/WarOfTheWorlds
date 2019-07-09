using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarOfTheWorlds
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "C:/temp/warOfTheWorlds.txt";
            var results = new Dictionary<string, int>();

            string[] lines = File.ReadAllLines(inputPath);

            //run through each line, remove any special characters then increment word counter
            foreach(string line in lines)
            {
                //no empty lines
                if (line.Length > 0)
                {
                    
                    //remove all instances of full stops or commas or semicolons
                    //I feel like these could have been done with Regex, but I don't know enough about it to use confidently
                    var _line = line.Replace(". ", " ");
                    _line = _line.Replace("\"", "");
                    _line = _line.Replace(", ", " ");
                    _line = _line.Replace("_", " ");//noticed this in a test
                    _line = _line.Replace("; ", " ");
                    _line = _line.Replace(" (", " ");
                    _line = _line.Replace(") ", " ");
                    _line = _line.Replace(" [", " ");
                    _line = _line.Replace("] ", " ");
                    _line = _line.Replace("?", "");
                    _line = _line.Replace("-", " ");

                    //take out the 's so they can be included in the original word
                    _line = _line.Replace("'s", "");

                    //had to add this as for some reason if these were at the end of the line, they didn't get removed
                    _line = _line.Trim();
                    _line = _line.TrimEnd('.');
                    _line = _line.TrimEnd(',');
                    _line = _line.TrimEnd(';');
                    _line = _line.TrimEnd(')');
                    _line = _line.TrimEnd(']');


                    //split into words
                    string[] words = _line.Split(' ');

                    foreach(string word in words)
                    {
                        //skip this one if it's a 1 letter word which isnt i or a (H G)
                        if(word.Length == 1 && !(word.ToLower().Contains("i") || word.ToLower().Contains("a")))
                        {
                            continue;
                        }


                        if (word.Length > 0 && !int.TryParse(word, out var i)) //extra credit
                        {
                            //Console.WriteLine(word); //testing to see what the output is
                            if (results.ContainsKey(word.ToLower()))
                            {
                                //add one to the tally
                                results[word.ToLower()] = ++results[word.ToLower()];
                            }
                            else
                            {
                                //add  new record
                                results.Add(word.ToLower(), 1);
                            }
                        }
                    }
                }
            }

            File.AppendAllLines("C:/temp/output.txt", results.Select(result => $"{result.Key}: {result.Value}"));
        }
    }
}
