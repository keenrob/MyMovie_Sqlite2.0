using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMovie_Sqlite2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ViMovieNumDal dal = new ViMovieNumDal();
        public int currentCellID;
        public int _numID;
        public string currentFilePath;
        public string[] videoPath;
        


        //重置
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData(dal.Select("select * from viMovieNum"));
            this.txtQuery.Text = "";
            this.txtQuery.Focus();
            
        }

        
        //加载窗体，显示数据
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cbSelectQuery.Text = "文件名";
            
            //LoadData(dal.Select());
            LoadDataTable(dal.SelectDataTable());



        }

        // 加载全部数据，并进行列宽、列名调整。
        private void LoadDataTable(DataTable dataTable)
        {
            this.dataGridView1.DataSource = dataTable;
            
            this.dataGridView1.Columns[0].Width = 40;
            this.dataGridView1.Columns[1].Width = 350;
            this.dataGridView1.Columns[2].Width = 150;
            this.dataGridView1.Columns[3].Width = 70;
            this.dataGridView1.Columns[4].Width = 70;
            this.dataGridView1.Columns[5].Width = 60;
            this.dataGridView1.Columns[6].Width = 230;
            this.dataGridView1.Columns[7].Width = 100;
            this.dataGridView1.Columns[1].HeaderText = "文件名";
            this.dataGridView1.Columns[2].HeaderText = "文件路径";
            this.dataGridView1.Columns[3].HeaderText = "番号";
            this.dataGridView1.Columns[4].HeaderText = "字幕";
            this.dataGridView1.Columns[5].HeaderText = "质量";
            this.dataGridView1.Columns[6].HeaderText = "演员";
            this.dataGridView1.Columns[7].HeaderText = "大小";
        }


        // 加载全部数据，并进行列宽、列名调整。
        private void LoadData(List<ViMovieNum> list)
        {
            //ID,folderName,folderPath,num,subTitle,quality,actors,fileSize,num_ID
            this.dataGridView1.DataSource = list;
            this.dataGridView1.Columns[0].Width = 40;
            this.dataGridView1.Columns[1].Width = 350;
            this.dataGridView1.Columns[2].Width = 150;
            this.dataGridView1.Columns[3].Width = 70;
            this.dataGridView1.Columns[4].Width = 70;
            this.dataGridView1.Columns[5].Width = 60;
            this.dataGridView1.Columns[6].Width = 230;
            this.dataGridView1.Columns[7].Width = 100;
            this.dataGridView1.Columns[1].HeaderText = "文件名";
            this.dataGridView1.Columns[2].HeaderText = "文件路径";
            this.dataGridView1.Columns[3].HeaderText = "番号";
            this.dataGridView1.Columns[4].HeaderText = "字幕";
            this.dataGridView1.Columns[5].HeaderText = "质量";
            this.dataGridView1.Columns[6].HeaderText = "演员";
            this.dataGridView1.Columns[7].HeaderText = "大小";

        }

        //根据输入的关键字进行查询。
        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            string str = txtQuery.Text.Trim();
            string sql;
            switch (cbSelectQuery.Text)
            {
                case "字幕":
                    sql = "select * from viMovieNum where subTitle like '%" + str + "%' order by folderName";
                    break;
                case "演员名":
                    sql = "select * from viMovieNum where actors like '%" + str + "%' order by folderName";
                    break;
                case "影片质量":
                    sql = "select * from viMovieNum where quality like '%" + str + "%' order by folderName";
                    break;
                default:
                    sql = "select * from viMovieNum where folderName like '%" + str + "%' order by folderName";
                     break;
            }

            LoadData(dal.Query(str,sql));
        }

        //双击事件：打开文件夹的路径
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = sender as DataGridView;//获取事件发送者
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                String folderName = view.Rows[e.RowIndex].Cells[1].Value.ToString();
                String folderPath = view.Rows[e.RowIndex].Cells[2].Value.ToString();
                //MessageBox.Show(folderPath+"\\"+folderName);
                //Process.Start("Explorer.exe", folderPath + "\\" + folderName.Trim());  //用IE打开文件夹，不识别" , " 等字符。

                try
                {
                    Process.Start(folderPath + "\\" + folderName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("错误："+ex.Message.ToString());
                }

                view.Rows[e.RowIndex].Selected = true;
            }
        }

        //扫描文件夹并插入数据。
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否要初始化扫描文件夹？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (result==DialogResult.Cancel)
            {
                return;
            }

            if (backgroundWorker1.IsBusy)  //如果正在执行，则跳出。
                return;

            this.progressBar1.Maximum = 100;
            //用backgroundWorker控件，异步执行。
            backgroundWorker1.RunWorkerAsync("Test.");
          }

        //用来存放临时数据
        Object cellTempValue = null;

        //单元格开始编辑时触发的事件cellTempValue赋值当前选中的单元格
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellTempValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //相同的话，则退出。
            if (object.Equals(cellTempValue, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value))
            {
                return;
            }

            if (MessageBox.Show("是否修改？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellTempValue;
                return;
            }

            string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
            string folderName = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            string sql = string.Format("update tblMovie set {0}='{1}' where ID={2}", columnName, folderName, id);
            //string sql = "update tblMovie set @columnName=@folderName where ID=@id";


            SqliteHelper.ExecuteNonQuery(sql);

        }

        //查找文件名不同，并进行文件更名操作
        private void btnCheckDiff_Click(object sender, EventArgs e)
        {
            //判断movie文件夹是否存在，如果不存在就退出。
            int currentID = currentCellID;
            if (!Directory.Exists(@"F:\Movie1st"))
            {
                MessageBox.Show("不能在此电脑中进行操作。");
                return;
            }

            List<TblMovie> li = new List<TblMovie>();
            TblMovie tm = null;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                string oldName = item.Cells["folderName"].Value.ToString();
                string newName = item.Cells["folderName_bak"].Value.ToString();
                if (string.Equals(oldName, newName)!=true) //不忽略大小写进行比较。
                {
                    tm = new TblMovie();
                    tm.ID = int.Parse(item.Cells["ID"].Value.ToString());
                    tm.FolderName = item.Cells["folderName"].Value.ToString();
                    tm.FolderName_bak = item.Cells["folderName_bak"].Value.ToString();
                    tm.FolderPath = item.Cells["folderPath"].Value.ToString();
                    li.Add(tm);
                }
            }

            if (li.Count > 0)
            {
                //MessageBox.Show(li.Count.ToString());
                //进行文件夹更名操作
                if (MessageBox.Show("是否对 "+li.Count+" 个文件夹进行更名操作？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                {
                    foreach (TblMovie item in li)
                    {
                        try
                        {
                            Directory.Move(item.FolderPath + "\\" + item.FolderName_bak, item.FolderPath + "\\" + item.FolderName);
                            string sql = string.Format("update tblMovie set folderName_bak='{0}' where ID={1}", item.FolderName, item.ID);
                            SqliteHelper.ExecuteNonQuery(sql);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                            return;
                        }
                        

                        //将folderName_bak内容在数据库中进行更新
                       

                    }

                    MessageBox.Show("共计对 " + li.Count + " 个文件夹进行了更名。");

                    //重新加载
                    LoadDataTable(dal.SelectDataTable());
                    //定位。
                    LocationRow(currentID);
                   

                }
            }

        }

        //定位到最后单击的行上
        private void LocationRow(int currentID)
        {
            //for (int i = 0; i < this.dataGridView1.RowCount; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells["ID"].Value.ToString().Equals(currentCellID.ToString()))
            //    {
            //        dataGridView1.ClearSelection();
            //        dataGridView1.FirstDisplayedScrollingRowIndex = i;
            //        dataGridView1.Rows[i].Selected = true;
            //        break;
            //    }
            //}

            if (currentID > 1)
            {
            dataGridView1.ClearSelection();
            dataGridView1.FirstDisplayedScrollingRowIndex = currentID - 1;
            dataGridView1.Rows[currentID - 1].Selected = true;
            }
           
        }

        int i = 0;
        int pathLen=0;
     
       /// <summary>
       /// 单击单元格
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ShowContent(sender, e);
        }
        /// <summary>
        /// 显示内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowContent(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                currentCellID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(),out i);
                _numID = i;
                currentFilePath = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + "\\" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            DataGridView view = sender as DataGridView;//获取事件发送者
            if (e.RowIndex > -1 && e.ColumnIndex > -1)//防止 Index 出错
            {
                String folderName = view.Rows[e.RowIndex].Cells[1].Value.ToString();
                String folderPath = view.Rows[e.RowIndex].Cells[2].Value.ToString();
                //MessageBox.Show(folderPath + "\\" + folderName);
                string filePath = folderPath + "\\" + folderName;
                lblImageName.Text = ShowImage(filePath, 0);

                //获取修改时间最早的图片的修改时间。
                FileInfo fli = new FileInfo(filePath + "\\" + lblImageName.Text);
                txtDate.Text = fli.LastWriteTime.ToString();

                lblFileName.Text = folderName; //标签显示文件夹名称。
                i = 0;
                string[] path = GetFormats(filePath, "*.jpg", "*.png", "*.jpeg"); //获得所有图片的路径
                videoPath = GetFormats(filePath, "*.mp4", "*.avi", "*.mkv", "*.wmv");//获得所有视频的路径
                btnPlay.Enabled = false;

                if (videoPath != null)
                {
                    if (videoPath.Length > 0)
                    {
                        btnPlay.Enabled = true;
                        btnPlay.Text = "播放视频 " + videoPath.Length;
                        FileInfo fi = new FileInfo(videoPath[0]);

                        lblFileName.Text += "  |||| " + Math.Round(fi.Length / 1024 / 1024 / 1024.00, 2).ToString() + "G";
                    }
                }


                if (path != null)
                {
                    if (path.Length <= 1)
                    {
                        btnNext.Enabled = false;
                        btnNext.Text = "下一张";
                        btnPre.Enabled = false;
                        btnEditTime.Enabled = false;
                    }
                    else
                    {
                        btnNext.Enabled = true;
                        btnNext.Text = "下一张" + "  " + path.Length;
                        btnPre.Enabled = true;
                        btnEditTime.Enabled = true;

                    }
                }
                else
                {
                    pictureBox1.Image = null;
                    btnNext.Enabled = false;
                    btnNext.Text = "下一张";
                    btnPre.Enabled = false;
                    btnEditTime.Enabled = false;
                }

                ShowNfoTag();

            }
        }

        /// <summary>
        /// 显示NFO文件中的Genre与Actor。动态生成label与动态清除label。
        /// </summary>
        private void ShowNfoTag()
        {
            try
            {
                FuncNFO nfo = new FuncNFO();
                string[] dirs = Directory.GetFiles(currentFilePath, "*.nfo");
                //this.lblTag.Text = null;

                //下面这种遍历的方式，由于控件的位置发生了变化，无法清除干净。
                //foreach (Control cc in this.gbNfo.Controls)
                //{
                //    gbNfo.Controls.Remove(cc);
                //    cc.Dispose();
                //}

                this.gbNfo.Controls.Clear();

                if (dirs != null)
                {
                    if (dirs.Length > 0)
                    {
                        List<string> list = nfo.GetTags(dirs[0]);
                        List<Label> lbs = new List<Label>();
                        for (int i = 0; i < list.Count; i++)
                        {
                            //this.lblTag.Text += list[i] + ";";
                            lbs.Add(new Label());
                            lbs[i].Name = "lbTag" + i;
                            lbs[i].Text = list[i];
                            if (lbs[i].Text == "Ge中文字幕")
                            {
                                lbs[i].ForeColor = Color.ForestGreen;
                            }
                            else
                            {
                                lbs[i].ForeColor = Color.Red;

                            }

                            lbs[i].Size = new Size(70, 15);
                            if (i <= 5)
                            {
                                lbs[i].Location = new Point(i * 70 + 10, 15);
                            }
                            else if(i<=10)
                            {
                                lbs[i].Location = new Point((i - 6) * 70 + 10, 30);

                            }
                            else if(i<=15)
                            {
                                lbs[i].Location = new Point((i - 11) * 70 + 10, 45);

                            }
                            else
                            {
                                lbs[i].Location = new Point((i - 16) * 70 + 10, 60);

                            }


                            this.gbNfo.Controls.Add(lbs[i]);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
        }





        //下一张图片
        private void btnNext_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(currentFilePath);
            i++;
            if (i>pathLen)
            {
                i = 0;
            }
           lblImageName.Text= ShowImage(currentFilePath, i);

        }

        //上一张图片
        private void btnPre_Click(object sender, EventArgs e)
        {
            i--;
            if (i<0)
            {
                i = pathLen - 1;
            }

            lblImageName.Text = ShowImage(currentFilePath, i);
        }

        /// <summary>
        /// 修改图片文件的创建时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void btnEditTime_Click(object sender, EventArgs e)
        {
            if (lblImageName.Text!="")
            {
                FileInfo fi = new FileInfo(currentFilePath + "\\" + lblImageName.Text.ToString());
                DateTime dt = Convert.ToDateTime(txtDate.Text);

                string str = string.Format("是否将图片{0}的原修改时间为{1}，修改成时间为{2}？", lblImageName.Text, fi.LastWriteTime.ToString(), dt.AddDays(-1).ToString());
                DialogResult dr = MessageBox.Show(str, "确认修改", MessageBoxButtons.OKCancel);
                if (dr==DialogResult.OK)
                {
                    File.SetCreationTime(fi.FullName.ToString(), dt.AddDays(-1));
                    File.SetLastWriteTime(fi.FullName.ToString(), dt.AddDays(-1));
                }
                
                
                

            }
            

        }

        /// <summary>
        /// 在PictureBox内显示文件夹内的图片
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="m"></param>
        private string ShowImage(string filePath, int m)
        {

            try
            {
                string[] path = GetFormats(filePath, "*.jpg", "*.png", "*.jpeg");

                int n = 0;
                pathLen = path.Length;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                if (path.Length > 0)
                {
                    n = m;
                    using (FileStream fs = new FileStream(path[n], FileMode.Open, FileAccess.Read))
                    {
                        pictureBox1.Image = Image.FromStream(fs);
                       
                       string fName = Path.GetFileName(fs.Name.ToString());
                        return fName;

                    }
                    //pictureBox1.Image = Image.FromFile(path[n]); //不容易释放资源。

                }
                else
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        /// <summary>
        /// 别人写的方法：获取多个格式的文件路径
        /// </summary>
        /// <param name="dirPath"></param>
        /// <param name="searchPatterns"></param>
        /// <returns></returns>
        private string[] GetFormats(string dirPath, params string[] searchPatterns)
        {
            try
            {
                if (searchPatterns.Length <= 0)
                {
                    return null;
                }
                else
                {
                    DirectoryInfo di = new DirectoryInfo(dirPath);
                    FileInfo[][] fis = new FileInfo[searchPatterns.Length][];
                    int count = 0;
                    for (int i = 0; i < searchPatterns.Length; i++)
                    {
                        FileInfo[] fileInfos = di.GetFiles(searchPatterns[i]);
                        fileInfos = fileInfos.OrderBy(f => f.LastWriteTime).ToArray();
                        fis[i] = fileInfos;
                        count += fileInfos.Length;
                    }
                    string[] files = new string[count];
                    int n = 0;
                    for (int i = 0; i <= fis.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j < fis[i].Length; j++)
                        {
                            string temp = fis[i][j].FullName;
                            files[n] = temp;
                            n++;
                        }
                    }
                    return files;
                }
            }
            catch (Exception)
            {

                return null;
            }
            
        }


        /// <summary>
        /// 播放视频文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            Process.Start(videoPath[0]);
        }

        /// <summary>
        /// 删除文件夹下所有文件
        /// </summary>
        /// <param name="dir"></param>
        public void DeleteFolder(string dir)
        {
            //如果存在这个文件夹删除之 
            if (Directory.Exists(dir))
            {
                foreach (string d in Directory.GetFileSystemEntries(dir))
                {
                    if (File.Exists(d))
                        File.Delete(d);//直接删除其中的文件 
                    else DeleteFolder(d);//递归删除子文件夹  
                }
                Directory.Delete(dir);
                //删除已空文件夹 
                MessageBox.Show(dir + "文件夹删除成功");
            }
            else //如果文件夹不存在则提示 
                MessageBox.Show(dir + "该文件夹不存在");
        }

        /// <summary>
        /// 是否删除数据库中及电脑中的文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFolder_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除当前文件夹","重要提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                DeleteFolder(currentFilePath);
            }
        }

       /// <summary>
       /// 增加Genre类别到NFO文件中。
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void BtnAddGenre_Click(object sender, EventArgs e)
        {
            if (this.cbGenre.Text.Length > 0)
            {
                string[] dirs = Directory.GetFiles(currentFilePath, "*.nfo");
                FuncNFO nfo = new FuncNFO();
                //bool boolGenreQuality=false;

                if (dirs.Length > 0)
                {
                   
                   List<string> lsTags= nfo.GetTags(dirs[0]);
                  //string zh=  lsTags.Where(s => s.Substring(2, 4) == "中文字幕").FirstOrDefault();
                  //string gq = lsTags.Where(s => s.Substring(2, 2) == "高清").FirstOrDefault();

                    //判断某字符串在集合中是否存在，存在就跳出。
                    foreach (string item in lsTags)
                    {
                        if ("Ge" + this.cbGenre.Text == item)
                            return;

                        //if (this.cbGenre.Text.Contains("清") && item.Contains("清"))
                        //{
                        //    boolGenreQuality = true;
                        //}   
                    }


                    //更新到数据库中。
                    TblNumDal numDal = new TblNumDal();
                    numDal.UpdateGenre(this.cbGenre.Text, _numID);
                    //重新加载。
                    ViMovieNumDal vi = new ViMovieNumDal();
                    LoadData(vi.Select("select * from viMovieNum"));


                    //添加到NFO文件中。
                    foreach (string item in dirs)
                    {
                       
                        nfo.AddGenre(item, this.cbGenre.Text);
                    }



                    MessageBox.Show("添加成功。");
                    
                    
                }
                else
                {
                    MessageBox.Show("未找到有效的NFO文件。");
                }
            }
            else
            {
                MessageBox.Show("Genre不能为空值。");
            }



        }

        #region 如何使用BackgroundWorker/进度条的问题。
        TblMovieDal mdal = new TblMovieDal();
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            int cc=mdal.InsertFolder();
            watch.Stop();

            for (int i = 0; i <= 100; i++)
            {
                backgroundWorker1.ReportProgress(i,"working");
                Thread.Sleep(10);
            }

            string[] results = { watch.Elapsed.ToString(), cc.ToString() };
            e.Result = String.Join("|", results);

            
            

            
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.lblPercent.Text = Convert.ToString(e.ProgressPercentage) + "%";


        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           string[] ee= e.Result.ToString().Split('|');
            MessageBox.Show("共计导入" + ee[1] + "条数据。用时：" + ee[0] + "秒。");
            LoadData(dal.Select( "select * from viMovieNum"));
        }
        #endregion


        private void BtnUpdateNum_Click(object sender, EventArgs e)
        {
            TblNumDal dal = new TblNumDal();
            int rows=dal.InsertToTblNum();
            MessageBox.Show("共计添加了"+rows.ToString()+"番号数据。");
        }

        //筛选出番号相同的记录来。
        private void btnFindSame_Click(object sender, EventArgs e)
        {
            string sqlSame = "select * from viMovieNum tm where tm.num in(select num from tblMovie group by num having count(*)>=2) order by num";
            LoadData(dal.Select(sqlSame));
            this.txtQuery.Text = "";
            this.txtQuery.Focus();
        }
    }
}
