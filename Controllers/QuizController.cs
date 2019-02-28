using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiQuiz.Service;

namespace WebApiQuiz.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {

        readonly IQuizService  iQuizService;

        public QuizController(IQuizService iQuizService){
            this.iQuizService=iQuizService;
        }
        // GET api/values
        [HttpGet]
        public IActionResult GetALL()
        {
            try{
            var result =iQuizService.GetALL();//GetQuizCategory();
            if(result.ToUpper()!="null" && !String.IsNullOrEmpty(result))
               return Ok(result);
               else
               return NoContent();
            }catch(Exception ex){
                Console.Write("============="+ex.Message);
                return NotFound();
            }
        }

          [HttpGet]
        public IActionResult Get()
        {
            try{
            var result =iQuizService.GetQuizCategory();
            if(result.ToUpper()!="null" && !String.IsNullOrEmpty(result))
               return Ok(result);
               else
               return NoContent();
            }catch(Exception ex){
                Console.Write("============="+ex.Message);
                return NotFound();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(iQuizService.GetQustionBundle(id));
        }
       
    }
}
