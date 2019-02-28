using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiQuiz.Models;

namespace WebApiQuiz.Repository{
    class QuizOptionRepository:IQuizOptionRepository
    {
        readonly DBContext iDBContext;
        public QuizOptionRepository(DBContext iDBContext){
               this.iDBContext =iDBContext;
        }

        public List<TblMstQuizOption> getALL()
        {
             try{
                return iDBContext.TblMstQuizOption.Where(x=>x.IsActive =="Y").ToList();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
        }

        public List<TblMstQuizOption> getBy(int QuizId)
        {
              try{
                return iDBContext.TblMstQuizOption.Where(x=>x.QuizCategoryId ==QuizId && x.IsActive =="Y" ).ToList();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
        }

        public List<TblMstQuizOption> getBy(int QuizId, int QustionId)
        {
             try{
                return iDBContext.TblMstQuizOption.Where(x=>x.QuizCategoryId ==QuizId && x.QuizQuestionId ==QustionId  && x.IsActive =="Y" ).ToList();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
        }
    }
}