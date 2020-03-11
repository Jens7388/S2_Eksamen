﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    /// <summary>
    /// Represents the data source.
    /// </summary>
public class Repository
{
    #region Fields and constants
    const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=5;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    #endregion


    #region Constructors
    /// <summary>
    /// Initializes a new instance of Repository. Attempts to establish a connection, and will throw an exception on connection error.
    /// </summary>
    public Repository()
    {
        try
        {
            SqlConnection connection = GetConnection(connectionString) as SqlConnection;
            (bool, Exception) connectionAttemptResult = TryConnectUsing(connection);
        }
        catch(Exception e)
        {
            throw new Exception("Data access error. See inner exception for details", e);
        }
    }
    #endregion


    #region Helper Methods
    /// <summary>
    /// Executes the provided SQL statement and returns data wrapped in a data set, if any.
    /// </summary>
    /// <param name="sql">The SQL statement to execute.</param>
    /// <returns>A <see cref="DataSet"/> wrapping any returned data.</returns>
    /// <exception cref="ArgumentException"/>
    /// <exception cref=""
    public DataSet Execute(string query)
    {
        if(string.IsNullOrWhiteSpace(query))
        {
            throw new ArgumentException("Null or whitespace.");
        }
        DataSet resultSet = new DataSet();
        try
        {
            SqlConnection connection = GetConnection(connectionString) as SqlConnection;
            using(SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand(query, connection)))
            {
                adapter.Fill(resultSet);
            }
            return resultSet;
        }
        catch(Exception e)
        {
            throw new Exception("Data access error. See inner exception for details", e);
        }
    }
    /// <summary>
    /// Creates a connection based on the name of the input parameter connection string.
    /// </summary>
    /// <param name="connectionString">The name of the connection string.</param>
    /// <returns>A new connection.</returns>
    private static DbConnection GetConnection(string connectionString)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }

    /// <summary>
    /// Attempts to connect to a data source using the provided connection.
    /// </summary>
    /// <param name="connection">The connection to use.</param>
    /// <returns>True, if the connection could be established, false otherwise.</returns>
    public (bool, Exception) TryConnectUsing(DbConnection connection)
    {
        try
        {
            using(connection)
            {
                connection.Open();
                connection.Close();
            }
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    /// <summary>
    /// Extract all data relevant to an employee from a dat row object, and return an employee object.
    /// </summary>
    /// <param name="dataRow"></param>
    /// <returns></returns>
    private static Order ExtractOrderFrom(DataRow dataRow)
    {
        int orderID = (int)dataRow["OrderID"];
        string customerID = (string)dataRow["CustomerID"];
        int employeeID = (int)dataRow["EmployeeID"];
        DateTime orderDate = (DateTime)dataRow["OrderDate"];
        DateTime requiredDate = (DateTime)dataRow["RequiredDate"];
        DateTime shippedDate = (DateTime)dataRow["ShippedDate"];
        int shipVia = (int)dataRow["ShipVia"];
        decimal freight = (decimal)dataRow["Freight"];
        string shipName = (string)dataRow["ShipName"];
        string shipAddress = (string)dataRow["ShipAddress"];
        string shipCity = (string)dataRow["ShipCity"];
        string shipRegion = (string)dataRow["ShipRegion"];
        string shipPostalCode = (string)dataRow["ShipPostalCode"];
        string shipCountry = (string)dataRow["ShipCountry"];

        Order order = new Order(orderID, customerID, employeeID, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry);

        return order;
    }
    #endregion


    #region Repository Methods
    /// <summary>
    /// Gets all employees.
    /// </summary>
    /// <returns>A list of all employees</returns>
    public List<Order> GetAllOrders()
    {
        List<Order> orders = new List<Order>();
        string query = "SELECT * FROM Orders";
        DataSet resultSet;
        try
        {
            resultSet = Execute(query);
        }
        catch(Exception)
        {
            throw;
        }

        if(resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
        {
            foreach(DataRow dataRow in resultSet.Tables[0].Rows)
            {
                Order order = ExtractOrderFrom(dataRow);
                orders.Add(order);
            }
        }
        return orders;
    }
    #endregion
}
}