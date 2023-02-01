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
            CreateTable();
        }

        void SetupStrings()
        {
            tableName = "time_scores";
        }

        /// <summary>
        /// Creates the required table for this function
        /// </summary>
        public override void CreateTable()
        {
            IDbCommand dbcmd;
            dbcmd = dbCon.CreateCommand();
            string q_createTable =
                "CREATE TABLE IF NOT EXISTS " + tableName +
                " ( id INTEGER PRIMARY KEY," + levelFieldName + " STRING, " + timeFieldName + " FLOAT )";

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

            cmnd.CommandText = query;

            reader = cmnd.ExecuteReader();

            float toReturn = 0f;
            while (reader.Read())
            {
                toReturn = reader.GetFloat(2);
            }
            return toReturn;
        }


        
        List<float> Top5Scores(string level)
        {
            List<float> toReturn = new List<float>();


            string query ="SELECT "+ timeFieldName +" FROM " + tableName +
                " WHERE " + levelFieldName + " == \"" + level +
                "\" order by " + timeFieldName + " ASC " +
                "limit 0, 5";
                Debug.Log(query);

            IDbCommand cmnd = dbCon.CreateCommand();
            cmnd.CommandText = query;
            IDataReader reader;
            reader = cmnd.ExecuteReader();

            while (reader.Read())
            {
                toReturn.Add(reader.GetFloat(0));
            }
            return toReturn;
        }
    }
}