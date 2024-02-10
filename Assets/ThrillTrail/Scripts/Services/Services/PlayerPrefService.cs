using UnityEngine;

namespace ThrillTrail.Services
{
    public class PlayerPrefService : IGameService
    {
        #region Get/Set Methods
        public void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }
        
        public bool GetFloat(string key, out float value)
        {
            if(PlayerPrefs.HasKey(key))
            {
                value = PlayerPrefs.GetFloat(key);
                return true;
            }
            value = 0;
            return false;
        }
        
        public void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }
        
        public bool GetInt(string key, out int value)
        {
            if(PlayerPrefs.HasKey(key))
            {
                value = PlayerPrefs.GetInt(key);
                return true;
            }
            value = 0;
            return false;
        }
        
        public void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }
        
        public bool GetString(string key, out string value)
        {
            if(PlayerPrefs.HasKey(key))
            {
                value = PlayerPrefs.GetString(key);
                return true;
            }
            value = "";
            return false;
        }
        
        public void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            PlayerPrefs.Save();
        }
        
        public bool GetBool(string key, out bool value)
        {
            if(PlayerPrefs.HasKey(key))
            {
                value = PlayerPrefs.GetInt(key) == 1;
                return true;
            }
            value = false;
            return false;
        }

        #endregion

        //Store the high score in the player prefs
        public void SetHighScore(int score)
        {
            if (score > GetHighScore())
            {
                SetInt("HighScore", score);
            }
        }
        
        public int GetHighScore()
        {
            return GetInt("HighScore", out int highScore) ? highScore : 0;
        }
        
    }
}