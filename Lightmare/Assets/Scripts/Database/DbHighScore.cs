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
        string connection;
        public static string levelFieldName = "level_name";
        public static string timeFieldName = "time";

        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
            SetupStrings();
            ClearTable();
            CreateTable();
            InsertIntoDatabase("test", 14.9f);
            Debug.Log("Get lowest time" + GetLowestTimeFromLevel("test").ToString());
        }

        void SetupStrings()
        {
            tableName = "time_scores";
        }

        public override void CreateTable()
        {
            IDbCommand dbcmd;
            dbcmd = dbCon.CreateCommand();
            string q_createTable =
                "CREATE TABLE IF NOT EXISTS " + tableName +
                " ( id INTEGER PRIMARY KEY," + levelFieldName + " STRING, " + timeFieldName + " FLOAT )";
            Debug.Log(q_createTable);

            dbcmd.CommandText = q_createTable;
            dbcmd.ExecuteReader();//Doesnt this have to be executeNonQuery?
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
                "VALUES (" + GetNewKey() + ", \"" + data.levelName + "\", " + (float)data.levelTime + ")";
            Debug.Log(q_Insert);
            cmnd.CommandText = q_Insert;
            cmnd.ExecuteNonQuery();
        }

        public float GetLowestTimeFromLevel(string level)
        {
            IDbCommand cmnd = dbCon.CreateCommand();
            IDataReader reader;
            string query = "SELECT * FROM " + tableName +
                " WHERE " + levelFieldName + " == \"" + level +
                "\" order by " + timeFieldName + " ASC " +
                "limit 0, 1";
            Debug.Log(query);

            cmnd.CommandText = query;

            reader = cmnd.ExecuteReader();

            float toReturn = 0f;
            while (reader.Read())
            {
                Debug.Log(reader.GetFloat(2));
                toReturn = reader.GetFloat(2);
            }
            return toReturn;
        }

        List<LevelTimeData> Top5Scores()
        {
            Debug.LogError("Has not yet been implemented");
            return null;
        }


    }
}