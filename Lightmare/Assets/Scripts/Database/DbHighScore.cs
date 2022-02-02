using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.SceneManagement;

namespace Database
{
    public class DbHighScore : TableManager
    {
        public static string tableName = "time_scores";
        string connection;
        public static string levelFieldName = "level_name";
        public static string timeFieldName = "time";

        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
        }

        public override void CreateTable()
        {
            IDbCommand dbcmd;
            dbcmd = dbCon.CreateCommand();
            string q_createTable =
                "CREATE TABLE IF NOT EXISTS " + tableName +
                " (id INTEGER PRIMARY KEY, " + levelFieldName + " STRING, " + timeFieldName + " INTEGER )";

            dbcmd.CommandText = q_createTable;
            //Debug.Log(q_createTable);
            dbcmd.ExecuteReader();

            Debug.Log("1");

            base.CreateTable();
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
        /// Clears every value from the table
        /// </summary>
        void ClearTable()
        {

        }
    }
}