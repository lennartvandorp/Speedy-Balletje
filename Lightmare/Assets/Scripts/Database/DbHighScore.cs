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
        public static string tableName = "time_scores";
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

            #region create table
            //create table if necessairy
            IDbCommand dbcmd;
            dbcmd = dbCon.CreateCommand();
            string q_createTable =
                "CREATE TABLE IF NOT EXISTS " + tableName +
                " (id INTEGER PRIMARY KEY, " + levelFieldName + " STRING, " + timeFieldName + " INTEGER )";

            dbcmd.CommandText = q_createTable;
            //Debug.Log(q_createTable);
            dbcmd.ExecuteReader();
            #endregion

            InsertIntoDatabase(new LevelTimeData(SceneManager.GetActiveScene().name, 1f));

        }


        //inserts the level name and time into the database
        public void InsertIntoDatabase(string levelName, float time)
        {
            InsertIntoDatabase(new LevelTimeData(levelName, time));
        }

        /// <summary>
        /// Inserts the name and time into the database
        /// </summary>
        /// <param name="data"></param>
        void InsertIntoDatabase(LevelTimeData data)
        {
            IDbCommand cmnd = dbCon.CreateCommand();
            string q_Insert = "INSERT INTO " + tableName + " ( id, " + levelFieldName + ", " + timeFieldName + ") " +
                "VALUES (" + GetNewKey() + ", \"" + data.levelName + "\", " + (int)data.levelTime + ")";
            cmnd.CommandText = q_Insert;
            cmnd.ExecuteNonQuery();
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


        /// <summary>
        /// Searches the table for the highest key
        /// </summary>
        /// <returns>The highest key in the table +1</returns>
        int GetNewKey()
        {
            int highestKey = 0;

            IDbCommand cmnd_read = dbCon.CreateCommand();
            IDataReader reader;
            cmnd_read.CommandText = "SELECT id FROM " + tableName;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetInt32(0) > highestKey) { highestKey = reader.GetInt32(0); }
            }
            return highestKey + 1;

        }

        /// <summary>
        /// Clears every value from the table
        /// </summary>
        void ClearTable()
        {
            IDbCommand cmnd = dbCon.CreateCommand();
            cmnd.CommandText = "DELETE FROM " + tableName;
            cmnd.ExecuteNonQuery();
        }


        private void OnDestroy()
        {
            dbCon.Close();
        }
    }
}