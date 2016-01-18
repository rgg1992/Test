using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WingtipToys.Logic;

/// <summary>
/// Summary description for Database
/// </summary>
public class DB
{
    //public Database()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}


    public int getCarCountForUser(string user)
    {
        int count = -99;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getCarCountForUser";

            //set up the parameters
            cmd.Parameters.Add("@user", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@count", System.Data.SqlDbType.VarChar, 50).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@user"].Value = user;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            count = Convert.ToInt32(cmd.Parameters["@count"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return count;
    }

    public int insertCar(Car car, string user)
    {
        int car_id = 0;
        try
        {
            string query = "dbo.insertCar";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Connection = conn;

            //set up the parameters
            cmd.Parameters.Add("@bnd", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@mdl", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@year", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@eng", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@fuel", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@pwr", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@usr", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@bnd"].Value = car.getCarBrand();
            cmd.Parameters["@mdl"].Value = car.getCarModel();
            cmd.Parameters["@year"].Value = car.getCarYear();
            cmd.Parameters["@eng"].Value = car.getCarEngine();
            cmd.Parameters["@fuel"].Value = car.getCarFuel();
            cmd.Parameters["@pwr"].Value = car.getCarHPowers();
            cmd.Parameters["@img"].Value = car.getCarImage();
            cmd.Parameters["@usr"].Value = user;


            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            car_id = Convert.ToInt32(cmd.Parameters["@id"].Value);
            //car_id = (int)cmd.ExecuteScalar();

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }

        return car_id;
    }

    public Car readCar(int carId, string user)
    {
        Car car = new Car();

        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.readCar";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@user", System.Data.SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@bnd", System.Data.SqlDbType.NVarChar, 50).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("@mdl", System.Data.SqlDbType.NVarChar, 50).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("@year", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("@eng", System.Data.SqlDbType.NVarChar, 50).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("@fuel", System.Data.SqlDbType.NVarChar, 50).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("@pwr", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 500).Direction = System.Data.ParameterDirection.Output;


            //set parameter values
            cmd.Parameters["@id"].Value = carId;
            cmd.Parameters["@user"].Value = user;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            car.setCarBrand(cmd.Parameters["@bnd"].Value.ToString());
            car.setCarModel(cmd.Parameters["@mdl"].Value.ToString());
            car.setCarYear(Convert.ToInt32(cmd.Parameters["@year"].Value));
            car.setCarEngine(cmd.Parameters["@eng"].Value.ToString());
            car.setCarFuel(cmd.Parameters["@fuel"].Value.ToString());
            car.setCarHPowers(Convert.ToInt32(cmd.Parameters["@pwr"].Value));
            car.setCarImage(cmd.Parameters["@img"].Value.ToString());
            car.setId(carId);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return car;
    }

    public double getAvgCons(int carId)
    {
        double avgCons = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getAvgCons";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@avg", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            avgCons = Convert.ToDouble(cmd.Parameters["@avg"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return avgCons;
    }

    public int getFillUps(int carId)
    {
        int fillUps = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getFillUps";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@fillUps", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            fillUps = Convert.ToInt32(cmd.Parameters["@fillUps"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return fillUps;
    }

    public double getMinCons(int carId)
    {
        double minCons = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getMinCons";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@min", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            minCons = Convert.ToDouble(cmd.Parameters["@min"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return minCons;
    }


    public int getKM(int carId)
    {
        int km = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getKM";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@km", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            km = Convert.ToInt32(cmd.Parameters["@km"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return km;
    }

    public double getTotalPrice(int carId)
    {
        double price = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getTotalPrice";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            price = Convert.ToDouble(cmd.Parameters["@price"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return price;
    }

    public List<int> getCarIDsForUser(string user)
    {
        List<int> carIDs = new List<int>();
        int id = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getCarIDsForUser";

            //set up the parameters
            cmd.Parameters.Add("@user", System.Data.SqlDbType.NVarChar, 50);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@user"].Value = user;

            cmd.Connection = conn;
            conn.Open();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id = dr.GetInt32(0);
                carIDs.Add(id);
            }

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return carIDs;
    }

    protected bool removeCar(int carId)
    {
        bool delete = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.removeCar";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            //price = Convert.ToDouble(cmd.Parameters["@price"].Value);

            conn.Close();
            delete = true;
        }
        catch (Exception ex)
        {
            delete = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return delete;
    }

    protected bool removeCarFuels(int carId)
    {
        bool delete = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.removeCarFuels";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            //price = Convert.ToDouble(cmd.Parameters["@price"].Value);

            conn.Close();
            delete = true;
        }
        catch (Exception ex)
        {
            delete = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return delete;
    }

    protected bool removeCarOthers(int carId)
    {
        bool delete = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.removeCarOthers";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            //price = Convert.ToDouble(cmd.Parameters["@price"].Value);

            conn.Close();
            delete = true;
        }
        catch (Exception ex)
        {
            delete = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return delete;
    }

    public bool deleteCar(int carId)
    {
        if (removeCarFuels(carId))
            if (removeCarOthers(carId))
                if (removeCar(carId))
                    return true;
                else return false;
            else return false;
        else return false;
    }

    public int getPreviousMileage(int carId)
    {
        int prevMileage = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getPreviousMileage";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@prevMileage", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            prevMileage = Convert.ToInt32(cmd.Parameters["@prevMileage"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return prevMileage;
    }

    public string getFuelType(int carId)
    {
        string fuel = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getFuelType";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@fuel", System.Data.SqlDbType.NVarChar, 50).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            fuel = cmd.Parameters["@fuel"].Value.ToString();

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return fuel;
    }

    public string getFuelConsumptionLastDate(int carId)
    {
        string lastDate = "";
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getFuelConsumptionLastDate";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@last", System.Data.SqlDbType.NVarChar, 50).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            lastDate = cmd.Parameters["@last"].Value.ToString();

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return lastDate;
    }

    public bool addRefueling(int car_id, string date, int mileage, string fuelType, int distance, double liters, double unitPrice, double totalCost, double average)
    {
        bool insert = false;
        try
        {
            string query = "dbo.addRefueling";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Connection = conn;

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@date", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@mileage", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@fuel", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@dst", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@ltr", System.Data.SqlDbType.Float);
            cmd.Parameters.Add("@unit", System.Data.SqlDbType.Float);
            cmd.Parameters.Add("@total", System.Data.SqlDbType.Float);
            cmd.Parameters.Add("@avg", System.Data.SqlDbType.Float);
            //cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = car_id;
            cmd.Parameters["@date"].Value = date;
            cmd.Parameters["@mileage"].Value = mileage;
            cmd.Parameters["@fuel"].Value = fuelType;
            cmd.Parameters["@dst"].Value = distance;
            cmd.Parameters["@ltr"].Value = liters;
            cmd.Parameters["@unit"].Value = unitPrice;
            cmd.Parameters["@total"].Value = totalCost;
            cmd.Parameters["@avg"].Value = average;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            insert = true;

            conn.Close();
        }
        catch (Exception ex)
        {
            insert = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }

        return insert;
    }


    public bool updateCar(int carId, Car car)
    {
        bool update = false;
        try
        {
            string query = "dbo.updateCar";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Connection = conn;

            cmd.Parameters.Add("@bnd", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@mdl", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@year", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@eng", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@fuel", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@pwr", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

            //set parameter values
            cmd.Parameters["@bnd"].Value = car.getCarBrand();
            cmd.Parameters["@mdl"].Value = car.getCarModel();
            cmd.Parameters["@year"].Value = car.getCarYear();
            cmd.Parameters["@eng"].Value = car.getCarEngine();
            cmd.Parameters["@fuel"].Value = car.getCarFuel();
            cmd.Parameters["@pwr"].Value = car.getCarHPowers();
            cmd.Parameters["@img"].Value = car.getCarImage();
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            update = true;

            conn.Close();
        }
        catch (Exception ex)
        {
            update = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }

        return update;
    }

    public double getLitersConsumed(int carId)
    {
        double liters = 0;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getLitersConsumed";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@liters", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            liters = Convert.ToDouble(cmd.Parameters["@liters"].Value);

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return liters;
    }

    public List<FuelConsumption> getFuelConsumptionsForCar(int carId)
    {
        FuelConsumption item;
        List<FuelConsumption> fuelCons = new List<FuelConsumption>();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getFuelConsumptionsForCar";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                item = new FuelConsumption(dr.GetInt32(0), dr.GetInt32(1), dr.GetString(2), dr.GetInt32(3), dr.GetString(4), dr.GetInt32(5)
                    , dr.GetDouble(6), dr.GetDouble(7), dr.GetDouble(8), dr.GetDouble(9));

                fuelCons.Add(item);
            }

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return fuelCons;
    }

    public bool removeFuelRecord(int fuelID)
    {
        bool delete = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.removeFuelRecord";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = fuelID;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            //price = Convert.ToDouble(cmd.Parameters["@price"].Value);

            conn.Close();
            delete = true;
        }
        catch (Exception ex)
        {
            delete = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return delete;
    }

    public bool addOtherCost(OtherCost input)
    {
        bool insert = false;
        try
        {
            string query = "dbo.addOtherCost";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Connection = conn;

            //set up the parameters
            cmd.Parameters.Add("@car", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@cat", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@dat", System.Data.SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@mil", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@cost", System.Data.SqlDbType.Float);
            cmd.Parameters.Add("@not", System.Data.SqlDbType.NVarChar, 1000);

            //set parameter values
            cmd.Parameters["@car"].Value = input.getCar_id();
            cmd.Parameters["@cat"].Value = input.getCategory();
            cmd.Parameters["@dat"].Value = input.getDate();
            cmd.Parameters["@mil"].Value = input.getMileage();
            cmd.Parameters["@cost"].Value = input.getTotal_cost();
            cmd.Parameters["@not"].Value = input.getNotes();


            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            insert = true;

            conn.Close();
        }
        catch (Exception ex)
        {
            insert = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }

        return insert;
    }

    public List<OtherCost> getOtherCostsForCar(int carId)
    {
        OtherCost item;
        List<OtherCost> others = new List<OtherCost>();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getOtherCostsForCar";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                item = new OtherCost(dr.GetInt32(0), dr.GetInt32(1), dr.GetString(2), dr.GetString(3), dr.GetInt32(4), dr.GetDouble(5), dr.GetString(6));

                others.Add(item);
            }

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return others;
    }

     public bool removeOtherCost(int id)
    {
        bool delete = false;
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.removeOtherCost";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = id;

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            //price = Convert.ToDouble(cmd.Parameters["@price"].Value);

            conn.Close();
            delete = true;
        }
        catch (Exception ex)
        {
            delete = false;
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return delete;
    }

    public List<Tuple<Double, DateTime>> getTotalCostPerMonth(int carId)
    {
        Tuple<Double, DateTime> item;
        List<Tuple<Double, DateTime>> list = new List<Tuple<Double, DateTime>>();
        try
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "dbo.getTotalCostPerMonth";

            //set up the parameters
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);
            //cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@id"].Value = carId;

            cmd.Connection = conn;
            conn.Open();

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                item = Tuple.Create(dr.GetDouble(0), dr.GetDateTime(1));

                list.Add(item);
            }

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }
        return list;
    }

    public int addCarBrandModel(string brand, string model)
    {
        int brand_id = 0;
        try
        {
            string query = "dbo.addCarBrandModel";

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CarDiaryDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Connection = conn;

            //set up the parameters
            cmd.Parameters.Add("@bnd", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@mdl", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

            //set parameter values
            cmd.Parameters["@bnd"].Value = brand;
            cmd.Parameters["@mdl"].Value = model;
            

            cmd.Connection = conn;
            conn.Open();

            cmd.ExecuteNonQuery();

            //read output value
            brand_id = Convert.ToInt32(cmd.Parameters["@id"].Value);
            //car_id = (int)cmd.ExecuteScalar();

            conn.Close();
        }
        catch (Exception ex)
        {
            // Log the exception.
            ExceptionUtility.LogException(ex, "DB.cs");
        }

        return brand_id;
    }
}