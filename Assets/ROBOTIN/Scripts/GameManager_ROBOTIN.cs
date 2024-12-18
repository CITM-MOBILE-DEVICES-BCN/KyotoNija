using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavigationSystem;

namespace ROBOTIN
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        Navigation navigation;

        public List<GameObject> screenList;

        public List<GameObject> popUpList;

        public List<GameObject> activeScreens;

        public List<GameObject> activePopUps;

        private GameObject currentPopUp;

        public ScoreManager scoreManager;

        public GameData gameData;

        public PlayerData playerData;

        public int maxLevelsPerLoop = 3;

        public Sprite baseSkinPlayer;


        //TODO: implement a list of level managers (levels) and instantiate one depending on the data (current level)
        [SerializeField]
        private List<LevelManager> allLevels;

        public LevelManager currentLevel;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
                navigation = new Navigation();
                scoreManager = new ScoreManager();
                gameData = new GameData();
                playerData = new PlayerData();
                //gameData.Reset();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(string scene)
        {
            navigation.LoadScene(scene);

            if (activeScreens != null)
            {
                activeScreens.Clear();
            }

            if (activePopUps != null)
            {
                activePopUps.Clear();
            }
        }

        public void LoadScreen(string screenName)
        {
            var screen = screenList.Find(x => x.name == screenName);
            if (screen != null)
            {
                activeScreens.Add(navigation.LoadScreen(screen));
            }
        }
        public void UnLoadScreen(string screenName)
        {
            var screen = activeScreens.Find(x => x.name.Equals(screenName));

            if (screen != null)
            {
                navigation.UnLoadScreen(screen);

                activeScreens.Remove(screen);
            }
        }

        public void LoadPopUp(string popUpName)
        {
            var popUp = popUpList.Find(x => x.name == popUpName);

            if (currentPopUp == null && popUp != null)
            {
                currentPopUp = navigation.LoadPopUp(popUp);
                Debug.Log(popUpName);
                activePopUps.Add(currentPopUp);
            }
        }

        public void UnLoadPopUp(string popUpName)
        {
            var popUp = activePopUps.Find(x => x.name.Equals(popUpName));

            if (popUp != null)
            {
                navigation.UnLoadPopUp(popUp);
                currentPopUp = null;
                activePopUps.Remove(popUp);
            }
        }

        public void LoadSceneAndLevel(string sceneName, int index)
        {
            StartCoroutine(LoadSceneAndLevelCoroutine(sceneName, index));
        }

        private IEnumerator LoadSceneAndLevelCoroutine(string sceneName, int index)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

            yield return new WaitUntil(() => UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == sceneName);

            LoadLevel(index);
        }

        //TODO: Implement with save and load to load the level that is required based on the level data (current level), for the moment it will just load the first level
        public void LoadLevel(int index)
        {
            int levelIndex = index % maxLevelsPerLoop;
            if (levelIndex == 0)
            {
                levelIndex = maxLevelsPerLoop;
            }
            var level = Instantiate(allLevels[(levelIndex) - 1]);
            playerData.currentLevel = index;
            playerData.SetPlayerSkin(baseSkinPlayer);
            level.Init(index, playerData.playerSkin);
            currentLevel = level;

        }

        public void OnLevelFinished()
        {
            int finalscore = scoreManager.CalculateLevelScore(currentLevel.timerManager.GetCurrentTime(), currentLevel.timeToCompleteLevel);
            gameData.UpdateLevelScore(currentLevel.levelOnWorld - 1, finalscore);
            gameData.SetNextLevel(currentLevel.levelOnWorld + 1);
            Debug.Log(gameData.GetNextLevel());
        }
    }
}
