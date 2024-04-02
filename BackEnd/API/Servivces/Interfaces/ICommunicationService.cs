using API.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface ICommunicationService
    {
        Task<int> AddIncomingLetter(LettersHdDto lettersHdDto);
        Task<int> UpdateIncomingLetter(LettersHdDto lettersHdDto);
        Task<int> DeleteIncomingCommunication(int id);
        Task<ReturnSingleLettersHdDto> GetIncomingLetter(int id);
        Task<List<IncommingCommunicationDto>> GetIncomingLetters();
        Task<List<IncommingCommunicationDto>> GetOutgoingLetters();

    }
}
