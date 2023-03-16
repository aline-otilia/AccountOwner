using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers;

[Route("api/owner")]
[ApiController]
public class OwnerController : ControllerBase
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repository;
    private IMapper _mapper;

    public OwnerController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var owners = _repository.Owner.GetAllOwners();
            _logger.LogInfo($"Retornando todos os owners do banco de dados.");

            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersResult);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método GetAllOwners: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetOwnerById(Guid id)
    {
        try
        {
            var owner = _repository.Owner.GetOwnerById(id);
            if (owner is null)
            {
                _logger.LogError($"Owner com Id: {id},não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando o owner com Id: {id} ");

                var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no Método GetOwnerById: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }

    [HttpGet("{id}/account")]
    public IActionResult GetOwnerWithDetails(Guid id)
    {
        try
        {
            var owner = _repository.Owner.GetOwnerWithDetails(id);
            if (owner == null)
            {
                _logger.LogError($"Owner com Id: {id}, não encontrado.");
                return NotFound();
            }
            else
            {
                _logger.LogInfo($"Retornando o owner com detalhes e Id: {id}");
                var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro no método GetOwnerWithDetails: {ex.Message}");
            return StatusCode(500, "Erro Interno do Servidor");
        }
    }
}
