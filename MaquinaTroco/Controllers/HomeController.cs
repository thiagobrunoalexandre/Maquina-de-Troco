using MaquinaTroco.DAO.Query;
using MaquinaTroco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MaquinaTroco.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddMoeda()
        {
            CallDB dbFROM = new CallDB(DBSource.maquinaTroco);
            List<Moeda> moedas = new TablesQuery(dbFROM).GetMoeda();
            if(moedas.Count == 0)
            {
                TempData["MensagemErro"] = "Caixa zerado";
            }
            ViewBag.moedas = moedas;
            return View();
        }
        [HttpPost]
        public ActionResult AddMoeda(Moeda moeda)
        {
            CallDB dbFROM = new CallDB(DBSource.maquinaTroco);
            bool existMoeda = new TablesQuery(dbFROM).MoedaExist(moeda.valor.ToString());

            if (existMoeda && moeda.quantidade > 0)
            {
                Moeda m = new TablesQuery(dbFROM).QuantidadeMoeda(moeda.valor.ToString());
                new TablesQuery(dbFROM).UpdateMoeda(m.id_moeda, m.quantidade + moeda.quantidade);
                TempData["MensagemErro"] = "Quantidade de moeda adicionada com sucesso";
                return RedirectToAction("AddMoeda", "Home");

            }
            else if(moeda.valor > 0 && moeda.quantidade > 0)
            {
               bool insert = new TablesQuery(dbFROM).InsertMoeda(moeda);
                if (insert)
                {
                    TempData["MensagemErro"] = "Moeda adicionada com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro ao adicionar moeda";
                }
              
            }
            else
            {
                TempData["MensagemErro"] = "Valor ou quantidade menor ou igual a zero!";
            }
            return RedirectToAction("AddMoeda", "Home");
        }

           

        [HttpGet]
        public ActionResult Sangria()
        {
            CallDB dbFROM = new CallDB(DBSource.maquinaTroco);
            List<Moeda> moedas = new TablesQuery(dbFROM).GetMoeda();
            if (moedas.Count == 0)
            {
                TempData["MensagemErro"] = "Caixa zerado, não é possivel fazer sangria";
                ViewBag.moedas = moedas;
                ViewBag.sangria = false;
                return View();
            }
            ViewBag.sangria = true;
            ViewBag.moedas = moedas;
            return View();
        }
        [HttpPost]
        public ActionResult Sangria(Moeda moeda)
        {
            CallDB dbFROM = new CallDB(DBSource.maquinaTroco);
            bool existMoeda = new TablesQuery(dbFROM).MoedaExist(moeda.valor.ToString());

            if (existMoeda && moeda.quantidade > 0)
            {
                Moeda m = new TablesQuery(dbFROM).QuantidadeMoeda(moeda.valor.ToString());

                if (moeda.quantidade > m.quantidade)
                {
                    TempData["MensagemErro"] = "Quantidade maior que a dispinível";
                    return RedirectToAction("Sangria", "Home");
                }else if(moeda.quantidade == m.quantidade)
                {
                    bool sangria = new TablesQuery(dbFROM).DeleteMoeda(m.id_moeda);
                    if (sangria) 
                    {
                        TempData["MensagemErro"] = "Sangria realizada com sucesso";
                        return RedirectToAction("Sangria", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Erro ao realizar sangria";
                        return RedirectToAction("Sangria", "Home");
                    }
                }
                    
                else
                {
                   bool sangria =  new TablesQuery(dbFROM).UpdateMoeda(m.id_moeda, m.quantidade - moeda.quantidade);
                    if (sangria)
                    {
                        TempData["MensagemErro"] = "Sangria realizada com sucesso";
                        return RedirectToAction("Sangria", "Home");
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Erro ao realizar sangria";
                        return RedirectToAction("Sangria", "Home");
                    }

                }
            }
            else if (moeda.valor > 0 && moeda.quantidade > 0)
            {
               
                TempData["MensagemErro"] = "Não existe moeda com esse valor";

            }
            else
            {
                TempData["MensagemErro"] = "Valor ou quantidade menor ou igual a zero!";
            }
            return RedirectToAction("Sangria", "Home");
        }
        [HttpGet]
        public ActionResult Troco()
        {
            CallDB dbFROM = new CallDB(DBSource.maquinaTroco);
            List<Moeda> moedas = new TablesQuery(dbFROM).GetMoeda();
            if (moedas.Count == 0)
            {
                TempData["MensagemErro"] = "Caixa zerado, não é possível gerar troco";
                ViewBag.moedas = moedas;
                ViewBag.troco = false;
                return View();
            }
            ViewBag.troco = true;
            ViewBag.moedas = moedas;
            return View();
        }
        [HttpPost]
        public ActionResult Troco(Troco troco)
        {
            if (troco.valor_pago == troco.valor_compra)
            {
                TempData["MensagemErro"] = "Não gerou troco";
                return RedirectToAction("Troco", "Home");
            }
            else if (troco.valor_pago > troco.valor_compra)
            {
                decimal _troco = troco.valor_pago - troco.valor_compra;

                CallDB dbFROM = new CallDB(DBSource.maquinaTroco);
                List<Moeda> moedas = new TablesQuery(dbFROM).GetMoeda();
                List<MoedasUtilizadas> moedasUti = new List<MoedasUtilizadas>();

                decimal t = _troco;
                foreach (Moeda moeda in moedas)
                {
                    var notas = (int)(_troco / moeda.valor);
                    if(notas > 0)
                    {
                        MoedasUtilizadas MoedaUti = new MoedasUtilizadas();
                        
                        if (moeda.quantidade < notas)
                        {
                            _troco -= moeda.valor * moeda.quantidade;
                            MoedaUti.quantidade = moeda.quantidade;
                            MoedaUti.id_moeda = moeda.id_moeda;
                            MoedaUti.quantidade_Anterior = moeda.quantidade;
                            MoedaUti.valor = moeda.valor.ToString();
                            moedasUti.Add(MoedaUti);

                        }
                        else
                        {
                            MoedaUti.quantidade = notas;
                            MoedaUti.valor = moeda.valor.ToString();
                            MoedaUti.id_moeda = moeda.id_moeda;
                            MoedaUti.quantidade_Anterior = moeda.quantidade;
                            moedasUti.Add(MoedaUti);
                            _troco -= moeda.valor * notas;
                        }
                       
                    }
                    
                    
                }
                if (_troco > 0)
                {
                    TempData["MensagemErro"] = "Não há troco disponível";
                    return RedirectToAction("Troco", "Home");
                }
                foreach(MoedasUtilizadas x in moedasUti)
                {
                    if(x.quantidade == x.quantidade_Anterior)
                    {
                        bool Update = new TablesQuery(dbFROM).DeleteMoeda(x.id_moeda);
                      
                    }
                    else
                    {
                        bool Delete = new TablesQuery(dbFROM).UpdateMoeda(x.id_moeda, x.quantidade_Anterior - x.quantidade);
                        
                       
                    }
                
                  
                }
                ViewBag.valortroco =  t;
                ViewBag.moedasUtilizadas = moedasUti;
                ViewBag.troco = true;
                ViewBag.moedas = new TablesQuery(dbFROM).GetMoeda(); 
                return View();
            }
            else
            {
                TempData["MensagemErro"] = "Não gerou troco (valor pago menor que o valor da compra)";
                return RedirectToAction("Troco", "Home");
            }

           
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
