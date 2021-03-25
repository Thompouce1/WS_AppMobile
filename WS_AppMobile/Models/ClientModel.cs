using System;

namespace WS_AppMobile.Models
{
    public class Client
    {
        public string MagId { get; set; }
        public int CliId { get; set; }
        public string CliNom { get; set; }
        public string CliNomcom { get; set; }
        public string CliAdrpos { get; set; }
        public string CliAdrcom { get; set; }
        public string CliCommune { get; set; }
        public string CliPoste { get; set; }
        public string CliTvacee { get; set; }
        public string CliTvafr { get; set; }
        public string CliTelephone { get; set; }
        public string CliPortable { get; set; }
        public string CliFax { get; set; }
        public bool CliCsup { get; set; }
        public string QuaId { get; set; }
        public string EcqId { get; set; }
        public string PayId { get; set; }
        public byte? CatId { get; set; }
        public byte CtxId { get; set; }
        public string CliEmail { get; set; }
        public decimal CliSeuildette { get; set; }
        public DateTime? CliDcreation { get; set; }
        public int? CliNcode { get; set; }
        public DateTime? CliDmodification { get; set; }
        public string CliCedex { get; set; }
        public string CliNsiret { get; set; }
        public string CliGerant { get; set; }
        public DateTime? CliDema { get; set; }
        public DateTime? CliDic { get; set; }
        public byte CliAdr { get; set; }
        public int? CliComptant { get; set; }
        public DateTime? CliDtelecom { get; set; }
        public string CliCertiphytoNum { get; set; }
        public DateTime? CliCertiphytoDvalid { get; set; }
        public string CliCertiphytoDelegataire { get; set; }
        public DateTime? CliDpreco { get; set; }
        public string CliFidNcarte { get; set; }
        public string CliFidSocCarte { get; set; }
        public string CliFidTypCarte { get; set; }
        public DateTime? CliFidDsignature { get; set; }
        public string CliNom2 { get; set; }
        public string CliPrenom { get; set; }
        public string CliAppartement { get; set; }
        public string CliBatiment { get; set; }
        public string CliEtage { get; set; }
        public string CliCouloir { get; set; }
        public string CliEscalier { get; set; }
        public string CliComplement { get; set; }
        public string CliRuenum { get; set; }
        public string CliRuenom { get; set; }
        public DateTime? CliDnaissance { get; set; }
        public int? CliPromoCourrier { get; set; }
        public int? CliPromoSms { get; set; }
        public int? CliPromoEmail { get; set; }
        public int? EcqConjointId { get; set; }
        public string CliConjointNom { get; set; }
        public string CliConjointPrenom { get; set; }
        public DateTime? CliConjointDnaissance { get; set; }
        public int? CliEnfant { get; set; }
        public string NtUtilisateur { get; set; }
        public int? CliFidClasseRfm { get; set; }
        public int? CliNpai { get; set; }
    }

    public class FID_POINTS
    {
        public string FID_NUM_CARTE { get; set; }
        public decimal FID_CARTE_POINTS { get; set; }
        public decimal FID_CARTE_SOLDE { get; set; }
    }

    public class ClientNotifications
    {
        public int CLI_PROMO_COURRIER { get; set; }
        public int CLI_PROMO_EMAIL { get; set; }
        public int CLI_PROMO_SMS { get; set; }
    }

    public class ClientInformations
    {
        public string CLI_EMAIL { get; set; }
        public string CLI_PRENOM { get; set; }
        public string CLI_NOM2 { get; set; }
        public string CLI_PORTABLE { get; set; }
        public string CLI_ADRPOS { get; set; }
        public string CLI_POSTE { get; set; }
        public string CLI_COMMUNE { get; set; }
    }
}
