using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiQuiz.Models
{
    [Table("Tbl_Mst_Questions")]
    public partial class TblMstQuestions
    {
        [Key]
        public int QuestionId { get; set; }
        public int QuizCategoryId { get; set; }
        public string Questions { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? QuestionTypeid { get; set; }
    }
}
