using System;
using Microsoft.AspNetCore.Mvc;

namespace HeartDisease.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeartDiseaseAnalysisController : ControllerBase
    {
        private readonly ILogger<HeartDiseaseAnalysisController> _logger;

        public HeartDiseaseAnalysisController(ILogger<HeartDiseaseAnalysisController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// get all the data
        /// </summary>
        /// <returns> all data</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<HeartDiseaseAnalysis>))]
        public IActionResult GetHeartDiseaseAnalysis()
        {
            return Ok(HeartDiseaseAnalysisRepository.getInstance().getHearts());
        }


        /// <summary>
        /// get data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>data by id</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(HeartDiseaseAnalysis))]
        [ProducesResponseType(404)]

        public IActionResult GetHeartDisease(int id)
        {
            HeartDiseaseAnalysis heart = HeartDiseaseAnalysisRepository.getInstance().GetHeart(id);


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

        public IActionResult CreateAnalysis([FromBody] HeartDiseaseAnalysis heart)
        {
            if (heart == null)
            {
                return BadRequest("Heart is null");
            }

            bool result = HeartDiseaseAnalysisRepository.getInstance().addHeart(heart);

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

        public IActionResult UpdateHeart(int id, HeartDiseaseAnalysis heart)
        {
            if (heart == null)
            {
                return BadRequest("heart is null");
            }
            bool isUpdated = HeartDiseaseAnalysisRepository.getInstance().editHeart(id, heart);

            if (!isUpdated)
            {
                return NotFound("No matching heart");
            }
            else
            {
                return Ok("Successfully updated");
            }
        }

        /// <summary>
        /// delete by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deleted</returns>

        [HttpDelete("{id}")]

        public IActionResult DeleteHeart(int id)
        {
            bool deleted = HeartDiseaseAnalysisRepository.getInstance().deleteHeart(id);

            if (!deleted)
            {
                return NotFound("No matching id");
            }
            else
            {
                return Ok("Heart deleted");
            }
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
            return Ok(HeartDiseaseAnalysisRepository.getInstance().getHeartsAnalysis(age));
        }
    }
}

