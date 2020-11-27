using System;
using System.Collections.Generic;
using System.Linq;
using FestivalProject.DAL;
using FestivalProject.DAL.Entities;
using FestivalProject.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace FestivalProject.Tests
{
    public class FestivalDbContextTests : IDisposable
    {
        private readonly FestivalDbContext _testContext;
        public FestivalDbContextTests()
        {
            var setup = new FestivalDbContextSetup("testDb");
            _testContext = setup.DbContextFactory.CreateDbContext();
            setup.PrepareDatabase();
        }
        [Fact]
        public void Interpret_GetAll()
        {
            int numberOfInterprets = 2;


            var interpretsList = _testContext.Interprets
                .ToList(); ;

            Assert.Equal(numberOfInterprets, interpretsList.Count);

        }

        [Fact]
        public void Interpret_GetById()
        {
            var id = Guid.Parse("0c41b222-d06b-4021-9668-a4f845bbe57b");
           


            var returnedInterpret = _testContext.Interprets
                .Include(x => x.MemberList)
                .Include(x=> x.FestivalInterpret)
                    .ThenInclude(x=> x.Festival)
                .Include(x => x.StageInterpret)
                    .ThenInclude(x => x.Stage)
                .First(x => x.Id == id);

            Assert.Equal(id, returnedInterpret.Id);
            Assert.NotNull(returnedInterpret.FestivalInterpret);
            Assert.NotNull(returnedInterpret.StageInterpret);
            Assert.NotNull(returnedInterpret.MemberList);

        }

        [Fact]
        public void Festival_GetById()
        {
            var festival = new FestivalEntity()
            {
                Id = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
                Capacity = 1500,
                Name = "Grape",
                City = "Piestany",
                Street = "Letiskova 123",
                Country = "Slovakia",
                Description = "One of the best festivals in Slovakia!",
                StartTime = new DateTime(2020, 7, 25),
                EndTime = new DateTime(2020, 7, 23),
                Genre = MusicGenre.Rock,
                Price = 55,
            };


            var returnedFestival = _testContext.Festivals
                .Include(x => x.StageList)
                    .ThenInclude(x => x.StageInterpret)
                .Include(x => x.FestivalInterpret)
                    .ThenInclude(x => x.Interpret)
                .First(x => x.Id == festival.Id);

            Assert.Equal(festival.Id, returnedFestival.Id);

        }

        [Fact]
        public void User_GetAll()
        {
            int users = 2;


            var usersList = _testContext.Users.Include(x=>x.ReservationList).ThenInclude(x=>x.Festival)
                .ToList(); ;

            Assert.Equal(users, usersList.Count);

        }

        [Fact]
        public void User_GetById()
        {
            var festival = new UserEntity()
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
            };


            var returnedUser = _testContext.Users
                .Include(x => x.ReservationList)
                .ThenInclude(x => x.Festival)
                .First(x => x.Id == festival.Id);

            Assert.Equal(festival.Id, returnedUser.Id);

        }

        [Fact]
        public void Reservation_GetById()
        {
            var reservation = new ReservationEntity()
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


            var returnedReservation = _testContext.Reservations
                .Include(x => x.Festival)
                .Include(x=>x.User)
                .First(x => x.Id == reservation.Id);

            Assert.Equal(reservation.Id, returnedReservation.Id);

        }

        [Fact]
        public void Reservation_GetAll()
        {
            int reservations = 1;


            var returnedReservationList = _testContext.Reservations
                .Include(x => x.Festival)
                .Include(x => x.User)
                .ToList();

            Assert.Equal(reservations, returnedReservationList.Count);

        }


       

        //padne ked sa prida viacej dat do db
        [Fact]
        public void Festival_Delete()
        {

            var festival = new FestivalEntity()
            {
                Id = Guid.Parse("46abef51-c53f-4cc5-a270-a2756ef1455e"),
                Capacity = 1500,
                Name = "Grape",
                City = "Piestany",
                Street = "Letiskova 123",
                Country = "Slovakia",
                Description = "One of the best festivals in Slovakia!",
                StartTime = new DateTime(2020, 7, 25),
                EndTime = new DateTime(2020, 7, 23),
                Genre = MusicGenre.Rock,
                Price = 55,
            };
            //var festivalss = _testContext.Festivals.ToList();
            //remove FestivalInterprets, where FestivalId == id
            _testContext.FestivalInterprets
                .RemoveRange(_testContext.FestivalInterprets.Where((x=>x.FestivalId == festival.Id)));
            
            //get all depended stages
            var stages = _testContext.Stages.Where(x=> x.FestivalId == festival.Id);

            //remove stageInterpret
            foreach (var stage in stages)
            {
                _testContext.StageInterprets
                    .RemoveRange(_testContext.StageInterprets.Where(x => x.StageId == stage.Id));
            }

            //remove stages
            _testContext.Stages.RemoveRange(stages);

            //remove festival
            _testContext.Festivals.Remove(festival);
            _testContext.SaveChanges();

            var festivalInterpret = _testContext.FestivalInterprets.Where(x=> x.FestivalId == festival.Id);
            var stageInterpret = _testContext.StageInterprets.ToList();
            var allstages = _testContext.Stages.ToList();
            var festivals = _testContext.Festivals.ToList();
            
            
            
            Assert.Empty(festivalInterpret);
            Assert.Empty(_testContext.StageInterprets);
            Assert.Empty(_testContext.Festivals);
            Assert.Empty(_testContext.Stages);

        }

        [Fact]
        public void Interpret_Delete()
        {

            var id = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0");


            //remove members
            _testContext.Members
                .RemoveRange(_testContext.Members.Where((x => x.InterpretId == id)));

            //remove festivalInterpret
            _testContext.FestivalInterprets
                .RemoveRange(_testContext.FestivalInterprets.Where((x => x.InterpretId == id)));
            //remove stageInterpret
            _testContext.StageInterprets
                .RemoveRange(_testContext.StageInterprets.Where((x => x.InterpretId == id)));
            //remove interpret
            var entity = _testContext.Interprets.First(t => t.Id == id);
            _testContext.Remove(entity);
            _testContext.SaveChanges();

            var festivalInterpret = _testContext.FestivalInterprets.Where(x=> x.InterpretId == id).ToList();
            var stageinterprets = _testContext.StageInterprets.Where(x => x.InterpretId == id).ToList();
            var interpretsCount = _testContext.Interprets.ToList().Count;

            Assert.Equal(1, interpretsCount);
            Assert.Empty(festivalInterpret);
            Assert.Empty(stageinterprets);

        }


        [Fact]
        public void Stage_Delete()
        {

            var id = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c");


            //remove stageInterpret
            _testContext.StageInterprets
                .RemoveRange(_testContext.StageInterprets.Where((x => x.StageId == id)));
            //remove stage
            var entity = _testContext.Stages.First(t => t.Id == id);
            _testContext.Remove(entity);
            _testContext.SaveChanges();

            var stageinterprets = _testContext.StageInterprets.Where(x => x.StageId == id).ToList();
            var stages = _testContext.Stages.FirstOrDefault(x=> x.Id == id);

            Assert.Null(stages);
            Assert.Empty(stageinterprets);

        }

        [Fact]
        public void User_Delete()
        {

            var id = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1");


            //remove all depended reservations
            _testContext.Reservations
                .RemoveRange(_testContext.Reservations.Where((x => x.UserId == id)));
         
                
            //remove user
            var entity = _testContext.Users.First(t => t.Id == id);
            _testContext.Remove(entity);
            _testContext.SaveChanges();

            var reservations = _testContext.Reservations.Where(x => x.UserId == id).ToList();
            var notExistingEntity = _testContext.Users.FirstOrDefault(x => x.Id == id);

            Assert.Null(notExistingEntity);
            Assert.Empty(reservations);

        }

        [Fact]
        public void User_Create()
        {

            var user = new UserEntity()
            {
                Role = UserRoles.Viewer,
                Name = "Michal",
                Surname = "Trkotko",
                Country = "Slovakia",
                City = "Bratislava",
                Street = "Vajnorska",
                Psc = "03855",
                Email = "trdielko@hotmail.sk",
            };


           var createdUser= _testContext.Users.Add(user);
            _testContext.SaveChanges();

            var isCreated =_testContext.Users.FirstOrDefault(x => x.Id == user.Id);

            Assert.NotNull(createdUser);
            Assert.NotNull(isCreated);

        }

        [Fact]
        public void Interpret_Create()
        {

            var interpret = new InterpretEntity()
            {
                Name = "Michal Docolomansky",
                LogoUri = "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg",
                Rating = 1.7f,
                Genre = MusicGenre.Chill,
                Description = "One of the most talented slovak singer.",
                MemberList = new List<MemberEntity>()
                {
                    new MemberEntity
                    {
                        Name = "Misko",
                        Surname = "ten",
                    },
                    new MemberEntity
                    {
                        Name = "lukas",
                        Surname = "moj",
                    }
                },
                StageInterpret = new List<StageInterpretEntity>()
                {
                    new StageInterpretEntity
                    {
                        StageId = Guid.Parse("cb22c323-729d-49e6-834a-644d47d3dc4c"),
                        ConcertLength =20,
                        ConcertStart = new DateTime(2025, 7, 15, 15, 0, 0),

                    },

                    new StageInterpretEntity
                    {
                        StageId = Guid.Parse("4afd5bb9-6c95-411b-becf-daffb873a7a4"),
                        ConcertLength = 30,
                        ConcertStart = new DateTime(2025, 7, 15, 15, 0, 0),

                    },

                }


            };


            var createdUser = _testContext.Interprets.Add(interpret);
            _testContext.SaveChanges();

            var isCreated = _testContext.Interprets.Include(x => x.MemberList)
                .Include(x => x.FestivalInterpret)
                .ThenInclude(x => x.Festival)
                .Include(x => x.StageInterpret)
                .ThenInclude(x => x.Stage).FirstOrDefault(x => x.Id == createdUser.Entity.Id);

            Assert.NotNull(createdUser);
            Assert.NotNull(isCreated);
            Assert.NotNull(isCreated.StageInterpret);

        }

        public void Dispose() => _testContext.Dispose();
      
    }
}
