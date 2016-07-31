using System;
using System.Collections.Generic;
using System.Linq;
using Empire.DataAccessLayer.Exceptions;
using Empire.DataAccessLayer.Interfaces;
using Empire.Database.Contexts;
using Empire.Database.Entities;
using Empire.ServiceLayer.DataTransferObjects;

namespace Empire.DataAccessLayer.DataAccessObjects
{
	public class ProductDao : IProductDao
	{
		private static IProductDao _instance;
		public static IProductDao Instance => _instance ?? (_instance = new ProductDao());

		public void Create(ProductDto product)
		{
			try
			{
				using (EmpireContext context = new EmpireContext())
				{
					context.Products.Add(GetEntity(product));

					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while creating a product.", ex);
			}
		}
		public void Update(ProductDto product)
		{
			try
			{
				using (EmpireContext context = new EmpireContext())
				{
					Product item = context.Products.Single(x => x.Id == product.Id);

					item.Name = product.Name;

					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while updating a product ({product.Id}).", ex);
			}
		}
		public void Delete(ProductDto product)
		{
			try
			{
				using (EmpireContext context = new EmpireContext())
				{
					Product item = context.Products.Single(x => x.Id == product.Id);

					context.Products.Remove(item);

					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while deleting a product ({product.Id}).", ex);
			}
		}

		public ProductDto GetById(int id)
		{
			try
			{
				using (EmpireContext context = new EmpireContext())
				{
					return GetDto(context.Products.Single(x => x.Id == id));
				}
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while getting a product ({id}).", ex);
			}
		}
		public List<ProductDto> GetAll()
		{
			try
			{
				using (EmpireContext database = new EmpireContext())
				{
					return database.Products.Select(GetDto).ToList();
				}
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting all products.", ex);
			}
		}

		private static ProductDto GetDto(Product product)
		{
			return new ProductDto
			{
				Id = product.Id,
				Name = product.Name
			};
		}
		private static Product GetEntity(ProductDto product)
		{
			return new Product
			{
				Id = product.Id,
				Name = product.Name
			};
		}
	}
}
