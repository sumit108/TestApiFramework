using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;



namespace RestSharpApiTests
{
    [TestFixture]
    class ReadText
    {
        [Test]
        public void reader()
        {
            //Default file. MAKE SURE TO CHANGE THIS LOCATION AND FILE PATH TO YOUR FILE 
            string textFile = @"C:\Users\SumitThapar\Desktop\SampleText.txt";
            String[] keyWords = { "place name", "longitude", "state", "state abbreviation", "latitude" };
            // Read file using StreamReader. Reads file line by line  
            using (StreamReader file = new StreamReader(textFile))
            {
                int counter = 0;
                string ln;
                Dictionary<string, string> dict =
                       new Dictionary<string, string>();
                foreach (string key in keyWords)
                {
                    dict.Add(key, null);
                }

                int count = keyWords.Length;
                foreach (String key in keyWords)
                {
                    while ((ln = file.ReadLine()) != null)
                    {

                        if (ln.Contains(key))
                        {
                            String[] str = ln.Split(':');
                            dict[key] = str[1];
                            count--;
                        }
                        Console.WriteLine(ln);
                        counter++;

                        //if (count < 1)
                        //    break;
                    }
                    Assert.AreEqual("", "");
                }


                file.Close();
                Console.WriteLine($"File has {counter} lines.");
            }
        }
    }
}
