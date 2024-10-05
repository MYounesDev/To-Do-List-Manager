using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List_Manager.Helpers;

namespace To_Do_List_Manager.Entities
{
    public class CurrentTask
    {
        public String TaskDiscription;
        public int CurrentTaskId;
        public static bool DeleteCurrentTask(int taskId)
        {   
            using (SqlConnection sqlConnection = DBHelper.OpenConnection())
            {
                string query = "DELETE FROM CurrentTasks where CurrentTaskId = @taskId";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@taskId", taskId);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public static bool DeleteAllCurrentTask()
        {
            using (SqlConnection sqlConnection = DBHelper.OpenConnection())
            {
                string query = "DELETE FROM CurrentTasks";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static int AddCurrentTask(string taskDescription)// basarisiz durumda 0 donuyor
        {
            if (taskDescription == null)
            {
                return -1;
            }
            try
            {
                string query = "Insert Into CurrentTasks(TaskDescription)" +
                       " Values(@TaskDescription)" +
                       " SELECT SCOPE_IDENTITY();";


                using (SqlConnection sqlConnection = DBHelper.OpenConnection())
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@TaskDescription", taskDescription);

                    object result = command.ExecuteScalar();

                    if (result == null)
                    {
                        return -1;
                    }

                    int laskTaskId = Convert.ToInt32(result);

                    return laskTaskId;

                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public static List<CurrentTask> GetCurrentTasks()
        {
            List<CurrentTask> tasks = new List<CurrentTask>();
            string query = "Select CurrentTaskId, TaskDescription from CurrentTasks";

            using (SqlConnection connection = DBHelper.OpenConnection())
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    CurrentTask task = new CurrentTask
                    {
                        CurrentTaskId = Convert.ToInt32(reader["CurrentTaskId"]),
                        TaskDiscription = reader["TaskDescription"].ToString()
                    };
                    tasks.Add(task);
                }
                return tasks;
            }
        }

    }
}
