using Microsoft.EntityFrameworkCore;
using otelyonet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Data
{
    public class OtelYonetDBContext : DbContext
    {

        public OtelYonetDBContext(DbContextOptions<OtelYonetDBContext> options)
         : base(options)
        {
        }

        public DbSet<Oda> Odalar{ get; set; }
        public DbSet<Birim> Birimler { get; set; }
        public DbSet<Kullanıcı> Kullanıcılar { get; set; }
        public DbSet<Rol> Roller { get; set; }

        public DbSet<Cinsiyet> Cinsiyetler { get; set; }

        public DbSet<MusteriTip> MusteriTipleri { get; set; }

        public DbSet<Musteri> Musteriler { get; set; }


    }
}

