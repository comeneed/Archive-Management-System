using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFProject.Common.Models;
using WPFProject.Service;

namespace WPFProject.ServerInfo
{
    public class ToDoService : BaseService<ToDoDto>, IToDoService
    {
        public ToDoService(HttpRestClient client) : base(client, "ToDo")
        {
        }
    }
}
