using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApiQuiz.Repository;


namespace WebApiQuiz.Service{
    class QuizService:IQuizService
    {
        readonly IQuizCategoryRepository iQuizCategoryRepository;
        readonly IQuestionsRepository iQuestionsRepository;
        readonly IQuizOptionRepository iQuizOptionRepository;
        public QuizService(IQuestionsRepository iQuestionsRepository,IQuizCategoryRepository iQuizCategoryRepository, 
                           IQuizOptionRepository iQuizOptionRepository){
               this.iQuestionsRepository =iQuestionsRepository;
               this.iQuizCategoryRepository=iQuizCategoryRepository;
               this.iQuizOptionRepository=iQuizOptionRepository;
        }     

        public string GetQuizCategory()
        {
             try{
                 var result =this.iQuizCategoryRepository.getALL();
                 if(result!=null)
                 return JsonConvert.SerializeObject(result.Select(x=> new { id = x.QuizId,name =x.QuizName}).ToList());
                 else
                 return null;
            }catch(Exception ex){
                Console.WriteLine("--------------  " +ex.Message);
                return null;
            }
        }


        public string GetALL()
        {
             try{
                 var result =this.iQuizCategoryRepository.getALL();
                 if(result!=null)
                 return JsonConvert.SerializeObject(
                     new {
                     Category = result.Select(x=> new { id = x.QuizId,name =x.QuizName}).ToList(),
                     Qustions = this.iQuestionsRepository.getALL(),
                     Options = this.iQuizOptionRepository.getALL(),
                     }
                     );
                 else
                 return null;
            }catch(Exception ex){
                Console.WriteLine("--------------  " +ex.Message);
                return null;
            }
        }

           public string GetQustionBundle(int id)
        {
            try{

                var Cate =iQuizCategoryRepository.getBy(id);
                if(Cate==null)
                return null;

                 var result =  new { id = Cate.Id ,name=Cate.QuizName ,description =Cate.Description ,
                                        questions = this.iQuestionsRepository.getBy(Cate.Id)
                                                        .Select(x=> new { 
                                                            id =x.QuestionId,
                                                            name =x.Questions,
                                                            questionTypeId =x.QuestionTypeid,
                                                            options = this.iQuizOptionRepository.getBy(Cate.Id,x.QuestionId)
                                                                        .Select(T=> new { 
                                                                                id =T.OptionId,
                                                                                questionId=T.QuizQuestionId,
                                                                                name =T.Options,
                                                                                isAnswer =T.IsAnswer
                                                                                }),             
                                                            }).ToList(),
                                        
                                    };

            return  JsonConvert.SerializeObject(result);

            }catch(Exception ex){
                Console.WriteLine("------------------------  " +ex.Message);
                return null;
            }
        }
    }
}