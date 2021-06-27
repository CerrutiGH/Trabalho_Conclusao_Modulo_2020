using System.ComponentModel.DataAnnotations;

namespace Spa_TCM.Models
{
    public class Reserva
    {


        public int COD_RES { get; set; }

        public string EMAIL_CLI { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string RESERVA_DATA { get; set; }


        public string RESERVA_HORA { get; set; }


        public string RESERVA_QTD { get; set; }
    }
}