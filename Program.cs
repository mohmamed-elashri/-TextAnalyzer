using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TextAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("Enter the text you want to analyze:");
                string inputText = Console.ReadLine().ToLower();

                int charCount = inputText.Length;
                int wordCount = inputText.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

                var wordFrequency = new Dictionary<string, int>();
                string[] words = inputText.Split(new char[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (wordFrequency.ContainsKey(word))
                        wordFrequency[word]++;
                    else
                        wordFrequency[word] = 1;
                }

                var sortedWords = wordFrequency.OrderByDescending(x => x.Value).Take(5);

             
                Console.WriteLine($"\n🔹 Character count: {charCount}");
                Console.WriteLine($"🔹 Word count: {wordCount}");
                Console.WriteLine("\n📊 Most frequent words:");

                string report = $"🔹 Character count: {charCount}\n🔹 Word count: {wordCount}\n\n📊 Most frequent words:\n";
                foreach (var item in sortedWords)
                {
                    string line = $"  - {item.Key}: {item.Value} times";
                    Console.WriteLine(line);
                    report += line + "\n";
                }

           
            File.WriteAllText("Report.txt", report);
                Console.WriteLine("\n✅ The report has been saved to Report.txt");
            }
        }
    }
    
