using System;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;

namespace FestivalProject.DAL.Seed
{
    public static class Data
    {
        public static readonly MemberEntity AdamDuricaMember1 = new MemberEntity
        {
            Id = Guid.Parse("d01d66d9-ac9d-4419-81b3-bc8ae2dfae96"),
            Name = "Janko",
            Surname = "Mrkvicka",
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")
        };
        public static readonly MemberEntity AdamDuricaMember2 = new MemberEntity
        {
            Id = Guid.Parse("af1e3d1f-fbd7-4d2f-a7f1-f7cda8e3547f"),
            Name = "Misko",
            Surname = "Maly",
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")
        };

        public static readonly InterpretEntity AdamDurica = new InterpretEntity
        {
            Id = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b"),
            Name = "Adam Durica",
            LogoUri = "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg",
            Rating = 8.7f,
            Genre = MusicGenre.Rock,
            Description = "One of the most talented slovak singer."

        };
        public static readonly InterpretEntity Metallica = new InterpretEntity
        {
            Id = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0"),
            Name = "Metallica",
            LogoUri = "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg",
            Rating = 9.7f,
            Genre = MusicGenre.Metal,
            Description = "Without word one of the best metal groups."
        };
        public static readonly StageEntity MainStage = new StageEntity
        {
            Id = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
            Name = "Main Stage",
            Capacity = 600,
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),

        };

        public static readonly StageEntity LowStage = new StageEntity
        {
            Id = Guid.Parse("4afd5bb9-6c95-411b-becf-daffb873a7a4"),
            Name = "Low Stage",
            Capacity = 200,
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),

        };

        public static readonly FestivalEntity FestivalGrape = new FestivalEntity
        {
            Id = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            Capacity = 1500,
            Name = "Grape",
            City = "Piestany",
            LogoUri = "https://www.gregi.net/wp-content/uploads/2018/07/logo-1.jpg",
            Street = "Letiskova 123",
            Country = "Slovakia",
            Description = "One of the best festivals in Slovakia!",
            StartTime = new DateTime(2020, 7, 25),
            EndTime = new DateTime(2020, 7, 23),
            Genre = MusicGenre.Rock,
            Price = 55,

        };
        public static readonly FestivalInterpretEntity FestivalInterpretGrapeDurica = new FestivalInterpretEntity
        {
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b")

        };

        public static readonly FestivalInterpretEntity FestivalInterpretGrapeMetallica = new FestivalInterpretEntity
        {
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            InterpretId = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0")

        };

        public static readonly StageInterpretEntity StageInterpretDuricaMainStage = new StageInterpretEntity
        {
            InterpretId = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b"),
            StageId = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
            ConcertLength = new TimeSpan(0, 2, 30, 0),
            ConcertStart = new DateTime(2020, 7, 25, 15, 0, 0)
        };


        public static readonly StageInterpretEntity StageInterpretMetallicaMainStage = new StageInterpretEntity
        {
            InterpretId = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0"),
            StageId = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
            ConcertLength = new TimeSpan(0, 3, 30, 0),
            ConcertStart = new DateTime(2020, 7, 26, 10, 0, 0)
        };

        public static readonly UserEntity Admin = new UserEntity
        {
            Id = Guid.Parse("1ae18ad6-9809-4b19-be41-94aa4ff622f8"),
            Role = UserRoles.Admin,
            Name = "David",
            Surname = "Spavor",
            Country = "Slovakia",
            City = null,
            Street = null,
            Psc = null,
            Email = "xspavo00@vutrb.cz",
            LoginId = Guid.Parse("a2347ca2-4a12-46f6-9013-3596b07c63ed")
        };

        public static readonly LoginEntity AdminLogin = new LoginEntity
        {
            Id = Guid.Parse("a2347ca2-4a12-46f6-9013-3596b07c63ed"),
            Username = "admin",
            Password = "123",
            UserId = Guid.Parse("1ae18ad6-9809-4b19-be41-94aa4ff622f8"),
        };

        public static readonly UserEntity Viewer1 = new UserEntity
        {
            Id = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"),
            Role = UserRoles.Viewer,
            Name = "Barbora",
            Surname = "Bakosova",
            Country = "Slovakia",
            City = "Bratislava",
            Street = "Vajnorska",
            Psc = "03855",
            Email = "trdielko@hotmail.sk",
            LoginId = Guid.Parse("f7e5a131-c097-47fc-8900-65c51819ecee")
        };

        public static readonly LoginEntity Viewer1Login = new LoginEntity
        {
            Id = Guid.Parse("f7e5a131-c097-47fc-8900-65c51819ecee"),
            Username = "trdielko",
            Password = "12345",
            UserId = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"),
        };
        public static readonly ReservationEntity Viewer1Reservation = new ReservationEntity
        {
            Id = Guid.Parse("8edf6ecd-8d1d-4fbf-92c1-9640e4bc21d9"),
            State = ReservationStatus.InProgress,
            Name = "Grape rezervacia (mozno bude lepsie nejake cislo rezervacie)",
            Tickets = 1,
            Price = 55,
            Description = "rezervacia sa vybavuje",
            FestivalId = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
            UserId = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1")
        };
    }
}
