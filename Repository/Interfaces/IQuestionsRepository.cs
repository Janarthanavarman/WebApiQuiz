using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiQuiz.Models;

namespace WebApiQuiz.Repository{
public  interface IQuestionsRepository
{
      List<TblMstQuestions> getALL();
       List<TblMstQuestions> getBy(int id);
}
}
