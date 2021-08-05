using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RTIS_Vulcan_ZECT.Classes
{
    class Client
    {
        public static string Login(string pin)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTLOGIN*@" + pin);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*Cannot connect to server:" + System.Environment.NewLine + ex.Message;
            }
        }

        #region Open Job
        public static string GetMFItemCode(string itemCode)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMFITEMCODEZECT*@" + itemCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetCatalystSlurries(string itemCode)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETCOATSLURRIES*@" + itemCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetSlurryLots(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETSLURRYLOTSONHANDFROMTANK*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetSlurryTanks(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETSLURRYLOTTANK*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string ZectOpenJob(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*OPENZECTJOBCARDWITHSLURRYTANK*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        #endregion

        #region check coats

        #endregion

        #region Reprint Job Tags
        public static string getReprintJobCoats(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTREPRINTGETCOATS*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string getReprintJobLots(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETREPRINTJOBLOTS*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReprintJobNumber(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTREPRINTGETJOBNO*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReprintJobInfo(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETREPRINTJOBINFO*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReprintLabelInfo(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETREREPRINTJOBLABElINFO*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        #endregion

        #region Add Slurry
        public static string ZectGetJobInfo(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETJOBSLURRY*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetAddSlurryLots(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                // ZECTGETADDSLURRYLOTS
                sendbytes = ascenc.GetBytes("*ZECTGETADDSLURRYLOTSFROMTANK*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string AddZectSlurry(string itemInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);
                // ZECTSLURRYADDITION
                sendbytes = ascenc.GetBytes("*ZECTSLURRYADDITIONFROMTANK*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        #endregion

        #region Print Tags
        public static string GetPTJobInfo(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETJOBINFO*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string PrintPalletTag(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTLOGPALLETPRINTED*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReprintTags(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETREPRINTPALLETS*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetRerintTagInfo(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETTAGREPRINTINFO*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }

        #endregion

        #region Close Job
        public static string GetJobRunning(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETJOBRUNNING*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetUserPermissions(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETUSERPERMS*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetClosingJobInfo(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETCLOSINGJOBINFO*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string CloseJob(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTCLOSEJOB*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        #endregion
       
        #region Re Open Job
        public static string checkJobOnLine(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTREOPENCHECKJOBONLINE*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string checkJobClosed(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTREOPENCHECkJOBSTATE*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetUserPermissionsReOpen(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETUSERPERMSREOPEN*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReOpenCoats(string itemCode)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETREOPENCATALYSTCOATS*@" + itemCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReOpenLots(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETVALIDJOBLOTS*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReOpenJobNumber(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETREOPENJOBNUMBER*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReOpenJobInfo(string jobTag)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTGETREOPENJOBINFO*@" + jobTag);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string ReOpenJob(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ZECTREOPENJOB*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        public static string GetReOpenJobLabelInfo(string jobInfo)
        {
            string ServerDetails = "";

            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                DataClient.SendTimeout = 30000;
                DataClient.ReceiveTimeout = 30000;

                //Send start request
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETREOPENJOBLABElINFO*@" + jobInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-2*" + ex.Message;
            }
        }
        #endregion
    }
}
