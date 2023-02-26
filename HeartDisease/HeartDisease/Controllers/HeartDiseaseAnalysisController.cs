using System;
using Microsoft.AspNetCore.Mvc;
using HeartDisease.Interfaces;
using HeartDisease.Models;
namespace HeartDisease.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeartDiseaseAnalysisController : ControllerBase
    {
        private readonly ILogger<HeartDiseaseAnalysisController> _logger;
        private readonly IHeartRepository _heartRepository;

        public HeartDiseaseAnalysisController(ILogger<HeartDiseaseAnalysisController> logger, IHeartRepository heartRepository)
        {
            _logger = logger;
            _heartRepository = heartRepository;
        }
        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns> all data</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Heart>))]
        public IActionResult GetHearts()
        {
            _logger.Log(LogLevel.Information, "Get Heart data analysis");
            return Ok(_heartRepository.GetHearts());
        }


        /// <summary>
        /// get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data by id</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Heart))]
        [ProducesResponseType(404)]

        public IActionResult GetHeart(int id)
        {
            Heart heart = _heartRepository.GetHeart(id);


            if (heart == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(heart);
            }

        }
        /// <summary>
        /// Add a data
        /// </summary>
        /// <param name="heart"></param>
        /// <returns>new data</returns>

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateAnalysis([FromBody] Heart heart)
        {
            if (heart == null)
            {
                return BadRequest("Heart is null");
            }

            bool result = _heartRepository.CreateHeart(heart);

            if (result)
            {
                return Ok("Successfully added");
            }
            else
            {
                return BadRequest("Heart not added");
            }
        }


        /// <summary>
        /// Update with respct to id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="heart"></param>
        /// <returns>updated value</returns>

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]

        public IActionResult UpdateHeart([FromBody] Heart heart)
        {
            if (heart == null)
            {
                return BadRequest("heart is null");
            }

            Heart dbHeart = _heartRepository.GetHeart(heart.Id);

            if (dbHeart == null)
            {
                return BadRequest("heart not found");
            }

            dbHeart.Description = heart.Description;
            dbHeart.IsCompleted = heart.IsCompleted;
            dbHeart.age = heart.age;
            bool isUpdated = _heartRepository.UpdateHeart(dbHeart);

            return isUpdated ? Ok() : BadRequest();
        }

        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deleted</returns>

        [HttpDelete("{id}")]

        public IActionResult DeleteHeart(int id)
        {
            bool isDeleted = _heartRepository.DeleteHeart(id);

            return isDeleted ? Ok() : BadRequest();
        }

        /// <summary>
        /// analyse the data
        /// </summary>
        /// <returns> all data</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(string))]
        [Route("age")]
        public IActionResult GetHeartDiseaseDataAnalysis(int age)
        {
            return Ok(_heartRepository.GetHeartsAnalysis(age));
        }
    }
}

