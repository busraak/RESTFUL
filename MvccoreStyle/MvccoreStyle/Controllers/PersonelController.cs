using Microsoft.AspNetCore.Mvc;
using MvccoreStyle.Models.Data;
using MvccoreStyle.Responses;

namespace MvccoreStyle.Controllers
{
    public class PersonelController : Controller
    {
        DBPerCoreContext _db;
        GeneralResponse _generalResponse;

        public PersonelController(DBPerCoreContext db,GeneralResponse generalResponse)
        {
            _db= db;
            _generalResponse = generalResponse;
        }
        public IActionResult List()
        {
            return (Json(_db.Set<Personel>().ToList()));
        }
        public IActionResult Find(int id)
        {
            return Json(_db.Set<Personel>().Find(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Personel personel)
        {
            try
            {
                _db.Set<Personel>().Add(personel);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{personel.Ad} basarili bir sekilde eklendi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{personel.Ad} eklenemedi.";
                _generalResponse.MsgError = $"{ex.Message}";
            }
            return (Json(_generalResponse));
        }
        public IActionResult Update([FromBody] Personel personel) //FromBody: tarayıcının yukarısı head,altı body kısmı.Once okuması gerekiyor ki post gelsin.
        {
            try
            {
                _db.Set<Personel>().Update(personel);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{personel.Ad} basarılı bir sekilde guncellendi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{personel.Ad} guncellenemedi.";
                _generalResponse.MsgError = $"{ex.Message}";

            }

            return (Json(_generalResponse));
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Personel personel)
        {
            try
            {
                _db.Set<Personel>().Remove(personel);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{personel.Ad} basarılı bir sekilde silindi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{personel.Ad} silinemedi.";
                _generalResponse.MsgError = $"{ex.Message}";

            }
            return (Json(_generalResponse));
        }

    }
}
