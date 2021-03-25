using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WS_AppMobile.Models;

namespace WS_AppMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FideliteController : ControllerBase
    {
        [HttpGet("{numCarte}/[action]")]
        public FID_POINTS Points(string numCarte)
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            FID_POINTS fid_points = new FID_POINTS();

            command = new SqlCommand("Points_Fidelite", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@NUMERO_CARTE", SqlDbType.VarChar).Value = numCarte;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                fid_points.FID_NUM_CARTE = ds.Tables[0].Rows[i]["FID_NUM_CARTE"].ToString();
                fid_points.FID_CARTE_POINTS = Convert.ToDecimal(ds.Tables[0].Rows[i]["FID_CARTE_POINTS"].ToString());
                fid_points.FID_CARTE_SOLDE = Convert.ToDecimal(ds.Tables[0].Rows[i]["FID_CARTE_SOLDE"].ToString());
            }

            Conn.Dispose();

            return fid_points;
        }


        [HttpGet("{numCarte}/[action]")]
        public ClientInformations Informations(string numCarte)
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            ClientInformations info_client = new ClientInformations();

            command = new SqlCommand("Informations_Fidelite", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@NUMERO_CARTE", SqlDbType.VarChar).Value = numCarte;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                info_client.CLI_EMAIL = ds.Tables[0].Rows[i]["CLI_EMAIL"].ToString();
                info_client.CLI_PRENOM = ds.Tables[0].Rows[i]["CLI_PRENOM"].ToString();
                info_client.CLI_NOM2 = ds.Tables[0].Rows[i]["CLI_NOM2"].ToString();
                info_client.CLI_ADRPOS = ds.Tables[0].Rows[i]["CLI_ADRPOS"].ToString();
                info_client.CLI_PORTABLE = ds.Tables[0].Rows[i]["CLI_PORTABLE"].ToString();
                info_client.CLI_POSTE = ds.Tables[0].Rows[i]["CLI_POSTE"].ToString();
                info_client.CLI_COMMUNE = ds.Tables[0].Rows[i]["CLI_COMMUNE"].ToString();
            }

            Conn.Dispose();

            return info_client;
        }

        [HttpPost("{numCarte}/[action]")]
        public bool Informations(string numCarte,ClientInformations clientInformations)
        {
            SqlTransaction Trans = null;
            bool TransOuverte = false;

            try
            {
                SqlConnection Conn;
                SqlCommand command;
                Conn = new SqlConnection(Startup.DSN_EXTRANET);
                Conn.Open();
                TransOuverte = true;

                Trans = Conn.BeginTransaction();

                command = new SqlCommand("Informations_Fidelite_update", Conn, Trans);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 750;
                command.Parameters.Add("@NUMERO_CARTE", SqlDbType.VarChar).Value = numCarte;
                command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = clientInformations.CLI_EMAIL;
                command.Parameters.Add("@PRENOM", SqlDbType.VarChar).Value = clientInformations.CLI_PRENOM;
                command.Parameters.Add("@NOM", SqlDbType.VarChar).Value = clientInformations.CLI_NOM2;
                command.Parameters.Add("@POR", SqlDbType.VarChar).Value = clientInformations.CLI_PORTABLE;
                command.Parameters.Add("@ADRPOS", SqlDbType.VarChar).Value = clientInformations.CLI_ADRPOS;
                command.Parameters.Add("@CODEPOSTAL", SqlDbType.Char).Value = clientInformations.CLI_POSTE;
                command.Parameters.Add("@COMMUNE", SqlDbType.VarChar).Value = clientInformations.CLI_COMMUNE;
                command.ExecuteNonQuery();
                command.Dispose();

                Trans.Commit();
                Trans.Dispose();
                Conn.Dispose();

                return true;
            }
            catch (Exception e)
            {
                if (TransOuverte)
                {
                    Trans.Rollback();
                    Trans.Dispose();
                }
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpGet("{numCarte}/[action]")]
        public List<ClientNotifications> Notifications(string numCarte)
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            List<ClientNotifications> list_notif_client = new List<ClientNotifications>();

            command = new SqlCommand("Notifications_Fidelite", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@NUMERO_CARTE", SqlDbType.VarChar).Value = numCarte;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                ClientNotifications notif_client = new ClientNotifications();
                notif_client.CLI_PROMO_COURRIER = Convert.ToInt32(ds.Tables[0].Rows[i]["CLI_PROMO_COURRIER"].ToString());
                notif_client.CLI_PROMO_EMAIL = Convert.ToInt32(ds.Tables[0].Rows[i]["CLI_PROMO_EMAIL"].ToString());
                notif_client.CLI_PROMO_SMS = Convert.ToInt32(ds.Tables[0].Rows[i]["CLI_PROMO_SMS"].ToString());
                list_notif_client.Add(notif_client);
            }
            Conn.Dispose();

            return list_notif_client;
        }

        [HttpPost("{numCarte}/[action]")]
        public bool Notifications(string numCarte,ClientNotifications clientNotifications)
        {
            SqlTransaction Trans = null;
            bool TransOuverte = false;

            try
            {
                SqlConnection Conn;
                SqlCommand command;
                Conn = new SqlConnection(Startup.DSN_EXTRANET);
                Conn.Open();
                TransOuverte = true;

                Trans = Conn.BeginTransaction();

                command = new SqlCommand("Notifications_Fidelite_update", Conn, Trans);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 750;
                command.Parameters.Add("@NUMERO_CARTE", SqlDbType.VarChar).Value = numCarte;
                command.Parameters.Add("@COURRIER", SqlDbType.Int).Value = clientNotifications.CLI_PROMO_COURRIER;
                command.Parameters.Add("@EMAIL", SqlDbType.Int).Value = clientNotifications.CLI_PROMO_EMAIL;
                command.Parameters.Add("@SMS", SqlDbType.Int).Value = clientNotifications.CLI_PROMO_SMS;
                command.ExecuteNonQuery();
                command.Dispose();

                Trans.Commit();
                Trans.Dispose();
                Conn.Dispose();

                return true;
            }
            catch (Exception e)
            {
                if (TransOuverte)
                {
                    Trans.Rollback();
                    Trans.Dispose();
                }
                Console.WriteLine(e);
                return false;
            }
        }

        [HttpPost("demandecarte")]
        public bool Demande_carte(ClientInformations ClientDemande)
        {
            SqlTransaction Trans = null;
            bool TransOuverte = false;

            try
            {
                SqlConnection Conn;
                SqlCommand command;
                Conn = new SqlConnection(Startup.DSN_EXTRANET);
                Conn.Open();
                TransOuverte = true;

                Trans = Conn.BeginTransaction();

                command = new SqlCommand("Demande_Carte", Conn, Trans);
                command.CommandType = CommandType.StoredProcedure;
                command.CommandTimeout = 750;
                command.Parameters.Add("@PRENOM", SqlDbType.VarChar).Value = ClientDemande.CLI_PRENOM;
                command.Parameters.Add("@NOM", SqlDbType.VarChar).Value = ClientDemande.CLI_NOM2;
                command.Parameters.Add("@TEL", SqlDbType.VarChar).Value = ClientDemande.CLI_PORTABLE;
                command.Parameters.Add("@ADRPOS", SqlDbType.VarChar).Value = ClientDemande.CLI_ADRPOS;
                command.Parameters.Add("@COMMUNE", SqlDbType.VarChar).Value = ClientDemande.CLI_COMMUNE;
                command.Parameters.Add("@CODEPOSTAL", SqlDbType.VarChar).Value = ClientDemande.CLI_POSTE;
                command.Parameters.Add("@EMAIL", SqlDbType.VarChar).Value = ClientDemande.CLI_EMAIL;
                command.ExecuteNonQuery();
                command.Dispose();

                Trans.Commit();
                Trans.Dispose();
                Conn.Dispose();

                return true;
            }
            catch (Exception e)
            {
                if (TransOuverte)
                {
                    Trans.Rollback();
                    Trans.Dispose();
                }
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
