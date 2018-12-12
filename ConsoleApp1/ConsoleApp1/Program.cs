using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Queen_s_Speech
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] Government = new string[3];
            Government[0] = "Labour";
            Government[1] = "Conservative";
            Government[2] = "Coalition";

            string[] files = new string[5];
            files[0] = (@"C:\Users\user\Documents\AI\Coalition9thMay2012.txt");
            files[1] = (@"C:\Users\user\Documents\AI\Conservative16thNov1994.txt");
            files[2] = (@"C:\Users\user\Documents\AI\Conservative27thMay2015.txt");
            files[3] = (@"C:\Users\user\Documents\AI\Labour6thNov2007.txt");
            files[4] = (@"C:\Users\user\Documents\AI\Labour26thNov2003.txt");

            double labPrior = 0D;
            double conPrior = 0D;
            double coaPrior = 0D;

            Dictionary<string, int> labDict = new Dictionary<string, int>();
            Dictionary<string, int> coaDict = new Dictionary<string, int>();
            Dictionary<string, int> conDict = new Dictionary<string, int>();



            foreach (string gov in Government)

            {
                double i = 0D;
                foreach (string file in files)
                {
                    if (file.Contains(gov))
                    {
                        i++;
                    }
                }

                if (gov == "Labour")
                {
                    labPrior = i / 5;
                    Console.WriteLine("labPrior " + labPrior);

                }


                if (gov == "Conservative")
                {
                    conPrior = i / 5;
                    Console.WriteLine("conPrior " + conPrior);

                }



                if (gov == "Coalition")
                {
                    coaPrior = i / 5;
                    Console.WriteLine("coaPrior " + coaPrior);

                }

            }
            Console.ReadLine();

            foreach ( string gov in Government)
            {
                Dictionary<string, int> dictionary = new Dictionary<string, int>();

                foreach (string file in files)
                    if (file.Contains(gov))
                    {
                        string text = System.IO.File.ReadAllText(file); //Read file 
                        text = text.ToLower(); //Convert our input to lowercase 

                        List<string> wordList = text.Split(' ').ToList();


                        foreach (var word in wordList)
                        {
                            if (dictionary.ContainsKey(word))
                            {
                                dictionary[word]++;
                            }
                            else
                            {
                                dictionary.Add(word, 1);
                            }
                        }



                        //var sortedDict = (from entry in dictionary orderby entry.Value descending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);
                        //int count = 1;
                        //Console.WriteLine("- " + filename + " ----");
                        Console.WriteLine();
                        foreach (KeyValuePair<string, int> pair in dictionary)
                        {
                            Console.WriteLine(pair.Key + ' ' + pair.Value);
                            //Console.ReadLine();

                        }


                    }

                if (gov == "Labour")
                {
                    labDict = dictionary;

                }

                if (gov == "Conservative")
                {
                    conDict = dictionary;

                }

                if (gov == "Coalition")
                {
                    coaDict = dictionary;

                }




            }


        











        }
    }
}














