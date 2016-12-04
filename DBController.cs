using Kino.Entity;
using Kino.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino
{
    static class DBController
    {
        public static void DelSchedule(int id)
        {
            DoStoredProc("DelSchedule", new ParameterStoredProc(SqlDbType.Int, "@schId", id)); 
        }
        public static void AddSchedule(DateTime start, int film_id, Double money, int hall_id)
        {
            DoStoredProc("AddSchedule",
                new ParameterStoredProc(SqlDbType.DateTime2, "@start", start),
                new ParameterStoredProc(SqlDbType.Int, "@film_id", film_id),
                new ParameterStoredProc(SqlDbType.Decimal, "@Price", money),
                new ParameterStoredProc(SqlDbType.Int, "@hall_id", hall_id));
        }
        public static List<FilmsByDate> GetInfoByDate(DateTime start, DateTime end)
        {
            DataTable dataTable = DoStoredProc("GetInfoByDate", new ParameterStoredProc(SqlDbType.DateTime2, "@start", start)
                , new ParameterStoredProc(SqlDbType.DateTime2, "@end", end));
            List<FilmsByDate> films = new List<FilmsByDate>();
            foreach (DataRow film in dataTable.Rows)
            {
                films.Add(new FilmsByDate(
                    film[0].ToString(),
                    Convert.ToInt32(film[1].ToString()),
                    Convert.ToDouble(film[2].ToString())));
            }
            return films;
        }
        public static Dictionary<string, double> GetTotalByFilm(int id)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();
            DataTable dataTable = DoStoredProc("GetTotalByFilm"
                , new ParameterStoredProc(SqlDbType.Int, "@film_id", id.ToString()));
            if (dataTable.Rows[0][0].ToString() == "0")
            {
                dict.Add("Tickets", 0);
                dict.Add("Total", 0);
            }
            else
            {
                dict.Add("Tickets", Double.Parse(dataTable.Rows[0][0].ToString()));
                dict.Add("Total", Double.Parse(dataTable.Rows[0][1].ToString()));
            }
            return dict;
        }
        public static List<Film> GetAllFilms()
        {
            List<Film> films = new List<Film>();
            DataTable dataTable = DoStoredProc("GetAllFilms");
            foreach (DataRow film in dataTable.Rows)
            {
                films.Add(new Film(
                    (int)film["film_id"],
                    film["Title"].ToString(),
                    (int)film["LengthInMinute"],
                    film["Description"].ToString()));
            }
            return films;
        }
        public static List<Hall> GetAllHalls()
        {
            List<Hall> halls = new List<Hall>();
            DataTable dataTable = DoStoredProc("GetAllHalls");
            foreach (DataRow hall in dataTable.Rows)
            {
                halls.Add(new Hall(
                    (int)hall["Hall_id"],
                    hall["HallName"].ToString()));
            }
            return halls;
        }
        public static void AddFilm(string title, int length, string desc)
        {
            DoStoredProc("AddFilm",
                new ParameterStoredProc(SqlDbType.NVarChar, "@Title", title),
                new ParameterStoredProc(SqlDbType.Int, "@LengthInMinute", length),
                new ParameterStoredProc(SqlDbType.NVarChar, "@Description", desc));
        }
        public static void SailTicket(int Schedule_id, int PlaceInHall_id)
        {
            DoStoredProc("SailTicket",
                new ParameterStoredProc(SqlDbType.Int, "@schId", Schedule_id),
                new ParameterStoredProc(SqlDbType.Int, "@placeId", PlaceInHall_id));

        }
        public static List<Ticket> GetAllTicketsBySchedule(int schId)
        {
            List<Ticket> tickets = new List<Ticket>();
            DataTable dataTable = DoStoredProc("GetAllTicketsBySchedule"
                , new ParameterStoredProc(SqlDbType.Int, "@schId", schId));
            foreach (DataRow ticket in dataTable.Rows)
            {
                tickets.Add(new Ticket(
                    (int)ticket["Ticket_id"],
                     (int)ticket["Schedule_id"],
                    (int)ticket["PlaceInHall_id"],
                    (int)ticket["coordX"],
                    (int)ticket["coordY"]));
            }
            return tickets;
        }
        public static List<PlaceInHall> GetAllPlaceInHall(int hallId)
        {
            List<PlaceInHall> plases = new List<PlaceInHall>();
            DataTable dataTable = DoStoredProc("GetAllPlaceInHall"
                , new ParameterStoredProc(SqlDbType.Int, "@hallId", hallId));
            foreach (DataRow place in dataTable.Rows)
            {
                plases.Add(new PlaceInHall(
                    (int)place["PlaceInHall_id"],
                     (int)place["Hall_id"],
                    (int)place["coordX"],
                     (int)place["coordY"]));
            }
            return plases;
        }
        public static string GetFilmTitleById(int id)
        {
            string title;
            DataTable dataTable = DoStoredProc("GetFilmTitleById"
                , new ParameterStoredProc(SqlDbType.Int, "@id", id));
            title = dataTable.Rows[0][0].ToString();
            return title;
        }
        public static string GetHallNameById(int id)
        {
            string title;
            DataTable dataTable = DoStoredProc("GetHallNameById"
                , new ParameterStoredProc(SqlDbType.Int, "@id", id));
            title = dataTable.Rows[0][0].ToString();
            return title;
        }
        public static List<SchedulePresent> GetSchedulersByDate(DateTime date)
        {
            List<SchedulePresent> schedulers = new List<SchedulePresent>();
            DataTable dataTable = DoStoredProc("GetSchedulersByDate"
                ,new ParameterStoredProc(SqlDbType.DateTime2, "@date", date));
            foreach (DataRow schedule in dataTable.Rows)
            {
                schedulers.Add(new SchedulePresent( 
                    new Schedule(
                    (int)schedule["Schedule_id"],
                    (DateTime)schedule["StartTime"],
                    (int)schedule["Film_id"],
                    Double.Parse(schedule["Price"].ToString()),
                    (int)schedule["Hall_id"])));                
            }
            return schedulers;
        }
        public static DataTable DoStoredProc(string procName, params ParameterStoredProc[] parameters)
        {
            DataTable dataTable = new DataTable();
            
                SqlDataAdapter adapter = new SqlDataAdapter(procName, ConnectionMaster.GetInstance().Connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                foreach (var parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.Add(parameter.key, parameter.sqlType).Value = parameter.value;
                }
                adapter.Fill(dataTable);
            return dataTable;
        }

    }
}
