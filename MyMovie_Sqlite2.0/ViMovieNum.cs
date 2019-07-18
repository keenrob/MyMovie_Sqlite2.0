using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovie_Sqlite2._0
{
    public class ViMovieNum
    {
        //ID,folderName,folderPath,num,subTitle,quality,actors,fileSize,num_ID
        public int ID { get; set; }
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        public string Num { get; set; }
        public string SubTitle { get; set; }
        public string Quality { get; set; }
        public string Actors { get; set; }
        public double FileSize { get; set; }
        public int Num_ID { get; set; }
        public string FolderName_bak { get; set; }
        public DateTime DirCreateTime { get; set; }

    }
}
