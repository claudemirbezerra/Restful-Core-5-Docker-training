﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestCore5Training.Models;
using RestCore5Training.Services;

namespace RestCore5Training.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger,
            IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var result = _personService.FindById(id);

            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Create(person));

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person != null)
                return Ok(_personService.Update(person));

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NotFound();
        }
    }
}
