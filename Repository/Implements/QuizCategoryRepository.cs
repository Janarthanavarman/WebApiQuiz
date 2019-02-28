using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiQuiz.Models;

namespace WebApiQuiz.Repository{
    class QuizCategoryRepository:IQuizCategoryRepository
    {
        readonly DBContext iDBContext;
        public QuizCategoryRepository(DBContext iDBContext){
               this.iDBContext =iDBContext;
        }
       
       public List<TblMstQuizCategory> getALL(){
            try{
                return iDBContext.TblMstQuizCategory.Where(x=>x.IsActive =="Y").ToList();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
       }      

       public TblMstQuizCategory getBy(int id){
            try{
                return iDBContext.TblMstQuizCategory.Where(x=> x.QuizId==id).FirstOrDefault();
            }catch(Exception ex){
                Console.WriteLine("+++++++++++++++  " +ex.Message);
                return null;
            }
       }
       
    }
}