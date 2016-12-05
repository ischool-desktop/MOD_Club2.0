﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Campus.DocumentValidator;
using FISCA.Data;

namespace K12.Club.Volunteer
{
    /// <summary>
    /// 檢查系統中是否社團名稱/學年度/學期重覆
    /// </summary>
    public class CLUBVolunteerNameCheck : IRowVaildator
    {
        Dictionary<string, CLUBRecord> ClubDic;
        int 學生選填志願數;

        public CLUBVolunteerNameCheck()
        {
            ClubDic = new Dictionary<string, CLUBRecord>();
            List<CLUBRecord> CLUBList = tool._A.Select<CLUBRecord>();
            foreach (CLUBRecord each in CLUBList)
            {
                string CourseKey = each.SchoolYear + "," + each.Semester + "," + each.ClubName;
                if (!ClubDic.ContainsKey(CourseKey))
                {
                    ClubDic.Add(CourseKey, each);
                }
            }

            學生選填志願數 = GetVolunteerData.GetVolumnteerCount();
        }

        #region IRowVaildator 成員

        public bool Validate(IRowStream Value)
        {
            bool check = true;
            for (int x = 1; x <= 學生選填志願數; x++)
            {
                if (Value.Contains("學年度") && Value.Contains("學期") && Value.Contains("志願" + x))
                {
                    string SchoolYear = Value.GetValue("學年度");
                    string Semester = Value.GetValue("學期");
                    string CourseName = Value.GetValue("志願" + x);
                    if (!string.IsNullOrEmpty(CourseName))
                    {
                        string CourseKey = SchoolYear + "," + Semester + "," + CourseName;

                        if (!ClubDic.ContainsKey(CourseKey))
                        {
                            check = false;
                        }
                    }
                }
            }

            return check;
        }

        /// <summary>
        /// 沒有提供自動修正
        /// </summary>
        public string Correct(IRowStream Value)
        {
            return string.Empty;
        }

        /// <summary>
        /// 傳回預設樣版
        /// </summary>
        public string ToString(string template)
        {
            return template;
        }

        #endregion
    }
}