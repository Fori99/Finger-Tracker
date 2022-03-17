using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DarkDemo
{
    class Funksione_MySql
    {
        static private MySqlConnection lidhja = new MySqlConnection("Server = tonic.o2switch.net; " +
                                                                    "Port = 3306; " +
                                                                    "Database = lafe6113_fingertracker; " +
                                                                    "UID = lafe6113_fingertracker_admin; " +
                                                                    "Password = oMdXu525rg; ");

        static public void Rifresko(DataGridView dataGridView)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }
                MySqlDataAdapter adapto = new MySqlDataAdapter("SELECT Punonjes_ID AS ID, Emri AS Name, Mbiemri AS Lastname, Pozicioni AS Position, Rroga_Ore AS 'Wage/Hour', Ditelindja AS Birthday, Nr_Cel AS 'Phone.Nr', E_Mail AS 'E-Mail', Kodi AS 'Password' FROM Punonjesit", lidhja);
                DataTable tabela = new DataTable();
                adapto.Fill(tabela);
                dataGridView.DataSource = tabela;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void Gjej_Punonjesit_Online(DataGridView dataGridView)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }
                MySqlDataAdapter adapto = new MySqlDataAdapter("SELECT Orari.Punonjes_ID AS ID, Punonjesit.Emri AS Name, Punonjesit.Mbiemri AS Lastname, Punonjesit.Pozicioni AS Position, Orari.Ora_Hyrjes AS EnteringTime FROM Orari INNER JOIN Punonjesit ON Orari.Punonjes_ID = Punonjesit.Punonjes_ID WHERE Ora_Daljes IS NULL", lidhja);
                DataTable tabela = new DataTable();
                adapto.Fill(tabela);
                dataGridView.DataSource = tabela;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void insert(int id, string emri, string mbiemri, string pozicioni, int rroga, DateTime ditelindja, string cel, string mail, string kodi, DataGridView dataGridView)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand inserti = new MySqlCommand("Insert Into Punonjesit(Punonjes_ID, Emri, Mbiemri, Pozicioni, Rroga_Ore, Ditelindja, Nr_Cel, E_Mail, Kodi) " +
                    "Values (@id, @emri, @mbiemri, @pozicioni, @rroga, @ditelindja, @cel, @mail, @kodi)", lidhja);

                inserti.Parameters.AddWithValue("@id", id);
                inserti.Parameters.AddWithValue("@emri", emri);
                inserti.Parameters.AddWithValue("@mbiemri", mbiemri);
                inserti.Parameters.AddWithValue("@pozicioni", pozicioni);
                inserti.Parameters.AddWithValue("@rroga", rroga);
                inserti.Parameters.AddWithValue("@ditelindja", ditelindja);
                inserti.Parameters.AddWithValue("@cel", cel);
                inserti.Parameters.AddWithValue("@mail", mail);
                inserti.Parameters.AddWithValue("@kodi", kodi);
                inserti.ExecuteNonQuery();
                inserti.Parameters.Clear();

                MessageBox.Show("Employee has been added !");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_emri(int ID, String variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Emri=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_mbiemri(int ID, String variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Mbiemri=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_pozicioni(int ID, String variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Pozicioni=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_rrogen(int ID, int variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Rroga_Ore=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_ditelindja(int ID, DateTime variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Ditelindja=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_nrCel(int ID, String variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Nr_Cel=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_eMail(int ID, String variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET E_Mail=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void update_kodin(int ID, String variabel)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                MySqlCommand bej_update = new MySqlCommand("UPDATE Punonjesit SET Kodi=@variabel WHERE Punonjes_ID = @ID", lidhja);
                bej_update.Parameters.AddWithValue("@variabel", variabel);
                bej_update.Parameters.AddWithValue("@ID", ID);
                bej_update.ExecuteNonQuery();
                bej_update.Parameters.Clear();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void login_logout(int fingerPrint_ID)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }

                string select = "SELECT Orari_ID, Punonjes_ID, Ora_Daljes FROM Orari WHERE Punonjes_ID = " + fingerPrint_ID + " AND Orari_ID = (select max(Orari_ID) FROM Orari WHERE Punonjes_ID = " + fingerPrint_ID + ")";
                MySqlCommand cmd = new MySqlCommand(select, lidhja);
                MySqlDataReader dr = cmd.ExecuteReader();
                //cmd.EndExecuteReader();

                if (dr.Read())
                {
                    if (dr["Ora_Daljes"] == DBNull.Value)
                    {
                        string orari_ID = dr["Orari_ID"].ToString();
                        dr.Close();
                        //MessageBox.Show("Update");

                        try
                        {
                            if (lidhja.State == ConnectionState.Closed)
                            {
                                lidhja.Open();
                            }

                            MySqlCommand bej_update = new MySqlCommand("UPDATE Orari SET Ora_Daljes = CURRENT_TIME() WHERE Punonjes_ID = @ID and Ora_Daljes is Null", lidhja);
                            bej_update.Parameters.AddWithValue("@ID", fingerPrint_ID);
                            bej_update.ExecuteNonQuery();
                            bej_update.Parameters.Clear();

                            MessageBox.Show("Goodbye !");

                            MySqlCommand update_dita_punes = new MySqlCommand("UPDATE Orari SET Dita_Punes = TimeDiff(Ora_Daljes, Ora_Hyrjes) WHERE Punonjes_ID = @ID and Dita_Punes is Null", lidhja);
                            update_dita_punes.Parameters.AddWithValue("@ID", fingerPrint_ID);
                            update_dita_punes.ExecuteNonQuery();
                            update_dita_punes.Parameters.Clear();
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            lidhja.Close();
                        }
                    }
                    else
                    {
                        dr.Close();
                        //MessageBox.Show("Insert");

                        try
                        {
                            if (lidhja.State == ConnectionState.Closed)
                            {
                                lidhja.Open();
                            }

                            MySqlCommand inserti = new MySqlCommand("Insert Into Orari (Punonjes_ID, Data, Ora_Hyrjes) VALUES(@id, CURRENT_DATE(), CURRENT_TIME)", lidhja);
                            inserti.Parameters.AddWithValue("@id", fingerPrint_ID);
                            inserti.ExecuteNonQuery();
                            inserti.Parameters.Clear();

                            MessageBox.Show("Welcome !");
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            lidhja.Close();
                        }
                    }
                }
                else
                {
                    try
                    {
                        dr.Close();
                        if (lidhja.State == ConnectionState.Closed)
                        {
                            lidhja.Open();
                        }

                        MySqlCommand inserti = new MySqlCommand("Insert Into Orari (Punonjes_ID, Data, Ora_Hyrjes) VALUES(@id, CURRENT_DATE(), CURRENT_TIME)", lidhja);
                        inserti.Parameters.AddWithValue("@id", fingerPrint_ID);
                        inserti.ExecuteNonQuery();
                        inserti.Parameters.Clear();

                        MessageBox.Show("Welcome !");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        lidhja.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }

        static public void kerko(DataGridView dataGridView, string emri, string mbiemri)
        {
            try
            {
                if (lidhja.State == ConnectionState.Closed)
                {
                    lidhja.Open();
                }
                MySqlDataAdapter adapto = new MySqlDataAdapter("SELECT Punonjes_ID AS ID, Emri AS Name, Mbiemri AS Lastname, Pozicioni AS Position, Rroga_Ore AS 'Wage/Hour', Ditelindja AS Birthday, Nr_Cel AS 'Phone.Nr', E_Mail AS 'E-Mail', Kodi AS 'Password' FROM Punonjesit Where Emri = '" + emri + "' and Mbiemri = '" + mbiemri + "' ;", lidhja);
                DataTable tabela = new DataTable();
                adapto.Fill(tabela);
                dataGridView.DataSource = tabela;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                lidhja.Close();
            }
        }
    }
}
