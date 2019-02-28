
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiQuiz.Models;

namespace WebApiQuiz.Repository{
public  interface IQuizOptionRepository
{
      List<TblMstQuizOption> getALL();
        List<TblMstQuizOption> getBy(int QuizId);
        List<TblMstQuizOption> getBy(int QuizId,int QustionId);
}
}
