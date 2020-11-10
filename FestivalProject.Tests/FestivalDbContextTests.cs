using System;
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
            var interpret = new InterpretEntity()
            {
                Id = Guid.Parse("c993e8d3-719b-43d7-908b-e26dc6f4ace0"),
                Name = "Metallica",
                LogoUri =
                    "https://www.adamdurica.com/wp-content/uploads/2019/04/album_adam_durica_mandolina-400x400.jpg",
                Rating = 9.7f,
                Genre = MusicGenre.Metal,
                Description = "Without word one of the best metal groups."
            };


            var returnedInterpret = _testContext.Interprets
                .Include(x => x.MemberList)
                .Include(x=> x.FestivalInterpret)
                    .ThenInclude(x=> x.Festival)
                .Include(x => x.StageInterpret)
                    .ThenInclude(x => x.Stage)
                .First(x => x.Id == interpret.Id);

            Assert.Equal(interpret.Id, returnedInterpret.Id);
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
                LoginId = Guid.Parse("f7e5a131-c097-47fc-8900-65c51819ecee")
            };


            var returnedFestival = _testContext.Users
                .Include(x => x.ReservationList)
                .ThenInclude(x => x.Festival)
                .First(x => x.Id == festival.Id);

            Assert.Equal(festival.Id, returnedFestival.Id);

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


        [Fact]
        public void Login_GetAll()
        {
            int logins = 2;


            var returnedLoginsList = _testContext.Logins
                .Include(x => x.User)
                .ToList();

            Assert.Equal(logins, returnedLoginsList.Count);

        }

        [Fact]
        public void Login_GetByUsername()
        {
            var login = new LoginEntity()
            {
                Id = Guid.Parse("f7e5a131-c097-47fc-8900-65c51819ecee"),
                Username = "trdielko",
                Password = "12345",
                UserId = Guid.Parse("e3681bb8-1e7f-4e4f-8abe-58dbd211d6d1"),
            };


            var returnedLogin = _testContext.Logins
                .Include(x => x.User)
                .First(x => x.Username == login.Username);

            Assert.Equal(returnedLogin.Id, login.Id);

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
            //remove login only when user is registered
            var login = _testContext.Logins.FirstOrDefault(x => x.UserId == id);
            if (login != null) _testContext.Logins.Remove(login);
                
            //remove user
            var entity = _testContext.Users.First(t => t.Id == id);
            _testContext.Remove(entity);
            _testContext.SaveChanges();

            var reservations = _testContext.Reservations.Where(x => x.UserId == id).ToList();
            var notExistingEntity = _testContext.Users.FirstOrDefault(x => x.Id == id);
            var nonExistingLogin = _testContext.Logins.FirstOrDefault(x => x.UserId == id);

            Assert.Null(notExistingEntity);
            Assert.Null(nonExistingLogin);
            Assert.Empty(reservations);

        }

        public void Dispose() => _testContext.Dispose();
      
    }
}
