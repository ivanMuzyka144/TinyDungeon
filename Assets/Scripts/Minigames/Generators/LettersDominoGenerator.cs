using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class LettersDominoGenerator : DominoGenerator
{
    [TextArea]
    [SerializeField] private string word4;
    [TextArea]
    [SerializeField] private string word5;
    [TextArea]
    [SerializeField] private string word6;
    public override TopologyConfiguration GenerateDominos(TopologyData topologyData, DifficultyType difficultyType)
    {
        TopologyConfiguration topologyConfiguration = new TopologyConfiguration();

        char[] letters = GetLetters(topologyData.smallPlacesCount);
        List<char> shuffledLetters = letters.OrderBy(x => Random.value).ToList();
        string allLetters = "abcdefghijklmnopqrstuvwxyz";
        List<char> otherLetters = allLetters.ToCharArray().Except(shuffledLetters).ToList();

        foreach (char letter in letters)
        {
            Domino smallPlaceDomino = new Domino();
            smallPlaceDomino.SetDominoValue(letter+"", DominoPlace.Whole);
            topologyConfiguration.AddSmallPlacesDomino(smallPlaceDomino);
        }
        foreach (char letter in shuffledLetters)
        {
            Domino answerDomino = new Domino();
            DominoPlace dominoPlace = Random.value > 0.5f ? DominoPlace.Top : DominoPlace.Bottom;
            DominoPlace anotherPlace = DominoValueHolder.ReversePlaceValue(dominoPlace);

            answerDomino.SetDominoValue(letter + "", dominoPlace);

            if (Random.value > 0.5f)
            {
                answerDomino.SetDominoValue(Random.Range(0, 7), anotherPlace);
            }
            else
            {
                char randomLetter = otherLetters[Random.Range(0, otherLetters.Count)];

                answerDomino.SetDominoValue(randomLetter + "", anotherPlace);
            }

            topologyConfiguration.AddAnswerDomino(answerDomino);
        }


        return topologyConfiguration;
    }

    public char[] GetLetters(int howManyLetters)
    {
        string bigWords = "";
        switch (howManyLetters)
        {
            case 4:
                bigWords = word4;
                break;
            case 5:
                bigWords = word5;
                break;
            case 6:
                bigWords = word6;
                break;
        }
        string[] words = bigWords.Split('\n');

        string randomWord = words[Random.Range(0, words.Length)];
        randomWord = randomWord.Replace("\r","");

        char[] letters = randomWord.ToCharArray();

        return letters;
    }
}
