﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace Shop.Infrastructure.Persistent.Dapper;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    //For various schemas.
    public string Inventories => "[seller].Inventories";
    public string UserAddresses => "[user].Addresses";
    public string OrderItems => "[order].Items";
    public string Products => "[product].Products";
    public string Sellers => "[seller].Sellers";
    public string UserTokens => "[user].Tokens";
}