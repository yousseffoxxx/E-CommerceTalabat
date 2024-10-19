global using Microsoft.EntityFrameworkCore;
global using Domain.Entities;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Domain.Contracts;
global using Domain.Entities.OrderEntities;
global using Domain.Entities.ProductEntities;
global using Domain.Entities.UserEntities;
global using Microsoft.AspNetCore.Identity;
global using System.Text.Json;
global using Persistence.Data;
global using System.Collections.Concurrent;
global using Domain.Entities.BasketEntities;
global using StackExchange.Redis;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

global using OrderEntity = Domain.Entities.OrderEntities.Order;