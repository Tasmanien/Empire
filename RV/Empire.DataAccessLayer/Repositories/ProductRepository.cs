using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Empire.DataAccessLayer.DataAccessObjects;
using Empire.DataAccessLayer.Exceptions;
using Empire.Database.Contexts;
using Empire.Database.Entities;

namespace Empire.DataAccessLayer.Repositories
{
	public class ProductRepository : BaseRepository<Product>
	{
		public ProductRepository()
			: base(new EmpireContext())
		{

		}

		public void CreateOrUpdate(ProductDao item)
		{
			try
			{
				Context.Products.AddOrUpdate(GetEntity(item));
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while creating or updating a product.", ex);
			}
		}
		public void Create(ProductDao item)
		{
			try
			{
				Context.Products.Add(GetEntity(item));
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while creating a product.", ex);
			}
		}
		public void Update(ProductDao item)
		{
			try
			{
				UpdateData(Context.Products.Single(x => x.Id == item.Id), item);
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while updating a product ({item.Id}).", ex);
			}
		}
		public void Delete(ProductDao item)
		{
			try
			{
				Context.Products.Remove(Context.Products.Single(x => x.Id == item.Id));
				Context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException($"Error while deleting a product ({item.Id}).", ex);
			}
		}

		public ProductDao GetById(int id)
		{
			try
			{
				return GetDao(Context.Products.Single(x => x.Id == id));
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting all products.", ex);
			}
		}
		public List<ProductDao> GetAll()
		{
			try
			{
				return Context.Products.Select(GetDao).ToList();
			}
			catch (Exception ex)
			{
				throw new DataAccessLayerException("Error while getting all products.", ex);
			}
		}

		private static ProductDao GetDao(Product item)
		{
			return new ProductDao
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Name = item.Name
			};
		}
		private static Product GetEntity(ProductDao item)
		{
			return new Product
			{
				Id = item.Id,
				CreatedDate = item.CreatedDate,
				UpdatedDate = item.UpdatedDate,
				Name = item.Name
			};
		}
		private static void UpdateData(Product entity, ProductDao item)
		{
			entity.Name = item.Name;
		}
	}
}
