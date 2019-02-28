using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiQuiz.Models;

namespace WebApiQuiz.Repository
{
    public interface IQuizCategoryRepository
    {
        List<TblMstQuizCategory> getALL();
        TblMstQuizCategory getBy(int id);
    }

}
