using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Text.RegularExpressions;

namespace MyMovie_Sqlite2._0
{
    /// <summary>
  /// 操作tblMovie表的数据访问层
  /// </summary>
    public  class TblMovieDal
    {
        public int GetRecordCount()
        {
            string sql = "select count(*) from tblMovie";
            return (int)SqliteHelper.ExecuteScalar(sql);
        }

        //扫描文件夹,并插入数据
        public int InsertFolder()
        {
            //1.先清除数据库中存在的表，然后新建表。
            DelRecorder();

            //2.调用方法将文件夹名称写入list集合中

            //string path = ConfigurationManager.AppSettings["sourceFolder1"];
            //string pathG = ConfigurationManager.AppSettings["sourceFolder2"];

            //获得App.config文件中，所有key的集合。
            List<string> keys = GetConfigKeys();
            keys = keys.Where(c => c.Substring(0, 5) == "movie").ToList();
            List<TblMovie> list = new List<TblMovie>();

            for (int i = 0; i < keys.Count(); i++)
            {
                foreach (string path in ConfigurationManager.AppSettings.GetValues(keys[i]))
                {
                    if (path!="")
                    {

                        LoadDir(path, list);
                    }
                }
            }
            
            //3.将list集合中的数据写入数据库中。
            string conStr = @"data source=MyMovie.db;version=3;";
            using (SQLiteConnection conn = new SQLiteConnection(conStr))
            {
                string sql = "insert into tblMovie(folderName,folderPath,folderName_bak,num,fileSize,dirCreateTime) values(@name,@path,@name_bak,@num,@fileSize,@dirCreateTime)";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                conn.Open();

                //开启sqlite的事务，加速数据插入速度。
                SQLiteTransaction trans = conn.BeginTransaction();
                for (int i = 0; i < list.Count; i++)
                {

                    SQLiteParameter[] pms = new SQLiteParameter[]
                    {
                    new SQLiteParameter("@name",System.Data.DbType.String,400) {Value=list[i].FolderName },
                    new SQLiteParameter("@path",System.Data.DbType.String,500) { Value=list[i].FolderPath },
                    new SQLiteParameter("@name_bak",System.Data.DbType.String,400) {Value=list[i].FolderName_bak },
                    new SQLiteParameter("@num",System.Data.DbType.String,10) {Value=list[i].Num },
                    new SQLiteParameter("@fileSize",System.Data.DbType.Double) {Value=list[i].FileSize },
                    new SQLiteParameter("@dirCreateTime",System.Data.DbType.DateTime) {Value=list[i].DirCreateTime }



                    };

                    cmd.Parameters.AddRange(pms);
                    cmd.ExecuteNonQuery();
                }
                trans.Commit();

            }


            return list.Count();
        }

        /// <summary>
        /// 获得App.config文件中所有的Key。
        /// 
        /// </summary>
        /// <returns></returns>
        private List<string> GetConfigKeys()
        {
            List<string> keys = new List<string>();
            if (ConfigurationManager.AppSettings.HasKeys())
            {
               int c= ConfigurationManager.AppSettings.Keys.Count;
                for (int i = 0; i < c; i++)
                {
                    
                    keys.Add( ConfigurationManager.AppSettings.Keys[i]);
                    
                }

            }
            return keys;
        }


        //方法：将路径名写入泛型集合，并递归。
        private static void LoadDir(string path, List<TblMovie> list)
        {
            //1.获取路径
            string[] dirs = Directory.GetDirectories(path);
            //TblMovie model = null;
            double size = 0;
            foreach (var item in dirs)
            {
                //获得当前文件夹的大小
                DirectoryInfo directoryInfo = new DirectoryInfo(item);
               FileInfo[] fileInfos= directoryInfo.GetFiles();
                foreach (FileInfo fi in fileInfos)
                {
                    size += fi.Length;
                }


                //写入泛型集合
                TblMovie model = new TblMovie
                {
                    FolderName = Path.GetFileName(item),
                    FolderPath = Path.GetDirectoryName(item),
                    FolderName_bak = Path.GetFileName(item),
                    Num = Regex.Match(Path.GetFileName(item), "^[A-Za-z|1pondo|T28]+-[0-9]+").ToString(),
                    FileSize = Math.Round(size / 1024 / 1024 / 1024, 2),
                    DirCreateTime = directoryInfo.LastWriteTime
                    
                };
                list.Add(model);
                size = 0;
                //递归
                LoadDir(item, list);
            }


        }


        //在导入数据之前，先删除表，然后新建。lite没有truncate命令。
        public void DelRecorder()
        {
            string sql = "delete from tblMovie";
            SqliteHelper.ExecuteNonQuery(sql);
            string sequence = "DELETE FROM sqlite_sequence WHERE name = 'tblMovie'";
           // string sqlCreate = "CREATE TABLE tblMovie (ID INTEGER PRIMARY KEY AUTOINCREMENT, folderName text (400), folderPath text (500), folderName_bak text (400),num text(10),fileSize double)";
            SqliteHelper.ExecuteNonQuery(sequence);
        }

        //加载，选择所有数据。
        public List<TblMovie> Select(string sql)
        {
            List<TblMovie> list = new List<TblMovie>();
            
            using (SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblMovie model = new TblMovie
                        {
                            ID = reader.GetInt32(0),
                            FolderName = reader["folderName"].ToString(),
                            FolderPath = reader["folderPath"].ToString(),
                            FolderName_bak = reader["folderName_bak"].ToString(),
                            Num=reader["num"].ToString(),
                            FileSize=(double)reader["fileSize"]

                        };
                        list.Add(model);
                    }
                }
            }
            return list;
        }

        //加载，datatable所有数据
        public DataTable SelectDataTable()
        {
            string sql = "select * from tblMovie";
           return SqliteHelper.GetDataTable(sql);
        }

        //查询
        public List<TblMovie> Query(string str)
        {
            List<TblMovie> list = new List<TblMovie>();
            string sql = "select * from tblMovie where folderName like '%" + str + "%' order by folderName";
            using (SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblMovie model = new TblMovie();
                        model.ID = reader.GetInt32(0);
                        model.FolderName = reader["folderName"].ToString();
                        model.FolderPath = reader["folderPath"].ToString();
                        model.FolderName_bak = reader["folderName_bak"].ToString();
                        model.Num = reader["num"].ToString();
                        model.FileSize = (double)reader["fileSize"];
                        list.Add(model);
                    }
                }
            }
            return list;
        }

    }
}
