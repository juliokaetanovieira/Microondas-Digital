// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var aquecimentoEmAndamento = false;
var tempoRestante = 0;


// Capturar os eventos de clique nos botões do teclado digital
document.addEventListener('DOMContentLoaded', function () {
    var campoTempo = document.getElementById("tempo");
    var campoPotencia = document.getElementById("potencia");

    var botoesTeclado = document.querySelectorAll("#tecladoDigital .tecla");

    for (var i = 0; i < botoesTeclado.length; i++) {
        botoesTeclado[i].addEventListener('click', function () {
            var numero = this.textContent;

            if (campoTempo.classList.contains('selecionado')) {
                campoTempo.value += numero;
            } else if (campoPotencia.classList.contains('selecionado')) {
                campoPotencia.value += numero;
            }
        });
    }

    campoTempo.addEventListener('click', function () {
        campoTempo.classList.add('selecionado');
        campoPotencia.classList.remove('selecionado');
    });

    campoPotencia.addEventListener('click', function () {
        campoTempo.classList.remove('selecionado');
        campoPotencia.classList.add('selecionado');
    });
});

document.getElementById("btnIniciarAquecimento").addEventListener("click", function () {
    if (aquecimentoEmAndamento) {
        // Continuar o aquecimento do ponto onde parou
        iniciarAquecimento(tempoRestante);
    } else {
        // Iniciar o aquecimento normalmente
        var tempo = parseInt(document.getElementById("tempo").value);
        var potencia = parseInt(document.getElementById("potencia").value);
        iniciarAquecimento(tempo, potencia);
    }
});

document.getElementById("btnPausaCancelar").addEventListener("click", function () {
    if (aquecimentoEmAndamento) {
        if (pausado) {
            // Cancelar o aquecimento e limpar as informações em tela
            cancelarAquecimento();
            limparInformacoes();
        } else {
            // Pausar o aquecimento
            pausarAquecimento();
        }
    } else {
        // Fazer o cancelamento do aquecimento e limpar as informações em tela
        cancelarAquecimento();
        limparInformacoes();
    }
});

function iniciarAquecimento(tempo, potencia) {
    // Iniciar o aquecimento com o tempo e potência fornecidos
    aquecimentoEmAndamento = true;
    tempoRestante = tempo;
}

function pausarAquecimento() {
    // Pausar o aquecimento
    aquecimentoEmAndamento = false;
}

function cancelarAquecimento() {
    // Cancelar o aquecimento
    aquecimentoEmAndamento = false;
    tempoRestante = 0;
}


