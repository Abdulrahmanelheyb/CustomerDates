using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Media;

namespace CustomerDates.Classes
{
    public class DataManagment
    {
        #region Insert
        private static int devicescnt()
        {
            int cnt = 0;
            SQLiteConnection con = new SQLiteConnection(Globals.DBPath);
            try
            {
                con.Open();
                SQLiteCommand cmdi = new SQLiteCommand("SELECT devcount FROM sysure", con);
                SQLiteDataReader sdr = cmdi.ExecuteReader();
                while (sdr.Read())
                {
                    cnt = sdr.GetInt32(0);
                }
                con.Close();

                con.Open();
                SQLiteCommand cmdu = new SQLiteCommand("UPDATE sysure SET devcount=@devcnt WHERE CDID='CD1'", con);
                cmdu.Parameters.AddWithValue("@devcnt", cnt++);
                cmdu.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("|ERROR-DB|\n" + ex.Message);
            }
            return cnt;
        }

        public static void Execute_InsertDevice(string tablename, List<object> devdata)
        {
            try
            {
                if (devicescnt() == 100)
                {
                    MessageBox.Show("Device Limit Is Expired \nPlease Contact With AE3 Company.");
                }
                
                if (devdata == null)
                {
                    return;
                }
                SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + tablename +
                        " (Infopren_Code,Serial_Number,CD_Name,CD_Phone,CD_Externals,CD_Device_company,CD_Model," +
                        "CD_Price,CD_Date,CD_Status)" +
                        " VALUES (@Infopren_Code,@Serial_Number,@CD_Name,@CD_Phone,@CD_Externals,@CD_Device_company," +
                        "@CD_Model,@CD_Price,@CD_Date,@CD_Status)", connect);

                    cmd.Parameters.AddWithValue("@Infopren_Code", devdata[0]);
                    cmd.Parameters.AddWithValue("@Serial_Number", devdata[1]);
                    cmd.Parameters.AddWithValue("@CD_Name", devdata[2]);
                    cmd.Parameters.AddWithValue("@CD_Phone", Convert.ToInt64(devdata[3]));
                    cmd.Parameters.AddWithValue("@CD_Externals", devdata[4]);
                    cmd.Parameters.AddWithValue("@CD_Device_company", devdata[5]);
                    cmd.Parameters.AddWithValue("@CD_Model", devdata[6]);
                    cmd.Parameters.AddWithValue("@CD_Price", Convert.ToInt32(devdata[7]));
                    cmd.Parameters.AddWithValue("@CD_Date", devdata[8]);
                    cmd.Parameters.AddWithValue("@CD_Status", devdata[9]);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    devicescnt();
                    CheckBooleans.execute_insert = true;
                }
                else { MessageBox.Show("|Error-INSERT| : Database not connected"); return; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("|Error-INSERT|\n" + ex.Message);
            }
        }
        public static void Execute_InsertPart(string tableaname)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            try
            {
                connect.Open();
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("INSERT INTO " + tableaname + " (Infopren_Code,Parttype" +
                        ",Description,Price,Status) " +
                        "VALUES (@Infopren_Code,@Parttype,@Description,@Price,@Status)", connect);
                    cmd.Parameters.AddWithValue("@Infopren_Code", Globals.infoprencode);


                    if (CheckBooleans.hwaretab == true)
                    {
                        if (HardwareParts.Parttype != null)
                        {
                            cmd.Parameters.AddWithValue("@Parttype", HardwareParts.Parttype);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Part Type|"); return; }

                        if (HardwareParts.Description != null)
                        {
                            cmd.Parameters.AddWithValue("@Description", HardwareParts.Description);
                        }
                        else { cmd.Parameters.AddWithValue("@Description", DBNull.Value); }

                        if (HardwareParts.Price != 0)
                        {
                            cmd.Parameters.AddWithValue("@Price", HardwareParts.Price);
                        }
                        else { cmd.Parameters.AddWithValue("@Price", 0); }


                        if (HardwareParts.Status != null)
                        {
                            cmd.Parameters.AddWithValue("@Status", HardwareParts.Status);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Status|"); return; }

                        cmd.ExecuteNonQuery();
                        connect.Close();

                    }

                    if (CheckBooleans.swarretab == true)
                    {
                        if (SoftwareParts.Parttype != null)
                        {
                            cmd.Parameters.AddWithValue("@Parttype", SoftwareParts.Parttype);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Part Type|"); return; }

                        if (SoftwareParts.Description != null)
                        {
                            cmd.Parameters.AddWithValue("@Description", SoftwareParts.Description);
                        }
                        else { cmd.Parameters.AddWithValue("@Description", DBNull.Value); }

                        if (SoftwareParts.Price != 0)
                        {
                            cmd.Parameters.AddWithValue("@Price", SoftwareParts.Price);
                        }
                        else { cmd.Parameters.AddWithValue("@Price", 0); }


                        if (SoftwareParts.Status != null)
                        {
                            cmd.Parameters.AddWithValue("@Status", SoftwareParts.Status);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Status|"); return; }

                        cmd.ExecuteNonQuery();
                        connect.Close();
                    }

                }
                else { MessageBox.Show("|Error-DB| : Database not connected"); return; }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Delete
        public static void DeleteMSG(string tbname)
        {
            if (MessageBox.Show("You are realy need delete is device ?", "Warring", MessageBoxButton.OKCancel, MessageBoxImage.Warning, MessageBoxResult.OK) == MessageBoxResult.OK)
            {
                Execute_Delete(tbname);

            }
            else
            {
                return;
            }
        }

        public static void Execute_Delete(string tablename)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();

            if (connect.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + tablename + " WHERE Infopren_Code='" + Globals.infoprencode + "'", connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public static void Execute_DeleteHPart(string tablename)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();

            if (connect.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + tablename + " WHERE ID='" + HardwareParts.ID + "'", connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void Execute_DeleteSPart(string tablename)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();

            if (connect.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand cmd = new SQLiteCommand("DELETE FROM " + tablename + " WHERE ID='" + SoftwareParts.ID + "'", connect);
                    cmd.ExecuteNonQuery();
                    connect.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region Update
        public static void Execute_UpdateDevice(string tablename, List<object> devdata)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();
            if (connect.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // 
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE " + tablename +
                        " SET Infopren_Code = @Infopren_Code,Serial_Number=@Serial_Number,CD_Name=@CD_Name,CD_Phone=@CD_Phone," +
                        "CD_Externals=@CD_Externals,CD_Device_company=@CD_Device_company,CD_Model=@CD_Model,CD_Price=@CD_Price,CD_Date=@CD_Date," +
                        "CD_Status=@CD_Status " +
                        "WHERE Infopren_Code='" + devdata[0] + "'", connect);

                    cmd.Parameters.AddWithValue("@Infopren_Code", devdata[0]);
                    cmd.Parameters.AddWithValue("@Serial_Number", devdata[1]);
                    cmd.Parameters.AddWithValue("@CD_Name", devdata[2]);
                    cmd.Parameters.AddWithValue("@CD_Phone", Convert.ToInt64(devdata[3]));
                    cmd.Parameters.AddWithValue("@CD_Externals", devdata[4]);
                    cmd.Parameters.AddWithValue("@CD_Device_company", devdata[5]);
                    cmd.Parameters.AddWithValue("@CD_Model", devdata[6]);
                    cmd.Parameters.AddWithValue("@CD_Price", Convert.ToInt32(devdata[7]));
                    cmd.Parameters.AddWithValue("@CD_Date", Convert.ToDateTime(devdata[8]));
                    cmd.Parameters.AddWithValue("@CD_Status", devdata[9]);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    CheckBooleans.execute_update = true;
                }
                catch (Exception ex)
                {
                    //In future can set error massage box designed..
                    MessageBox.Show("|Error-UPDATE|\n" + ex.Message);
                }
            }
        }

        public static void Execute_UpdatePart(string tbname)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();
            try
            {
                if (connect.State == System.Data.ConnectionState.Open)
                {
                    if (CheckBooleans.hwaretab == true)
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE " + tbname + " " +
                        "SET Parttype=@Parttype,Description=@Description,Price=@Price,Status=@Status" +
                        " WHERE ID='" + HardwareParts.ID + "'", connect);
                        if (HardwareParts.Parttype != null)
                        {
                            cmd.Parameters.AddWithValue("@Parttype", HardwareParts.Parttype);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Part Type|"); return; }

                        if (HardwareParts.Description != null)
                        {
                            cmd.Parameters.AddWithValue("@Description", HardwareParts.Description);
                        }
                        else { cmd.Parameters.AddWithValue("@Description", DBNull.Value); }

                        if (HardwareParts.Price != 0)
                        {
                            cmd.Parameters.AddWithValue("@Price", HardwareParts.Price);
                        }
                        else { cmd.Parameters.AddWithValue("@Price", 0); }


                        if (HardwareParts.Status != null)
                        {
                            cmd.Parameters.AddWithValue("@Status", HardwareParts.Status);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Status|"); return; }
                        cmd.ExecuteNonQuery();
                        connect.Close();
                    }

                    if (CheckBooleans.swarretab == true)
                    {
                        SQLiteCommand cmd = new SQLiteCommand("UPDATE " + tbname + " " +
                        "SET Parttype=@Parttype,Description=@Description,Price=@Price,Status=@Status" +
                        " WHERE ID='" + SoftwareParts.ID + "'", connect);

                        if (SoftwareParts.Parttype != null)
                        {
                            cmd.Parameters.AddWithValue("@Parttype", SoftwareParts.Parttype);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Part Type|"); return; }

                        if (SoftwareParts.Description != null)
                        {
                            cmd.Parameters.AddWithValue("@Description", SoftwareParts.Description);
                        }
                        else { cmd.Parameters.AddWithValue("@Description", DBNull.Value); }

                        if (SoftwareParts.Price != 0)
                        {
                            cmd.Parameters.AddWithValue("@Price", SoftwareParts.Price);
                        }
                        else { cmd.Parameters.AddWithValue("@Price", 0); }


                        if (SoftwareParts.Status != null)
                        {
                            cmd.Parameters.AddWithValue("@Status", SoftwareParts.Status);
                        }
                        else { MessageBox.Show("|INFO-PART : Please Select Status|"); return; }
                        cmd.ExecuteNonQuery();
                        connect.Close();
                    }

                }
                else { MessageBox.Show("|Error-DB| : Database not connected"); return; }
                HardwareParts.ID = -1;
                SoftwareParts.ID = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("|Error-UPDATE|\n" + ex.Message);
            }
        }
        #endregion

        #region Search
        static public DataTable dtsearch;
        public static void Execute(string tablename, string vtype, string svalue)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);

            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {

                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM " + tablename + " WHERE " + vtype + " LIKE '%" + svalue + "%'", connect);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    if (dtsearch != null)
                    {
                        dtsearch.Reset();
                    }
                    dtsearch = new DataTable();
                    da.Fill(dtsearch);
                    connect.Close();
                    CheckBooleans.execute_search = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("|Error-SEARCH|\n" + ex.Message);
            }
        }
        #endregion

        #region Select
        public static DataSet reportinfods;


        public static void Execute(string tablename, string svalue)
        {
            reportinfods = new DataSet("ReportDBS");
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();
            try
            {
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM " + tablename + " WHERE " +
                    "Infopren_Code LIKE '%" + svalue + "%'", connect);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(reportinfods);
                    Globals.infoprencode = reportinfods.Tables[0].Rows[0][0].ToString();
                    Globals.serialnumber = reportinfods.Tables[0].Rows[0][1].ToString();
                    Globals.cdname = reportinfods.Tables[0].Rows[0][2].ToString();
                    Globals.cdphone = reportinfods.Tables[0].Rows[0][3].ToString();
                    Globals.cdexternal = reportinfods.Tables[0].Rows[0][4].ToString();
                    Globals.cddevicecompany = reportinfods.Tables[0].Rows[0][5].ToString();
                    Globals.cdmodel = reportinfods.Tables[0].Rows[0][6].ToString();
                    Globals.cdprice = reportinfods.Tables[0].Rows[0][7].ToString();
                    Globals.cddate = Convert.ToDateTime(reportinfods.Tables[0].Rows[0][8]);
                    Globals.statustext = reportinfods.Tables[0].Rows[0][9].ToString();

                }
                connect.Close();
                CheckBooleans.execute_select = true;



            }
            catch (Exception ex)
            {
                MessageBox.Show("|ERROR-REPORT|\n" + ex.Message);
            }
        }
        #endregion

        #region Load
        public static DataTable dtload;
        public static void Execute(string Tablename)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM " + Tablename, connect);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    dtload = new DataTable();
                    da.Fill(dtload);
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                //In future can set error massage box designed..
                MessageBox.Show(ex.Message);
            }
        }

        public static void ExecuteParts(string tbname)
        {
            dtload = new DataTable();
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM " + tbname + " " +
                    "WHERE Infopren_Code='" + Globals.infoprencode + "'", connect);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    da.Fill(dtload);
                    connect.Close();

                }
                else { MessageBox.Show("|Error-LOAD| : Database not connected"); return; }



            }
            catch (Exception ex)
            {
                MessageBox.Show("|Error-LOAD|\n" + ex.Message);
            }
        }

        public static void HPartsEx(string Tablename)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT HTypes FROM " + Tablename, connect);
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ComboBoxItem cbi = new ComboBoxItem();
                        cbi.Foreground = Brushes.Black;
                        cbi.Tag = dr.GetString(0);
                        cbi.Content = dr.GetString(0);
                        HardwareParts.parts.Add(cbi);
                    }

                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("|Error-LOAD|\n" + ex.Message);
            }

        }

        public static void SPartsEx(string Tablename)
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            connect.Open();
            try
            {
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT SOperations FROM " + Tablename, connect);
                    SQLiteDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["SOperations"] != DBNull.Value)
                        {
                            ComboBoxItem cbi = new ComboBoxItem();
                            cbi.Foreground = Brushes.Black;
                            cbi.Tag = dr.GetString(0);
                            cbi.Content = dr.GetString(0);
                            SoftwareParts.parts.Add(cbi);
                        }

                    }

                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
        #endregion

        #region Users
        public static DataTable dtusers;
        public static List<string> users = new List<string>();
        public static List<string> pwds = new List<string>();
        public static string Username { get; set; }
        public static string Password { get; set; }
        public static string UserID { get; set; }
        public static void LoadUsers()
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Users", connect);
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                    dtusers = new DataTable();
                    da.Fill(dtusers);
                    for (int i = 0; i != dtusers.Rows.Count; i++)
                    {
                        users.Add(dtusers.Rows[i][1].ToString());
                        pwds.Add(dtusers.Rows[i][2].ToString());
                    }
                    connect.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("|ERROR-USERS|" + ex.Message);
            }
        }

        public static void UpdateUsers()
        {
            SQLiteConnection connect = new SQLiteConnection(Globals.DBPath);
            try
            {
                connect.Open();
                if (connect.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = new SQLiteCommand("UPDATE Users SET CD_User=@username,CD_Pwd=@password" +
                        " WHERE UserID='" + UserID + "'", connect);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@password", Password);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("|ERROR-USERS|" + ex.Message);
            }
        }
        #endregion

    }
}
