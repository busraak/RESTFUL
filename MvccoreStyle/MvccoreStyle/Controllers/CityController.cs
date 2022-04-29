using Microsoft.AspNetCore.Mvc;
using MvccoreStyle.Models.Data;
using MvccoreStyle.Responses;

namespace MvccoreStyle.Controllers
{
    public class CityController : Controller
    {
        DBPerCoreContext _db;
        GeneralResponse _generalResponse;

        public CityController(DBPerCoreContext db,GeneralResponse generalResponse)
        {
            _db = db;
            _generalResponse = generalResponse;
        }
        public IActionResult List()
        {
            return Json(_db.Set<Sehir>().ToList());
        }
        public IActionResult Find(int id)
        {
            return Json(_db.Set<Sehir>().Find(id));
        }
        [HttpPost]
        public IActionResult Update([FromBody] Sehir sehir) //FromBody: tarayıcının yukarısı head,altı body kısmı.Once okuması gerekiyor ki post gelsin.
        {
            try
            {
                _db.Set<Sehir>().Update(sehir);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{sehir.SehirAd} basarılı bir sekilde guncellendi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{sehir.SehirAd} guncellenemedi.";
                _generalResponse.MsgError = $"{ex.Message}";
                
            }

            return (Json(_generalResponse));
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Sehir sehir)
        {
            try
            {
                _db.Set<Sehir>().Remove(sehir);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{sehir.SehirAd} basarılı bir sekilde silindi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{sehir.SehirAd} silinemedi.";
                _generalResponse.MsgError = $"{ex.Message}";

            }
            return (Json(_generalResponse));
        }

      
        public IActionResult Delete(int id)
        {
            Sehir sehir = _db.Sehirs.Find(id);

            try
            {
                _db.Set<Sehir>().Remove(sehir);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{sehir.SehirAd} basarılı bir sekilde silindi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{sehir.SehirAd} silinemedi.";
                _generalResponse.MsgError = $"{ex.Message}";

            }
            return (Json(_generalResponse));
        }
        [HttpPost]
        public IActionResult Create([FromBody] Sehir sehir)
        {
            try
            {
                _db.Set<Sehir>().Add(sehir);
                _db.SaveChanges();
                _generalResponse.MsgSuccess = $"{sehir.SehirAd} basarılı bir sekilde eklendi.";
            }
            catch (Exception ex)
            {

                _generalResponse.MsgSuccess = $"{sehir.SehirAd} eklenemedi.";
                _generalResponse.MsgError = $"{ex.Message}";

            }
            return (Json(_generalResponse));
        }
    }
}
