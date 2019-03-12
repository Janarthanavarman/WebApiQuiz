using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiQuiz.Models;
using WebApiQuiz.Service;

namespace WebApiQuiz.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    [EnableCors("ngCrosPolicy")]
    public class QuizController : ControllerBase
    {

        readonly IQuizService  iQuizService;

        public QuizController(IQuizService iQuizService){
            this.iQuizService=iQuizService;
        }
        // GET api/values
        [DisableCors]
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
             try{
                var result =iQuizService.GetQustionBundle(id);
                if(result.ToUpper()!="null" && !String.IsNullOrEmpty(result))
                    return Ok(result);
               else
                     return NoContent();
            }catch(Exception ex){
                Console.Write("============="+ex.Message);
                return NotFound();
            }
        }
        [HttpPut]
        public IActionResult put(){     
            //List<IFormFile> files  
            try{          

            var fw =HttpContext.Request.Form.Files["JSON"];            
            Console.WriteLine("++++++++++++++++" + HttpContext.Request.Form["FFFF"]); 
            string filedata="";
            using(var file=new StreamReader(fw.OpenReadStream())){            
            filedata=file.ReadToEnd();
            }
            Console.WriteLine("++++++++++++++++"+filedata);                                   
            
                            // Date = Convert.ToDateTime(HttpContext.Current.Request.Form["Date"]).ToString("ddMMMyyyy"),
                            // Image = HttpContext.Current.Request.Files["Image"] ,
                            // PDF = HttpContext.Current.Request.Files["PDF"] ,
                            // Content = HttpContext.Current.Request.Form["Content"] ,
                            // ImageContent = HttpContext.Current.Request.Form["ImageContent"] ,
                            // ContentFile =HttpContext.Current.Request.Files["ContentFile"] ,
                            // cmd =HttpContext.Current.Request.Form["cmd"]
            var dy=JsonConvert.DeserializeObject<RootObject>(filedata);//@""); 


            return Ok(dy);
            }
            catch(Exception ex){
                Console.WriteLine("++++++++++"+ex.Message);
                return StatusCode(503);// Service unavailable
            }

        }
       
    }
}
