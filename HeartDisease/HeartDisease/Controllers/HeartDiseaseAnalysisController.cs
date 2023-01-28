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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<HeartDiseaseAnalysis>))]
        public IActionResult GetHeartDiseaseAnalysis()
        {
            return Ok(HeartDiseaseAnalysisRepository.getInstance().getHearts());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
    }
}

