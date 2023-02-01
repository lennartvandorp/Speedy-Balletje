using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Database
{
    [RequireComponent(typeof(DbHighScore))]
    public class DataBaseManager : MonoBehaviour
    {
        [HideInInspector] public static string databaseName = "My_Database";

        private static DataBaseManager instance;
        public static DataBaseManager Instance
        {
            get
            {
                return instance;
            }
        }

        public DbHighScore highScore;
        string levelName;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            highScore = GetComponent<DbHighScore>();
            levelName = SceneManager.GetActiveScene().name;
            
        }

        void AddTimeToDatabase(float timeToAdd)
        {
            StartCoroutine(AddCurrentTimeToDatabase(timeToAdd));
        }

        public IEnumerator AddCurrentTimeToDatabase(float timeToAdd)
        {
            highScore.InsertIntoDatabase(SceneManager.GetActiveScene().name, timeToAdd);
            return null;
        }

    }
}