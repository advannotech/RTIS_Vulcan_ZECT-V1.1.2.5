using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_ZECT.Classes
{
    public class GlobalVars
    {
        public static string sep = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

        public static Control lastControl;
        public static string RSCFolder = string.Empty;
        public static string SettingsDB = string.Empty;
        public static string Printer = string.Empty;
        public static TextEdit focusedEdit = new TextEdit();
        public enum msgState { Error, Success, Question, First, Info }
        public static string userName { get; set; }
        public enum CoatNumber { first, second, third, forth }
        public enum AppState { AddSlurry, PrintTags, CloseJob, ReOpenJob }
        public static AppState currentState { get; set; }
        public enum reOpenTye { Scan, Manual}
        public static reOpenTye currentReopenType { get; set; }
        public static XtraReport configTag { get; set; }
        public static XtraReport zectTag { get; set; }

        #region Settings
        public static string ServerIP { get; set; }
        public static string ServerPort { get; set; }
        public static string zectWhse { get; set; }
        public static string zectIT { get; set; }
        public static string configLoc { get; set; }
        public static string zectLoc { get; set; }
        public static string lotLookupPeriod { get; set; }
        #endregion

        #region Open Job
        public static string OJCheckSheet { get; set; }
        public static string OJLotNumber { get; set; }
        public static CoatNumber OJCoatNumber { get; set; }
        public static string OJSlurry { get; set; }
        public static string OJSlurryLot { get; set; }

        public static string OJSlurryTankType { get; set; }
        public static string OJSlurryTank { get; set; }
        public static string OJWetWeight { get; set; }
        public static string OJDryWeight { get; set; }
        #endregion

        #region Reprint Job Tags
        public static string RPjobNo { get; set; }
        public static string RPitem { get; set; }
        public static string RPLotNumber { get; set; }
        public static CoatNumber RPCoatNumber { get; set; }
        #endregion

        #region Add Slurry
        public static string ASjobNo { get; set; }
        public static string ASitemCode { get; set; }
        public static string ASlotNumber { get; set; }
        public static string ASslurryCode { get; set; }
        public static string AScoatNum { get; set; }
        public static string ASslurryLot { get; set; }
        public static string ASslurryTankType { get; set; }
        public static string ASslurryTank { get; set; }
        public static string ASslurryWetWeight { get; set; }
        public static string ASslurryDryWeight { get; set; }
        #endregion

        #region Print Tags
        public static string PTjobNo { get; set; }
        public static string PTitemCode { get; set; }
        public static string PTlotNumber { get; set; }
        public static string PTcoatNumber { get; set; }
        public static string PTjobQty { get; set; }
        public static string PTmanufQty { get; set; }
        #endregion

        #region Close Job
        public static string CJjobNo { get; set; }
        #endregion

        #region Reopen Job
        public static string ROjobNo { get; set; }
        public static string ROitem { get; set; }
        public static string ROcoat { get; set; }
        public static string ROLotNumber { get; set; }

        public static CoatNumber ROCoatNumber { get; set; }
        #endregion
    }
}
