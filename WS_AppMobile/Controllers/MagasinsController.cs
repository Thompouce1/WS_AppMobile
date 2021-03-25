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
    public class MagasinsController : ControllerBase
    {
        [HttpGet]
        public List<Magasins> Get()
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            List<Magasins> list_magasin = new List<Magasins>();

            command = new SqlCommand("Liste_Magasins", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Magasins magasin = new Magasins();
                magasin.MAG_ID = ds.Tables[0].Rows[i]["MAG_ID"].ToString();
                magasin.MAG_COMMUNE = ds.Tables[0].Rows[i]["MAG_COMMUNE"].ToString();
                magasin.MAG_LATITUDE = Convert.ToDecimal(ds.Tables[0].Rows[i]["MAG_LATITUDE"].ToString());
                magasin.MAG_LONGITUDE = Convert.ToDecimal(ds.Tables[0].Rows[i]["MAG_LONGITUDE"].ToString());
                magasin.MAG_ADRPOS = ds.Tables[0].Rows[i]["MAG_ADRPOS"].ToString();
                magasin.MAG_POSTE = ds.Tables[0].Rows[i]["MAG_POSTE"].ToString();
                magasin.MAG_ENS_LIBELLE = ds.Tables[0].Rows[i]["MAG_ENS_LIBELLE"].ToString();
                magasin.STATUT = ds.Tables[0].Rows[i]["STATUT"].ToString();
                list_magasin.Add(magasin);
            }
            Conn.Dispose();

            return list_magasin;
        }


        [HttpGet("{id}")]
        public MagasinDetails Get(string Id)
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            MagasinDetails mad_det = new MagasinDetails();

            command = new SqlCommand("Magasin_Details", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = Id;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                mad_det.MAG_LATITUDE = Convert.ToDecimal(ds.Tables[0].Rows[i]["MAG_LATITUDE"].ToString());
                mad_det.MAG_LONGITUDE = Convert.ToDecimal(ds.Tables[0].Rows[i]["MAG_LONGITUDE"].ToString());
                mad_det.MAG_ADRPOS = ds.Tables[0].Rows[i]["MAG_ADRPOS"].ToString();
                mad_det.MAG_POSTE = ds.Tables[0].Rows[i]["MAG_POSTE"].ToString();
                mad_det.MAG_COMMUNE = ds.Tables[0].Rows[i]["MAG_COMMUNE"].ToString();
                mad_det.MAG_ENS_LIBELLE = ds.Tables[0].Rows[i]["MAG_ENS_LIBELLE"].ToString();
                mad_det.MAG_TELEPHONE = ds.Tables[0].Rows[i]["MAG_TELEPHONE"].ToString();
                mad_det.MAG_PHOTO = ds.Tables[0].Rows[i]["MAG_PHOTO"].ToString();
            }
            Conn.Dispose();

            return mad_det;
        }

        [HttpGet("{id}/horaires")]
        public List<Horaires> Horaires(string Id)
        {
            SqlConnection Conn;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            Conn = new SqlConnection(Startup.DSN_EXTRANET);
            Conn.Open();
            List<Horaires> list_horaire = new List<Horaires>();

            command = new SqlCommand("Magasin_Horaires", Conn);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 750;
            command.Parameters.Add("@ID", SqlDbType.VarChar).Value = Id;
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            adapter.Dispose();
            command.Dispose();

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Horaires horaire = new Horaires();
                horaire.MAG_HOR_JOUR = ds.Tables[0].Rows[i]["MAG_HOR_JOUR"].ToString();
                horaire.MAG_HOR_M_AP = ds.Tables[0].Rows[i]["MAG_HOR_M_AP"].ToString();
                horaire.MAG_HOR_OUV = ds.Tables[0].Rows[i]["MAG_HOR_OUV"].ToString();
                horaire.MAG_HOR_FER = ds.Tables[0].Rows[i]["MAG_HOR_FER"].ToString();
                list_horaire.Add(horaire);
            }
            Conn.Dispose();

            return list_horaire;
        }
    }
}
