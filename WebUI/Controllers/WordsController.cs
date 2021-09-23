using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordService wordService;

        public WordsController(IWordService wordService)
        {
            this.wordService = wordService;
        }

        public List<Word> Get()
        {
            return wordService.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Word Get(int id)
        {
            return wordService.GetById(id);
        }

        [HttpPost]
        public void Create(CreateWordDto dto)
        {
            wordService.Create(dto.Word, dto.Synonyms);
        }

        [Route("/api/[controller]/search/{search?}")]
        public List<Word> Search(string search = "")
        {
            return wordService.Search(search).ToList();
        }
    }
}
