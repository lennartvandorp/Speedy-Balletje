using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

namespace Database
{
    public class DbHighScore : MonoBehaviour
    {
        public static string tableName = "level_times";
        string connection;
        public static string levelFieldName = "level_name";
        public static string timeFieldName = "time";
        IDbConnection dbCon;

        // Start is called before the first frame update
        void Start()
        {
            //create database
            connection = "URI=file:" + Application.persistentDataPath + "/" + "My_Database";

            //open connection
            dbCon = new SqliteConnection(connection);
            dbCon.Open();

            //create table if necessairy
            IDbCommand dbcmd;
            dbcmd = dbCon.CreateCommand();
            string q_createTable =
                "CREATE TABLE IF NOT EXISTS " + tableName +
                " (id INTEGER PRIMARY KEY, " + levelFieldName + "STRING" + timeFieldName + " FLOAT )";

            InsertIntoDatabase(new LevelTimeData(SceneManager.GetActiveScene().ToString(), 1f));

            // Read and print all values in table
            IDbCommand cmnd_read = dbCon.CreateCommand();
            IDataReader reader;
            string query = "SELECT * FROM " + tableName;
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
            {
                Debug.Log("id: " + reader[0].ToString());
                Debug.Log(levelFieldName + ": " + reader[1].ToString());
                Debug.Log(timeFieldName + ": " + reader[1].ToString());

            }
        }

        public void InsertIntoDatabase(string levelName, float time)
        {
            /*IDbCommand getMax = dbCon.CreateCommand();
            getMax.CommandText = "SELECT MAX(id) FROM " + tableName;
            int maxId = 
            string q_insertTime = "INSERT INTO " + tableName + " ("  + */
            InsertIntoDatabase(new LevelTimeData(levelName, time));

        }
        void InsertIntoDatabase(LevelTimeData data)
        {
            string q_Insert = "INSERT INTO" + tableName + "(" + levelFieldName + ", " + timeFieldName + ")" +
                "VALUES (" + data.levelName + ", " + data.levelTime + ")";

        }
        float GetLowestTimeFromLevel(string level)
        {
            Debug.LogError("Has not yet been implemented");
            return 0f;
        }

        List<LevelTimeData> Top5Scores()
        {
            Debug.LogError("Has not yet been implemented");
            return null;
        }

        private void OnDestroy()
        {
            dbCon.Close();
        }
    }
}