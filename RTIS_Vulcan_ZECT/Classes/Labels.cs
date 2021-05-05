﻿using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIS_Vulcan_ZECT.Classes
{
    public class Labels
    {
        public static string setupConfigTag()
        {
            try
            {
                string labelName = string.Empty;
                DirectoryInfo configDirectory = new DirectoryInfo(GlobalVars.configLoc);
                FileInfo[] allLabels = configDirectory.GetFiles("*.repx");
                foreach (FileInfo label in allLabels)
                {
                    labelName = label.Name;                   
                }

                if (labelName != string.Empty)
                {
                    GlobalVars.configTag = XtraReport.FromFile(GlobalVars.configLoc + labelName, true);
                    return "1*Success";
                }
                else
                {
                    return "0*No config tags found in the seleced location";
                }
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }

        public static string setupZectTag()
        {
            try
            {
                string labelName = string.Empty;
                DirectoryInfo configDirectory = new DirectoryInfo(GlobalVars.zectLoc);
                FileInfo[] allLabels = configDirectory.GetFiles("*.repx");
                foreach (FileInfo label in allLabels)
                {
                    labelName = label.Name;
                }

                if (labelName != string.Empty)
                {
                    GlobalVars.zectTag = XtraReport.FromFile(GlobalVars.zectLoc + labelName, true);
                    return "1*Success";
                }
                else
                {
                    return "0*No zect tags found in the seleced location";
                }
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
    }
}
