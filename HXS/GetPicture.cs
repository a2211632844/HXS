using iTextSharp.text;
using iTextSharp.text.pdf;
using Kingdee.BOS.WebApi.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Document = iTextSharp.text.Document;
using Font = iTextSharp.text.Font;
using Image = System.Drawing.Image;

namespace HXS
{
    public partial class GetPicture : Form
    {
        List<List<Object>> data = new List<List<object>>();//全部数据
        List<string> FMaterialNameList = new List<string>();//物料名称列表
        /// <summary>
        /// 缩略图路径
        /// </summary>
        List<string> sltPath = new List<string>();
        public GetPicture()
        {
            InitializeComponent();
        }
        string SLPic = "";
        private void GetPicture_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// 获取金蝶数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetInfo_Click(object sender, EventArgs e)
        {
            string datetime = Convert.ToDateTime(this.dateTimePicker.Value).ToString("yyyy-MM-dd HH:mm:ss");
            string endtime = Convert.ToDateTime(this.dateTimePickerEnd.Value).ToString("yyyy-MM-dd HH:mm:ss");
            string date = string.Format("FCreateDate>='{0}' and FCreateDate<='{1}'", datetime, endtime);
            //bool Check = this.checkBox1.Checked;
            string checktrue = string.Format("  AND F_ABCD_GETPIC='已抓取'");
            string checkfalse = string.Format("  AND F_ABCD_GETPIC<>'已抓取'");

            var checkcomboboxvalue = this.comboBox1.SelectedIndex;

            string KH = this.textBoxKH.Text.ToString().Trim();//客户
            string KHValueTrue = "";
            if (KH != "")
            {
                KHValueTrue = string.Format(" AND FCustId.FName like '%{0}%'", KH);
            }
            else
            {
                KHValueTrue = "";
            }
            string CK = this.textBoxCK.Text.ToString().Trim();//仓库
            string CKValueTrue = "";
            if (CK != "")
            {
                CKValueTrue = string.Format(" AND FSOSTOCKID.FName like '%{0}%'", CK);
            }
            else
            {
                CKValueTrue = "";
            }
            string SCX = this.textBoxSCX.Text.ToString().Trim();//生产线
            string SCXValueTrue = "";
            if (SCX != "")
            {
                SCXValueTrue = string.Format(" AND F_abcd_SCLine like '%{0}%'", SCX);
            }
            else
            {
                SCXValueTrue = "";
            }
            string HBZ = this.textBoxHBZ.Text.ToString().Trim();//行备注
            string HBZValueTrue = "";
            if (HBZ != "")
            {
                HBZValueTrue = string.Format(" AND FEntryNote like '%{0}%'", HBZ);
            }
            else
            {
                HBZValueTrue = "";
            }

            string WLMC = this.textBoxWLMC.Text.ToString().Trim();//物料名称
            string WLMCValueTrue = "";
            if (WLMC != "")
            {
                WLMCValueTrue = string.Format(" AND FMaterialName like '%{0}%'", WLMC);
            }
            else
            {
                WLMCValueTrue = "";
            }

            string GGMS = this.textBoxGGMS.Text.ToString().Trim();//规格描述
            string GGMSValueTrue = "";
            if (GGMS != "")
            {
                GGMSValueTrue = string.Format(" AND F_explain like '%{0}%'", GGMS);
            }
            else
            {
                GGMSValueTrue = "";
            }

            string YWBL = this.textBoxYWBL.Text.ToString().Trim();//有无玻璃
            string YWBLValueTrue = "";
            if (YWBL != "")
            {
                YWBLValueTrue = string.Format(" AND F_glass like '%{0}%'", YWBL);
            }
            else
            {
                YWBLValueTrue = "";
            }

            string KYS = this.textBoxKYS.Text.ToString().Trim();//框颜色
            string KYSValueTrue = "";
            if (KYS != "")
            {
                KYSValueTrue = string.Format(" AND F_OutlineColor like '%{0}%'", KYS);
            }
            else
            {
                KYSValueTrue = "";
            }

            string KCZ = this.textBoxKCZ.Text.ToString().Trim();//框材质
            string KCZValueTrue = "";
            if (KCZ != "")
            {
                KCZValueTrue = string.Format(" AND F_OutlineQuality like '%{0}%'", KCZ);
            }
            else
            {
                KCZValueTrue = "";
            }

            string LX = this.textBoxLX.Text.ToString().Trim();//类型
            string LXValueTrue = "";
            if (LX != "")
            {
                LXValueTrue = string.Format(" AND F_type like '%{0}%'", LX);
            }
            else
            {
                LXValueTrue = "";
            }

            string JC = this.textBoxJC.Text.ToString().Trim();//简称
            string JCValueTrue = "";
            if (JC != "")
            {
                JCValueTrue = string.Format(" AND F_abcd_MnemonicCode like '%{0}%'", JC);
            }
            else
            {
                JCValueTrue = "";
            }



            string NotBDC = " AND FSOSTOCKID.FName <> '补单仓'";//不获取为补单仓的单据
            // 使用webapi引用组件Kingdee.BOS.WebApi.Client.dll
            K3CloudApiClient client = new K3CloudApiClient("http://47.119.190.7:8090/K3Cloud/");
            var loginResult = client.ValidateLogin("60d01a1379e237", "Administrator", "888888", 2052);
            var resultType = JObject.Parse(loginResult)["LoginResultType"].Value<int>();
            JObject jo = new JObject();
            if (checkcomboboxvalue == 0) //全部抓取状态
            {
                jo.Add("FormId", "SAL_SaleOrder");
                jo.Add("FieldKeys", "F_abcd_GetPic,FEntryNote,F_abcd_MnemonicCode,F_abcd_SCLine,F_explain,F_OutlineColor,F_OutlineQuality,F_abcd_GYPeiHuotime,FDate,FCustId.FName,FBillNo,FSOStockId.FName,FMaterialName,FMaterialModel,F_glass,F_Outline,F_type ,FQty,FUnitID.FName,FMaterialId.FNumber,F_abcd_Picurl,FMaterialId.F_abcd_PicPath,FMaterialId.F_abcd_CreatePath,FMaterialId.F_abcd_CachePath,FSaleOrderEntry_FSeq,FID,FSaleOrderEntry_FEntryID");
                jo.Add("FilterString", date + KHValueTrue + CKValueTrue + SCXValueTrue + NotBDC + HBZValueTrue + WLMCValueTrue + GGMSValueTrue + YWBLValueTrue + KYSValueTrue + KCZValueTrue + LXValueTrue + JCValueTrue);
            }
            else if (checkcomboboxvalue == 1)//已抓取
            {
                jo.Add("FormId", "SAL_SaleOrder");
                jo.Add("FieldKeys", "F_abcd_GetPic,FEntryNote,F_abcd_MnemonicCode,F_abcd_SCLine,F_explain,F_OutlineColor,F_OutlineQuality,F_abcd_GYPeiHuotime,FDate,FCustId.FName,FBillNo,FSOStockId.FName,FMaterialName,FMaterialModel,F_glass,F_Outline,F_type,FQty,FUnitID.FName,FMaterialId.FNumber,F_abcd_Picurl,FMaterialId.F_abcd_PicPath,FMaterialId.F_abcd_CreatePath,FMaterialId.F_abcd_CachePath,FSaleOrderEntry_FSeq,FID,FSaleOrderEntry_FEntryID");
                jo.Add("FilterString", date + checktrue + KHValueTrue + CKValueTrue + SCXValueTrue + NotBDC + HBZValueTrue + WLMCValueTrue + GGMSValueTrue + YWBLValueTrue + KYSValueTrue + KCZValueTrue + LXValueTrue + JCValueTrue);
            }
            else if (checkcomboboxvalue == 2)//未抓取
            {
                jo.Add("FormId", "SAL_SaleOrder");
                jo.Add("FieldKeys", "F_abcd_GetPic,FEntryNote,F_abcd_MnemonicCode,F_abcd_SCLine,F_explain,F_OutlineColor,F_OutlineQuality,F_abcd_GYPeiHuotime,FDate,FCustId.FName,FBillNo,FSOStockId.FName,FMaterialName,FMaterialModel,F_glass,F_Outline,F_type ,FQty,FUnitID.FName,FMaterialId.FNumber,F_abcd_Picurl,FMaterialId.F_abcd_PicPath,FMaterialId.F_abcd_CreatePath,FMaterialId.F_abcd_CachePath,FSaleOrderEntry_FSeq,FID,FSaleOrderEntry_FEntryID");
                jo.Add("FilterString", date + checkfalse + KHValueTrue + CKValueTrue + SCXValueTrue + NotBDC + HBZValueTrue + WLMCValueTrue + GGMSValueTrue + YWBLValueTrue + KYSValueTrue + KCZValueTrue + LXValueTrue + JCValueTrue);
            }
            string ss = JsonConvert.SerializeObject(jo);
            if (resultType == 1)
            {
                data = client.ExecuteBillQuery(ss);

            }
            //抓取画芯状态，行备注，简称，生产线 ，规格描述，框颜色，框材质，创建日期，日期，客户，单据编号，
            //仓库，物料名称，规格型号，有无玻璃，外框，类型
            //销售数量，销售单位，物料编码，图片路径，画芯图库路径，图片生成路径，缩略图缓存路径，单据体序号，单据头内码，单据体内码
            dataGridView1.DataSource = null;
            List<Sal_Order> sal = new List<Sal_Order>();
            foreach (var item in data)
            {
                sal.Add(new Sal_Order()
                {
                    F_abcd_GetPic = item[0].ToString()
                , FEntryNote = item[1].ToString()
                , F_abcd_MnemonicCode = item[2].ToString()
                , F_abcd_SCLine = item[3].ToString()

                , F_explain = item[4].ToString()
                , F_OutlineColor = item[5].ToString()
                , F_OutlineQuality = item[6].ToString()

                , F_abcd_GYPeiHuotime = Convert.ToDateTime(item[7]).ToString()
                , FDate = Convert.ToDateTime(item[8]).ToString("yyyy-MM-dd")
                , FCustId = item[9].ToString()
                , FBillNo = item[10].ToString()
                , FSOStockId = (item[11] == null) ? " " : item[11].ToString()
                , FMaterialName = item[12].ToString()
                , FMaterialModel = item[13].ToString()
                , F_glass = item[14].ToString()
                , F_Outline = item[15].ToString()
                , F_type = item[16].ToString()
                , FQty = Convert.ToInt32(item[17]).ToString()
                , FUnitID = item[18].ToString()

                , FMaterialId = item[19].ToString()
                , F_abcd_Picurl = item[20].ToString()
                , F_abcd_PicPath = item[21].ToString().Substring(3)
                , F_abcd_CreatePath = item[22].ToString()
                , F_abcd_CachePath = item[23].ToString()
                , FSeq = item[24].ToString()
                , FID = item[25].ToString()
                , FEntryid = item[26].ToString()

                });
                FMaterialNameList.Add(item[12].ToString());
            }
            dataGridView1.DataSource = sal;
            #region
            dataGridView1.Columns[0].Width = 70;

            dataGridView1.Columns[1].HeaderCell.Value = "选择";
            dataGridView1.Columns[1].Width = 50;

            dataGridView1.Columns[2].HeaderCell.Value = "图片";
            dataGridView1.Columns[2].Width = 205;

            dataGridView1.Columns[3].HeaderCell.Value = "抓取状态";
            dataGridView1.Columns[3].Width = 140;

            dataGridView1.Columns[4].HeaderCell.Value = "行备注";
            dataGridView1.Columns[4].DefaultCellStyle.WrapMode = DataGridViewTriState.True;//文本换行

            dataGridView1.Columns[5].HeaderCell.Value = "简称";
            dataGridView1.Columns[5].Width = 170;
            dataGridView1.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns[6].HeaderCell.Value = "生产线";

            dataGridView1.Columns[7].HeaderCell.Value = "规格描述";
            dataGridView1.Columns[8].HeaderCell.Value = "框颜色";
            dataGridView1.Columns[9].HeaderCell.Value = "框材质";

            dataGridView1.Columns[10].HeaderCell.Value = "配货日期";
            dataGridView1.Columns[10].Width = 150;

            dataGridView1.Columns[11].HeaderCell.Value = "日期";
            dataGridView1.Columns[11].Width = 150;
            dataGridView1.Columns[11].Visible = false;

            dataGridView1.Columns[12].HeaderCell.Value = "客户";
            dataGridView1.Columns[12].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns[13].HeaderCell.Value = "单据编号 ";

            dataGridView1.Columns[14].HeaderCell.Value = "仓库";



            dataGridView1.Columns[15].HeaderCell.Value = "物料名称";
            dataGridView1.Columns[16].HeaderCell.Value = "规格型号";
            dataGridView1.Columns[17].HeaderCell.Value = "有无玻璃";

            dataGridView1.Columns[18].HeaderCell.Value = "外框";
            dataGridView1.Columns[18].Width = 120;

            dataGridView1.Columns[19].HeaderCell.Value = "类型";



            dataGridView1.Columns[20].HeaderCell.Value = "数量";

            dataGridView1.Columns[21].HeaderCell.Value = "单位";
            dataGridView1.Columns[21].Width = 70;



            dataGridView1.Columns[22].HeaderCell.Value = "物料编码";

            dataGridView1.Columns[23].HeaderCell.Value = "图片路径";
            dataGridView1.Columns[23].Width = 170;
            dataGridView1.Columns[23].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.Columns[24].HeaderCell.Value = "画芯图库路径";
            dataGridView1.Columns[24].Width = 170;

            dataGridView1.Columns[25].HeaderCell.Value = "图片生成路径";
            dataGridView1.Columns[25].Width = 170;

            dataGridView1.Columns[26].HeaderCell.Value = "缩略图缓存路径";
            dataGridView1.Columns[26].Width = 170;

            dataGridView1.Columns[27].HeaderCell.Value = "单据体序号";
            dataGridView1.Columns[28].HeaderCell.Value = "单据内码";
            dataGridView1.Columns[29].HeaderCell.Value = "单据体内码";

            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;


            this.dataGridView1.AllowUserToOrderColumns = true;

            //dataGridView1.RowTemplate.Height = 800;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表头居中
            #endregion
            //string SLPic = RootPath + "\\" + "SLPic";//根目录缩略图路径

            string FileName;//缩略图保存路径
            string Url;
            int j = 0;

            foreach (var item in data)
            {
                if (item[23] != null)//缩略图缓存路径
                {
                    SLPic = item[23].ToString();//缩略图缓存路径
                    if (Directory.Exists(SLPic) == false) //判断路径是否存在
                    {
                        if (SLPic == "") { SLPic = @"D:\画芯缩略图缓存"; }
                        Directory.CreateDirectory(SLPic);
                        FileName = string.Format(SLPic + "\\" + item[12].ToString() + ".jpg");//物料名称
                        Url = item[20].ToString();//图片路径
                        //string newurl = "D" + Url.Substring(1);
                        SavePhotoFromUrl(FileName, Url);
                        this.dataGridView1.Rows[j].Cells["Images"].Value = GetImage(FileName);
                        sltPath.Add(FileName);
                        j++;
                    }
                    else
                    {
                        FileName = string.Format(SLPic + "\\" + item[12].ToString() + ".jpg");
                        Url = item[20].ToString();
                        //string newurl = "D" + Url.Substring(4);
                        SavePhotoFromUrl(FileName, Url);
                        this.dataGridView1.Rows[j].Cells["Images"].Value = GetImage(FileName);
                        sltPath.Add(FileName);
                        j++;
                    }
                }

                if (item[12].ToString().Contains("定制成品"))//物料名称
                {
                    this.dataGridView1.Rows[j - 1].Cells["FMaterialName"].Style.BackColor = Color.Red;
                }
                if (item[1].ToString().Contains("定制")) //行备注
                {
                    this.dataGridView1.Rows[j - 1].Cells["FEntryNote"].Style.BackColor = Color.Yellow;
                }
            }

            //CopyImg(@"D:\06天猫-海龙红\山野-D-【一套两幅】");

            if (data.Count > 0)
            {
                DialogResult dr = MessageBox.Show("获取成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                DialogResult dr = MessageBox.Show("无符合记录条件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        List<bool> chec = new List<bool>();
        /// <summary>
        /// 生成数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateInfo_Click(object sender, EventArgs e)
        {
            int f = 0;
            int c = 0;
            int d = 0;
            string pf = "";
            System.IO.DriveInfo[] disk = System.IO.DriveInfo.GetDrives();

            string FolderName = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(":", ".");//以时间命名的文件夹名
            string TargetPath = string.Format(@"D:\订单图片生成" + "\\" + FolderName);//目标路径文件夹

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[i].Cells[1];
                bool Check = Convert.ToBoolean(cb.Value);
                chec.Add(Check);
                if (Check == true)
                {
                    f++;
                    string FBillNo = dataGridView1.Rows[i].Cells["FBillNo"].Value.ToString();//单据编号
                    string FMaterialName = dataGridView1.Rows[i].Cells["FMaterialName"].Value.ToString();//物料名称
                    int FID = Convert.ToInt32(dataGridView1.Rows[i].Cells["FID"].Value);
                    int FEntryid = Convert.ToInt32(dataGridView1.Rows[i].Cells["FEntryid"].Value);
                    string FSeq = dataGridView1.Rows[i].Cells["FSeq"].Value.ToString();
                    string IsGetPic = "已抓取";

                    //string HXOldPath = dataGridView1.Rows[i].Cells["F_abcd_PicPath"].Value.ToString();//画芯图库路径
                    //string HXNewPath = HXOldPath + "\\" + FMaterialName + ".jpg";//画芯图库路径带图片
                    string Path1 = "";
                    string NewPath1 = "";
                    string pjpath = "";
                    if (dataGridView1.Rows[i].Cells["F_abcd_PicPath"].Value.ToString() != "")
                    {
                        Path1 = dataGridView1.Rows[i].Cells["F_abcd_PicPath"].Value.ToString();//画芯图库路径
                        pjpath = Path1 + "\\" + FMaterialName;
                        if (FMaterialName.Contains("套") || FMaterialName.Contains("组合"))
                        {
                            foreach (System.IO.DriveInfo di in disk)
                            {
                                pf = di.Name;
                                if (Directory.Exists(pf + pjpath))
                                {
                                    NewPath1 = pf + pjpath;
                                }
                            }
                            string rootPath = string.Format(NewPath1);
                            if (Directory.Exists(TargetPath) == false)//如果移动后路径内没有该文件夹 
                            {
                                Directory.CreateDirectory(TargetPath);
                                CopyImg(rootPath);
                                JsonEdit(FID, IsGetPic, FEntryid);//修改状态为已修改
                            }
                            else
                            {
                                CopyImg(rootPath);
                                JsonEdit(FID, IsGetPic, FEntryid);//修改状态为已修改
                            }

                        }
                        else
                        {
                            pjpath = Path1 + "\\" + FMaterialName + ".jpg";
                            foreach (System.IO.DriveInfo di in disk)
                            {
                                pf = di.Name;
                                if (File.Exists(pf + pjpath))
                                {
                                    NewPath1 = pf + pjpath;
                                }
                            }
                            string Path2 = dataGridView1.Rows[i].Cells["F_abcd_CreatePath"].Value.ToString();//带单据编号路径
                            string HXNewPath1 = string.Format(NewPath1);//+ "\\" + FMaterialName + ".jpg"
                            string HXPath2 = string.Format(Path2 + "\\" + FBillNo);
                            string HXPic1 = string.Format(Path2 + "\\" + FBillNo + "\\" + FMaterialName + "_" + FSeq + ".jpg");
                            //图片生成路径
                            string TargerPathPic = string.Format(@"D:\订单图片生成" + "\\" + FolderName + "\\" + FMaterialName + "_" + FBillNo + "_" + FSeq + ".jpg");
                            if (File.Exists(HXNewPath1))
                            {

                                if (Directory.Exists(TargetPath) == false)//如果移动后路径内没有该文件夹 
                                {
                                    Directory.CreateDirectory(TargetPath);
                                    File.Copy(HXNewPath1, TargerPathPic);
                                    JsonEdit(FID, IsGetPic, FEntryid);//修改状态为已修改
                                }
                                else
                                {
                                    if (File.Exists(TargerPathPic) == false)
                                    {
                                        File.Copy(HXNewPath1, TargerPathPic);
                                        JsonEdit(FID, IsGetPic, FEntryid);//修改状态为已修改
                                    }
                                }
                            }
                            else
                            {
                                c++;
                            }
                        }
                    }
                }
            }

            if (!chec.Find(p => p))
            {
                DialogResult dr = MessageBox.Show("请勾选单据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dr = MessageBox.Show("生成成功,成功" + (f - c) + "条,失败" + c + "条", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            GetInfo_Click(sender, e);

        }
        /// <summary>
        /// 从图片地址下载图片到本地磁盘
        /// </summary>
        /// <param name="ToLocalPath">图片本地磁盘地址</param>
        /// <param name="Url">图片网址</param>
        /// <returns></returns>
        public static bool SavePhotoFromUrl(string FileName, string Url)
        {
            bool Value = false;
            WebResponse response = null;
            Stream stream = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);

                response = request.GetResponse();
                stream = response.GetResponseStream();

                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    Value = SaveBinaryFile(response, FileName);

                }
            }
            catch (Exception err)
            {
                string aa = err.ToString();
            }
            return Value;
        }

        /// <summary>
        /// Save a binary file to disk.  将二进制文件保存到磁盘
        /// </summary>
        /// <param name="response">The response used to save the file</param>
        private static bool SaveBinaryFile(WebResponse response, string FileName)
        {
            bool Value = true;
            byte[] buffer = new byte[1024];

            try
            {
                if (File.Exists(FileName))
                    File.Delete(FileName);
                Stream outStream = System.IO.File.Create(FileName);
                Stream inStream = response.GetResponseStream();

                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0)
                        outStream.Write(buffer, 0, l);
                }
                while (l > 0);

                outStream.Close();
                inStream.Close();
            }
            catch
            {
                Value = false;
            }
            return Value;
        }
        public Image GetImage(string path)
        {
            Image result;
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                result = System.Drawing.Image.FromStream(fs);
                fs.Close();
                return result;
            }
            else
            {
                result = null;
                return result;
            }

        }
        public static string JsonEdit(int FID, string IsGetPic, int FEntryId)
        {

            string strresult = string.Empty;
            //金蝶云组件
            K3CloudApiClient client = new K3CloudApiClient("http://47.119.190.7:8090/k3cloud/");
            var loginResult = client.Login(
                   "60d01a1379e237",
                   "administrator",
                   "888888",
                   2052);

            string result = "登录失败，请检查与站点地址、数据中心Id，用户名及密码！";

            if (loginResult == true)
            {
                // 开始构建Web API参数对象
                // 参数根对象：包含Creator、NeedUpDateFields、Model这三个子参数
                JObject jsonRoot = new JObject();
                jsonRoot.Add("IsDeleteEntry", false);
                // Model: 单据详细数据参数
                JObject model = new JObject();
                JObject modelentity = new JObject();

                JArray ja = new JArray();
                model.Add("FID", FID);//
                model.Add("FChangeReason", "123");
                jsonRoot.Add("Model", model);
                model.Add("FSaleOrderEntry", ja);
                // 单据主键：必须填写，系统据此判断是新增还是修改单据；新增单据，填0     

                modelentity.Add("FEntryID", FEntryId);
                modelentity.Add("F_ABCD_GETPIC", IsGetPic);//是否抓取画芯
                ja.Add(modelentity);

                // 调用Web API接口服务，保存即时库存汇总
                result = client.Execute<string>(
                    "Kingdee.BOS.WebApi.ServicesStub.DynamicFormService.Save",
                    new object[] { "SAL_SaleOrder", jsonRoot.ToString() });
            }
            return result;
        }
        /// <summary>
        /// 全选/全不选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((dataGridView1.Rows[i].Cells["Choose"].EditedFormattedValue.ToString().Trim()).Equals("False"))
                {
                    dataGridView1.Rows[i].Cells["Choose"].Value = true;
                }
                else if ((dataGridView1.Rows[i].Cells["Choose"].EditedFormattedValue.ToString().Trim()).Equals("True"))
                {
                    dataGridView1.Rows[i].Cells["Choose"].Value = false;
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
        }

        private void CopyImg(string path)//,string newpath
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            System.IO.DriveInfo[] disk = System.IO.DriveInfo.GetDrives();
            foreach (FileInfo file in files)
            {
                string fileName = file.Name;
                //string newpath = @"D:\订单图片生成\"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(":", ".") + "\\" + fileName;
                //file.CopyTo(newpath);
                string desPath = @"D:\订单图片生成\" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").Replace(":", "."); //定义转存的目录
                string filePath = desPath + "\\" + fileName;
                if (!Directory.Exists(desPath)) //判断是否存在目录
                {
                    Directory.CreateDirectory(desPath);
                }
                file.CopyTo(filePath, true); //执行复制,并且覆盖原文件
                //file.CopyTo(filePath);

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExportTOPdf(dataGridView1);
        }

        //public static class DataGridViewTOPdf
        //{
        ///
        /// 转换GridView为PDF文档    ///
        /// GridView
        /// 目标PDF文件名字
        /// 字体所在路径
        /// 字体大小
        /// 返回调用是否成功
        public void ExportTOPdf(DataGridView datagridview)
        {
            ///设置导出字体
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            string FontPath = path + "\\simsun.ttc";
            int FontSize = 12;
            if (File.Exists(FontPath))
            {
                FontPath += ",1";
            }
            else
            {
                MessageBox.Show("无法导出，因为无法取得中文宋体字型。");
                return;
            }


            Boolean cc = false;
            string strFileName;
            SaveFileDialog savFile = new SaveFileDialog();
            savFile.Filter = "PDF文件|.pdf";
            savFile.ShowDialog();
            if (savFile.FileName != "")
            {
                strFileName = savFile.FileName;
            }
            else
            {
                //MessageBox.Show("终止导出", "终止导出", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //初始化一个目标文档类       
            //Document document = new Document();
            //竖排模式,大小为A4，四周边距均为25
            //Document document = new Document(PageSize.A4, 25, 25, 25, 25);
            //横排模式,大小为A4，四周边距均为25
            Document document = new Document(PageSize.A4.Rotate(), 1, 1, 1,1);

            //调用PDF的写入方法流
            //注意FileMode-Create表示如果目标文件不存在，则创建，如果已存在，则覆盖。
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(strFileName, FileMode.Create));

            //创建PDF文档中的字体
            BaseFont baseFont = BaseFont.CreateFont(
                FontPath,
                BaseFont.IDENTITY_H,
                BaseFont.NOT_EMBEDDED);

            //根据字体路径和字体大小属性创建字体
            Font font = new Font(baseFont, FontSize);

            // 添加页脚
            // HeaderFooter footer = new HeaderFooter(new Phrase("-- ", font), new Phrase(" --", font));
            //footer.Border = Rectangle.NO_BORDER;        // 不显示两条横线
            //footer.Alignment = Rectangle.UNDEFINED;  // 让页码居中
            //document.Footer = footer;

            //打开目标文档对象
            document.Open();

            int ColCount = 0;

            //根据数据表内容创建一个PDF格式的表
            for (int j = 0; j < 8; j++)//datagridview.Columns.Count
            {
                if (datagridview.Columns[j].Visible == true)
                {
                    ColCount++;
                }
            }
            PdfPTable table = new PdfPTable(ColCount);
            

            
            int[] TableWidths = { 20,10, 20, 10, 10,10,10,10 };//按百分比分配单元格宽带
            table.SetWidths(TableWidths);
            table.TotalWidth = 800;//设置绝对宽度
            table.LockedWidth = true;//使绝对宽度模式生效
            

            // GridView的所有数据全输出
            //datagridview.AllowPaging = false;

            // ---------------------------------------------------------------------------
            // 添加表头
            // ---------------------------------------------------------------------------
            // 设置表头背景色
            //table.DefaultCell.BackgroundColor = Color.GRAY;  // OK
            //table.DefaultCell.BackgroundColor = (iTextSharp.text.Color)System.Drawing.Color.FromName("#3399FF"); // NG
            //table.DefaultCell.BackgroundColor = iTextSharp.text.Color;

            //table.DefaultCell.BackgroundColor = BaseColor.BLUE;

            // 添加表头，每一页都有表头
            //for (int j = 0; j < 7; j++)//datagridview.Columns.Count
            //{
            //    if (datagridview.Columns[j].Visible == true)
            //    {
            //        table.AddCell(new Phrase(datagridview.Columns[j].HeaderText, font));
            //    }
            //}
            int[] list = { 2,4, 5, 6, 7, 8, 10, 20 };
            foreach (var item in list)
            {
                if (datagridview.Columns[item].Visible == true)
                {
                    table.AddCell(new Phrase(datagridview.Columns[item].HeaderText, font));
                }
            }

            // 告诉程序这行是表头，这样页数大于1时程序会自动为你加上表头。
            table.HeaderRows = 1;
            //
            // ---------------------------------------------------------------------------
            // 添加数据
            // ---------------------------------------------------------------------------
            // 设置表体背景色
            table.DefaultCell.BackgroundColor = BaseColor.WHITE;
            
            //遍历原gridview的数据行
            //写内容  
            int[] k = { 3,4,  5,6, 7, 8, 10, 20 };//, 6
            for (int j = 0; j < datagridview.Rows.Count; j++)
            {
                #region
                //foreach (var item in list)
                //{
                //    if (datagridview.Rows[j].Cells[item].Visible == true)
                //    {
                //        try
                //        {
                //            string value = "";
                //            if (datagridview.Rows[j].Cells[item].Value != null)
                //            {
                //                if (item == 1)
                //                {
                //                    //var ss = ImageFile2Base64(sltPath[j]);
                //                    //var ss = ImageFile2Base64(@"D:\画芯缩略图缓存\听海E.JPG");
                //                    //ConvertBase64ToImage(ss);
                //                    //ConvertBase64ToImage(ss);
                //                    //GetImage(sltPath[j]);
                //                    //value = sltPath[j];
                //                    PdfPCell cell;
                //                    cell = new PdfPCell(new Phrase());
                //                    iTextSharp.text.Image imgCIE = iTextSharp.text.Image.GetInstance(sltPath[j]);
                //                    //imgCIE.ScaleToFit(618f,281f);
                //                    cell.AddElement(new Chunk(imgCIE, 0, 0));
                //                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                //                    table.AddCell(cell);

                //                }
                //                else
                //                {
                //                    value = datagridview.Rows[j].Cells[item].Value.ToString();
                //                }
                //                table.AddCell(new Phrase(value, font));
                //            }

                //        }
                //        catch (Exception e)
                //        {
                //            //MessageBox.Show(e.Message);
                //            cc = true;
                //        }
                //    }
                //}
                #endregion
                if (dataGridView1.Rows[j].Cells[0].Visible==true)
                {
                    string value = "";
                    foreach (var s in k)
                    {
                        if (datagridview.Rows[j].Cells[s].Value != null)
                        {
                            if (s == 3)
                            {
                                PdfPCell cell;
                                cell = new PdfPCell(new Phrase());
                                iTextSharp.text.Image imgCIE = iTextSharp.text.Image.GetInstance(sltPath[j]);
                                imgCIE.ScaleToFit(618f,281f);
                                cell.AddElement(new Chunk(imgCIE, 0, 0));
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                                //table.TotalWidth = 500L;
                                //table.LockedWidth = true;
                                table.DefaultCell.MinimumHeight = 150;
                                table.AddCell(cell);
                            }
                            else
                            {
                                value = datagridview.Rows[j].Cells[s].Value.ToString();
                                //table.TotalWidth = 300L;
                                //table.LockedWidth = true;
                                table.DefaultCell.MinimumHeight = 150;
                                table.AddCell(new Phrase(value, font));

                            }
                        }
                       
                    }
                    
                }

                //for (int k = 0; k < 7; k++)// datagridview.Columns.Count
                //{
                //    if (datagridview.Rows[j].Cells[k].Visible == true)
                //    {
                //        try
                //        {
                //            string value = "";
                //            if (datagridview.Rows[j].Cells[k].Value != null)
                //            {
                //                if (k == 2)
                //                {
                //                    //var ss = ImageFile2Base64(sltPath[j]);
                //                    //var ss = ImageFile2Base64(@"D:\画芯缩略图缓存\听海E.JPG");
                //                    //ConvertBase64ToImage(ss);
                //                    //ConvertBase64ToImage(ss);
                //                    //GetImage(sltPath[j]);
                //                    //value = sltPath[j];
                //                    PdfPCell cell;
                //                    cell = new PdfPCell(new Phrase());
                //                    iTextSharp.text.Image imgCIE = iTextSharp.text.Image.GetInstance(sltPath[j]);
                //                    //imgCIE.ScaleToFit(618f,281f);
                //                    cell.AddElement(new Chunk(imgCIE, 0, 0));
                //                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                //                    cell.VerticalAlignment = Element.ALIGN_BOTTOM;
                //                    table.AddCell(cell);

                //                }
                //                else
                //                {
                //                    value = datagridview.Rows[j].Cells[k].Value.ToString();
                //                }
                //                table.AddCell(new Phrase(value, font));
                //            }

                //        }
                //        catch (Exception e)
                //        {
                //            //MessageBox.Show(e.Message);
                //            cc = true;
                //        }
                //    }   
                //}
            }
            //在目标文档中添加转化后的表数据
            document.Add(table);
            //关闭目标文件
            document.Close();
            //关闭写入流
            writer.Close();
            // Dialog
            if (!cc)
            {
                MessageBox.Show("已生成PDF文件。", "生成成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //}


        String ImageFile2Base64(String imageFile)
        {
            Image image = Image.FromFile(imageFile);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] byteArray = ms.ToArray();
            ms.Close();
            return Convert.ToBase64String(byteArray);
        }

      
        public Image ConvertBase64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }

    }

    class Sal_Order
    {
        /// <summary>
        /// 抓取画芯状态
        /// </summary>
        public string F_abcd_GetPic { get; set; }
        /// <summary>
        /// 行备注
        /// </summary>
        public string FEntryNote { get; set; }
        /// <summary>
        /// 简称      
        /// </summary>
        public string F_abcd_MnemonicCode { get; set; }
        /// <summary>
        /// 生产线（整合）
        /// </summary>
        public string F_abcd_SCLine { get; set; }
        /// <summary>
        /// 规格描述
        /// </summary>
        public string F_explain { get; set; }
        /// <summary>
        /// 框颜色
        /// </summary>
        public string F_OutlineColor { get; set; }
        /// <summary>
        /// 框材质
        /// </summary>
        public string F_OutlineQuality { get; set; }
        /// <summary>
        /// 配货日期
        /// </summary>
        public string F_abcd_GYPeiHuotime { get; set; }
        /// <summary>
        /// 日期
        /// </summary>
        public string FDate { get; set; }
        /// <summary>
        /// 客户
        /// </summary>
        public string FCustId { get; set; }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string FBillNo { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public string FSOStockId { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string FMaterialName { get; set; }
        /// <summary>
        /// 规格型号  
        /// </summary>
        public string FMaterialModel { get; set; }
        /// <summary>
        /// 有无玻璃   
        /// </summary>
        public string F_glass { get; set; }
        /// <summary>
        /// 外框     
        /// </summary>
        public string F_Outline { get; set; }
        /// <summary>
        /// 类型      
        /// </summary>
        public string F_type { get; set; }
        
        /// <summary>
        /// 销售数量      
        /// </summary>
        public string FQty { get; set; }
        /// <summary>
        /// 销售单位      
        /// </summary>
        public string FUnitID { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string FMaterialId { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string F_abcd_Picurl { get; set; }
        /// <summary>
        /// 画芯图库路径
        /// </summary>
        public string F_abcd_PicPath { get; set; }
        /// <summary>
        /// 图片生成路径
        /// </summary>
        public string F_abcd_CreatePath { get; set; }
        /// <summary>
        /// 缩略图缓存路径
        /// </summary>
        public string F_abcd_CachePath { get; set; }
        /// <summary>
        /// 单据体序号
        /// </summary>
        public string FSeq { get; set; }

        /// <summary>
        /// 单据头内码
        /// </summary>
        public string FID { get; set; }
        /// <summary>
        /// 单据体内码
        /// </summary>
        public string FEntryid { get; set; }

    }
}

