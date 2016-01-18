using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OtherCost
/// </summary>
public class OtherCost
{

    private int id;
    private int car_id;
    private string category;
    private string date;
    private int mileage; // can be null
    private double total_cost;
    private string notes; // can be null

    public OtherCost(int id, int carID, string cat, string date, int mileage, double tot_cost, string notes)
    {
        this.id = id;
        this.car_id = carID;
        this.category = cat;
        this.date = date;
        this.mileage = mileage;
        this.total_cost = tot_cost;
        this.notes = notes;
    }
    
    public OtherCost()
    {

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
    public string getCategory()
    {
        return category;
    }
    public void setCategory(string category)
    {
        this.category = category;
    }
    public string getDate()
    {
        return date;
    }
    public void setDate(string date)
    {
        this.date = date;
    }
    public int getMileage()
    {
        return mileage;
    }
    public void setMileage(int mileage)
    {
        this.mileage = mileage;
    }
    public double getTotal_cost()
    {
        return total_cost;
    }
    public void setTotal_cost(double total_cost)
    {
        this.total_cost = total_cost;
    }
    public string getNotes()
    {
        return notes;
    }
    public void setNotes(string notes)
    {
        this.notes = notes;
    }
}