using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie_Sqlite2._0
{
    public class ViMovieNumDal
    {
        //加载，选择所有数据。
        public List<ViMovieNum> Select(string sql)
        {
            List<ViMovieNum> list = new List<ViMovieNum>();

            using (SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ViMovieNum model = new ViMovieNum
                        {
                            ID = reader.GetInt32(0),
                            FolderName = reader["folderName"].ToString(),
                            FolderPath = reader["folderPath"].ToString(),
                            Num = reader["num"].ToString(),
                            SubTitle = reader["subTitle"].ToString(),
                            Quality = reader["quality"].ToString(),
                            Actors = reader["actors"].ToString(),
                            FileSize = (double)reader["fileSize"],
                            Num_ID = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                            FolderName_bak = reader["folderName_bak"].ToString(),
                            DirCreateTime = (DateTime)reader["dirCreateTime"]

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
            string sql = "select * from viMovieNum";
            
            return SqliteHelper.GetDataTable(sql);
        }

        //查询
        public List<ViMovieNum> Query(string str,string sql)
        {
            List<ViMovieNum> list = new List<ViMovieNum>();
            //string sql = "select * from viMovieNum where folderName like '%" + str + "%' order by folderName";
            using (SQLiteDataReader reader = SqliteHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ViMovieNum model = new ViMovieNum();
                        model.ID = reader.GetInt32(0);
                        model.FolderName = reader["folderName"].ToString();
                        model.FolderPath = reader["folderPath"].ToString();
                        model.Num = reader["num"].ToString();
                        model.SubTitle = reader["subTitle"].ToString();
                        model.Quality = reader["quality"].ToString();
                        model.Actors = reader["actors"].ToString();
                        model.FileSize = (double)reader["fileSize"];
                        model.Num_ID = reader.IsDBNull(8)?0:reader.GetInt32(8);
                        model.FolderName_bak = reader["folderName_bak"].ToString();
                        model.DirCreateTime = (DateTime)reader["dirCreateTime"];
                        list.Add(model);
                    }
                }
            }
            return list;
        }

    }
}
