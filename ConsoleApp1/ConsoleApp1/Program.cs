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
            //CP loop ( foreach pair in condict  )
            //unique words = dictionary.count
            //total number of words = *myDict.Sum(x => x.Value); *
            // word frequency = word.value

            //word frequency +1 / total number of words + unique words(conditional probability is this)

            //concp.add(word, condi)
            Dictionary<string, double> conCP = new Dictionary<string, double>();
            Dictionary<string, double> coaCP = new Dictionary<string, double>();
            Dictionary<string, double> labCP = new Dictionary<string, double>();


            foreach ( var pair in conDict )
            {
                int uniqueWords = conDict.Count();
                int totalNumberOfWords = conDict.Sum(x => x.Value);
                int wordFrequency = pair.Value;

                double cp =(wordFrequency + 1) / (totalNumberOfWords + uniqueWords);
                conCP.Add(pair.Key, cp);

            }

            foreach (var pair in coaDict)
            {
                int uniqueWords = coaDict.Count();
                int totalNumberOfWords = coaDict.Sum(x => x.Value);
                int wordFrequency = pair.Value;

                double cp = (wordFrequency + 1) / (totalNumberOfWords + uniqueWords);
                conCP.Add(pair.Key, cp);

            }

            foreach (var pair in labDict)
            {
                int uniqueWords = labDict.Count();
                int totalNumberOfWords = labDict.Sum(x => x.Value);
                int wordFrequency = pair.Value;

                double cp = (wordFrequency + 1) / (totalNumberOfWords + uniqueWords);
                conCP.Add(pair.Key, cp);

            }
            //dictionary with test file words
            
            

            Console.WriteLine("Enter path to test file.");

            string input = Console.ReadLine();

            Dictionary<string, int> testdictionary = new Dictionary<string, int>();

            string testtext = System.IO.File.ReadAllText(input); //Read file 
            testtext = testtext.ToLower(); //Convert our input to lowercase 

            List<string> wordList = testtext.Split(' ').ToList();


            foreach (var word in wordList)
            {
                if (testdictionary.ContainsKey(word))
                {
                    testdictionary[word]++;
                }
                else
                {
                    testdictionary.Add(word, 1);
                }
            }





        double coaLog = 0F;
        double conLog = 0F;
        double labLog = 0F;
            foreach (var word in testdictionary) ;

            if (coaDict.ContainsKey(Word.Value))
            {
                coaLog += Math.Log(Math.Pow(coaDict(word), 
            }

        





                    }
                }
}














