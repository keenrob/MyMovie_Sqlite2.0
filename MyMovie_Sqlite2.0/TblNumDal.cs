using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace MyMovie_Sqlite2._0
{
    public class TblNumDal
    {
        public int InsertToTblNum()
        {



            string sqlNumNotInMovie = "select num,numIndex,folderPath||'\\'||folderName as path,1 from " +
                                  "tblMovie left join tblNum on tblNum.numIndex=tblMovie.num where  numIndex is null and num<>''";
            string sqlInsertIntoNum = " insert into tblNum(numIndex,subTitle,filePath,xmlScan) " + sqlNumNotInMovie;


            //插入tblNum表中没有的番号数据（从tblMovie中）
            int rows = SqliteHelper.ExecuteNonQuery(sqlInsertIntoNum);


            string sqlNumXmlScan = "select * from tblNum where xmlScan=1";
            UpdateTblNumNode(sqlNumXmlScan);

            return rows;

        }

        /// <summary>
        /// 通过读取文件夹内NFO文件，将相关节点写入tblNum表中。
        /// </summary>
        /// <param name="sqlNumXmlScan">获得tblNum表中待扫描（1）的数据。</param>
        private static void UpdateTblNumNode(string sqlNumXmlScan)
        {
            //获得数据
            List<TblNum> listRead = new List<TblNum>();
            using (SQLiteDataReader reader = SqliteHelper.ExecuteReader(sqlNumXmlScan))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblNum model = new TblNum
                        {
                            Num_ID = reader.GetInt32(0),
                            NumIndex = reader["numIndex"].ToString(),
                            SubTitle = reader["subTitle"].ToString(),
                            Quality = reader["quality"].ToString(),
                            Actors = reader["actors"].ToString(),
                            FilePath = reader["filePath"].ToString(),
                            XmlScan = reader.GetInt32(6)
                        };
                        listRead.Add(model);
                    }
                }
            }


            for (int i = 0; i < listRead.Count; i++)
            {
                //其次，扫描FilePath下面的NFO文件，提取相关的节点值。
                FuncNFO nfo = new FuncNFO();

                string[] nfoFiles = Directory.GetFiles(listRead[i].FilePath, "*.nfo");
                List<string> liTags = nfo.GetTags(nfoFiles[0]);
                TblNum model = listRead[i];

                foreach (string tag in liTags)
                {
                    if (tag.Substring(0, 2) == "Ge")
                    {
                        if (tag == "Ge中文字幕")
                        {
                            model.SubTitle = tag.Replace("Ge", "");
                        }
                    }
                    else
                    {
                        model.Actors += tag + ",";

                    }

                }
                //数据库更新操作。
                string sqlUpdate = "update tblNum set subTitle=@subTitle,actors=@actors,xmlScan=0 where num_ID=@id";
                SqliteHelper.ExecuteNonQuery(sqlUpdate, new SQLiteParameter[] {
                    new SQLiteParameter("@subTitle",System.Data.DbType.String,10){ Value=model.SubTitle},
                    new SQLiteParameter("@actors",System.Data.DbType.String,600){Value=model.Actors.Substring(0,model.Actors.Length-1)},
                    new SQLiteParameter("@id",System.Data.DbType.Int32){Value=model.Num_ID}
                });
            }
        }

        /// <summary>
        /// 个别更新subtitle与quality
        /// </summary>
        /// <param name="genreText"></param>
        /// <param name="id"></param>
        public  void UpdateGenre(string genreText,int id)
        {
            string sqlUpdate;
            if (genreText=="中文字幕")
            {
                sqlUpdate = "update tblNum set subTitle=@text where num_ID=@id";

            }
            else
            {
                 sqlUpdate = "update tblNum set quality=@text where num_ID=@id";

            }
            SqliteHelper.ExecuteNonQuery(sqlUpdate, new SQLiteParameter[] {
                    new SQLiteParameter("@text",System.Data.DbType.String,10){ Value=genreText},
                    new SQLiteParameter("@id",System.Data.DbType.Int32){Value=id}
                });
        }
    }
}
