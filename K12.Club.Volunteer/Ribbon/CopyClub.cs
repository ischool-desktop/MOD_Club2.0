﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FISCA.Presentation.Controls;
using FISCA.Data;
using FISCA.UDT;
using K12.Data;

namespace K12.Club.Volunteer
{
    public partial class CopyClub : BaseForm
    {
        BackgroundWorker BGW = new BackgroundWorker();

        //不複製欄位：社員 / 社長 / 副社長

        AccessHelper _AccessHelper = new AccessHelper();
        QueryHelper _QueryHelper = new QueryHelper();

        bool StudentCopy = false;
        bool CadresCopy = false;

        int _SchoolYear = 90;
        int _Semester = 1;

        /// <summary>
        /// 所要拷貝的社團
        /// </summary>
        List<CLUBRecord> Copylist = new List<CLUBRecord>();
        /// <summary>
        /// 重覆需要移除的社團
        /// </summary>
        List<string> removelist = new List<string>();

        /// <summary>
        /// 所要複製的社團
        /// </summary>
        List<CLUBRecord> newInsertList = new List<CLUBRecord>();

        /// <summary>
        /// 所要複製的社團幹部
        /// </summary>
        List<CadresRecord> newInsertCadresList = new List<CadresRecord>();

        List<SCJoin> ScjStudentList = new List<SCJoin>();

        List<CadresRecord> CadreStudentList = new List<CadresRecord>();

        List<SCJoin> insertSCJList = new List<SCJoin>();

        List<CadresRecord> insertCadreList = new List<CadresRecord>();

        public CopyClub()
        {
            InitializeComponent();
        }

        private void CopyClub_Load(object sender, EventArgs e)
        {
            if (!CheckSelectClubIsIdentical())
                MsgBox.Show("欲複製之社團,不可來自不同學年度/學期");

            SetNextSchoolYear();

            BGW.DoWork += new DoWorkEventHandler(BGW_DoWork);
            BGW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BGW_RunWorkerCompleted);
        }

        /// <summary>
        /// 設定學年度學期呈現資訊
        /// </summary>
        private void SetNextSchoolYear()
        {
            string TitleText = "所選擇的社團為　" + _SchoolYear + "學年度　第" + _Semester + "學期";
            lbHelp2.Text = TitleText;

            if (_Semester == 1)
            {
                _Semester++;
            }
            else
            {
                _SchoolYear++;
                _Semester--;
            }

            intSchoolYear.Value = _SchoolYear;
            intSemester.Value = _Semester;
        }

        /// <summary>
        /// 檢查所選社團是否為相同學年度/學期
        /// </summary>
        private bool CheckSelectClubIsIdentical()
        {
            bool IsTrue = true;
            string stringUDT = string.Join("','", ClubAdmin.Instance.SelectedSource);
            Copylist = _AccessHelper.Select<CLUBRecord>("uid in ('" + stringUDT + "')");
            if (Copylist.Count > 0)
            {
                _SchoolYear = Copylist[0].SchoolYear;
                _Semester = Copylist[0].Semester;

                foreach (CLUBRecord each in Copylist)
                {
                    if (_SchoolYear == each.SchoolYear && _Semester == each.Semester)
                        continue;

                    IsTrue = false;
                }
            }
            return IsTrue;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!BGW.IsBusy)
            {
                btnStart.Enabled = false;
                intSchoolYear.Enabled = false;
                intSemester.Enabled = false;

                StudentCopy = checkBoxX1.Checked;
                CadresCopy = checkBoxX2.Checked;

                _SchoolYear = intSchoolYear.Value;
                _Semester = intSemester.Value;

                BGW.RunWorkerAsync();
            }
            else
            {
                MsgBox.Show("忙碌中請稍後再試...");
            }
        }

        void BGW_DoWork(object sender, DoWorkEventArgs e)
        {

            //檢查目標學年期,是否有相同名稱之社團資料
            //如果有則移除該社團
            //並透過覆製功能進行新增動作
            removelist = CheckOldReMoveClub();
            Dictionary<string, List<SCJoin>> studentSCJDic = new Dictionary<string, List<SCJoin>>();

            if (StudentCopy)
            {
                //取得原有社團之學生社團記錄
                ScjStudentList = _AccessHelper.Select<SCJoin>(string.Format("ref_club_id in ('{0}')", string.Join("','", ClubAdmin.Instance.SelectedSource)));

                foreach (SCJoin each in ScjStudentList)
                {
                    if (!studentSCJDic.ContainsKey(each.RefClubID))
                    {
                        studentSCJDic.Add(each.RefClubID, new List<SCJoin>());
                    }
                    studentSCJDic[each.RefClubID].Add(each);
                }
            }

            Dictionary<string, List<CadresRecord>> studentCadreDic = new Dictionary<string, List<CadresRecord>>();
            if (CadresCopy)
            {
                //取得原有社團之學生社團記錄
                CadreStudentList = _AccessHelper.Select<CadresRecord>(string.Format("ref_club_id in ('{0}')", string.Join("','", ClubAdmin.Instance.SelectedSource)));

                foreach (CadresRecord each in CadreStudentList)
                {
                    if (!studentCadreDic.ContainsKey(each.RefClubID))
                    {
                        studentCadreDic.Add(each.RefClubID, new List<CadresRecord>());
                    }
                    studentCadreDic[each.RefClubID].Add(each);
                }
            }

            int LogSchoolYear = 90;
            int LogSemester = 1;

            if (Copylist.Count > 0)
            {
                LogSchoolYear = Copylist[0].SchoolYear;
                LogSemester = Copylist[0].Semester;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("已進行複製社團作業：");
            sb.AppendLine(string.Format("由學年度「{0}」學期「{1}」複製至學年度「{2}」學期「{3}」", LogSchoolYear.ToString(), LogSemester.ToString(), _SchoolYear.ToString(), _Semester.ToString()));
            if (StudentCopy)
            {
                sb.AppendLine("(已勾選複製學生選項)");
            }
            sb.AppendLine("");
            sb.AppendLine("新學期社團清單如下：");

            foreach (CLUBRecord each in Copylist)
            {
                #region 複製社團基本資料

                //如果是重覆社團則不處理
                if (removelist.Contains(each.ClubName))
                    continue;

                //是否複製學生
                if (StudentCopy)
                {
                    CopyClubRecord new_ccr = new CopyClubRecord(each);
                    if (studentSCJDic.ContainsKey(each.UID))
                    {
                        new_ccr.SetSCJ(studentSCJDic[each.UID]);
                    }
                }

                CLUBRecord cr = new CLUBRecord();
                cr.About = each.About;
                cr.ClubNumber = each.ClubNumber;
                cr.ClubCategory = each.ClubCategory;
                cr.ClubName = each.ClubName;
                cr.DeptRestrict = each.DeptRestrict;
                cr.GenderRestrict = each.GenderRestrict;
                cr.Grade1Limit = each.Grade1Limit;
                cr.Grade2Limit = each.Grade2Limit;
                cr.Grade3Limit = each.Grade3Limit;
                cr.Limit = each.Limit;
                cr.Location = each.Location;
                cr.Photo1 = each.Photo1;
                cr.Photo2 = each.Photo2;
                cr.RefTeacherID = each.RefTeacherID;
                cr.RefTeacherID2 = each.RefTeacherID2;
                cr.RefTeacherID3 = each.RefTeacherID3;

                if (CadresCopy)
                {
                    //社長,副社長
                    cr.President = each.President;
                    cr.VicePresident = each.VicePresident;

                    //處理其它幹部

                    //newInsertCadresList
                }

                //使用者所設定之學年度學期
                cr.SchoolYear = _SchoolYear;
                cr.Semester = _Semester;
                newInsertList.Add(cr);

                sb.AppendLine(string.Format("學年度「{0}」學期「{1}」社團名稱「{2}」", cr.SchoolYear.ToString(), cr.Semester.ToString(), cr.ClubName));


                #endregion

            }

            //新增之社團ID
            List<string> IDList = new List<string>();

            try
            {
                IDList = _AccessHelper.InsertValues(newInsertList);
            }
            catch (Exception ex)
            {
                SmartSchool.ErrorReporting.ReportingService.ReportException(ex);
                e.Cancel = true;
                return;
            }

            FISCA.LogAgent.ApplicationLog.Log("社團", "複製社團", sb.ToString());

            //取得社團
            List<CLUBRecord> ListInsertRecord = _AccessHelper.Select<CLUBRecord>(string.Format("UID in('{0}')", string.Join("','", IDList)));
            //如果有勾選複製社團
            //要把複製的社團取得ID,並且比隊其對應的原社團
            if (StudentCopy)
            {
                #region 複製社團學生

                if (IDList.Count != 0)
                {

                    //建立學生的社團記錄Record
                    //所要複製的社團
                    List<CopyClubRecord> new_list = new List<CopyClubRecord>();
                    foreach (CLUBRecord each1 in Copylist)
                    {
                        CopyClubRecord new_ccr = new CopyClubRecord(each1);
                        if (studentSCJDic.ContainsKey(each1.UID))
                        {
                            new_ccr.SetSCJ(studentSCJDic[each1.UID]);
                            new_list.Add(new_ccr);
                        }
                    }

                    foreach (CLUBRecord each in ListInsertRecord)
                    {
                        foreach (CopyClubRecord each2 in new_list)
                        {
                            if (each.ClubName == each2._Club.ClubName)
                            {
                                each2._new_Club = each;
                                break;
                            }
                        }
                    }

                    //新增社團清單
                    insertSCJList = new List<SCJoin>();
                    foreach (CopyClubRecord each in new_list)
                    {
                        insertSCJList.AddRange(each.GetNewSCJoinList());
                    }

                    try
                    {
                        _AccessHelper.InsertValues(insertSCJList);
                    }
                    catch (Exception ex)
                    {
                        SmartSchool.ErrorReporting.ReportingService.ReportException(ex);
                        e.Cancel = true;
                        return;
                    }
                }

                #endregion
            }

            if (CadresCopy)
            {
                #region 複製社團幹部 -2

                if (IDList.Count != 0)
                {
                    List<CopyClubRecord> new_list = new List<CopyClubRecord>();
                    foreach (CLUBRecord each1 in Copylist)
                    {
                        CopyClubRecord new_ccr = new CopyClubRecord(each1);
                        if (studentCadreDic.ContainsKey(each1.UID))
                        {
                            new_ccr.SetSCJ(studentCadreDic[each1.UID]);
                            new_list.Add(new_ccr);
                        }
                    }

                    foreach (CLUBRecord each in ListInsertRecord)
                    {
                        foreach (CopyClubRecord each2 in new_list)
                        {
                            if (each.ClubName == each2._Club.ClubName)
                            {
                                each2._new_Club = each;
                                break;
                            }
                        }
                    }

                    //新增社團清單
                    insertCadreList = new List<CadresRecord>();
                    foreach (CopyClubRecord each in new_list)
                    {
                        insertCadreList.AddRange(each.GetNewCadresList());
                    }

                    try
                    {
                        _AccessHelper.InsertValues(insertCadreList);
                    }
                    catch (Exception ex)
                    {
                        SmartSchool.ErrorReporting.ReportingService.ReportException(ex);
                        e.Cancel = true;
                        return;
                    }
                }

                #endregion
            }
        }

        private List<string> CheckOldReMoveClub()
        {
            List<string> list_2 = new List<string>();
            List<CLUBRecord> list = _AccessHelper.Select<CLUBRecord>(string.Format("school_year={0} and semester={1}", _SchoolYear, _Semester));

            foreach (CLUBRecord each1 in Copylist)
            {
                foreach (CLUBRecord each2 in list)
                {
                    if (each1.ClubName == each2.ClubName)
                    {
                        list_2.Add(each2.ClubName);
                        break;
                    }
                }
            }
            return list_2;
        }

        void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MsgBox.Show("複製社團操作已中止!!");
                return;
            }

            if (e.Error != null)
            {
                MsgBox.Show("複製社團失敗!\n" + e.Error.Message);
                SmartSchool.ErrorReporting.ReportingService.ReportException(e.Error);
                return;
            }

            if (removelist.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("共" + newInsertList.Count + "個社團複製成功!!\n");
                sb.AppendLine("共" + removelist.Count + "個重覆社團,已略過處理!!");
                if (StudentCopy)
                {
                    sb.AppendLine("已同步建立" + insertSCJList.Count + "名學生的社團參與記錄!!");
                }

                if (CadresCopy)
                {
                    sb.AppendLine("已同步建立學生的社團幹部記錄!!");
                }

                sb.AppendLine(string.Join(",", removelist));

                MsgBox.Show(sb.ToString());
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("共" + newInsertList.Count + "個社團複製成功!!\n");
                if (StudentCopy)
                {
                    sb.AppendLine("已同步建立" + insertSCJList.Count + "名學生的社團參與記錄!!");
                }

                if (CadresCopy)
                {
                    sb.AppendLine("已同步建立學生的社團幹部記錄!!");
                }

                MsgBox.Show(sb.ToString());
            }

            ClubEvents.RaiseAssnChanged();
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxX2.Enabled = checkBoxX1.Checked;
            if (checkBoxX1.Checked == false)
            {
                checkBoxX2.Checked = false;
            }
        }
    }
}
