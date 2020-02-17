using System.Collections;
using Library.Events;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Networking;

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
        public HighScore[] highScoreList;

        public void SaveHighScore(string username)
        {
            if (username.IsNullOrWhitespace() || username.Length < 1) username = "NoName";
            var score = (int)LevelEnd.Instance.score;
            var level = SpawnNextPatternManager.Instance.levelNumber;
            StartCoroutine(UploadNewHighScore(username, score, level));
        }
        
        public void LoadHighScore()
        {
            StartCoroutine(DownloadHighScoreFromDatabase());
        }

        private static IEnumerator UploadNewHighScore(string username, int score, int level)
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

        private IEnumerator DownloadHighScoreFromDatabase()
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
            var entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
            highScoreList = new HighScore[entries.Length];

            for (var i = 0; i < entries.Length; i++)
            {
                var entryInfo = entries[i].Split(new char[] {'|'});
                var username = entryInfo[0];
                var score = int.Parse(entryInfo[1]);
                var level = int.Parse(entryInfo[2]);
                highScoreList[i] = new HighScore(username,score,level);
            }
        }
        
        public struct HighScore
        {
            public readonly string username;
            public readonly int score;
            public readonly int level;

            public HighScore(string username, int score, int level)
            {
                this.username = username;
                this.score = score;
                this.level = level;
            }
        }
    }
}