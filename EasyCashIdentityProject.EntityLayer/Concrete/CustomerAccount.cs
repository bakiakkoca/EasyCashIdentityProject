using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public int CustomerAccountID { get; set; }
        //sinifin isminin sonuna ID ifadesini veya ID ifadesini kullanirsak-eklersek
        //sistem otomatik bunu primary key ve otomatik artan olarak algilar
        public string CustomerAccountNumber { get; set; }
        //hesap numarasi tekrarsiz random sayidan secelim
        public string CustomerAccountCurrency { get; set; }
        //hesap turu ne dolar mi euro mu
        public decimal CustomerAccountBalance { get; set; }
        //musteri toplam bakiyesi
        public string BankBranc { get; set; }
        //banka subesi

        public int  AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        //hesabin kime ait oldugunu bilmek icin ekledik
        //1eCok iliski 


    }
}
