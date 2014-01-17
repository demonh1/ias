using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Telecom2.Models;

namespace Telecom2.DAL
{
    public class TInitializer : DropCreateDatabaseIfModelChanges<TContext>
    {
        protected override void Seed(TContext context)
        {

            var clients = new List<Client> { 
                new Client { LastName = "Семенов", FirstMidName = "Григорий", SecondName = "Сергеевич", Phone = "6160303", Address = "Руднева ул. д. 3 корп. 1 кв. 170", Region = "Выборгский"},
                new Client { LastName = "Егорова", FirstMidName = "Нина", SecondName = "Михайловна", Phone = "6160316", Address = "Верности ул. д. 10 корп 3 кв. 49", Region = "Калининский"},
                new Client { LastName = "Павлов", FirstMidName = "Николай", SecondName = "Федорович", Phone = "6161115", Address = "Северный пр. д. 63 корп. 4 кв. 24", Region = "Калининский"},
                new Client { LastName = "Аверьянова", FirstMidName = "Елена", SecondName = "Андреевна", Phone = "6161259", Address = "Тверская ул. д. 38 кв. 241", Region = "Центральный"},
                new Client { LastName = "Трофимов", FirstMidName = "Вячеслав", SecondName = "Николаевич", Phone = "6162415", Address = "Маршала Блюхера пр. д. 61 корп. 1 кв. 78", Region = "Красногвардейский"},
                new Client { LastName = "Володин", FirstMidName = "Алексей", SecondName = "Федорович", Phone = "6167803", Address = "Лиговский пр. д. 133 кв. 402", Region = "Центральный"},
                new Client { LastName = "Веденеева", FirstMidName = "Ирина", SecondName = "Юрьевна", Phone = "6162317", Address = "Конная ул. д. 28 корп. 2 кв. 3", Region = "Центральный"},
                new Client { LastName = "Захаров", FirstMidName = "Константин", SecondName = "Семенович", Phone = "6160125", Address = "Металлистов пр. д. 23 корп. 2 кв. 192", Region = "Красногвардейский"},
                new Client { LastName = "Степанов", FirstMidName = "Владимир", SecondName = "Борисович", Phone = "6160601", Address = "Невский пр. д. 123 корп. 2 кв 12", Region = "Центральный"},
                new Client { LastName= "Ильин", FirstMidName = "Константин", SecondName = "Александрович", Phone = "6160793", Address = "Херсонская ул. д. 23 корп. 1 кв. 5", Region = "Центральный"}  
            };

            clients.ForEach(t => context.Clients.Add(t));
            context.SaveChanges();

            var operators = new List<Operator> { 

                new Operator {  LastName = "Бондарев", FirstMidName = "Вячеслав", SecondName = "Сергеевич", Clients = new List<Client>()},
                new Operator {  LastName = "Морозов", FirstMidName = "Алексей", SecondName = "Андреевич", Clients = new List<Client>()},
                new Operator {  LastName = "Сурков", FirstMidName = "Михаил", SecondName = "Александрович", Clients = new List<Client>()}
                
            };
            operators.ForEach(t => context.Operators.Add(t));
            context.SaveChanges();

            var engineers = new List<Engineer> {

                new Engineer { LastName = "none", RegionNumber = 0 },
                new Engineer {  LastName = "Жданов", FirstMidName = "Николай", SecondName = "Александрович", RegionNumber = 4},
                new Engineer {  LastName = "Антонов", FirstMidName = "Денис", SecondName = "Николаевич", RegionNumber = 2},
                new Engineer {  LastName = "Винокуров", FirstMidName = "Андрей", SecondName = "Владимирович", RegionNumber = 5},
                new Engineer {  LastName = "Тарасов", FirstMidName = "Сергей", SecondName = "Александрович", RegionNumber = 1}
                
            };

            engineers.ForEach(t => context.Engineers.Add(t));
            context.SaveChanges();

            var opencodes = new List<OpenCode>
            {
                new OpenCode { COpen = 1, Requests = new List<Request>()},
                new OpenCode { COpen = 2, Requests = new List<Request>()},
                new OpenCode { COpen = 3, Requests = new List<Request>()},
                new OpenCode { COpen = 4, Requests = new List<Request>()},
                new OpenCode { COpen = 5, Requests = new List<Request>()},
                new OpenCode { COpen = 6, Requests = new List<Request>()},
                new OpenCode { COpen = 7, Requests = new List<Request>()},
                new OpenCode { COpen = 8, Requests = new List<Request>()}
            };
            opencodes.ForEach(t => context.OpenCodes.Add(t));
            context.SaveChanges();

            var damage = new List<DamageCode> { 

                new DamageCode { CDamage = 0, Requests = new List<Request>()},
                new DamageCode { CDamage = 1, Requests = new List<Request>()},
                new DamageCode { CDamage = 2, Requests = new List<Request>()},
                new DamageCode { CDamage = 3, Requests = new List<Request>()},
                new DamageCode { CDamage = 4, Requests = new List<Request>()},
                new DamageCode { CDamage = 5, Requests = new List<Request>()},
                new DamageCode { CDamage = 6, Requests = new List<Request>()}
                
            };

            damage.ForEach(t => context.DamageCodes.Add(t));
            context.SaveChanges();

            var closecodes = new List<CloseCode> 
            {
                new CloseCode { CClose = 0, Requests = new List<Request>()},
                new CloseCode { CClose = 1, Requests = new List<Request>()},
                new CloseCode { CClose = 2, Requests = new List<Request>()}
            };

            closecodes.ForEach(t => context.CloseCodes.Add(t));
            context.SaveChanges();

            var requests = new List<Request>
            {
                new Request {  OperatorID = 1, ClientID = 2,   RDate = DateTime.Parse("29.12.2013 15:15:05"), OpenCodeID = 1, DamageCodeID = 1, CloseCodeID = 1, EngineerID = 1, Comment = "first comment" },
                new Request {  OperatorID = 2, ClientID = 1,  RDate = DateTime.Parse("29.12.2013 16:05:33"), OpenCodeID = 2, DamageCodeID = 1, CloseCodeID = 1, EngineerID = 2, Comment ="first comment" },
                new Request {  OperatorID = 1, ClientID = 3,  RDate = DateTime.Parse("29.12.2013 19:05:15"), OpenCodeID = 2, DamageCodeID = 5, CloseCodeID = 2, EngineerID = 3, Comment ="first comment" },
                new Request {  OperatorID = 1, ClientID = 4, RDate = DateTime.Parse("29.12.2013 14:10:15"), OpenCodeID = 5, DamageCodeID = 2, CloseCodeID = 1, EngineerID = 2, Comment ="first comment" },
                new Request {  OperatorID = 2, ClientID = 5, RDate = DateTime.Parse("29.12.2013 11:11:03"), OpenCodeID = 3, DamageCodeID = 1, CloseCodeID = 1, EngineerID = 3, Comment ="first comment" },
                new Request {  OperatorID = 3, ClientID = 6,  RDate = DateTime.Parse("29.12.2013 18:10:23"), OpenCodeID = 7, DamageCodeID = 6, CloseCodeID = 1, EngineerID = 0, Comment ="first comment" },
                new Request {  OperatorID = 3, ClientID = 7,  RDate = DateTime.Parse("29.12.2013 19:10:47"), OpenCodeID = 4, DamageCodeID = 6, CloseCodeID = 2, EngineerID = 0, Comment ="first comment" } 
                
            };

            requests.ForEach(t => context.Requests.Add(t));
            context.SaveChanges();

        }
    }
}