using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FuelConsumption
/// </summary>
public class FuelConsumption
{
    private int id;
    private int car_id;
    private String fuel_date;
    private int mileage;
    private String fuel_type;
    private int distance;
    private double liters;
    private double unitPrice;
    private double totalCost;
    private double avgConsPer100Km;

    public FuelConsumption()
    {
 
    }

    public FuelConsumption(int id, int carID, String date, int mileage, String fuel, int distance, double liters, double unit_price, double cost, double average)
    {
        this.id = id;
        this.car_id = carID;
        this.fuel_date = date;
        this.mileage = mileage;
        this.fuel_type = fuel;
        this.distance = distance;
        this.liters = liters;
        this.unitPrice = unit_price;
        this.totalCost = cost;
        this.avgConsPer100Km = average;
    }

    public int getId()
    {
        return id;
    }
    public void setId(int id)
    {
        this.id = id;
    }
    public int getCar_id()
    {
        return car_id;
    }
    public void setCar_id(int car_id)
    {
        this.car_id = car_id;
    }
    public String getFuel_date()
    {
        return fuel_date;
    }
    public void setFuel_date(String fuel_date)
    {
        this.fuel_date = fuel_date;
    }
    public int getMileage()
    {
        return mileage;
    }
    public void setMileage(int mileage)
    {
        this.mileage = mileage;
    }
    public String getFuel_type()
    {
        return fuel_type;
    }
    public void setFuel_type(String fuel_type)
    {
        this.fuel_type = fuel_type;
    }
    public int getDistance()
    {
        return distance;
    }
    public void setDistance(int distance)
    {
        this.distance = distance;
    }
    public double getLiters()
    {
        return liters;
    }
    public void setLiters(double liters)
    {
        this.liters = liters;
    }
    public double getUnitPrice()
    {
        return unitPrice;
    }
    public void setUnitPrice(double unitPrice)
    {
        this.unitPrice = unitPrice;
    }
    public double getTotalCost()
    {
        return totalCost;
    }
    public void setTotalCost(double totalCost)
    {
        this.totalCost = totalCost;
    }
    public double getAvgConsPer100Km()
    {
        return avgConsPer100Km;
    }
    public void setAvgConsPer100Km(double avgConsPer100Km)
    {
        this.avgConsPer100Km = avgConsPer100Km;
    }

}