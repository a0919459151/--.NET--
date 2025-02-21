using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class DepartmentRepository
{
    // 定義資料庫連線字串
    private readonly string _connectionString = "your_connection_string";

    /// <summary>
    /// 查詢 Departments 資料表
    /// </summary>
    /// <param name="departmentId">部門 ID，可選參數</param>
    /// <param name="userId">用戶 ID，可選參數</param>
    /// <returns></returns>
    public IEnumerable<object> GetDepartments(string? departmentId, string? userId)
    {
        // 用於存放查詢結果
        var departments = new List<object>();

        // 建立資料庫連線
        using (var cn = new SqlConnection(_connectionString))
        {
            cn.Open(); // 開啟資料庫連線
            
            // 基礎 SQL 查詢語句
            var sql = """
                SELECT 
                    DepartmentId, 
                    UserId, 
                    UserName 
                FROM Departments
                WHERE 1=1
            """;

            // 用於存放 SQL 參數
            var parameters = new List<SqlParameter>();

            // 若傳入 departmentId，則加入篩選條件
            if (!string.IsNullOrEmpty(departmentId))
            {
                sql += " AND DepartmentId = @DepartmentId";
                parameters.Add(new SqlParameter("@DepartmentId", SqlDbType.VarChar, 50) { Value = departmentId });
            }

            // 若傳入 userId，則加入篩選條件
            if (!string.IsNullOrEmpty(userId))
            {
                sql += " AND UserId = @UserId";
                parameters.Add(new SqlParameter("@UserId", SqlDbType.VarChar, 50) { Value = userId });
            }

            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddRange(parameters.ToArray());

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        departments.Add(new
                        {
                            DepartmentId = dr["DepartmentId"].ToString(),
                            UserId = dr["UserId"].ToString(),
                            UserName = dr["UserName"] as string
                        });
                    }
                }
            }
        }

        // 
