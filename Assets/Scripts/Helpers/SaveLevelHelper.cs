using Enums;
using Models;
using UnityEngine;

namespace Helpers
{
    public class SaveHelper
    {
        private const string LevelKey = "level_";
        private const string ScoreKey = "score";

        public static void SaveLevel(Level levelToSave)
        {
            PlayerPrefs.SetInt(LevelKey + levelToSave.Number, (int) levelToSave.State);
        }

        public static Level LoadLevel(ushort number)
        {
            if (PlayerPrefs.HasKey(LevelKey + number))
            {
                return new Level(number, (LevelState) PlayerPrefs.GetInt(LevelKey + number));
            }

            return number == 1 ? new Level(number, LevelState.Opened) : new Level(number, LevelState.Сlosed);
        }

        public static void SaveScore(int score)
        {
            PlayerPrefs.SetInt(ScoreKey, score);
        }

        public static int LoadScore()
        {
            return PlayerPrefs.HasKey(ScoreKey) ? PlayerPrefs.GetInt(ScoreKey) : 0;
        }
    }
}