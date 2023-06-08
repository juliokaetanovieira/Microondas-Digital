using MicroondasDigital.Models;
using Microsoft.AspNetCore.Mvc;
using MicroondasDigital.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroondasDigital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicroondasController : Controller
    {
        private int tempoRestante;
        private int potencia;
        private string stringProgresso;
        private List<ProgramaAquecimento> programasAquecimento;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarAquecimento(int tempo, int potencia = 10)
        {
            if (tempo == null && potencia == null)
            {
                // Início rápido - nenhum tempo ou potência informada
                tempo = 30;
                potencia = 10;
            }

            if (tempoRestante != null && tempoRestante != 0)
            {
                // Acrescentar 30 segundos ao tempo restante
                tempoRestante += 30;
            }

            // Verifique se o tempo está no intervalo de 60 a 99 segundos
            if (tempo >= 60 && tempo <= 99)
            {
                // Converte o tempo em minutos e segundos formatados
                int minutos = tempo / 60;
                int segundos = tempo % 60;
                string tempoFormatado = $"{minutos}:{segundos:D2}";

                // Utilize a variável 'tempoFormatado' como necessário para exibir o tempo formatado na interface ou realizar outras operações

                return View();
            }
            else if (tempo < 1 || tempo > 120)
            {
                // Retorne uma resposta de erro ou redirecione para uma página de erro
                ModelState.AddModelError("tempo", "Informe um tempo válido (entre 1 segundo e 2 minutos).");
                return View();
            }

            // Verifique se a potência está dentro do intervalo desejado (1 a 10)
            if (potencia < 0 || potencia > 10)
            {
                // Retorne uma resposta de erro ou redirecione para uma página de erro
                ModelState.AddModelError("potencia", "Informe uma potência válida (entre 0 e 10).");
                return View();
            }

            tempoRestante = tempo;

            // Lógica para iniciar o aquecimento
            // Utilize os parâmetros 'tempo' e 'potencia' como necessário

            TempData["Mensagem"] = "Aquecimento iniciado com sucesso!";
            return View();
        }

        private void AtualizarStringProgresso()
        {
            if (tempoRestante != null && potencia != null)
            {
                int quantidadeCaracteres = potencia;
                int quantidadePontos = tempoRestante * quantidadeCaracteres;
                stringProgresso = new string('.', quantidadePontos);
            }
            else
            {
                stringProgresso = string.Empty;
            }
        }

        public MicroondasController()
        {
            programasAquecimento = new List<ProgramaAquecimento>();

            // Adicione os programas pré-definidos à lista
            programasAquecimento.Add(new ProgramaAquecimento
            {
                Nome = "Pipoca",
                Alimento = "Pipoca (de micro-ondas)",
                Tempo = 180,
                Potencia = 7,
                StringAquecimento = "PPC",
                InstrucoesComplementares = "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um\r\nestouro e outro, interrompa o aquecimento."
            });

            programasAquecimento.Add(new ProgramaAquecimento
            {
                Nome = "Leite",
                Alimento = "Leite",
                Tempo = 300,
                Potencia = 5,
                StringAquecimento = "LT",
                InstrucoesComplementares = "Cuidado com aquecimento de líquidos, o choque térmico aliado ao movimento do recipiente pode\r\ncausar fervura imediata causando risco de queimaduras."
            });

            programasAquecimento.Add(new ProgramaAquecimento
            {
                Nome = "Carnes de boi",
                Alimento = "Carnes em pedaço ou fatias",
                Tempo = 840,
                Potencia = 4,
                StringAquecimento = "CB",
                InstrucoesComplementares = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o\r\ndescongelamento uniforme."
            });

            programasAquecimento.Add(new ProgramaAquecimento
            {
                Nome = "Frango",
                Alimento = "Frango (qualquer corte)",
                Tempo = 480,
                Potencia = 7,
                StringAquecimento = "FG",
                InstrucoesComplementares = "Interrompa o processo na metade e vire o conteúdo com a parte de baixo para cima para o\r\ndescongelamento uniforme"
            });

            programasAquecimento.Add(new ProgramaAquecimento
            {
                Nome = "Feijão",
                Alimento = "Feijão congelado",
                Tempo = 480,
                Potencia = 9,
                StringAquecimento = "FJC",
                InstrucoesComplementares = "Deixe o recipiente destampado e em casos de plástico, cuidado ao retirar o recipiente pois o mesmo\r\npode perder resistência em altas temperaturas."
            });
            // Adicione mais programas pré-definidos se necessário
        }



    }
}
