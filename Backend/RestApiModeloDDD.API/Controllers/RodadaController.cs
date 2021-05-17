using Microsoft.AspNetCore.Mvc;
using RestApiModeloDDD.Application.Dtos;
using RestApiModeloDDD.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestApiModeloDDD.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RodadasController : ControllerBase
    {
        private readonly IApplicationServiceRodada applicationServiceRodada;

        public RodadasController(IApplicationServiceRodada applicationServiceRodada)
        {
            this.applicationServiceRodada = applicationServiceRodada;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new JsonResult(applicationServiceRodada.GetAll()));
        }

       
        // POST api/values
        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                RodadaDto rodadaDTO = new RodadaDto();
                if (rodadaDTO == null)
                    return NotFound();

               //Gerando valores randomicos para os dados
                string retorno = "";
                var objRandom = new Random();

                //Valores de 1 a 6
                for (int i = 1; i <= 5; i++)
                {
                    retorno = retorno.ToString() + objRandom.Next(1, 7).ToString();
                }
                rodadaDTO.Dado = Convert.ToInt32(retorno);

                string[] dadoarray = new string[5];

                for (int contador = 0; contador <= 4; contador++)
                {
                    dadoarray[contador] = rodadaDTO.Dado.ToString().Substring(contador, 1);
                }

                //Criando Array com a quantidade de repetições
                var arrayAgrupadosRepeticao = dadoarray
                .GroupBy(x => x)
                .Select(a => new {
                    Item = a.Key,
                    Quant = a.Count()
                })
                .ToArray();

                string premio = "";
                int pontos = 0;

                //Premio para Sequencia Maior
                if (rodadaDTO.Dado.ToString() == "12345")
                {
                    premio = "Sequencia Maior";
                    pontos = 20;                                        
                    rodadaDTO.Mensagem = "O nº sorteado " + rodadaDTO.Dado.ToString() + " gerou prêmio " + premio + " com  (" + pontos + " pontos).";
                }
                //Premio para Sequencia Menor
                else if (rodadaDTO.Dado.ToString().Substring(0, 4) == "1234" || rodadaDTO.Dado.ToString().Substring(1, 4) == "2345")
                {
                    premio = "Sequencia Menor";
                    pontos = 15;                    
                    rodadaDTO.Mensagem = "O nº sorteado " + rodadaDTO.Dado.ToString() + " gerou prêmio " + premio + " com  (" + pontos + " pontos).";
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
                                premio = "Quatros";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "5")
                            {
                                premio = "Cincos";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }
                            else if (a.Item == "6")
                            {
                                premio = "Seis";
                                pontos = pontos + Convert.ToInt32(a.Item);
                            }

                        }

                    }

                }
                
                rodadaDTO.Mensagem = "O nº sorteado " + rodadaDTO.Dado.ToString() + " gerou prêmio " + premio + " com  (" + pontos + " pontos).";

                applicationServiceRodada.Add(rodadaDTO);
                
                return Ok(new JsonResult("A rodada foi cadastrada com sucesso"));
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }
        
    }

}