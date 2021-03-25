namespace WS_AppMobile.Models
{
    public class Magasin
    {
        public string MagId { get; set; }
        public string MagLibelle { get; set; }
        public string MagAdrpos { get; set; }
        public string MagPoste { get; set; }
        public string MagTelephone { get; set; }
        public string MagFax { get; set; }
        public string MagTyplsa { get; set; }
        public string MagTypappro { get; set; }
        public string SocId { get; set; }
        public int? CliId { get; set; }
        public int? CliIdSic { get; set; }
        public int? MagBonApproMin { get; set; }
        public int? MagBonApproMax { get; set; }
        public int? MagBonApproDep { get; set; }
        public string MagTypmag { get; set; }
        public decimal? NaiaSglnum { get; set; }
        public int? MagContenant { get; set; }
        public string MagHoraire { get; set; }
        public int? MagPrestataire { get; set; }
        public string MagCommune { get; set; }
        public int? MagFrsId { get; set; }
        public int? MagGestion { get; set; }
        public int? MagCsup { get; set; }
        public decimal? MagLatitude { get; set; }
        public decimal? MagLongitude { get; set; }
        public string MagSoc { get; set; }
        public string MagActivite { get; set; }
        public string MagLibcourt { get; set; }
        public int? MagComId { get; set; }
        public string MagDepId { get; set; }
        public string MagEmail { get; set; }
        public string MagBqueTpe { get; set; }
        public string MagBqueVers { get; set; }
        public string MagPortable { get; set; }
        public decimal? MagSurfTot { get; set; }
        public decimal? MagSurfInt { get; set; }
        public decimal? MagSurfSerre { get; set; }
        public decimal? MagSurfMarCouv { get; set; }
        public decimal? MagSurfVegExt { get; set; }
        public decimal? MagSurfAutre { get; set; }
        public decimal? MagSurfReserve { get; set; }
        public int? MagZapette { get; set; }
        public string MagWebpro { get; set; }
        public string MagPhoto { get; set; }
    }

    public class Magasins
    {
        public string MAG_ID { get; set; }
        public string MAG_COMMUNE { get; set; }
        public decimal MAG_LATITUDE { get; set; }
        public decimal MAG_LONGITUDE { get; set; }
        public string MAG_ADRPOS { get; set; }
        public string MAG_POSTE { get; set; }
        public string MAG_ENS_LIBELLE { get; set; }
        public string STATUT { get; set; }
    }

    public class MagasinDetails
    {
        public decimal MAG_LATITUDE { get; set; }
        public decimal MAG_LONGITUDE { get; set; }
        public string MAG_ADRPOS { get; set; }
        public string MAG_POSTE { get; set; }
        public string MAG_COMMUNE { get; set; }
        public string MAG_TELEPHONE { get; set; }
        public string MAG_ENS_LIBELLE { get; set; }
        public string MAG_PHOTO { get; set; }
    }

    public class Horaires
    {
        public string MAG_HOR_JOUR { get; set; }
        public string MAG_HOR_M_AP { get; set; }
        public string MAG_HOR_OUV { get; set; }
        public string MAG_HOR_FER { get; set; }
    }
}
