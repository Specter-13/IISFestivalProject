using FestivalProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;

namespace FestivalProject.DAL.Seed
{
    public static class Seed
    {

        public static void SeedMembers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberEntity>(entity =>
            {
                entity.HasData(new
                {
                    Data.AdamDuricaMember1.Id,
                    Data.AdamDuricaMember1.Name,
                    Data.AdamDuricaMember1.Surname,
                    Data.AdamDuricaMember1.InterpretId
                });
                entity.HasData(new
                {
                    Data.AdamDuricaMember2.Id,
                    Data.AdamDuricaMember2.Name,
                    Data.AdamDuricaMember2.Surname,
                    Data.AdamDuricaMember2.InterpretId
                });
            });
            
        }
      
        public static void SeedInterprets(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InterpretEntity>(entity =>
            {
                entity.HasData(new
                {
                    Data.AdamDurica.Id,
                    Data.AdamDurica.Name,
                    Data.AdamDurica.Genre,
                    Data.AdamDurica.Description,
                    Data.AdamDurica.LogoUri,
                    Data.AdamDurica.Rating
                });
                entity.HasData(new
                {
                    Data.Metallica.Id,
                    Data.Metallica.Name,
                    Data.Metallica.Genre,
                    Data.Metallica.Description,
                    Data.Metallica.LogoUri,
                    Data.Metallica.Rating
                });
            });
        }

        public static void SeedMainStage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StageEntity>()
                .HasData(new
                {
                    Data.MainStage.Id,
                    Data.MainStage.Capacity,
                    Data.MainStage.Name,
                    Data.MainStage.FestivalId
                });
        }

        

        public static void SeedFestivals(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FestivalEntity>(entity =>
            {
                entity.HasMany(x => x.StageList).WithOne(x => x.Festival);
                entity.HasData(new
                {
                    Data.FestivalGrape.Id,
                    Data.FestivalGrape.Name,
                    Data.FestivalGrape.Street,
                    Data.FestivalGrape.Genre,
                    Data.FestivalGrape.Capacity,
                    Data.FestivalGrape.City,
                    Data.FestivalGrape.Country,
                    Data.FestivalGrape.Description,
                    Data.FestivalGrape.StartTime,
                    Data.FestivalGrape.EndTime,
                    Data.FestivalGrape.Price,
                   
                });
            });
        }
        public static void SeedFestivalInterpret(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FestivalInterpretEntity>(entity =>
            {
                entity.HasKey(bc => new {bc.InterpretId, bc.FestivalId});
                entity.HasOne<FestivalEntity>(bc => bc.Festival)
                    .WithMany(bc => bc.FestivalInterpret)
                    .HasForeignKey(bc => bc.FestivalId);
                entity.HasOne<InterpretEntity>(bc => bc.Interpret)
                    .WithMany(bc => bc.FestivalInterpret)
                    .HasForeignKey(bc => bc.InterpretId);
                entity.HasData(new
                {
                    Data.FestivalInterpretGrapeDurica.Id,
                    Data.FestivalInterpretGrapeDurica.InterpretId,
                    Data.FestivalInterpretGrapeDurica.FestivalId
                });
                entity.HasData(new
                {
                    Data.FestivalInterpretGrapeMetallica.Id,
                    Data.FestivalInterpretGrapeMetallica.InterpretId,
                    Data.FestivalInterpretGrapeMetallica.FestivalId
                });
            });
        }

        public static void SeedStageInterpret(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StageInterpretEntity>(entity =>
            {
                entity.HasKey(bc => new { bc.InterpretId, bc.StageId });
                entity.HasOne<StageEntity>(bc => bc.Stage)
                    .WithMany(bc => bc.StageInterpret)
                    .HasForeignKey(bc => bc.StageId);
                entity.HasOne<InterpretEntity>(bc => bc.Interpret)
                    .WithMany(bc => bc.StageInterpret)
                    .HasForeignKey(bc => bc.InterpretId);
                entity.HasData(new
                {
                    Data.StageInterpretDuricaMainStage.Id,
                    Data.StageInterpretDuricaMainStage.StageId,
                    Data.StageInterpretDuricaMainStage.InterpretId,
                    Data.StageInterpretDuricaMainStage.ConcertLength,
                    Data.StageInterpretDuricaMainStage.ConcertStart

                });
                entity.HasData(new
                {
                    Data.StageInterpretMetallicaMainStage.Id,
                    Data.StageInterpretMetallicaMainStage.StageId,
                    Data.StageInterpretMetallicaMainStage.InterpretId,
                    Data.StageInterpretMetallicaMainStage.ConcertLength,
                    Data.StageInterpretMetallicaMainStage.ConcertStart

                });
            });
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.HasData(new
                {
                    Data.Admin.Id,
                    Data.Admin.Name,
                    Data.Admin.Street,
                    Data.Admin.Country,
                    Data.Admin.City,
                    Data.Admin.Surname,
                    Data.Admin.Email,
                    Data.Admin.LoginId,
                    Data.Admin.Psc,
                    Data.Admin.Role
                });
                entity.HasData(new
                {
                    Data.Viewer1.Id,
                    Data.Viewer1.Name,
                    Data.Viewer1.Street,
                    Data.Viewer1.Country,
                    Data.Viewer1.City,
                    Data.Viewer1.Surname,
                    Data.Viewer1.Email,
                    Data.Viewer1.LoginId,
                    Data.Viewer1.Psc,
                    Data.Viewer1.Role
                });
            });
        }

        public static void SeedReservations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationEntity>(entity =>
            {
                entity.HasData(new
                {
                    Data.Viewer1Reservation.Id,
                    Data.Viewer1Reservation.FestivalId,
                    Data.Viewer1Reservation.Name,
                    Data.Viewer1Reservation.Price,
                    Data.Viewer1Reservation.Description,
                    Data.Viewer1Reservation.State,
                    Data.Viewer1Reservation.Tickets,
                    Data.Viewer1Reservation.UserId
                });
              
            });
        }

        public static void SeedLogins(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginEntity>(entity =>
            {
                entity.HasIndex(i => i.Username).IsUnique();
                entity.HasData(new
                {
                    Data.AdminLogin.Id,
                    Data.AdminLogin.Username,
                    Data.AdminLogin.Password,
                    Data.AdminLogin.UserId
                    
                });
                entity.HasData(new
                {
                    Data.Viewer1Login.Id,
                    Data.Viewer1Login.Username,
                    Data.Viewer1Login.Password,
                    Data.Viewer1Login.UserId

                });

            });
        }



    }
}
