using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROBOTIN
{
    public class GameData
    {
        private const string LevelScoresKey = "LevelScores";
        private const string NextLevelKey = "NextLevel";
        private Dictionary<int, int> levelScores;
        private int nextLevel;

        public GameData()
        {
            levelScores = new Dictionary<int, int>();
            Load();
        }

        private void Save()
        {
            // Serialize levelScores dictionary into a JSON string
            string serializedScores = JsonUtility.ToJson(new SerializableDictionary<int, int>(levelScores));
            PlayerPrefs.SetString(LevelScoresKey, serializedScores);

            // Save nextLevel
            PlayerPrefs.SetInt(NextLevelKey, nextLevel);

            PlayerPrefs.Save();
        }

        public void Reset()
        {
            levelScores.Clear();
            nextLevel = 1;
            Save();
        }

        public void Load()
        {
            // Deserialize the LevelScores dictionary
            string serializedScores = PlayerPrefs.GetString(LevelScoresKey, "{}"); // Default to empty JSON object
            levelScores = JsonUtility.FromJson<SerializableDictionary<int, int>>(serializedScores).ToDictionary();

            // Load nextLevel with default of 1
            nextLevel = PlayerPrefs.GetInt(NextLevelKey, 1);
        }

        public int GetNextLevel()
        {
            return nextLevel;
        }

        public void SetNextLevel(int currentLevel)
        {
            if (currentLevel > nextLevel)
            {
                nextLevel = currentLevel;
            }
            Save();
        }

        public int GetHighScoreFromLevel(int level)
        {
            return levelScores.ContainsKey(level) ? levelScores[level] : 0;
        }

        public void UpdateLevelScore(int level, int newScore)
        {
            if (!levelScores.ContainsKey(level) || newScore > levelScores[level])
            {
                levelScores[level] = newScore;
                Save();
            }
        }

        public int GetTotalScore()
        {
            int total = 0;
            foreach (var score in levelScores.Values)
            {
                total += score;
            }
            return total;
        }


        // Helper class for serialization
        [System.Serializable]
        private class SerializableDictionary<TKey, TValue>
        {
            public List<TKey> keys = new List<TKey>();
            public List<TValue> values = new List<TValue>();

            public SerializableDictionary() { }

            public SerializableDictionary(Dictionary<TKey, TValue> dict)
            {
                foreach (var kvp in dict)
                {
                    keys.Add(kvp.Key);
                    values.Add(kvp.Value);
                }
            }

            public Dictionary<TKey, TValue> ToDictionary()
            {
                var dict = new Dictionary<TKey, TValue>();
                for (int i = 0; i < keys.Count; i++)
                {
                    dict[keys[i]] = values[i];
                }
                return dict;
            }
        }


    }
}