using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiQuiz.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<TblMstQuestions> TblMstQuestions { get; set; }
        public virtual DbSet<TblMstQuizCategory> TblMstQuizCategory { get; set; }
        public virtual DbSet<TblMstQuizOption> TblMstQuizOption { get; set; }       
    }
}
