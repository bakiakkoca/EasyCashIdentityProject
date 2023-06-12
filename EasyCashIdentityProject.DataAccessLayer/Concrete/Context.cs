using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        //miras olarak DbContext vermedim IdentityDbContext ozunde DbContexti
        //miras alir o yuzden vermedim. Identity calisicagim icin onu verdim.


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=BAKI;initial catalog=EasyCashDb; integrated Security=true");
        }
        //sql baglantisini saglayacagiz



        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        //DB ye yansitmak istedigim entityleri burada tanimlamam lazim.
        //EL katmanina geldim Concrete icerisinde 2 tane sinif var bunlari yansitilmasini istiyorum
        //<icerisindeki C# da sinif ismi olarak kalir> DB yansiycak tablonun ismidir buda





    }
}
