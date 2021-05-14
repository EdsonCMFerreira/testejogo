using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RodadaReadDataApi.Repository;

namespace RodadaReadDataApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RodadaController : ControllerBase
    {

        private readonly ILogger<RodadaController> _logger;
        private readonly IRodadaRepository _rodadaRepository;

        public RodadaController(ILogger<RodadaController> logger, IRodadaRepository rodadaRepository)
        {
            _logger = logger;
            _rodadaRepository = rodadaRepository;
        }

        [HttpGet]
        public IActionResult GetAllData()
        {
            try
            {
                var data = _rodadaRepository.ListAll();

                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter dados");
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        public IActionResult SetData([FromBody] int dado, string mensagem)
        {
            try
            {
                dado = getNumberRandom();
                
                //Para testar Premio de Sequencia Maior
                //dado = 12345;  

                //Para testar Premio de Sequencia Menor
                //dado = 62345;
                string[] dadoarray = { "0", "0", "0", "0", "0" };

                for (int contador = 0; contador <= 4; contador++)
                {
                    dadoarray[contador] = dado.ToString().Substring(contador, 1);
                }

                //Criando Array com a quantidade de repetições
                var arrayAgrupadosRepeticao = dadoarray
                .GroupBy(x => x)
                .Select(a => new
                {
                    Item = a.Key,
                    Quant = a.Count()
                })
                .ToArray();

                string premio = "";
                int pontos = 0;

                //Premio para Sequencia Maior
                if (dado.ToString() == "12345")
                {
                    premio = "Sequencia Maior";
                    pontos = 20;

                    mensagem = mensagem
                                    + "* Prêmio " + premio
                                    + " o valor " + pontos
                                    + " ocorreu 1 vez."
                                    + " - (" + pontos + " pontos).";
                }
                //Premio para Sequencia Menor
                else if (dado.ToString().Substring(0, 4) == "1234" || dado.ToString().Substring(1, 4) == "2345")
                {
                    premio = "Sequencia Menor";
                    pontos = 15;
                    mensagem = mensagem + "* Prêmio " + premio + " - (" + pontos + " pontos).";
                }

                else
                {

                    foreach (var a in arrayAgrupadosRepeticao)
                    {
                        //Verificando tipo de premio para mais de uma unidade 
                        if (a.Quant == 5)
                        {
                            premio = "Aurora";
                            pontos = 50;
                        }

                        else if (a.Quant == 4)
                        {
                            premio = "Quadra";
                            pontos = pontos + Convert.ToInt32(a.Item) * 4;

                        }
                        else if (a.Quant == 3)
                        {
                            premio = "Trio";
                            pontos = pontos + Convert.ToInt32(a.Item) * 3;
                        }

                        else if (a.Quant == 2)
                        {
                            premio = "Par";
                            pontos = pontos + Convert.ToInt32(a.Item) * 2;
                        }

                        //Verificando tipo de premio para unidade sorteada
                        if (a.Quant == 1)
                        {

                            if (a.Item == "1")
                            {
                                premio = "Uns";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "2")
                            {
                                premio = "Dois";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "3")
                            {
                                premio = "Três";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "4")
                            {
                                premio = "Quatro";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "5")
                            {
                                premio = "Cinco";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "6")
                            {
                                premio = "Seis";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }

                        }

                        mensagem = mensagem
                                        + "* Prêmio " + premio
                                        + " o valor " + a.Item
                                        + " ocorreu " + a.Quant.ToString() + " vezes."
                                        + " - (" + pontos + " pontos).";
                    }
                }

                mensagem = mensagem + " * Nº SORTEADO " + dado.ToString();
                mensagem = mensagem + " COM TOTAL DE " + pontos + " PONTOS.";

                var result = _rodadaRepository.Insert(dado, mensagem);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar inserir dados");
                return new StatusCodeResult(500);
            }
        }

        public static int getNumberRandom()
        {
            int[] nArray = new int[5];

            string retorno = "";

            var rng = new Random();

            for (int i = 1; i <= 5; i++)
            {
                retorno = retorno.ToString() + rng.Next(1, 7).ToString();

            }

            int numeroresposta = Convert.ToInt32(retorno);
            return numeroresposta;
        }

    }

}