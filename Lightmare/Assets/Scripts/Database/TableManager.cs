using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

namespace Database
{
    public class TableManager : MonoBehaviour
    {
        [HideInInspector] public string tableName;
        [HideInInspector] public string connection;

        public IDbConnection dbCon;

        // Start is called before the first frame update
        virtual public void Start()
        {
            CreateConnection();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public virtual void CreateConnection()
        {
            connection = "URI=file:" + Application.persistentDataPath + "/" + DataBaseManager.databaseName;
            dbCon = new SqliteConnection(connection);
            dbCon.Open();
        }

        public virtual void CreateTable() { }

        /// <summary>
        /// Gives a new key in the table. 
        /// </summary>
        /// <returns>The highest key in the table +1</returns>
        public virtual int GetNewKey()
        {
            int highestKey = 0;

            IDbCommand cmnd_read = dbCon.CreateCommand();
            IDataReader reader;
            string query = "SELECT id FROM " + tableName;
            Debug.Log(query);
            cmnd_read.CommandText = query;
            reader = cmnd_read.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetInt32(0) > highestKey) { highestKey = reader.GetInt32(0); }
            }
            return highestKey + 1;
        }

        public void ClearTable()
        {
            IDbCommand cmnd = dbCon.CreateCommand();
            cmnd.CommandText = "DELETE FROM " + tableName;
            cmnd.ExecuteNonQuery();
        }

        public virtual void OnDestroy()
        {
            dbCon.Close();
        }
    }
}
