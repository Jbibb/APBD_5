﻿namespace APBD_5.Classes;

public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}