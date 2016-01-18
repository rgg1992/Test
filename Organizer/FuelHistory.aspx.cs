﻿using Organizer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FuelHistory : System.Web.UI.Page
{
    DB db = new DB();
    string user;
    int car_id;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Application["userName"] != null)
            user = Application["userName"].ToString();
        else
            user = User.Identity.Name;
        if (Application["carID"] != null)
            car_id = Int32.Parse(Application["carID"].ToString());
        else
            IdentityHelper.RedirectToReturnUrl(/*Request.QueryString["ReturnUrl"]*/"~/CarProfile.aspx", Response);

        loadInitialData();
    }

    private void loadInitialData()
    {
        Car car = db.readCar(car_id, user);
        imgProfile.ImageUrl = car.getCarImage();
        lbCarTitle.Text = car.getCarBrand() + " " + car.getCarModel();
        lbConsumptionInfo.Text = "Разход (" + car.getCarFuel() + "):";

        double average = db.getAvgCons(car.getId());
        if (average == 0)
        {
            lbConsumption.Text = "---";
        }
        else
        {
            lbConsumption.Text = average.ToString("0.##");
        }
        lbDistanceInfo.Text = db.getKM(car.getId()).ToString() + " км";
        lbLiters.Text = db.getLitersConsumed(car.getId()).ToString() + " л.";
        fillFuelHistory();
        fillOtherHistory();
    }

    private void fillFuelHistory()
    {
        fillFuelHeader();
        int count = 0;
        List<FuelConsumption> list = db.getFuelConsumptionsForCar(car_id);
        if (list.Count != 0)
            foreach (FuelConsumption item in list)
            {
                count++;
                fillFuelRow(count, item);
            }
        else
        {
            fillEmptyRow("fuel");
        }
    }

    private void fillFuelHeader()
    {
        Table tbl = new Table();

        tbl.Width = new Unit("100%");
        tbl.Height = new Unit("100%");
        tbl.Style.Add("min-width","500px");

        //------------------row-----------------------
        TableRow rw = new TableRow();
        rw.BackColor = System.Drawing.Color.Yellow;
        //---------------------cell--------------
        TableCell cell = new TableCell();
        cell.Width = new Unit("10%");

        Label date = new Label();
        date.Width = new Unit("100%");
        date.Style.Add("text-align", "center");
        date.Font.Bold = true;
        date.Font.Size = 12;
        date.Text = "Дата";

        cell.Controls.Add(date);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("15%");

        Label mileage = new Label();
        mileage.Width = new Unit("100%");
        mileage.Style.Add("text-align", "center");
        mileage.Font.Bold = true;
        mileage.Font.Size = 12;
        mileage.Text = "Километраж";

        cell.Controls.Add(mileage);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label distance = new Label();
        distance.Width = new Unit("100%");
        distance.Style.Add("text-align", "center");
        distance.Font.Bold = true;
        distance.Font.Size = 12;
        distance.Text = "Изминато";

        cell.Controls.Add(distance);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label fuel = new Label();
        fuel.Width = new Unit("100%");
        fuel.Style.Add("text-align", "center");
        fuel.Font.Bold = true;
        fuel.Font.Size = 12;
        fuel.Text = "Гориво";

        cell.Controls.Add(fuel);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("15%");

        Label quantity = new Label();
        quantity.Width = new Unit("100%");
        quantity.Style.Add("text-align", "center");
        quantity.Font.Bold = true;
        quantity.Font.Size = 12;
        quantity.Text = "Количество";

        cell.Controls.Add(quantity);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label price = new Label();
        price.Width = new Unit("100%");
        price.Style.Add("text-align", "center");
        price.Font.Bold = true;
        price.Font.Size = 12;
        price.Text = "Цена";

        cell.Controls.Add(price);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label average = new Label();
        average.Width = new Unit("100%");
        average.Style.Add("text-align", "center");
        average.Font.Bold = true;
        average.Font.Size = 12;
        average.Text = "Разход";

        cell.Controls.Add(average);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        rw.Cells.Add(cell);

        cell.Width = new Unit("10%");

        rw.Cells.Add(cell);

        tbl.Controls.Add(rw);

        Panel1.Controls.Add(tbl);
    }

    private void fillFuelRow(int count, FuelConsumption item)
    {
        Table tbl = new Table();

        tbl.Width = new Unit("100%");
        tbl.Height = new Unit("100%");
        tbl.Style.Add("min-width", "500px !important");

        //------------------row-----------------------
        TableRow rw = new TableRow();
        if (count % 2 == 0)
            rw.BackColor = System.Drawing.Color.White;
        else
            rw.BackColor = System.Drawing.Color.LightGray;
        //---------------------cell--------------
        TableCell cell = new TableCell();
        cell.Width = new Unit("10%");


        Label date = new Label();
        date.Width = new Unit("100%");
        date.Style.Add("text-align", "center");
        date.Font.Size = 10;
        date.Text = item.getFuel_date();

        cell.Controls.Add(date);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("15%");

        Label mileage = new Label();
        mileage.Width = new Unit("100%");
        mileage.Style.Add("text-align", "center");
        mileage.Font.Size = 10;
        mileage.Text = item.getMileage().ToString("0.##");

        cell.Controls.Add(mileage);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label distance = new Label();
        distance.Width = new Unit("100%");
        distance.Style.Add("text-align", "center");
        distance.Font.Size = 10;
        distance.Text = item.getDistance().ToString("0.##");

        cell.Controls.Add(distance);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label fuel = new Label();
        fuel.Width = new Unit("100%");
        fuel.Style.Add("text-align", "center");
        fuel.Font.Size = 10;
        fuel.Text = item.getFuel_type();

        cell.Controls.Add(fuel);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("15%");

        Label quantity = new Label();
        quantity.Width = new Unit("100%");
        quantity.Style.Add("text-align", "center");
        quantity.Font.Size = 10;
        quantity.Text = item.getLiters().ToString("0.##");

        cell.Controls.Add(quantity);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("20%");

        cell.Width = new Unit("10%");

        Label price = new Label();
        price.Width = new Unit("100%");
        price.Style.Add("text-align", "center");
        price.Font.Size = 10;
        price.Text = item.getTotalCost().ToString("0.##");

        cell.Controls.Add(price);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label average = new Label();
        average.Width = new Unit("100%");
        average.Style.Add("text-align", "center");
        average.Font.Size = 10;
        average.Text = item.getAvgConsPer100Km().ToString("0.##");

        cell.Controls.Add(average);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        ImageButton delete = new ImageButton();
        //Image img = new Image();
        //img.ImageUrl = "~/delete.ico";
        //delete.BackgroundImage = img;
        delete.ImageUrl = "~/Images/delete.png";
        delete.Style.Add("height", "20px");
        delete.Style.Add("width", "20px");
        delete.ID = "Delete" + item.getId();
        delete.Click += new ImageClickEventHandler(ImageButton_Click);
        delete.ToolTip = "Изтрий";

        cell.Controls.Add(delete);
        rw.Cells.Add(cell);

        cell.Width = new Unit("10%");

        rw.Cells.Add(cell);

        tbl.Controls.Add(rw);

        Panel1.Controls.Add(tbl);
    }

    private void ImageButton_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string id = img.ID.Replace("Delete", "");
        int fuel_id = Int32.Parse(id);
        //Application["carID"] = car_id;

        if (db.removeFuelRecord(fuel_id))
            Response.Redirect(Request.RawUrl);
        else
            Response.Write("<script>alert('Грешка при изтриване на зареждане !')</script>");

    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MultiView1.ActiveViewIndex = Int32.Parse(e.Item.Value);
    }

    private void fillOtherHistory()
    {
        fillOtherHeader();
        int count = 0;
        List<OtherCost> list = db.getOtherCostsForCar(car_id);
        if (list.Count != 0)
            foreach (OtherCost item in list)
            {
                count++;
                fillOtherRow(count, item);
            }
        else
        {
            fillEmptyRow("other");
        }
    }

    private void fillOtherHeader()
    {
        Table tbl = new Table();

        tbl.Width = new Unit("100%");
        tbl.Height = new Unit("100%");
        tbl.Style.Add("min-width", "330px !important");

        //------------------row-----------------------
        TableRow rw = new TableRow();
        rw.BackColor = System.Drawing.Color.Yellow;
        //---------------------cell--------------
        TableCell cell = new TableCell();
        cell.Width = new Unit("10%");

        Label date = new Label();
        date.Width = new Unit("100%");
        date.Style.Add("text-align", "center");
        date.Font.Bold = true;
        date.Font.Size = 12;
        date.Text = "Дата";

        cell.Controls.Add(date);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("15%");

        Label mileage = new Label();
        mileage.Width = new Unit("100%");
        mileage.Style.Add("text-align", "center");
        mileage.Font.Bold = true;
        mileage.Font.Size = 12;
        mileage.Text = "Километраж";

        cell.Controls.Add(mileage);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("50%");

        Label distance = new Label();
        distance.Width = new Unit("100%");
        distance.Style.Add("text-align", "center");
        distance.Font.Bold = true;
        distance.Font.Size = 12;
        distance.Text = "Категория";

        cell.Controls.Add(distance);
        rw.Cells.Add(cell);


        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("10%");

        Label price = new Label();
        price.Width = new Unit("100%");
        price.Style.Add("text-align", "center");
        price.Font.Bold = true;
        price.Font.Size = 12;
        price.Text = "Цена";

        cell.Controls.Add(price);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("8%");

        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("7%");

        rw.Cells.Add(cell);


        tbl.Controls.Add(rw);

        Panel2.Controls.Add(tbl);
    }

    private void fillOtherRow(int count, OtherCost item)
    {
        Table tbl = new Table();

        tbl.Width = new Unit("100%");
        tbl.Height = new Unit("100%");
        tbl.Style.Add("min-width", "330px !important");

        //------------------row-----------------------
        TableRow rw = new TableRow();
        if (count % 2 == 0)
            rw.BackColor = System.Drawing.Color.White;
        else
            rw.BackColor = System.Drawing.Color.LightGray;
        //---------------------cell--------------
        TableCell cell = new TableCell();
        cell.Width = new Unit("10%");

        Label date = new Label();
        date.Width = new Unit("100%");
        date.Style.Add("text-align", "center");
        date.Font.Size = 10;
        date.Text = item.getDate();

        cell.Controls.Add(date);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("15%");

        Label mileage = new Label();
        mileage.Width = new Unit("100%");
        mileage.Style.Add("text-align", "center");
        mileage.Font.Size = 10;
        mileage.Text = item.getMileage().ToString("0.##");

        cell.Controls.Add(mileage);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("50%");

        Label category = new Label();
        category.Width = new Unit("100%");
        category.Style.Add("text-align", "center");
        category.Font.Size = 10;
        category.Text = item.getCategory();

        cell.Controls.Add(category);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();

        cell.Width = new Unit("10%");

        Label price = new Label();
        price.Width = new Unit("100%");
        price.Style.Add("text-align", "center");
        price.Font.Size = 10;
        price.Text = item.getTotal_cost().ToString("0.##");

        cell.Controls.Add(price);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("8%");

        ImageButton delete = new ImageButton();
        //Image img = new Image();
        //img.ImageUrl = "~/delete.ico";
        //delete.BackgroundImage = img;
        delete.ImageUrl = "~/Images/delete.png";
        delete.Style.Add("height", "20px");
        delete.Style.Add("width", "20px");
        delete.ID = "DeleteOther" + item.getId();
        delete.Click += new ImageClickEventHandler(DeleteOtherCost_Click);
        delete.ToolTip = "Изтрий";

        cell.Controls.Add(delete);
        rw.Cells.Add(cell);

        //---------------------cell--------------
        cell = new TableCell();
        cell.Width = new Unit("7%");



        ImageButton notes = new ImageButton();
        notes.ImageUrl = "~/Images/icon_note.png";
        notes.Style.Add("height", "20px");
        notes.Style.Add("width", "20px");
        notes.ID = "Notes" + item.getId();
        //notes.Click += new ImageClickEventHandler(ShowNotes_Click);
        string noteText = item.getNotes();
        if (!noteText.Equals(""))
            notes.ToolTip = noteText;
        else
            notes.ToolTip = "Няма въведени записки за този разход";
        notes.Enabled = false;

        cell.Controls.Add(notes);
        rw.Cells.Add(cell);

        tbl.Controls.Add(rw);

        Panel2.Controls.Add(tbl);
    }

    private void DeleteOtherCost_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        string id = img.ID.Replace("DeleteOther", "");
        int other_id = Int32.Parse(id);
        //Application["carID"] = car_id;

        if (db.removeOtherCost(other_id))
            Response.Redirect(Request.RawUrl);
        else
            Response.Write("<script>alert('Грешка при изтриване на друг разход !')</script>");

    }

    private void fillEmptyRow(string input)
    {
        Table tbl = new Table();

        tbl.Width = new Unit("100%");
        tbl.Height = new Unit("100%");
        tbl.Style.Add("min-width", "330px !important");

        //------------------row-----------------------
        TableRow rw = new TableRow();
        //---------------------cell--------------
        TableCell cell = new TableCell();
        cell.Width = new Unit("100%");

        Label info = new Label();
        info.Width = new Unit("100%");
        info.Style.Add("text-align", "left");
        info.Font.Size = 12;
        info.Text = "Няма намерени резултати";

        cell.Controls.Add(info);
        rw.Cells.Add(cell);

        tbl.Controls.Add(rw);

        if(input.Equals("fuel"))
            Panel1.Controls.Add(tbl);
        else if (input.Equals("other"))
            Panel2.Controls.Add(tbl);
    }
}