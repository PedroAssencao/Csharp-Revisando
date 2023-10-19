using Concessonária.DAL;
using Concessonária.Models;
using Microsoft.AspNetCore.Mvc;

namespace Concessonária.Controllers
{
    public class CarrosController : Controller
    {
        public IActionResult Index()
        {
            CarrosDAO carros = new CarrosDAO();
            Carros carros2 = new Carros();
            ViewBag.Carros = carros.getTodososCarros();
            return View();
        }

        public IActionResult create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarCarros(string car_modelo, string car_ano, string car_cor)
        {
            CarrosDAO carros = new CarrosDAO();
            Carros carros2 = new Carros();
            carros2.car_cor = car_cor;
            carros2.car_ano = car_ano;
            carros2.car_modelo = car_modelo;
            carros.InserirCarros(carros2);
            return RedirectToAction("index", "Carros");
        }

        [HttpGet]

        public IActionResult Apagar(int id)
        {
            CarrosDAO carros = new CarrosDAO();
            Carros carros2 = new Carros();
            carros2.car_id = id;
            carros.Apagar(carros2);
            return RedirectToAction("index");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateCarros(int id, string car_modelo, string car_ano, string car_cor)
        {
            var Carros = new CarrosDAO().getTodososCarros();
            var carro = Carros.First(carro => carro.car_id.Equals(id));
            carro.car_cor = car_cor;
            carro.car_ano = car_ano;
            carro.car_modelo = car_modelo;
            new CarrosDAO().UpdateCarros(carro);
            return RedirectToAction("index", "Carros");
        }
    }
}
