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
        

        //app
        static void Main(string[] args)
        {
            try
            {

                bool continueWordUnscramble = true;
                do
                {
                    //decisão
                    Console.WriteLine(Constants.OptionsOnHowToEntenderScrambledWords);
                    var option = Console.ReadLine() ?? String.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.WriteLine(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.WriteLine(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.EnterScrambledOptionNotRecognized);
                            break;
                    }

                    //depois perguntar ao user se quer continuar

                    var continueDecision = string.Empty;

                    do
                    {

                        Console.WriteLine(Constants.OptionsOnHowToContinueTheProgram);
                        continueDecision = (Console.ReadLine() ?? String.Empty);

                    } while (
                    !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase)
                    );

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble);

            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
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
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + ex.Message);
            }
        }

        //mostrar matches
        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            } else
            {
                //se não houver matches
                Console.WriteLine(Constants.MatchNotFound);
            }
            
        }
    }
}