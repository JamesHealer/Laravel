using API.DTOs;
using API.Models;
using API.Servivces.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationController : ControllerBase
    {
        private readonly ICommunicationService _communicationService;
        public CommunicationController(ICommunicationService communicationService)
        {
            _communicationService = communicationService;
        }

        [HttpPost]
        [Route("AddIncomingLetter")]
        public async Task<ActionResult<int>> AddIncomingLetter([FromForm]LettersHdDto lettersHdDto)
        {
            var result = await _communicationService.AddIncomingLetter(lettersHdDto);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateIncomingLetter")]
        public async Task<ActionResult<int>> UpdateIncomingLetter([FromForm] LettersHdDto lettersHdDto)
        {
            var result = await _communicationService.UpdateIncomingLetter(lettersHdDto);
            return Ok(result);
        } 

        [HttpDelete]
        [Route("DeleteIncomingLetter/{id}")]
        public async Task<int> DeleteIncomingLetter(int id)
        {
            int result = 0;
            if (id != 0)
            {
                result = await _communicationService.DeleteIncomingCommunication(id);
            }
            return result;
        }

        [HttpGet]
        [Route("GetIncomingLetter/{id}")]
        public async Task<ActionResult<ReturnSingleLettersHdDto>> GetIncomingLetter(int id)
        {
            var result = await _communicationService.GetIncomingLetter(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetIncomingLetters")]
        public async Task<ActionResult<IEnumerable<IncommingCommunicationDto>>> GetIncomingLetters()
        {
            var result = await _communicationService.GetIncomingLetters();
            return Ok(result);
        }
        [HttpGet]
        [Route("GetOutgoingLetters")]
        public async Task<ActionResult<IEnumerable<IncommingCommunicationDto>>> GetOutgoingLetters()
        {
            var result = await _communicationService.GetOutgoingLetters();
            return Ok(result);
        }





    }
}
