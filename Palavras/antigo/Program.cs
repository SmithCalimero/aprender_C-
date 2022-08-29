/*
using Palavras.Data;
using Palavras.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palavras
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";

        //app
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;
            do
            {
                //decisão
                Console.WriteLine("Please enter the option - F for File or M for Manual");
                var option = Console.ReadLine() ?? String.Empty;

                switch (option.ToUpper())
                {
                    case "F":
                        Console.WriteLine("Enter scrambled words file name: ");
                        ExecuteScrambledWordsInFileScenario();
                        break;
                    case "M":
                        Console.WriteLine("Enter scrambled words manually: ");
                        ExecuteScrambledWordsManualEntryScenario();
                        break;
                    default:
                        Console.WriteLine("Option was not recognized");
                        break;
                }

                //depois perguntar ao user se quer continuar

                var continueDecision = string.Empty;

                do
                {

                    Console.WriteLine("Do you want to continue?");
                    continueDecision = (Console.ReadLine() ?? String.Empty);

                } while (
                !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) && 
                !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase)
                );

                continueWordUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueWordUnscramble);
        }

        //entradas manuais são separadas por vírgulas
        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        //ficheiro
        private static void ExecuteScrambledWordsInFileScenario()
        {
            var filename = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(filename);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        //mostrar matches
        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            } else
            {
                //se não houver matches
                Console.WriteLine("No matches have been found.");
            }
            
        }
    }
}
*/