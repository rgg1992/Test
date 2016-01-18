using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Car
/// </summary>
public class Car
{
    private int id;
    private String carBrand;
    private String carModel;
    private int carYear;
    private String carEngine;
    private String carFuel;
    private int carHPowers;
    private String carImage;

    public Car(string brand, string model, int year, string engine, string fuel, int horse_powers, string image)
    {
        this.carBrand = brand;
        this.carModel = model;
        this.carYear = year;
        this.carEngine = engine;
        this.carFuel = fuel;
        this.carHPowers = horse_powers;
        this.carImage = image;
    }

    public Car()
    {

    }

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id= id;
    }

    public string getCarBrand()
    {
        return carBrand;
    }

    public void setCarBrand(string carBrand)
    {
        this.carBrand = carBrand;
    }

    public string getCarModel()
    {
        return carModel;
    }

    public void setCarModel(string carModel)
    {
        this.carModel = carModel;
    }

    public int getCarYear()
    {
        return carYear;
    }

    public void setCarYear(int carYear)
    {
        this.carYear = carYear;
    }

    public string getCarEngine()
    {
        return carEngine;
    }

    public void setCarEngine(string carEngine)
    {
        this.carEngine = carEngine;
    }

    public string getCarFuel()
    {
        return carFuel;
    }

    public void setCarFuel(string carFuel)
    {
        this.carFuel = carFuel;
    }

    public int getCarHPowers()
    {
        return carHPowers;
    }

    public void setCarHPowers(int carHPowers)
    {
        this.carHPowers = carHPowers;
    }

    public string getCarImage()
    {
        return carImage;
    }

    public void setCarImage(string carImage)
    {
        this.carImage = carImage;
    }

}