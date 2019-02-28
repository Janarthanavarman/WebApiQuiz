using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiQuiz.Models;

namespace WebApiQuiz.Service{
public  interface IQuizService
{
   string GetQuizCategory();
   string GetQustionBundle(int id);
   string GetALL();

}
}
