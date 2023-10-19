using Concessonária.DAL;
using Concessonária.Models;
using Microsoft.AspNetCore.Mvc;

namespace Concessonária.Controllers
{
    public class MotosController : Controller
    {
        public IActionResult Index()
        {
            MotosDAO motos = new MotosDAO();
            Motos motos2 = new Motos();
            ViewBag.Motos = motos.getTodasasMotos();
            return View();
        }
        public IActionResult create()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CriarMotos(string mot_modelo, string mot_ano, string mot_cor)
        {
            MotosDAO motos = new MotosDAO();
            Motos Motos2 = new Motos();
            Motos2.mot_cor = mot_cor;
            Motos2.mot_ano = mot_ano;
            Motos2.mot_modelo = mot_modelo;
            motos.InserirMotos(Motos2);
            return RedirectToAction("index", "Motos");
        }

        public IActionResult Apagar(int id)
        {
            MotosDAO motos = new MotosDAO();
            Motos motos2 = new Motos();
            motos2.mot_id = id;
            motos.Apagar(motos2);
            return RedirectToAction("index");

        }

        public async Task<IActionResult> UpdateMotos( int id ,string mot_modelo, string mot_ano, string mot_cor)
        {
            var Motos  = new MotosDAO().getTodasasMotos();
            var moto = Motos.First(moto => moto.mot_id.Equals(id));
            moto.mot_cor = mot_cor;
            moto.mot_ano = mot_ano;
            moto.mot_modelo = mot_modelo;
            new MotosDAO().UpdateMotos(moto);
            return RedirectToAction("index", "Motos");
        }
    }
}
