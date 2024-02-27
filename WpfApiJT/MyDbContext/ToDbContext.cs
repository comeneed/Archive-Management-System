using Microsoft.EntityFrameworkCore;
using WpfApi.Models;

namespace WpfApi.MyDbContext
{
    public class ToDbContext:DbContext
    {
            public ToDbContext(DbContextOptions<ToDbContext> options) : base(options)
            {

            }
            public DbSet<Memo> Memos { get; set; }
            public DbSet<ToDo> ToDos { get; set; }
        }
    }

