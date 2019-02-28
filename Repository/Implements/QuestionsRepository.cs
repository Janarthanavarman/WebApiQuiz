using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiQuiz.Models;

namespace WebApiQuiz.Repository{
    class QuestionsRepository:IQuestionsRepository
    {
        readonly DBContext iDBContext;
        public QuestionsRepository(DBContext iDBContext){
               this.iDBContext =iDBContext;
        }

        public List<TblMstQuestions> getALL()
        {
            
              try{
                return iDBContext.TblMstQuestions.Where(x=> x.IsActive =="Y" ).ToList();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
        }

        public List<TblMstQuestions> getBy(int id)
        {
            
              try{
                return iDBContext.TblMstQuestions.Where(x=>x.QuizCategoryId ==id && x.IsActive =="Y" ).ToList();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
        }
    }
}