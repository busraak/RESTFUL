using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NufusKontrol.Data;
using NufusKontrol.Data.Classes;
using NufusKontrol.DTO;
using static Mernis.KPSPublicSoapClient;

namespace NufusKontrol.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly Context _db;

        public PeopleController(Context db)
        {
            _db = db;
        }

        [HttpGet(Name = "List")]
        public List<People> List()
        {
            return _db.Set<People>().ToList();
        }
        //public Task<bool> TcKimlikDogrula(People people)
        //{
        //    bool dogrulamaSonucu = false;
        //    try
        //    {
        //        var mernisClient = new Mernis.KPSPublicSoapClient(EndpointConfiguration.KPSPublicSoap);
        //        var tcKimlikDogrulamaServisResponse = mernisClient.TCKimlikNoDogrulaAsync(long.Parse(people.TC), people.Name, people.Surname, people.Birthday.Year).GetAwaiter().GetResult();
        //        dogrulamaSonucu = tcKimlikDogrulamaServisResponse.Body.TCKimlikNoDogrulaResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        dogrulamaSonucu = false;
        //    }
        //    return Task.FromResult(dogrulamaSonucu);
        //}

        [HttpGet]
        public bool TcKimlikDogrula(string TcKimlik, string Ad, string Soyad, int DogumTarihi)
        {
            People people = _db.People.Where(x => x.TC == TcKimlik && x.Name == Ad && x.Surname == Soyad && x.Birthday.Year == DogumTarihi).FirstOrDefault();

            if (people==null)
            {
                return false;
            }
            else
                return true;
        }
    }
}
