using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int> //primary key turunu int verdik otomatik
    {
        //identityuser miras verdim cunku AspNetUsers iliskindirmem lazimdi.
        //MSSQL de AspNetUser tablosu c#da IdentityUser tablosudur. buraya ne eklersem AspNetUser da eklenir.


        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; } //ilce
        public string City { get; set; }
        public string ImageUrl { get; set; }

        public List<CustomerAccount> CustomerAccounts { get; set; }
        //iliski 1eCok tanimladik.

    }
}
