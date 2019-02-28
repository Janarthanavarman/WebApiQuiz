using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiQuiz.Models
{
     [Table("Tbl_Mst_QuizCategory")]
    public partial class TblMstQuizCategory
    {
        public int Id { get; set; }
        public string QuizName { get; set; }
        public string Description { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Key]
        public int QuizId { get; set; }
    }
}
