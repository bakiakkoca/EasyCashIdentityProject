using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {

        public string ProcessType { get; set; } //islem turu
        public decimal Amount { get; set; } //para miktari ne kadar gonderildi
        public DateTime ProcessDate { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string ReceiverAccountNumber { get; set; }

    }
}
