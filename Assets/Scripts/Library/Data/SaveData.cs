using System.Collections;
using Library.Events;
using Sirenix.Utilities;
using UnityEngine;

namespace Library.Data
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData Instance;
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There can only be one instance of SaveData!");
                Application.Quit();
            }

            Instance = this;
            LoadHighScore();
        }

        private const string PrivateCode = "5W6CphQFz0yVqxJ-kIuKAwYwKSQ5jJHkuQt0oQP93JAg";
        private const string PublicCode = "5e485cf0fe232612b8331df7";
        private const string WebUrl = "http://dreamlo.com/lb/";
        public Highscore[] highscoreList;

        public void SaveHighScore(string username)
        {
            if (username.IsNullOrWhitespace() || username.Length < 1) username = "NoName";
            var score = (int)LevelEnd.Instance.score;
            var level = SpawnNextPatternManager.Instance.levelNumber;
            StartCoroutine(UploadNewHighscore(username, score, level));
        }
        
        public void LoadHighScore()
        {
            StartCoroutine(DownloadHighscoreFromDatabase());
        }

        IEnumerator UploadNewHighscore(string username, int score, int level)
        {
            var www = new WWW(WebUrl + PrivateCode + "/add/" + WWW.EscapeURL(username) + "/" + score + "/" + level);
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                print("Upload Successful");
            }
            else
            {
                print("Error: " + www.error);
            }
        }
        
        IEnumerator DownloadHighscoreFromDatabase()
        {
            var www = new WWW(WebUrl + PublicCode + "/pipe/");
            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                FormatHighScores(www.text);
            }
            else
            {
                print("Error: " + www.error);
            }

        }

        private void FormatHighScores(string textStream)
        {
            string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
            highscoreList = new Highscore[entries.Length];

            for (int i = 0; i < entries.Length; i++)
            {
                string[] entryInfo = entries[i].Split(new char[] {'|'});
                string username = entryInfo[0];
                int score = int.Parse(entryInfo[1]);
                int level = int.Parse(entryInfo[2]);
                highscoreList[i] = new Highscore(username,score,level);
            }
        }
        
        public struct Highscore
        {
            public string username;
            public int score;
            public int level;

            public Highscore(string _username, int _score, int _level)
            {
                username = _username;
                score = _score;
                level = _level;
            }
        }
    }
}