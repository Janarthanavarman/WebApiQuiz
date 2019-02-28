using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiQuiz.Models
{
    [Table("Tbl_Mst_QuizOption")]
    public partial class TblMstQuizOption
    {
        [Key]
        public int OptionId { get; set; }
        public int QuizCategoryId { get; set; }
        public int QuizQuestionId { get; set; }
        public string Options { get; set; }
        public string IsActive { get; set; }
        public string Remarks { get; set; }
        public string Createdby { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string ModifedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsAnswer { get; set; }
    }
}
