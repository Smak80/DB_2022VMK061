using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DB_2022VMK061;
public static class DBHelper
{
    private static SqlConnection? _conn;
    public static bool Connect(string connStr)
    {
        try
        {
            _conn = new SqlConnection(connStr);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void ExecuteNonQuery(SqlCommand cmd)
    {
        if (_conn is { } conn)
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Working on closed connection");
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }

    private static void ExequteQuery(SqlCommand cmd, out BindingList<Student> stds)
    {
        stds = new BindingList<Student>();
        if (_conn is { } conn)
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Connection = conn;
                    var dr = cmd.ExecuteReader();
                    if (dr is { } r)
                    {
                        if (r.HasRows)
                        {
                            while (r.Read())
                            {
                                stds.Add(new Student(
                                    r.GetInt32("Id"),
                                    r.GetString("fname"),
                                    r.GetString("lname"),
                                    r.GetString("group"),
                                    0.0,
                                    new DateTime(),
                                    r.GetBoolean("gender")
                                ));
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Working on closed connection");
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }

    public static void CreateMainTable()
    {
        var query = "CREATE TABLE stud(" +
                    "id int not null primary key identity, " +
                    "lname varchar(50) not null, " +
                    "fname varchar(50) not null, " +
                    "mname varchar(50), " +
                    "[group] varchar(6) not null, " +
                    "gender bit not null default 1);";
        var cmd = new SqlCommand();
        cmd.CommandText = query;
        ExecuteNonQuery(cmd);
    }

    public static void InsertData(params Student[] std)
    {
        var query = "INSERT INTO stud (" +
                    "lname, fname, [group], gender) " +
                    "VALUES (@lname, @fname, @gr, @gend)" +
                    ";";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        foreach (var stud in std)
        {
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("lname", stud.LastName);
            cmd.Parameters.AddWithValue("fname", stud.FirstName);
            cmd.Parameters.AddWithValue("gr", stud.Group);
            cmd.Parameters.AddWithValue("gend", stud.Gender);
            ExecuteNonQuery(cmd);
        }
    }

    public static BindingList<Student> GetData()
    {
        BindingList<Student> stds;
        var query = "SELECT * FROM stud;";
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        ExequteQuery(cmd, out stds);
        return stds;
    }
}
