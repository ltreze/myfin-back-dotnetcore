﻿using MyFin.Application.Messages;
using MyFin.Domain.Interfaces;
using MyFin.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MyFin.Api.Controllers
{
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet("/obter-semana")]
        public Semana ObterSemana(DateTime primeiroDia)
        {
            var semana = _tarefaService.ObterSemana(primeiroDia);
            return semana;
        }

        [HttpPut("/criar")]
        public Tarefa Criar([FromBody] TarefaRequest request)
        {
            return _tarefaService.Inserir(new Tarefa(request.Descricao, request.Data, request.Pontos));
        }

        [HttpPost("/alterar")]
        public Tarefa Alterar([FromBody] TarefaRequest request)
        {
            return _tarefaService.Atualizar(new Tarefa(request.Id, request.Descricao, request.Data, request.Pontos));
        }
    }
}
