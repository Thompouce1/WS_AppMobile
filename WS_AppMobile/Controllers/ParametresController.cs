using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WS_AppMobile.Models;

namespace WS_AppMobile.Controllers
{
    [Route("api/privacy_policy")]
    [ApiController]
    public class ParametresController : ControllerBase
    {
        [HttpGet("version")]
        public Parametres GetVersion()
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            Parametres param = new Parametres();

            command = new SqlCommand("Recup_Parametres", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@PARAMETRE", SqlDbType.VarChar).Value = "PDC_VERSION";
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                param.Nom = ds.Tables[0].Rows[i]["Nom"].ToString();
                param.Valeur = ds.Tables[0].Rows[i]["Valeur"].ToString();
            }

            Conn.Dispose();

            return param;
        }

        [HttpGet("fichier")]
        public Parametres GetFichier()
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            Parametres param = new Parametres();

            command = new SqlCommand("Recup_Parametres", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@PARAMETRE", SqlDbType.VarChar).Value = "PDC_FICHIER";
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                param.Nom = ds.Tables[0].Rows[i]["Nom"].ToString();
                param.Valeur = ds.Tables[0].Rows[i]["Valeur"].ToString();
                param.Fichier = Convert.ToBase64String(ds.Tables[0].Rows[i].Field<byte[]>(2));
            }

            Conn.Dispose();

            return param;
        }
    }
}