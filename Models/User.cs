using System;
using System.Collections.Generic;

namespace MeuVeiculo.Models;

public class User
{
    public User(string username, string password)
    {
        Id = Guid.NewGuid();
        Username = username;
        PasswordHash = password;
        CreatedAt = DateTime.Now;
        Vehicles = new List<Vehicle>();
    }

    public Guid Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Vehicle> Vehicles { get; set; }
}