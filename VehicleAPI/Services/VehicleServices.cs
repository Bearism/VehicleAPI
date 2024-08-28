using System;
using VehicleAPI.Models;
using VehicleAPI.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace VehicleAPI.Services;

public interface IVehicleServices
{
    IEnumerable<Car> GetCarsByColorAndWheels(string color, int wheels);
    IEnumerable<Bus> GetBusesByColor(string color);
    IEnumerable<Boat> GetBoatsByColor(string color);
    Car GetCarById(int id);
    void UpdateCarHeadlights(int id);
    Task AddBoat(Boat boat);
    void DeleteCar(int id);
    
}

public class VehicleServices : IVehicleServices
{
    private readonly VehicleDbContext _context;

    public VehicleServices(VehicleDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Car> GetCarsByColorAndWheels(string color, int wheels)
    {
        return _context.Cars.Where(c => c.Color == color && c.Wheels == wheels).ToList();
    }

    public IEnumerable<Bus> GetBusesByColor(string color)
    {
        return _context.Buses.Where(b => b.Color.Contains(color)).ToList();
    }

    public IEnumerable<Boat> GetBoatsByColor(string color)
    {
        return _context.Boats.Where(b => b.Color == color).ToList();
    }

    public Car GetCarById(int id)
    {
        return _context.Cars.Find(id);
    }

    public void UpdateCarHeadlights(int id)
    {
        var car = _context.Cars.Find(id);
        var headlightInfo = car.Headlights;

        var x= headlightInfo ? !headlightInfo : headlightInfo;

        _context.SaveChanges();
    }

    public async Task AddBoat(Boat boat)
    {
        await _context.Boats.AddAsync(boat);
        await _context.SaveChangesAsync();
    }

    public void DeleteCar(int id)
    {
        var car = _context.Cars.Find(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}

