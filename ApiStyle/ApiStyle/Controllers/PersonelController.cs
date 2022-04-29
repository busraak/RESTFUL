using ApiStyle.Data;
using ApiStyle.DTO;
using ApiStyle.Responses;
using Microsoft.AspNetCore.Mvc;

namespace ApiStyle.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonelController : ControllerBase
    {
        PerdbCore2Context _db;
        //GeneralResponse _response;

        public PersonelController(PerdbCore2Context db)
        {
            _db = db;
            //_response = response;
        }

        [HttpGet(Name = "List")]
        public List<PersonelList> List()
        {
            return _db.Personels.Select(x => new PersonelList
            {
                PersonelId = x.PersonelId,
                PersonelName = x.PersonelName,
                PersonelSurname = x.PersonelSurname,
                Cityname = x.City.CityName

            }).ToList();
        }


        [HttpPost(Name = "Create")] // HttpPut: Update ederken HttpDelete: Silerken HttpPost:Create ederken. Hepsi icin HttpPost kullanılabilir. Diğerleri geleneksel kolay okunsun diye
        public GeneralResponse Create([FromBody] Personel personel, [FromServices] GeneralResponse response) //Fromservices: response sadece burada kullanılacaksa yukarıda tanımlamaya gerek kalmıyor.
        {
            try
            {
                _db.Personels.Add(personel);

                _db.SaveChanges();

                response.MsgSuccess = $"{personel.PersonelName} basarılı bir şekilde kaydedildi.";
            }
            catch (Exception)
            {
                response.MsgError = $"{personel.PersonelName} eklenemedi.";

            }
            return response;
        }


        [HttpPut(Name = "Update")] // HttpPut: Update ederken HttpDelete: Silerken HttpPost:Create ederken. Hepsi icin HttpPost kullanılabilir. Diğerleri geleneksel kolay okunsun diye
        public GeneralResponse Update([FromBody] Personel personel, [FromServices] GeneralResponse response) //Fromservices: response sadece burada kullanılacaksa yukarıda tanımlamaya gerek kalmıyor.
        {
            try
            {
                _db.Personels.Update(personel);

                _db.SaveChanges();

                response.MsgSuccess = $"{personel.PersonelName} basarılı bir şekilde guncellendi.";
            }
            catch (Exception)
            {
                response.MsgError = $"{personel.PersonelName} guncellenemedi.";

            }
            return response;
        }
        [HttpDelete(Name = "Delete")] // HttpPut: Update ederken HttpDelete: Silerken HttpPost:Create ederken. Hepsi icin HttpPost kullanılabilir. Diğerleri geleneksel kolay okunsun diye
        public GeneralResponse Delete([FromBody] Personel personel, [FromServices] GeneralResponse response) //Fromservices: response sadece burada kullanılacaksa yukarıda tanımlamaya gerek kalmıyor.
        {
            try
            {
                _db.Personels.Remove(personel);

                _db.SaveChanges();

                response.MsgSuccess = $"{personel.PersonelName} basarılı bir şekilde silindi.";
            }
            catch (Exception)
            {
                response.MsgError = $"{personel.PersonelName} silindi.";

            }
            return response;
        }
        [HttpGet("{id:int}")]
        public Personel Find(int id)
        {
            return _db.Personels.Find(id);
        }

        [HttpGet("{id:int}")] //delete işlemini get ile yapma, direkt silme 
        public Personel Delete(int id)
        {
            var personel = _db.Personels.Find(id);
            _db.Personels.Remove(personel);
            _db.SaveChanges();
            return personel;
        }
    }
}
